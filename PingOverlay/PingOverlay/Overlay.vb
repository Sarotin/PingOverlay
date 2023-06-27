Imports System.Net
Imports System.Net.NetworkInformation
Public Class Overlay
    Private ErrorCount As UInt16 = 0
    Const ErrorCountMax As UInt16 = 10

    Public Shared ServerIP As IPAddress

    Private trayIcon As NotifyIcon
    Private contextMenu As ContextMenuStrip
    Private Sub InitializeTrayIcon()
        trayIcon = New NotifyIcon()
        trayIcon.Icon = Me.Icon ' Icon?

        contextMenu = New ContextMenuStrip()
        contextMenu.Items.Add("Disable", Nothing, AddressOf Status_Click)
        contextMenu.Items.Add("Settings", Nothing, AddressOf Settings_Click)
        '  contextMenu.Items.Add("Hotkeys", Nothing, AddressOf Hotkeys_Click) ?
        contextMenu.Items.Add("Exit", Nothing, AddressOf Exit_Click)

        trayIcon.ContextMenuStrip = contextMenu
        trayIcon.Visible = True
    End Sub

    Private Sub Settings_Click(sender As Object, e As EventArgs)
        SettingsForm.Show()
    End Sub
    Private Sub Status_Click(sender As Object, e As EventArgs)
        If PingThread.Enabled = True Then
            Deaktivieren()
        Else
            Aktivieren()
        End If
    End Sub
    Private Sub Exit_Click(sender As Object, e As EventArgs)
        Environment.Exit(0)
    End Sub
    Sub New()
        InitializeComponent()
        InitializeTrayIcon()

        Me.Visible = False
        Me.AllowTransparency = True
        Label1.Visible = False
        Label1.AutoSize = True
        Label1.FlatStyle = FlatStyle.Flat
        Me.BackColor = Color.FromArgb(0, 0, 0)
        Label1.BackColor = Me.BackColor

        Me.FormBorderStyle = FormBorderStyle.None
        Me.TransparencyKey = Me.BackColor 'TransparencyKey = Opp. OverlayColor
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.TopMost = True

    End Sub
    Public Sub LoadSettings()
        Try
            Label1.Text = "9999"
            PingThread.Interval = My.Settings.PingInterval
            Label1.Font = My.Settings.OverlayFont
            Label1.ForeColor = My.Settings.OverlayColor
            Me.Location = New Point(My.Settings.OverlayLocation)
            Me.Size = New Size(Label1.Width + 20, Label1.Height + 20)
        Catch ex As Exception
            MsgBox(ErrorToString)
        End Try
    End Sub
    Public Sub Deaktivieren()
        Me.Hide()
        Label1.Text = ""
        PingThread.Enabled = False
        Label1.Visible = False
        contextMenu.Items(0).Text = "Enable"
    End Sub
    Public Sub Aktivieren()
        Me.Show()
        LoadSettings()
        Try
            If SettingsForm.ServerPing(My.Settings.Server) < 2000 And Not 0 Then
                ServerIP = System.Net.IPAddress.Parse(My.Settings.Server)
                Label1.Text = ""
                Label1.Visible = True
                ErrorCount = 0
                PingThread.Enabled = True
                contextMenu.Items(0).Text = "Disable"
            Else
                Deaktivieren()
            End If
        Catch ex As Exception
            Deaktivieren()

        End Try
    End Sub
    Private Async Sub PingThread_Tick(sender As Object, e As EventArgs) Handles PingThread.Tick
        Using pingSender As New Ping()
            Dim reply As PingReply = Await pingSender.SendPingAsync(ServerIP)
            If reply.Status = IPStatus.Success Then
                Label1.Text = CInt(reply.RoundtripTime).ToString
                ErrorCount = 0
            ElseIf ErrorCount <> ErrorCountMax Then
                ErrorCount = ErrorCount + 1
            Else
                Deaktivieren()
            End If
        End Using
    End Sub
    Private Sub Overlay_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Aktivieren()
    End Sub
End Class
