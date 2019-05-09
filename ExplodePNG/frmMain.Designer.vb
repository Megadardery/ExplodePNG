<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMain))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtInput = New System.Windows.Forms.TextBox()
        Me.btnDir = New System.Windows.Forms.Button()
        Me.btnStart = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtLog = New System.Windows.Forms.TextBox()
        Me.prgOverall = New System.Windows.Forms.ProgressBar()
        Me.chkOptions = New System.Windows.Forms.CheckBox()
        Me.grpOptions = New System.Windows.Forms.GroupBox()
        Me.btnAssume = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.chkStep = New System.Windows.Forms.CheckBox()
        Me.chkFile = New System.Windows.Forms.CheckBox()
        Me.chkSub = New System.Windows.Forms.CheckBox()
        Me.numThreads = New System.Windows.Forms.NumericUpDown()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.chkOpt6 = New System.Windows.Forms.CheckBox()
        Me.chkOpt5 = New System.Windows.Forms.CheckBox()
        Me.chkOpt4 = New System.Windows.Forms.CheckBox()
        Me.chkOpt3 = New System.Windows.Forms.CheckBox()
        Me.chkOpt2 = New System.Windows.Forms.CheckBox()
        Me.chkOpt1 = New System.Windows.Forms.CheckBox()
        Me.chkLoop = New System.Windows.Forms.CheckBox()
        Me.chkBackup = New System.Windows.Forms.CheckBox()
        Me.btnFiles = New System.Windows.Forms.Button()
        Me.fileBrowse = New System.Windows.Forms.OpenFileDialog()
        Me.dirBrowse = New System.Windows.Forms.FolderBrowserDialog()
        Me.bgThreadsCalc = New System.ComponentModel.BackgroundWorker()
        Me.GroupBox1.SuspendLayout()
        Me.grpOptions.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.numThreads, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(55, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Directory:"
        '
        'txtInput
        '
        Me.txtInput.Location = New System.Drawing.Point(73, 6)
        Me.txtInput.Name = "txtInput"
        Me.txtInput.Size = New System.Drawing.Size(232, 20)
        Me.txtInput.TabIndex = 1
        '
        'btnDir
        '
        Me.btnDir.Location = New System.Drawing.Point(311, 5)
        Me.btnDir.Name = "btnDir"
        Me.btnDir.Size = New System.Drawing.Size(35, 23)
        Me.btnDir.TabIndex = 2
        Me.btnDir.Text = "dir"
        Me.btnDir.UseVisualStyleBackColor = True
        '
        'btnStart
        '
        Me.btnStart.Location = New System.Drawing.Point(12, 32)
        Me.btnStart.Name = "btnStart"
        Me.btnStart.Size = New System.Drawing.Size(374, 23)
        Me.btnStart.TabIndex = 4
        Me.btnStart.Text = "Start Compressing"
        Me.btnStart.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtLog)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 61)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(377, 250)
        Me.GroupBox1.TabIndex = 5
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Log"
        '
        'txtLog
        '
        Me.txtLog.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtLog.Location = New System.Drawing.Point(3, 16)
        Me.txtLog.Multiline = True
        Me.txtLog.Name = "txtLog"
        Me.txtLog.Size = New System.Drawing.Size(371, 231)
        Me.txtLog.TabIndex = 0
        Me.txtLog.Text = "022"
        '
        'prgOverall
        '
        Me.prgOverall.Location = New System.Drawing.Point(12, 317)
        Me.prgOverall.Name = "prgOverall"
        Me.prgOverall.Size = New System.Drawing.Size(270, 23)
        Me.prgOverall.Step = 1
        Me.prgOverall.TabIndex = 6
        '
        'chkOptions
        '
        Me.chkOptions.Appearance = System.Windows.Forms.Appearance.Button
        Me.chkOptions.Location = New System.Drawing.Point(288, 317)
        Me.chkOptions.Name = "chkOptions"
        Me.chkOptions.Size = New System.Drawing.Size(101, 23)
        Me.chkOptions.TabIndex = 7
        Me.chkOptions.Text = "Show Options -->"
        Me.chkOptions.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.chkOptions.UseVisualStyleBackColor = True
        '
        'grpOptions
        '
        Me.grpOptions.Controls.Add(Me.btnAssume)
        Me.grpOptions.Controls.Add(Me.Label2)
        Me.grpOptions.Controls.Add(Me.GroupBox2)
        Me.grpOptions.Controls.Add(Me.chkSub)
        Me.grpOptions.Controls.Add(Me.numThreads)
        Me.grpOptions.Controls.Add(Me.GroupBox3)
        Me.grpOptions.Controls.Add(Me.chkLoop)
        Me.grpOptions.Controls.Add(Me.chkBackup)
        Me.grpOptions.Location = New System.Drawing.Point(402, 6)
        Me.grpOptions.Name = "grpOptions"
        Me.grpOptions.Size = New System.Drawing.Size(171, 334)
        Me.grpOptions.TabIndex = 8
        Me.grpOptions.TabStop = False
        Me.grpOptions.Text = "Options"
        '
        'btnAssume
        '
        Me.btnAssume.Location = New System.Drawing.Point(110, 309)
        Me.btnAssume.Name = "btnAssume"
        Me.btnAssume.Size = New System.Drawing.Size(57, 23)
        Me.btnAssume.TabIndex = 11
        Me.btnAssume.Text = "Assume"
        Me.btnAssume.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 313)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(50, 13)
        Me.Label2.TabIndex = 10
        Me.Label2.Text = "Threads:"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.chkStep)
        Me.GroupBox2.Controls.Add(Me.chkFile)
        Me.GroupBox2.Location = New System.Drawing.Point(6, 209)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(157, 72)
        Me.GroupBox2.TabIndex = 3
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Reporting Progress"
        '
        'chkStep
        '
        Me.chkStep.AutoSize = True
        Me.chkStep.Location = New System.Drawing.Point(6, 19)
        Me.chkStep.Name = "chkStep"
        Me.chkStep.Size = New System.Drawing.Size(93, 17)
        Me.chkStep.TabIndex = 0
        Me.chkStep.Text = "For Each Step"
        Me.chkStep.UseVisualStyleBackColor = True
        '
        'chkFile
        '
        Me.chkFile.AutoSize = True
        Me.chkFile.Checked = True
        Me.chkFile.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkFile.Location = New System.Drawing.Point(6, 42)
        Me.chkFile.Name = "chkFile"
        Me.chkFile.Size = New System.Drawing.Size(87, 17)
        Me.chkFile.TabIndex = 1
        Me.chkFile.Text = "For Each File"
        Me.chkFile.UseVisualStyleBackColor = True
        '
        'chkSub
        '
        Me.chkSub.AutoSize = True
        Me.chkSub.Checked = True
        Me.chkSub.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkSub.Location = New System.Drawing.Point(6, 284)
        Me.chkSub.Name = "chkSub"
        Me.chkSub.Size = New System.Drawing.Size(148, 17)
        Me.chkSub.TabIndex = 4
        Me.chkSub.Text = "Search all Sub-Directories"
        Me.chkSub.UseVisualStyleBackColor = True
        '
        'numThreads
        '
        Me.numThreads.Location = New System.Drawing.Point(62, 311)
        Me.numThreads.Maximum = New Decimal(New Integer() {8, 0, 0, 0})
        Me.numThreads.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.numThreads.Name = "numThreads"
        Me.numThreads.Size = New System.Drawing.Size(40, 20)
        Me.numThreads.TabIndex = 9
        Me.numThreads.Value = New Decimal(New Integer() {3, 0, 0, 0})
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.chkOpt6)
        Me.GroupBox3.Controls.Add(Me.chkOpt5)
        Me.GroupBox3.Controls.Add(Me.chkOpt4)
        Me.GroupBox3.Controls.Add(Me.chkOpt3)
        Me.GroupBox3.Controls.Add(Me.chkOpt2)
        Me.GroupBox3.Controls.Add(Me.chkOpt1)
        Me.GroupBox3.Location = New System.Drawing.Point(6, 42)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(157, 161)
        Me.GroupBox3.TabIndex = 2
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Compression steps"
        '
        'chkOpt6
        '
        Me.chkOpt6.AutoSize = True
        Me.chkOpt6.Checked = True
        Me.chkOpt6.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkOpt6.Location = New System.Drawing.Point(6, 134)
        Me.chkOpt6.Name = "chkOpt6"
        Me.chkOpt6.Size = New System.Drawing.Size(105, 17)
        Me.chkOpt6.TabIndex = 5
        Me.chkOpt6.Text = "Zopflipng (new!)"
        Me.chkOpt6.UseVisualStyleBackColor = True
        '
        'chkOpt5
        '
        Me.chkOpt5.AutoSize = True
        Me.chkOpt5.Checked = True
        Me.chkOpt5.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkOpt5.Location = New System.Drawing.Point(6, 111)
        Me.chkOpt5.Name = "chkOpt5"
        Me.chkOpt5.Size = New System.Drawing.Size(65, 17)
        Me.chkOpt5.TabIndex = 4
        Me.chkOpt5.Text = "AdvPNG"
        Me.chkOpt5.UseVisualStyleBackColor = True
        '
        'chkOpt4
        '
        Me.chkOpt4.AutoSize = True
        Me.chkOpt4.Checked = True
        Me.chkOpt4.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkOpt4.Location = New System.Drawing.Point(6, 88)
        Me.chkOpt4.Name = "chkOpt4"
        Me.chkOpt4.Size = New System.Drawing.Size(64, 17)
        Me.chkOpt4.TabIndex = 3
        Me.chkOpt4.Text = "PNGOut"
        Me.chkOpt4.UseVisualStyleBackColor = True
        '
        'chkOpt3
        '
        Me.chkOpt3.AutoSize = True
        Me.chkOpt3.Checked = True
        Me.chkOpt3.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkOpt3.Location = New System.Drawing.Point(6, 65)
        Me.chkOpt3.Name = "chkOpt3"
        Me.chkOpt3.Size = New System.Drawing.Size(66, 17)
        Me.chkOpt3.TabIndex = 2
        Me.chkOpt3.Text = "OptiPNG"
        Me.chkOpt3.UseVisualStyleBackColor = True
        '
        'chkOpt2
        '
        Me.chkOpt2.AutoSize = True
        Me.chkOpt2.Checked = True
        Me.chkOpt2.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkOpt2.Location = New System.Drawing.Point(6, 42)
        Me.chkOpt2.Name = "chkOpt2"
        Me.chkOpt2.Size = New System.Drawing.Size(74, 17)
        Me.chkOpt2.TabIndex = 1
        Me.chkOpt2.Text = "PNGCrush"
        Me.chkOpt2.UseVisualStyleBackColor = True
        '
        'chkOpt1
        '
        Me.chkOpt1.AutoSize = True
        Me.chkOpt1.Checked = True
        Me.chkOpt1.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkOpt1.Enabled = False
        Me.chkOpt1.Location = New System.Drawing.Point(6, 19)
        Me.chkOpt1.Name = "chkOpt1"
        Me.chkOpt1.Size = New System.Drawing.Size(83, 17)
        Me.chkOpt1.TabIndex = 0
        Me.chkOpt1.Text = "PNGRewrite"
        Me.chkOpt1.UseVisualStyleBackColor = True
        '
        'chkLoop
        '
        Me.chkLoop.AutoSize = True
        Me.chkLoop.Location = New System.Drawing.Point(77, 19)
        Me.chkLoop.Name = "chkLoop"
        Me.chkLoop.Size = New System.Drawing.Size(86, 17)
        Me.chkLoop.TabIndex = 1
        Me.chkLoop.Text = "Loop (Slow!)"
        Me.chkLoop.UseVisualStyleBackColor = True
        '
        'chkBackup
        '
        Me.chkBackup.AutoSize = True
        Me.chkBackup.Enabled = False
        Me.chkBackup.Location = New System.Drawing.Point(6, 19)
        Me.chkBackup.Name = "chkBackup"
        Me.chkBackup.Size = New System.Drawing.Size(60, 17)
        Me.chkBackup.TabIndex = 0
        Me.chkBackup.Text = "Backup"
        Me.chkBackup.UseVisualStyleBackColor = True
        '
        'btnFiles
        '
        Me.btnFiles.Location = New System.Drawing.Point(351, 5)
        Me.btnFiles.Name = "btnFiles"
        Me.btnFiles.Size = New System.Drawing.Size(35, 23)
        Me.btnFiles.TabIndex = 3
        Me.btnFiles.Text = "files"
        Me.btnFiles.UseVisualStyleBackColor = True
        '
        'fileBrowse
        '
        Me.fileBrowse.Filter = "PNG files|*.png"
        Me.fileBrowse.Multiselect = True
        '
        'dirBrowse
        '
        Me.dirBrowse.Description = "Please choose a folder to nuke:"
        Me.dirBrowse.ShowNewFolderButton = False
        '
        'bgThreadsCalc
        '
        Me.bgThreadsCalc.WorkerSupportsCancellation = True
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(583, 349)
        Me.Controls.Add(Me.btnFiles)
        Me.Controls.Add(Me.grpOptions)
        Me.Controls.Add(Me.chkOptions)
        Me.Controls.Add(Me.prgOverall)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnStart)
        Me.Controls.Add(Me.btnDir)
        Me.Controls.Add(Me.txtInput)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frmMain"
        Me.Text = "ExplodePNG (beta)"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.grpOptions.ResumeLayout(False)
        Me.grpOptions.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.numThreads, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtInput As System.Windows.Forms.TextBox
    Friend WithEvents btnDir As System.Windows.Forms.Button
    Friend WithEvents btnStart As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtLog As System.Windows.Forms.TextBox
    Friend WithEvents prgOverall As System.Windows.Forms.ProgressBar
    Friend WithEvents chkOptions As System.Windows.Forms.CheckBox
    Friend WithEvents grpOptions As System.Windows.Forms.GroupBox
    Friend WithEvents chkStep As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents chkOpt6 As System.Windows.Forms.CheckBox
    Friend WithEvents chkOpt5 As System.Windows.Forms.CheckBox
    Friend WithEvents chkOpt4 As System.Windows.Forms.CheckBox
    Friend WithEvents chkOpt3 As System.Windows.Forms.CheckBox
    Friend WithEvents chkOpt2 As System.Windows.Forms.CheckBox
    Friend WithEvents chkOpt1 As System.Windows.Forms.CheckBox
    Friend WithEvents chkLoop As System.Windows.Forms.CheckBox
    Friend WithEvents chkBackup As System.Windows.Forms.CheckBox
    Friend WithEvents chkSub As System.Windows.Forms.CheckBox
    Friend WithEvents btnFiles As System.Windows.Forms.Button
    Friend WithEvents fileBrowse As System.Windows.Forms.OpenFileDialog
    Friend WithEvents dirBrowse As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents chkFile As System.Windows.Forms.CheckBox
    Friend WithEvents bgThreadsCalc As System.ComponentModel.BackgroundWorker
    Friend WithEvents numThreads As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnAssume As System.Windows.Forms.Button

End Class
