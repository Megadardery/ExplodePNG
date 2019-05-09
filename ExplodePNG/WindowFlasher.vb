Public Class WindowFlasher
    Private flash As FLASHWINFO
    Private _IsBeingFlashed As Boolean
    ''' <summary>
    ''' Shows if the assigned window is being flashed or no. Using FWForeground breaks this property.
    ''' </summary>
    Public ReadOnly Property IsBeingFlashed As Boolean
        Get
            Return _IsBeingFlashed
        End Get
    End Property
    Public Property Flags As WFFlags

    Private Structure FLASHWINFO
        Dim cbSize As Int32
        Dim hwnd As IntPtr
        Dim dwFlags As Int32
        Dim uCount As Int32
        Dim dwTimeout As Int32
    End Structure
    Public Enum WFFlags
        ''' <summary>
        ''' Flash the window caption.
        ''' </summary>
        FWCaption = 1
        ''' <summary>
        ''' Flash the taskbar button.
        ''' </summary>
        FWTray = 2
        ''' <summary>
        ''' Flash both the window caption and taskbar button.
        ''' </summary>
        FWAll = 3
        ''' <summary>
        ''' Flash continuously.
        ''' </summary>
        FWNoStop = 4
        ''' <summary>
        ''' Flash continuously until the window comes to the foreground. 
        ''' </summary>
        FWForeground = 12
    End Enum
    ''' <summary>
    ''' Creates a new instanse of WindowFlasher.
    ''' </summary>
    ''' <param name="Handle">The window to flash, use "Me.Handle" to flash the current window.</param>
    ''' <param name="Flags">Apply special flags to the flashing of the window.</param>
    ''' <remarks></remarks>
    Public Sub New(ByVal Handle As IntPtr, Optional ByVal Flags As WFFlags = CType(15, WFFlags))
        flash = New FLASHWINFO
        flash.cbSize = System.Runtime.InteropServices.Marshal.SizeOf(flash)
        flash.hwnd = Handle
        Me.Flags = Flags
    End Sub

    Private Declare Function FlashWindowEx Lib "user32.dll" (ByRef pfwi As FLASHWINFO) As Integer
    ''' <summary>
    ''' Start flashing the assigned window using the set flags
    ''' </summary>
    ''' <param name="Override">Indicates whether to reflash the window even if it is currently being flashed.</param>
    Public Sub FlashWindow(Optional Override As Boolean = False)
        If Override = False And _IsBeingFlashed = True Then Exit Sub
        flash.dwFlags = Flags
        FlashWindowEx(flash)
        _IsBeingFlashed = True
    End Sub
    ''' <summary>
    ''' Stop flashing anytime. The system restores the window to its original state.
    ''' </summary>
    Public Sub StopFlashing()
        flash.dwFlags = 0
        FlashWindowEx(flash)
        _IsBeingFlashed = False
    End Sub
End Class