Imports System.Linq
Imports System.ComponentModel
Class PNGoptimizer

#Region "Executables"
    Public Shared ReadOnly advpng As String = GetCommonPath("advpng.exe")
    Public Shared ReadOnly optipng As String = GetCommonPath("optipng.exe")
    Public Shared ReadOnly pngcrush As String = GetCommonPath("pngcrush.exe")
    Public Shared ReadOnly pngout As String = GetCommonPath("pngout.exe")
    Public Shared ReadOnly pngrewrite As String = GetCommonPath("pngrewrite.exe")
    Public Shared ReadOnly zopflipng As String = GetCommonPath("zopflipng.exe")
    Public Shared ReadOnly zlib As String = GetCommonPath("zlib.dll")
#End Region

#Region "Properties"
    Public Property DataStr As String
    Public Property OptList As Boolean()
    Public Property Aftermath As Action
    Public Property Logger As TextBox
    Public Property AdvanceFile As Action
    Public Property SearchOpt As FileIO.SearchOption
    Public Property ShouldLoop As Boolean
    Public Property ForEachStep As Boolean
    Public Property ForEachFile As Boolean

    Private _ThreadsCount As Integer
    Public ReadOnly Property ThreadsCount As Integer
        Get
            Return _ThreadsCount
        End Get
    End Property

    Private _FilesCount As Integer
    Public ReadOnly Property FilesCount As Integer
        Get
            Return _FilesCount
        End Get
    End Property

    Private _BytesAtStart As Long
    Public ReadOnly Property BytesAtStart As Long
        Get
            Return _BytesAtStart
        End Get
    End Property

    Private _BytesAtEnd As Long
    Public ReadOnly Property BytesAtEnd As Long
        Get
            Return _BytesAtEnd
        End Get
    End Property

    Private _SubPNGList() As List(Of String)
    Public ReadOnly Property SubPNGList As List(Of String)()
        Get
            Return _SubPNGList
        End Get
    End Property

    Private _BGWorkers As List(Of BackgroundWorker)
    Public ReadOnly Property BGWorkers As List(Of BackgroundWorker)
        Get
            Return _BGWorkers
        End Get
    End Property
#End Region




    Private Sub SubWorkers_DoWork(sender As Object, e As DoWorkEventArgs)
        Dim MyPNGlist As List(Of String) = CType(e.Argument, List(Of String))
        If MyPNGlist.Count = 0 Then Return
        For i As Integer = 0 To MyPNGlist.Count - 1
            CompressPNG(MyPNGlist(i))
            _AdvanceFile()
        Next

    End Sub


    Private Delegate Sub LogInvoker([text] As String)
    Private Sub Log([text] As String)
        If Me.Logger IsNot Nothing Then
            If Me.Logger.InvokeRequired Then
                Me.Logger.Invoke(New LogInvoker(AddressOf Log), [text])
            Else
                Me.Logger.AppendText(String.Concat([text], Environment.NewLine))
            End If
        End If
    End Sub

    Private Sub SubWorkers_RunWorkerCompleted(sender As Object, e As System.ComponentModel.AsyncCompletedEventArgs)

        For Each workee As BackgroundWorker In _BGWorkers
            If workee.IsBusy = True Then Exit Sub
        Next

        _Aftermath()
    End Sub

    Private Sub CompressPNG(File As String)
        Try
            Dim FileStr As String = String.Concat("""", File, """")
            Dim FileName As String = String.Concat("""", IO.Path.GetFileName(File), """")
            With My.Computer.FileSystem
                Dim InSize As Long = .GetFileInfo(File).Length
                Dim Currsize, Lastsize As Long

                If ShouldLoop Then Currsize = Lastsize

                Dim p As New ProcessStartInfo
                p.WindowStyle = ProcessWindowStyle.Hidden
                p.CreateNoWindow = True
                p.UseShellExecute = False

                'p.WorkingDirectory = Application.CommonAppDataPath

                If OptList(0) Then
                    p.FileName = pngrewrite
                    p.Arguments = String.Concat(FileStr, " ", FileStr)
                    Try
                        Process.Start(p).WaitForExit()
                        If _ForEachStep Then Log(String.Concat(FileName, " was PNGRewritten."))
                    Catch ex As Win32Exception
                        Log("Unable to load the PNGRewrite excutable.")
                    End Try
                End If
                If ShouldLoop Then Currsize = .GetFileInfo(File).Length

                Do
                    If OptList(1) Then
                        If ShouldLoop Then Lastsize = Currsize
                        Dim tempfile As String = String.Concat(File, ".temp")
                        p.FileName = pngcrush
                        p.Arguments = String.Concat("-rem gAMA -rem cHRM -rem iCCP -rem sRGB -brute -l 9 -max -reduce -m 0 -q ", FileStr, " """, tempfile, """")
                        Try
                            Process.Start(p).WaitForExit()
                            If .FileExists(tempfile) Then
                                .DeleteFile(File)
                                .RenameFile(tempfile, IO.Path.GetFileName(File))
                                If _ForEachStep Then Log(String.Concat(FileName, " was PNGCrush-ed."))
                            End If
                        Catch ex As Win32Exception
                            Log("Unable to load the PNGCrush excutable.")
                        End Try
                    End If
                    If OptList(2) Then
                        p.FileName = optipng
                        p.Arguments = String.Concat("-o7 -q ", FileStr)
                        Try
                            Process.Start(p).WaitForExit()
                            If _ForEachStep Then Log(String.Concat(FileName, " was OptiPNG-ed."))
                        Catch ex As Win32Exception
                            Log("Unable to load the OptiPNG excutable.")
                        End Try
                    End If
                    If OptList(3) Then
                        p.FileName = pngout
                        p.Arguments = String.Concat("/q /y /k0 /s0 ", FileStr, " ", FileStr)
                        Try
                            Process.Start(p).WaitForExit()
                            If _ForEachStep Then Log(String.Concat(FileName, " was PNGOut-ed."))
                        Catch ex As Win32Exception
                            Log("Unable to load the PNGout excutable.")
                        End Try
                    End If
                    If OptList(4) Then
                        p.FileName = advpng
                        p.Arguments = String.Concat("-z -4 ", FileStr)
                        Try
                            Process.Start(p).WaitForExit()
                            If _ForEachStep Then Log(String.Concat(FileName, " was AdvPNG-ed."))
                        Catch ex As Win32Exception
                            Log("Unable to load the AdvPNG excutable.")
                        End Try
                    End If
                    If OptList(5) Then
                        p.FileName = PNGoptimizer.zopflipng
                        p.Arguments = String.Concat("-y ", FileStr, " ", FileStr)
                        Try
                            Process.Start(p).WaitForExit()
                            If _ForEachStep Then Log(String.Concat(FileName, " was Zopflipng-ed."))
                        Catch ex As Win32Exception
                            Log("Unable to load the Zopflipng excutable.")
                        End Try
                    End If
                    If ShouldLoop Then Currsize = .GetFileInfo(File).Length
                Loop While Lastsize <> Currsize

                p = Nothing

                If Not ShouldLoop Then Currsize = .GetFileInfo(File).Length

                _BytesAtStart += InSize
                _BytesAtEnd += Currsize
            End With
            If _ForEachFile Then Log(String.Concat(FileName, " was ionized."))
        Catch ex As Exception
            Log(GetExceptionInfo(ex))
        End Try

    End Sub

    Private Function GetPNGlist() As List(Of String)
        Dim PNGlist As New List(Of String)
        Log("Informing the authorities about the required actions...")

        For Each Str As String In Split(DataStr, "|")
            If IO.Path.GetExtension(Str) = ".png" AndAlso My.Computer.FileSystem.FileExists(Str) Then
                PNGlist.Add(Str)
            ElseIf My.Computer.FileSystem.DirectoryExists(Str) Then
                For Each img In My.Computer.FileSystem.GetFiles(Str, SearchOpt, {"*.png"})
                    PNGlist.Add(img)
                Next
            Else
                Log(String.Concat("""", IO.Path.GetFileName(Str), """", " was not approved."))
            End If
        Next
        If PNGlist.Count > 0 Then Log(String.Concat(PNGlist.Count, " files have been approved."))

        Return PNGlist
    End Function

    Private Shared Function SplitList(Of T)(ByVal list As List(Of T), ByVal count As Integer) As List(Of T)()
        Dim lists As New List(Of List(Of T))
        Dim itemCount As Integer = list.Count
        Dim maxCount = CInt(Math.Ceiling(itemCount / count))
        Dim skipCount = 0

        For number As Integer = count To 1 Step -1
            Dim takeCount As Integer = Math.Min(maxCount, itemCount)

            lists.Add(list.Skip(skipCount).Take(takeCount).ToList())
            'lists.Add(Skip(list, skipCount, takeCount))

            itemCount -= takeCount
            skipCount += takeCount

        Next

        Return lists.ToArray
    End Function

    Public Sub New(ByVal ThreadsCount As Integer, ByVal Locations As String, ByVal SearchSub As Boolean, ByVal ShouldLoop As Boolean, ByVal opts As Boolean(), ByVal foreachstep As Boolean, ByVal foreachfile As Boolean, ByRef textbox As TextBox, advancefile As Action, aftermath As Action)
        Me._ThreadsCount = ThreadsCount
        Me._DataStr = Locations
        Me._SearchOpt = If(SearchSub, FileIO.SearchOption.SearchAllSubDirectories, FileIO.SearchOption.SearchTopLevelOnly)
        Me._ShouldLoop = ShouldLoop
        Me._OptList = opts
        Me._Logger = textbox
        Me._AdvanceFile = advancefile
        Me._Aftermath = aftermath
        Me._ForEachStep = foreachstep
        Me._ForEachFile = foreachfile
        Dim bglist As New List(Of BackgroundWorker)
        For i As Integer = 0 To ThreadsCount - 1
            bglist.Add(New BackgroundWorker)
            AddHandler bglist(i).DoWork, AddressOf SubWorkers_DoWork
            AddHandler bglist(i).RunWorkerCompleted, AddressOf SubWorkers_RunWorkerCompleted
        Next
        _BGWorkers = bglist
    End Sub
    Public Sub PreparePNGlist()
        Dim PNGlist As List(Of String) = GetPNGlist()
        Me._FilesCount = PNGlist.Count
        Me._SubPNGList = SplitList(PNGlist, _ThreadsCount)
    End Sub
    Public Sub Start()
        For i As Integer = 0 To _ThreadsCount - 1
            _BGWorkers(i).RunWorkerAsync(SubPNGList(i))
        Next
    End Sub
    Public Shared Function GetCommonPath(st As String) As String
        Return IO.Path.Combine(Application.CommonAppDataPath, st)
    End Function
    Public Shared Function GetExceptionInfo(ex As Exception) As String
        Dim Result As String
        Dim hr As Integer = Runtime.InteropServices.Marshal.GetHRForException(ex)
        Result = ex.GetType.ToString & "(0x" & hr.ToString("X8") & "): " & ex.Message & Environment.NewLine & Environment.NewLine
        Dim st As StackTrace = New StackTrace(ex, True)
        For Each sf As StackFrame In st.GetFrames
            If sf.GetFileLineNumber() > 0 Then

                Result &= "Filename: " & IO.Path.GetFileName(sf.GetFileName) & ", Line: " & sf.GetFileLineNumber() & ", in method: " & sf.GetMethod.Name & Environment.NewLine

            End If
        Next
        Return Result
    End Function
End Class
