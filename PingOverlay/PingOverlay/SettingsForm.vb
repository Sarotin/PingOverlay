Imports System.Net
Imports System.Net.NetworkInformation
Imports System.Runtime.InteropServices
Imports Microsoft.Win32
'Hotkeys?


Public Class SettingsForm


#Region "List Connections"
    <StructLayout(LayoutKind.Sequential)>
    Public Structure MIB_TCPROW_OWNER_PID
        Public state As UInteger
        Public localAddr As UInteger
        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=4)>
        Public localPort As Byte()
        Public remoteAddr As UInteger
        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=4)>
        Public remotePort As Byte()
        Public owningPid As UInteger
    End Structure
    <StructLayout(LayoutKind.Sequential)>
    Public Structure MIB_TCPTABLE_OWNER_PID
        Public dwNumEntries As UInteger
        <MarshalAs(UnmanagedType.ByValArray, ArraySubType:=UnmanagedType.Struct)>
        Public table As MIB_TCPROW_OWNER_PID()
    End Structure
    Private Const AF_INET As Integer = 2
    Private Const TCP_TABLE_OWNER_PID_ALL As Integer = 5
    <DllImport("iphlpapi.dll", SetLastError:=True)>
    Private Shared Function GetExtendedTcpTable(pTcpTable As IntPtr, ByRef dwOutBufLen As Integer, bOrder As Boolean, ulAf As Integer, tableClass As Integer, reserved As UInteger) As UInteger
    End Function

    Private Async Sub ListConnections() 'ByVal P_Name As String
        Await Task.Run(Sub()
                           Try
                               Dim bufferSize As Integer = 0
                               GetExtendedTcpTable(IntPtr.Zero, bufferSize, True, AF_INET, TCP_TABLE_OWNER_PID_ALL, 0)

                               Dim tcpTablePtr = Marshal.AllocHGlobal(bufferSize)
                               Dim result = GetExtendedTcpTable(tcpTablePtr, bufferSize, True, AF_INET, TCP_TABLE_OWNER_PID_ALL, 0)

                               If result <> 0 Then
                                   Throw New Exception("GetExtendedTcpTable failed with error: " & result)
                               End If

                               Dim tcpTable = CType(Marshal.PtrToStructure(tcpTablePtr, GetType(MIB_TCPTABLE_OWNER_PID)), MIB_TCPTABLE_OWNER_PID)
                               Dim rowPtr = CType(tcpTablePtr + Marshal.SizeOf(tcpTable.dwNumEntries), IntPtr)

                               For i = 0 To tcpTable.dwNumEntries - 1
                                   Dim tcpRow = CType(Marshal.PtrToStructure(rowPtr, GetType(MIB_TCPROW_OWNER_PID)), MIB_TCPROW_OWNER_PID)
                                   Dim remoteAddress = New IPAddress(tcpRow.remoteAddr).ToString()
                                   Dim remotePort = BitConverter.ToUInt16(New Byte() {tcpRow.remotePort(1), tcpRow.remotePort(0)}, 0)
                                   Dim processId = tcpRow.owningPid
                                   Dim processName As String = Process.GetProcessById(processId).ProcessName
                                   Dim ResponseTime As UInt16 = ServerPing(remoteAddress)
                                   If ResponseTime < 1000 And ResponseTime <> 0 And remoteAddress.ToString <> "127.0.0.1" And remoteAddress.ToString <> "0.0.0.0" Then

                                       UpdateListBox(processName & " (PID: " & processId & ") IP:" & remoteAddress & ":" & remotePort & " " & ResponseTime.ToString & "MS")

                                   End If
                                   rowPtr += Marshal.SizeOf(GetType(MIB_TCPROW_OWNER_PID))
                               Next

                               Marshal.FreeHGlobal(tcpTablePtr)
                           Catch ex As Exception
                               MessageBox.Show(ex.Message)
                           End Try
                       End Sub)
    End Sub
    Private Sub UpdateListBox(ByVal item As String)
        Try
            If ListBox1.InvokeRequired Then
                ListBox1.Invoke(New Action(Of String)(AddressOf UpdateListBox), item)
            Else
                ListBox1.Items.Add(item)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ListBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox1.SelectedIndexChanged
        Try
            If ListBox1.SelectedItem IsNot Nothing Then
                Dim selectedItem As String = ListBox1.SelectedItem.ToString()
                Dim startIndex As Integer = selectedItem.IndexOf("IP:") + 3 '  Anfang der IP-Adresse
                Dim endIndex As Integer = selectedItem.IndexOf(":", startIndex) '  Ende der IP-Adresse
                Dim remoteAddress As String = selectedItem.Substring(startIndex, endIndex - startIndex)

                ServerTextBox.Text = remoteAddress
            End If
        Catch ex As Exception
            '   MsgBox(ErrorToString)
        End Try
    End Sub
#End Region
    Public Shared Function ServerPing(ByVal IP As String) As UInt16
        Try
            Using pingSender As New Ping()
                Dim reply As PingReply = pingSender.Send(IP)
                If reply.Status = IPStatus.Success Then

                    Return CInt(reply.RoundtripTime)

                Else
                    Return 9999

                End If
            End Using
        Catch ex As Exception
            Return 9999
        End Try

    End Function

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles ListConnectionBtn.Click
        ListBox1.Items.Clear()
        ListConnections()

    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles StartButton.Click
        Try
            If ServerTextBox.Text <> Nothing Then
                If ServerPing(ServerTextBox.Text) < 2000 And Not 0 Then
                    Overlay.ServerIP = System.Net.IPAddress.Parse(ServerTextBox.Text)
                    SaveSettings()
                    Me.Hide()
                    Overlay.Aktivieren()
                Else
                    MsgBox("No Response.")
                End If
            Else
                MsgBox("No Server.")
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub SelectFontBtn_Click(sender As Object, e As EventArgs) Handles SelectFontBtn.Click
        Dim fontDialog As New FontDialog()
        Try
            If fontDialog.ShowDialog() = DialogResult.OK Then
                My.Settings.OverlayFont = fontDialog.Font
                Font_NameTextBox.Text = fontDialog.Font.Name
                Font_StyleTextBox.Text = fontDialog.Font.Style.ToString
                Font_SizeTextBox.Text = fontDialog.Font.Size
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub TextToLocation()
        Dim x As Integer
        Dim y As Integer
        Try
            If Integer.TryParse(Overlay_LocationX.Text, x) AndAlso Integer.TryParse(Overlay_LocationY.Text, y) Then
                Dim location As New Point(x, y)
                My.Settings.OverlayLocation = location
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub LoadSettings()
        Try

            CheckBox1.Checked = StartupManager.IsStartupSet
            LoadColorInBox()

            IntervalTextBox.Text = My.Settings.PingInterval
            ComboBox1.SelectedItem = My.Settings.OverlayColor

            Overlay_LocationX.Text = My.Settings.OverlayLocation.X.ToString
            Overlay_LocationY.Text = My.Settings.OverlayLocation.Y.ToString

            Font_NameTextBox.Text = My.Settings.OverlayFont.Name.ToString
            Font_SizeTextBox.Text = My.Settings.OverlayFont.Size.ToString
            Font_StyleTextBox.Text = My.Settings.OverlayFont.Style.ToString
            '
            ServerTextBox.Text = My.Settings.Server

        Catch ex As Exception
            MsgBox("Error loading Settings!")
        End Try
    End Sub
    Private Sub SaveSettings()
        Try
            StartupManager.SetStartup(CheckBox1.Checked)
            My.Settings.PingInterval = IntervalTextBox.Text
            TextToLocation() 'My.Settings.OverlayLocation = Textbox1&2
            My.Settings.Server = ServerTextBox.Text
            My.Settings.OverlayColor = ComboBox1.SelectedItem
            My.Settings.Save() 'Font will also be saved

        Catch ex As Exception
            MsgBox(ErrorToString)
        End Try
    End Sub
    Private Sub LoadColorInBox()
        Try


            Dim colors As Array = System.Enum.GetValues(GetType(KnownColor))


            For Each color As KnownColor In colors
                Dim colorName As String = color.ToString()
                Dim colorValue As Color = ColorTranslator.FromHtml(colorName)
                ComboBox1.Items.Add(colorValue)
            Next
        Catch ex As Exception
            MsgBox(ErrorToString)
        End Try
    End Sub

    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadSettings()

    End Sub
End Class


Public Class StartupManager
    Private Shared Sub AddToStartup()
        Try


            Dim key As RegistryKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\Microsoft\Windows\CurrentVersion\Run", True)
            key.SetValue("PingOverlay", Application.ExecutablePath)
            key.Close()
        Catch ex As Exception
            MsgBox(ErrorToString)
        End Try
    End Sub

    Private Shared Sub RemoveFromStartup()
        Try


            Dim key As RegistryKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\Microsoft\Windows\CurrentVersion\Run", True)
            key.DeleteValue("PingOverlay", False)
            key.Close()
        Catch ex As Exception
            MsgBox(ErrorToString)
        End Try
    End Sub

    Public Shared Function IsStartupSet() As Boolean
        Try


            Dim key As RegistryKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\Microsoft\Windows\CurrentVersion\Run", True)
            Dim value As Object = key.GetValue("PingOverlay")
            key.Close()

            Return value IsNot Nothing
        Catch ex As Exception
            MsgBox(ErrorToString)
        End Try
    End Function
    Public Shared Sub SetStartup(ByVal StartUp As Boolean)
        If IsStartupSet() = True And StartUp = False Then
            RemoveFromStartup()
        ElseIf IsStartupSet() = False And StartUp = True Then
            AddToStartup()
        End If
    End Sub
End Class
