Public Class frmMain
    Dim Taskbar As New WindowFlasher(Me.Handle)

    Const MyName As String = "ExplodePNG (beta)"
    Dim Manager As PNGoptimizer
    Dim timer As New Stopwatch()

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles chkOptions.CheckedChanged
        If chkOptions.Checked Then Me.Width = 595 Else Me.Width = 415
    End Sub


    Private Sub btnDir_Click(sender As Object, e As EventArgs) Handles btnDir.Click
        Using dirbrowse As New OpenFolderDialog()

            If dirbrowse.ShowDialog() = Windows.Forms.DialogResult.OK Then
                txtInput.Text = dirbrowse.Folder
            End If
        End Using

    End Sub

    Private Sub btnFiles_Click(sender As Object, e As EventArgs) Handles btnFiles.Click
        If fileBrowse.ShowDialog = Windows.Forms.DialogResult.OK Then
            txtInput.Text = Join(fileBrowse.FileNames, "|")
        End If
    End Sub

    Private Sub btnStart_Click(sender As Object, e As EventArgs) Handles btnStart.Click
        If txtInput.Text.Trim = "" Then
            Me.Text = MyName
            txtLog.AppendText("Nothing to Ionize :(")
            txtLog.AppendText(Environment.NewLine)
            Exit Sub
        End If



        Manager = New PNGoptimizer(CInt(numThreads.Value), txtInput.Text, chkSub.Checked, chkLoop.Checked, {chkOpt1.Checked, chkOpt2.Checked, chkOpt3.Checked, chkOpt4.Checked, chkOpt5.Checked, chkOpt6.Checked}, chkStep.Checked, chkFile.Checked, txtLog, AddressOf AdvanceProgressBar, AddressOf AllDone)
        Manager.PreparePNGlist()

        If Manager.FilesCount = 0 Then
            txtLog.AppendText("Nothing to Ionize :(")
            txtLog.AppendText(Environment.NewLine)
        Else
            btnStart.Enabled = False
            grpOptions.Enabled = True
            btnDir.Enabled = False
            btnFiles.Enabled = False
            prgOverall.Maximum = Manager.FilesCount
            Me.Text = String.Concat(MyName, " - 0%")
            timer.Start()
            Manager.Start()
        End If
    End Sub

    Private Delegate Sub AdvanceProgressBarInvoker()
    Private Sub AdvanceProgressBar()
        If Me.prgOverall.InvokeRequired Then
            Me.prgOverall.Invoke(New AdvanceProgressBarInvoker(AddressOf AdvanceProgressBar))
        Else
            prgOverall.PerformStep()
            FormText()
        End If
    End Sub
    Private Delegate Sub FormTextInvoker()
    Private Sub FormText()
        If Me.InvokeRequired Then
            Me.Invoke(New FormTextInvoker(AddressOf FormText))
        Else
            Me.Text = String.Concat(MyName, " - ", Math.Round(prgOverall.Value / prgOverall.Maximum, 4) * 100, "%")
        End If
    End Sub

    Private Sub AllDone()
        timer.Stop()
        txtLog.AppendText(String.Concat("Maximum capacity reached!", Environment.NewLine))
        txtLog.AppendText(String.Concat(Environment.NewLine, "A total of ", Manager.FilesCount, " files have been committed to the experiment.", Environment.NewLine))
        txtLog.AppendText(String.Concat("Bytes before: ", Manager.BytesAtStart, Environment.NewLine))
        txtLog.AppendText(String.Concat("Bytes after: ", Manager.BytesAtEnd, Environment.NewLine))
        txtLog.AppendText(String.Concat("Compression ratio: ", Math.Round(Manager.BytesAtEnd / Manager.BytesAtStart, 4) * 100, "%", Environment.NewLine))
        txtLog.AppendText(String.Concat("Elapsed Time: ", timer.ElapsedMilliseconds, "ms", Environment.NewLine))
        txtLog.AppendText(String.Concat(Environment.NewLine, Environment.NewLine))

        btnStart.Enabled = True
        grpOptions.Enabled = True
        btnDir.Enabled = True
        btnFiles.Enabled = True
        txtLog.Select(txtLog.TextLength, 0)
        btnStart.Focus()
        prgOverall.Value = 0
        timer.Reset()

        Taskbar.FlashWindow(True)
    End Sub

    Private Sub txtLog_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtLog.KeyPress
        e.Handled = True
    End Sub

    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        My.Settings.Reload()
        chkOpt2.Checked = My.Settings.PNGCrush
        chkOpt3.Checked = My.Settings.OptiPNG
        chkOpt4.Checked = My.Settings.PNGOut
        chkOpt5.Checked = My.Settings.AdvPNG
        chkOpt6.Checked = My.Settings.Zopflipng
        chkSub.Checked = My.Settings.SubSearch
        numThreads.Value = My.Settings.Threads
        Me.Text = MyName
        Try
            With My.Computer.FileSystem
                .WriteAllBytes(PNGoptimizer.advpng, My.Resources.advpng, False)
                .WriteAllBytes(PNGoptimizer.optipng, My.Resources.optipngconsole, False)
                .WriteAllBytes(PNGoptimizer.pngcrush, My.Resources.pngcrush, False)
                .WriteAllBytes(PNGoptimizer.pngout, My.Resources.pngout, False)
                .WriteAllBytes(PNGoptimizer.pngrewrite, My.Resources.pngrewrite, False)
                .WriteAllBytes(PNGoptimizer.zopflipng, My.Resources.zopflipng, False)
                .WriteAllBytes(PNGoptimizer.zlib, My.Resources.zlib, False)
            End With
        Catch ex As Exception
            btnStart.Enabled = False
            btnAssume.Enabled = False
            ReportError(ex)

        End Try
        Me.AllowDrop = True
        If My.Application.CommandLineArgs.Count > 0 Then
            Dim builder As New System.Text.StringBuilder()
            For Each x As String In My.Application.CommandLineArgs
                builder.Append(x)
                builder.Append("|")
            Next
            builder.Remove(builder.Length - 1, 1)
            txtInput.Text = builder.ToString
            builder = Nothing
            btnStart.PerformClick()
        End If
    End Sub
    Private Sub frmMain_DragDrop(sender As System.Object, e As System.Windows.Forms.DragEventArgs) Handles Me.DragDrop
        If btnStart.Enabled Then
            Dim files() As String = CType(e.Data.GetData(DataFormats.FileDrop), String())
            txtInput.Text = Join(files, "|")
            btnStart.PerformClick()
        End If
    End Sub

    Private Sub frmMain_DragEnter(sender As System.Object, e As System.Windows.Forms.DragEventArgs) Handles Me.DragEnter
        If e.Data.GetDataPresent(DataFormats.FileDrop) And btnStart.Enabled Then
            e.Effect = DragDropEffects.Link
        Else
            e.Effect = DragDropEffects.None
        End If
    End Sub

    Private Sub btnAssume_Click(sender As Object, e As EventArgs) Handles btnAssume.Click
        btnAssume.Enabled = False
        numThreads.Enabled = False
        btnStart.Enabled = False
        txtLog.AppendText(String.Concat("Calculating the recommended number of threads for the operations.", Environment.NewLine))
        bgThreadsCalc.RunWorkerAsync()
    End Sub

    Private Sub bgThreadsCalc_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles bgThreadsCalc.DoWork

        With My.Computer.FileSystem
            Dim mypath As String = IO.Path.Combine(.SpecialDirectories.Temp, "Assume.png")
            Dim mytemppath As String = String.Concat(mypath, ".temp")
            Try
                Dim cpuUsage As PerformanceCounter = New PerformanceCounter("Processor", "% Processor Time", "_Total")
                Dim p As New ProcessStartInfo
                p.WindowStyle = ProcessWindowStyle.Hidden
                p.CreateNoWindow = True
                p.UseShellExecute = False
                p.FileName = PNGoptimizer.pngcrush
                p.Arguments = String.Format("-rem gAMA -rem cHRM -rem iCCP -rem sRGB -brute -l 9 -max -reduce -m 0 -q ""{0}"" ""{1}""", mypath, mytemppath)

                .WriteAllBytes(mypath, My.Resources.Assume, False)

                cpuUsage.NextValue()
                Dim x As Process
                Threading.Thread.Sleep(1000)
                Try
                    x = Process.Start(p)
                Catch ex As Exception
                    ReportError(ex)
                    e.Cancel = True
                    Return
                End Try

                Dim Usage As Single
                Do
                    Usage = Math.Max(Usage, cpuUsage.NextValue())
                    Threading.Thread.Sleep(800)
                Loop Until x.HasExited
                e.Result = Usage
                cpuUsage.Dispose()
            Catch ex As Exception
                ReportError(ex)

                e.Cancel = True
            Finally

                If .FileExists(mypath) Then .DeleteFile(mypath)
                If .FileExists(mytemppath) Then .DeleteFile(mytemppath)
            End Try
        End With
    End Sub

    Private Sub bgThreadsCalc_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bgThreadsCalc.RunWorkerCompleted
        If Not e.Cancelled Then

            Dim usage As Single = CSng(e.Result)
            Dim threads As Double = Math.Min(Math.Max(Math.Floor(100 / usage), numThreads.Minimum), numThreads.Maximum)
            Dim possibleusage As Double = Math.Round(threads * usage, 2)

            numThreads.Value = CDec(threads)

            txtLog.AppendText(String.Format("The recommended number of threads is {0}{2}Estimated Average CPU Usage is: {1}%{2}", threads, possibleusage, Environment.NewLine))
          
        End If
        btnAssume.Enabled = True
        numThreads.Enabled = True
        btnStart.Enabled = True
    End Sub
    Private Delegate Sub ReportErrorInvoker(ex As Exception)

    Sub ReportError(ex As Exception)
        If txtLog.InvokeRequired Then
            txtLog.Invoke(New ReportErrorInvoker(AddressOf ReportError), ex)
        Else
            On Error Resume Next
            Dim x As String = PNGoptimizer.GetExceptionInfo(ex)
            txtLog.AppendText(String.Concat("Uh Oh! The Nuclear Power Plant exploded! :(", Environment.NewLine, "The details of the unfortunate accident are: ", x, Environment.NewLine))
        End If

    End Sub

    Private Sub chkOpt2_CheckedChanged(sender As Object, e As EventArgs) Handles chkOpt2.CheckedChanged
        My.Settings.PNGCrush = chkOpt2.Checked
    End Sub
    Private Sub chkOpt3_CheckedChanged(sender As Object, e As EventArgs) Handles chkOpt3.CheckedChanged
        My.Settings.OptiPNG = chkOpt3.Checked
    End Sub
    Private Sub chkOpt4_CheckedChanged(sender As Object, e As EventArgs) Handles chkOpt4.CheckedChanged
        My.Settings.PNGOut = chkOpt4.Checked
    End Sub
    Private Sub chkOpt5_CheckedChanged(sender As Object, e As EventArgs) Handles chkOpt5.CheckedChanged
        My.Settings.AdvPNG = chkOpt5.Checked
    End Sub
    Private Sub chkOpt6_CheckedChanged(sender As Object, e As EventArgs) Handles chkOpt6.CheckedChanged
        My.Settings.Zopflipng = chkOpt6.Checked
    End Sub
    Private Sub chkSub_CheckedChanged(sender As Object, e As EventArgs) Handles chkSub.CheckedChanged
        My.Settings.SubSearch = chkSub.Checked
    End Sub
    Private Sub frmMain_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        My.Settings.Save()
    End Sub


    Private Sub numThreads_ValueChanged(sender As Object, e As EventArgs) Handles numThreads.ValueChanged
        My.Settings.Threads = CInt(numThreads.Value)
    End Sub
End Class
