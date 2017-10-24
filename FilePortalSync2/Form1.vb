Imports System.ComponentModel
Imports System.Diagnostics
Imports System.IO
Imports System.Security
Imports AshbyTools

Public Class Form1
    Dim cancelled As Boolean = True
    Dim worker As New BackgroundWorker
    Dim myEventLog As EventLog
    Dim portalUsername As String
    Dim portalPassword As SecureString


    Public Delegate Sub LogDelegate(ByVal status As String)

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        worker.WorkerSupportsCancellation = True
        AddHandler worker.DoWork, AddressOf Worker_DoWork
        SetupLogging()
    End Sub

#Region "Logging"
    Private Sub SetupLogging()
        Try
            If Not EventLog.SourceExists(My.Application.Info.ProductName) Then
                EventLog.CreateEventSource(My.Application.Info.ProductName, "HandinPortal")
            End If

            myEventLog = New EventLog With {
                .Source = My.Application.Info.ProductName,
                .Log = "HandinPortal",
                .EnableRaisingEvents = True
            }
            AddHandler myEventLog.EntryWritten, AddressOf Log_Informer
        Catch ex As Exception
            MsgBox("Cannot create eventlog")
        End Try

    End Sub

    Private Sub Log_Informer(ByVal sender As Object, ByVal e As EntryWrittenEventArgs)
        LogInfo(String.Format("{0}{1}{2}{3}", e.Entry.TimeGenerated.ToShortTimeString, vbTab, e.Entry.Message, vbCrLf))
    End Sub

    Private Sub LogInfo(ByVal s As String)
        If Me.InvokeRequired Then
            OutputBox.Invoke(New LogDelegate(AddressOf LogInfo), s)
        Else
            OutputBox.AppendText(s)
        End If
    End Sub
#End Region

#Region "Interface"
    Private Sub LibraryInspectButton_Click(sender As Object, e As EventArgs) Handles LibraryInspectButton.Click
        Dim processProperties As New ProcessStartInfo With {
            .FileName = "C:\windows\explorer.exe",
            .Arguments = String.Format("/n /e /root,{0}/shares", LibraryShareBox.Text)
        }
        Dim myProcess As Process = Process.Start(processProperties)
        myEventLog.WriteEntry("Inspect Library")
    End Sub

    Private Sub LocalInspectButton_Click(sender As Object, e As EventArgs) Handles LocalInspectButton.Click
        Dim processProperties As New ProcessStartInfo With {
            .FileName = "C:\windows\explorer.exe",
            .Arguments = String.Format("/n /e /root,{0}", LocalShareBox.Text)
        }
        Dim myProcess As Process = Process.Start(processProperties)
        myEventLog.WriteEntry("Inspect Local Share")
    End Sub

    Private Sub StarterButton_Click(sender As Object, e As EventArgs) Handles StarterButton.Click
        If cancelled Then
            cancelled = False
            StarterButton.Text = "Stop"
            StarterButton.BackColor = Color.Red
            portalUsername = UsernameBox.Text
            portalPassword = AshbyTools.convertToSecureString(PasswordBox.Text)
            UsernameBox.Enabled = False
            PasswordBox.Enabled = False
            LibraryShareBox.Enabled = False
            LocalShareBox.Enabled = False
            worker.RunWorkerAsync()
            myEventLog.WriteEntry("Started processing")
        Else
            cancelled = True
            worker.CancelAsync()
            StarterButton.Text = "Start"
            StarterButton.BackColor = Color.Green
            UsernameBox.Enabled = True
            PasswordBox.Enabled = True
            LibraryShareBox.Enabled = True
            LocalShareBox.Enabled = True
            myEventLog.WriteEntry("Stopped processing")
        End If

    End Sub

    Private Sub Worker_DoWork(ByVal sender As Object, ByVal e As DoWorkEventArgs)
        While Not cancelled
            UploadFiles()
            DeleteFiles()
            DownloadFiles()
            Threading.Thread.Sleep(2500)
        End While
    End Sub

#End Region

#Region "Sharepoint"
    Private Sub UploadFiles()
        Dim readyFiles As fileportalDataSet.filedataDataTable

        readyFiles = FiledataTableAdapter1.GetReadyFiles()
        For Each dr As DataRow In readyFiles.Rows
            Try
                Dim assID As Integer = dr.Field(Of Integer)("idAssignment")
                Dim origFN As String = dr.Field(Of String)("filename")
                Dim user As String = dr.Field(Of String)("username")
                Dim id As Integer = dr.Field(Of Integer)("idFileData")
                Dim assignmentName As String = AssignmentTableAdapter1.GetAssignmentByID(assID).Rows(0).Field(Of String)("title")

                Dim fileext As String = Path.GetExtension(origFN)
                Dim copyFN As String = String.Format("{0}{1}{2}", LocalShareBox.Text, id, fileext)
                Dim res As String = AshbyTools.FileOperations.copyToSP(copyFN, LibraryShareBox.Text, "Shares", portalUsername, portalPassword)
                If res.ToLower.Equals("ok") Then
                    FiledataTableAdapter1.SetUploaded(True, id)
                    File.Delete(copyFN)
                    myEventLog.WriteEntry(String.Format("{1}{0}{2}{0}{3}{0}{4} Uploaded", vbTab, user, assignmentName, origFN, copyFN))
                Else
                    FiledataTableAdapter1.SetError(True, id)
                    myEventLog.WriteEntry(String.Format("{1}{0}{2}{0}{3}{0}{4} Failed To upload", vbTab, user, assignmentName, origFN, copyFN), EventLogEntryType.Warning)
                End If


            Catch ex As Exception
                myEventLog.WriteEntry(ex.Message, EventLogEntryType.Error)
            Finally
                FileportalDataSet1.AcceptChanges()

            End Try
        Next
    End Sub

    Private Sub DeleteFiles()
        Dim deleteFiles As fileportalDataSet.filedataDataTable
        deleteFiles = FiledataTableAdapter1.GetListToDelete()

        For Each dr As DataRow In deleteFiles.Rows
            Try
                Dim rowID As Integer = dr.Field(Of Integer)("idFileData")
                Dim assID As Integer = dr.Field(Of Integer)("idAssignment")
                Dim origFN As String = dr.Field(Of String)("filename")
                Dim user As String = dr.Field(Of String)("username")
                Dim id As Integer = dr.Field(Of Integer)("idFileData")
                Dim assignmentName As String = AssignmentTableAdapter1.GetAssignmentByID(assID).Rows(0).Field(Of String)("title")

                Dim fileext As String = Path.GetExtension(origFN)
                Dim copyFN As String = String.Format("{0}{1}", id, fileext)
                Dim res As String = AshbyTools.FileOperations.deleteFromSP(copyFN, LibraryShareBox.Text, "Shares", portalUsername, portalPassword)
                FiledataTableAdapter1.SetUploaded(False, rowID)

                myEventLog.WriteEntry(String.Format("{1}{0}{2}{0}{3}{0}{4} Deleted", vbTab, user, assignmentName, origFN, copyFN))
            Catch ex As Exception
                myEventLog.WriteEntry(ex.Message, EventLogEntryType.Error)
            Finally
                FileportalDataSet1.AcceptChanges()
            End Try
        Next

    End Sub

    Private Sub DownloadFiles()
        Dim readyFiles As fileportalDataSet.filedataDataTable
        readyFiles = FiledataTableAdapter1.getFilesToDownload()
        For Each dr As DataRow In readyFiles
            Try
                Dim assID As Integer = dr.Field(Of Integer)("idAssignment")
                Dim origFN As String = dr.Field(Of String)("filename")
                Dim id As Integer = dr.Field(Of Integer)("idFileData")
                Dim fileext As String = Path.GetExtension(origFN)
                Dim remoteFile As String = String.Format("{0}{1}", id, fileext)
                Dim fs As Stream = Nothing
                FiledataTableAdapter1.setDownloadFlag(False, id)
                Try
                    fs = FileOperations.loadFromSP(remoteFile, LibraryShareBox.Text, "Shares", portalUsername, portalPassword)
                    Using nfs As New FileStream(LocalShareBox.Text & remoteFile, FileMode.Create)
                        fs.CopyTo(nfs)
                    End Using
                    FiledataTableAdapter1.setDownloadReadyFlag(True, id)
                    FileportalDataSet1.AcceptChanges()
                    myEventLog.WriteEntry(String.Format("{1}{0}{2} Downloaded", vbTab, origFN, remoteFile))
                Catch ex As Exception
                    If IsNothing(fs) Then
                        myEventLog.WriteEntry(ex.Message & " when opening " & remoteFile, EventLogEntryType.Error)
                    Else
                        myEventLog.WriteEntry(ex.Message & " when writing to local share " & remoteFile, EventLogEntryType.Error)
                    End If
                    FiledataTableAdapter1.setDownloadFlag(False, id)
                    FileportalDataSet1.AcceptChanges()
                Finally
                    If IsNothing(fs) Then
                        'failure to Kirts PHP Page.
                        FiledataTableAdapter1.setDownloadFlag(False, id)
                        FiledataTableAdapter1.setDownloadReadyFlag(False, id)
                        FiledataTableAdapter1.SetError(True, id)
                        FileportalDataSet1.AcceptChanges()

                    End If
                End Try

            Catch ex As Exception
                myEventLog.WriteEntry(ex.Message, EventLogEntryType.Error)
            Finally
                FileportalDataSet1.AcceptChanges()
            End Try


        Next


    End Sub
#End Region



End Class
