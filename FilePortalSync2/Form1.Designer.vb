<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.SetupGroupBox = New System.Windows.Forms.GroupBox()
        Me.LocalInspectButton = New System.Windows.Forms.Button()
        Me.LibraryInspectButton = New System.Windows.Forms.Button()
        Me.LocalShareBox = New System.Windows.Forms.TextBox()
        Me.LibraryShareBox = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.StarterButton = New System.Windows.Forms.Button()
        Me.PasswordBox = New System.Windows.Forms.TextBox()
        Me.UsernameBox = New System.Windows.Forms.TextBox()
        Me.PasswordLabel = New System.Windows.Forms.Label()
        Me.UsernameLabel = New System.Windows.Forms.Label()
        Me.OutputGroupBox = New System.Windows.Forms.GroupBox()
        Me.OutputBox = New System.Windows.Forms.RichTextBox()
        Me.FileportalDataSet1 = New FilePortalSync2.fileportalDataSet()
        Me.FiledataTableAdapter1 = New FilePortalSync2.fileportalDataSetTableAdapters.filedataTableAdapter()
        Me.TableAdapterManager1 = New FilePortalSync2.fileportalDataSetTableAdapters.TableAdapterManager()
        Me.AssignmentTableAdapter1 = New FilePortalSync2.fileportalDataSetTableAdapters.assignmentTableAdapter()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SetupGroupBox.SuspendLayout()
        Me.OutputGroupBox.SuspendLayout()
        CType(Me.FileportalDataSet1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.Controls.Add(Me.SetupGroupBox, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.OutputGroupBox, 0, 1)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 2
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(1070, 508)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'SetupGroupBox
        '
        Me.SetupGroupBox.Controls.Add(Me.LocalInspectButton)
        Me.SetupGroupBox.Controls.Add(Me.LibraryInspectButton)
        Me.SetupGroupBox.Controls.Add(Me.LocalShareBox)
        Me.SetupGroupBox.Controls.Add(Me.LibraryShareBox)
        Me.SetupGroupBox.Controls.Add(Me.Label2)
        Me.SetupGroupBox.Controls.Add(Me.Label1)
        Me.SetupGroupBox.Controls.Add(Me.StarterButton)
        Me.SetupGroupBox.Controls.Add(Me.PasswordBox)
        Me.SetupGroupBox.Controls.Add(Me.UsernameBox)
        Me.SetupGroupBox.Controls.Add(Me.PasswordLabel)
        Me.SetupGroupBox.Controls.Add(Me.UsernameLabel)
        Me.SetupGroupBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SetupGroupBox.Location = New System.Drawing.Point(3, 3)
        Me.SetupGroupBox.Name = "SetupGroupBox"
        Me.SetupGroupBox.Size = New System.Drawing.Size(1064, 94)
        Me.SetupGroupBox.TabIndex = 0
        Me.SetupGroupBox.TabStop = False
        Me.SetupGroupBox.Text = "Setup"
        '
        'LocalInspectButton
        '
        Me.LocalInspectButton.Location = New System.Drawing.Point(747, 44)
        Me.LocalInspectButton.Name = "LocalInspectButton"
        Me.LocalInspectButton.Size = New System.Drawing.Size(75, 23)
        Me.LocalInspectButton.TabIndex = 10
        Me.LocalInspectButton.Text = "Inspect"
        Me.LocalInspectButton.UseVisualStyleBackColor = True
        '
        'LibraryInspectButton
        '
        Me.LibraryInspectButton.Location = New System.Drawing.Point(747, 19)
        Me.LibraryInspectButton.Name = "LibraryInspectButton"
        Me.LibraryInspectButton.Size = New System.Drawing.Size(75, 23)
        Me.LibraryInspectButton.TabIndex = 9
        Me.LibraryInspectButton.Text = "Inspect"
        Me.LibraryInspectButton.UseVisualStyleBackColor = True
        '
        'LocalShareBox
        '
        Me.LocalShareBox.Location = New System.Drawing.Point(422, 46)
        Me.LocalShareBox.Name = "LocalShareBox"
        Me.LocalShareBox.Size = New System.Drawing.Size(319, 20)
        Me.LocalShareBox.TabIndex = 8
        Me.LocalShareBox.Text = "\\192.168.5.57\public\"
        '
        'LibraryShareBox
        '
        Me.LibraryShareBox.Location = New System.Drawing.Point(422, 20)
        Me.LibraryShareBox.Name = "LibraryShareBox"
        Me.LibraryShareBox.Size = New System.Drawing.Size(319, 20)
        Me.LibraryShareBox.TabIndex = 7
        Me.LibraryShareBox.Text = "https://ashbyschool.sharepoint.com/StaffShared/AshbyShare"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(353, 49)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(64, 13)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Local Share"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(353, 23)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(63, 13)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Library URL"
        '
        'StarterButton
        '
        Me.StarterButton.BackColor = System.Drawing.Color.Lime
        Me.StarterButton.Location = New System.Drawing.Point(980, 71)
        Me.StarterButton.Name = "StarterButton"
        Me.StarterButton.Size = New System.Drawing.Size(75, 23)
        Me.StarterButton.TabIndex = 4
        Me.StarterButton.Text = "Start"
        Me.StarterButton.UseVisualStyleBackColor = False
        '
        'PasswordBox
        '
        Me.PasswordBox.Location = New System.Drawing.Point(100, 46)
        Me.PasswordBox.Name = "PasswordBox"
        Me.PasswordBox.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.PasswordBox.Size = New System.Drawing.Size(186, 20)
        Me.PasswordBox.TabIndex = 3
        Me.PasswordBox.Text = "tkcdx7jiywmbYfmsxKTq"
        Me.PasswordBox.UseSystemPasswordChar = True
        '
        'UsernameBox
        '
        Me.UsernameBox.Location = New System.Drawing.Point(100, 20)
        Me.UsernameBox.Name = "UsernameBox"
        Me.UsernameBox.Size = New System.Drawing.Size(186, 20)
        Me.UsernameBox.TabIndex = 2
        Me.UsernameBox.Text = "sharepointuser@ashbyschool.org.uk"
        '
        'PasswordLabel
        '
        Me.PasswordLabel.AutoSize = True
        Me.PasswordLabel.Location = New System.Drawing.Point(9, 49)
        Me.PasswordLabel.Name = "PasswordLabel"
        Me.PasswordLabel.Size = New System.Drawing.Size(83, 13)
        Me.PasswordLabel.TabIndex = 1
        Me.PasswordLabel.Text = "Portal Password"
        '
        'UsernameLabel
        '
        Me.UsernameLabel.AutoSize = True
        Me.UsernameLabel.Location = New System.Drawing.Point(9, 23)
        Me.UsernameLabel.Name = "UsernameLabel"
        Me.UsernameLabel.Size = New System.Drawing.Size(85, 13)
        Me.UsernameLabel.TabIndex = 0
        Me.UsernameLabel.Text = "Portal Username"
        '
        'OutputGroupBox
        '
        Me.OutputGroupBox.Controls.Add(Me.OutputBox)
        Me.OutputGroupBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.OutputGroupBox.Location = New System.Drawing.Point(3, 103)
        Me.OutputGroupBox.Name = "OutputGroupBox"
        Me.OutputGroupBox.Size = New System.Drawing.Size(1064, 402)
        Me.OutputGroupBox.TabIndex = 1
        Me.OutputGroupBox.TabStop = False
        Me.OutputGroupBox.Text = "Output"
        '
        'OutputBox
        '
        Me.OutputBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.OutputBox.Location = New System.Drawing.Point(3, 16)
        Me.OutputBox.Name = "OutputBox"
        Me.OutputBox.Size = New System.Drawing.Size(1058, 383)
        Me.OutputBox.TabIndex = 0
        Me.OutputBox.Text = ""
        '
        'FileportalDataSet1
        '
        Me.FileportalDataSet1.DataSetName = "fileportalDataSet"
        Me.FileportalDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'FiledataTableAdapter1
        '
        Me.FiledataTableAdapter1.ClearBeforeFill = True
        '
        'TableAdapterManager1
        '
        Me.TableAdapterManager1.assignmentTableAdapter = Me.AssignmentTableAdapter1
        Me.TableAdapterManager1.BackupDataSetBeforeUpdate = False
        Me.TableAdapterManager1.filedataTableAdapter = Me.FiledataTableAdapter1
        Me.TableAdapterManager1.UpdateOrder = FilePortalSync2.fileportalDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete
        '
        'AssignmentTableAdapter1
        '
        Me.AssignmentTableAdapter1.ClearBeforeFill = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1070, 508)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Form1"
        Me.Text = "FilePortalSync2"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.SetupGroupBox.ResumeLayout(False)
        Me.SetupGroupBox.PerformLayout()
        Me.OutputGroupBox.ResumeLayout(False)
        CType(Me.FileportalDataSet1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents SetupGroupBox As GroupBox
    Friend WithEvents LibraryShareBox As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents StarterButton As Button
    Friend WithEvents PasswordBox As TextBox
    Friend WithEvents UsernameBox As TextBox
    Friend WithEvents PasswordLabel As Label
    Friend WithEvents UsernameLabel As Label
    Friend WithEvents OutputGroupBox As GroupBox
    Friend WithEvents LocalInspectButton As Button
    Friend WithEvents LibraryInspectButton As Button
    Friend WithEvents LocalShareBox As TextBox
    Friend WithEvents OutputBox As RichTextBox
    Friend WithEvents FileportalDataSet1 As fileportalDataSet
    Friend WithEvents FiledataTableAdapter1 As fileportalDataSetTableAdapters.filedataTableAdapter
    Friend WithEvents TableAdapterManager1 As fileportalDataSetTableAdapters.TableAdapterManager
    Friend WithEvents AssignmentTableAdapter1 As fileportalDataSetTableAdapters.assignmentTableAdapter
End Class
