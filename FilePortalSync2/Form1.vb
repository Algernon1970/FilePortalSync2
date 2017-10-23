Imports System.ComponentModel

Public Class Form1
    Dim cancelled As Boolean = True
    Dim worker As New BackgroundWorker

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        worker.WorkerSupportsCancellation = True
        AddHandler worker.DoWork, AddressOf Worker_DoWork
    End Sub

    Private Sub LibraryInspectButton_Click(sender As Object, e As EventArgs) Handles LibraryInspectButton.Click
        Dim processProperties As New ProcessStartInfo With {
            .FileName = "C:\windows\explorer.exe",
            .Arguments = String.Format("/n /e /root,{0}/shares", LibraryShareBox.Text)
        }
        Dim myProcess As Process = Process.Start(processProperties)
    End Sub

    Private Sub LocalInspectButton_Click(sender As Object, e As EventArgs) Handles LocalInspectButton.Click
        Dim processProperties As New ProcessStartInfo With {
            .FileName = "C:\windows\explorer.exe",
            .Arguments = String.Format("/n /e /root,{0}", LocalShareBox.Text)
        }
        Dim myProcess As Process = Process.Start(processProperties)
    End Sub

    Private Sub EventLogging_EntryWritten(sender As Object, e As EntryWrittenEventArgs) Handles EventLogging.EntryWritten
        OutputBox.AppendText(String.Format("{1}{0}{2}{0}{3}", vbTab, e.Entry.TimeGenerated, e.Entry.Message, vbCrLf))
    End Sub

    Private Sub StarterButton_Click(sender As Object, e As EventArgs) Handles StarterButton.Click
        If cancelled Then
            cancelled = False
            StarterButton.Text = "Stop"
            StarterButton.BackColor = Color.Red
            worker.RunWorkerAsync()
        Else
            cancelled = True
            worker.CancelAsync()
            StarterButton.Text = "Start"
            StarterButton.BackColor = Color.Green
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

#Region "Sharepoint"
    Private Sub UploadFiles()

    End Sub

    Private Sub DeleteFiles()

    End Sub

    Private Sub DownloadFiles()

    End Sub
#End Region



End Class
