<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SettingsForm
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
        components = New ComponentModel.Container()
        ListBox1 = New ListBox()
        StartButton = New Button()
        ListConnectionBtn = New Button()
        Timer1 = New Timer(components)
        IntervalTextBox = New TextBox()
        Label5 = New Label()
        Label4 = New Label()
        Label3 = New Label()
        Font_SizeTextBox = New TextBox()
        Label6 = New Label()
        Label7 = New Label()
        Font_StyleTextBox = New TextBox()
        Font_NameTextBox = New TextBox()
        SelectFontBtn = New Button()
        ServerTextBox = New TextBox()
        Label2 = New Label()
        Label8 = New Label()
        Overlay_LocationX = New TextBox()
        ComboBox1 = New ComboBox()
        Overlay_LocationY = New TextBox()
        CheckBox1 = New CheckBox()
        SuspendLayout()
        ' 
        ' ListBox1
        ' 
        ListBox1.BorderStyle = BorderStyle.FixedSingle
        ListBox1.FormattingEnabled = True
        ListBox1.ItemHeight = 32
        ListBox1.Location = New Point(340, 0)
        ListBox1.Name = "ListBox1"
        ListBox1.Size = New Size(557, 546)
        ListBox1.TabIndex = 0
        ' 
        ' StartButton
        ' 
        StartButton.Font = New Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point)
        StartButton.Location = New Point(3, 450)
        StartButton.Name = "StartButton"
        StartButton.Size = New Size(331, 46)
        StartButton.TabIndex = 1
        StartButton.Text = "Save & Load"
        StartButton.UseVisualStyleBackColor = True
        ' 
        ' ListConnectionBtn
        ' 
        ListConnectionBtn.Location = New Point(3, 325)
        ListConnectionBtn.Name = "ListConnectionBtn"
        ListConnectionBtn.Size = New Size(331, 46)
        ListConnectionBtn.TabIndex = 7
        ListConnectionBtn.Text = "List Connections"
        ListConnectionBtn.UseVisualStyleBackColor = True
        ' 
        ' IntervalTextBox
        ' 
        IntervalTextBox.Location = New Point(168, 225)
        IntervalTextBox.Name = "IntervalTextBox"
        IntervalTextBox.Size = New Size(166, 39)
        IntervalTextBox.TabIndex = 24
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Location = New Point(3, 90)
        Label5.Name = "Label5"
        Label5.Size = New Size(62, 32)
        Label5.TabIndex = 22
        Label5.Text = "Size:"
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Location = New Point(3, 45)
        Label4.Name = "Label4"
        Label4.Size = New Size(70, 32)
        Label4.TabIndex = 21
        Label4.Text = "Style:"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Location = New Point(3, 0)
        Label3.Name = "Label3"
        Label3.Size = New Size(83, 32)
        Label3.TabIndex = 20
        Label3.Text = "Name:"
        ' 
        ' Font_SizeTextBox
        ' 
        Font_SizeTextBox.Location = New Point(95, 90)
        Font_SizeTextBox.Name = "Font_SizeTextBox"
        Font_SizeTextBox.ReadOnly = True
        Font_SizeTextBox.Size = New Size(239, 39)
        Font_SizeTextBox.TabIndex = 19
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.Location = New Point(3, 370)
        Label6.Name = "Label6"
        Label6.Size = New Size(86, 32)
        Label6.TabIndex = 18
        Label6.Text = "Server:"
        ' 
        ' Label7
        ' 
        Label7.AutoSize = True
        Label7.Location = New Point(3, 225)
        Label7.Name = "Label7"
        Label7.Size = New Size(147, 32)
        Label7.TabIndex = 17
        Label7.Text = "Interval(MS):"
        ' 
        ' Font_StyleTextBox
        ' 
        Font_StyleTextBox.Location = New Point(95, 45)
        Font_StyleTextBox.Name = "Font_StyleTextBox"
        Font_StyleTextBox.ReadOnly = True
        Font_StyleTextBox.Size = New Size(239, 39)
        Font_StyleTextBox.TabIndex = 16
        ' 
        ' Font_NameTextBox
        ' 
        Font_NameTextBox.Location = New Point(95, 0)
        Font_NameTextBox.Multiline = True
        Font_NameTextBox.Name = "Font_NameTextBox"
        Font_NameTextBox.ReadOnly = True
        Font_NameTextBox.Size = New Size(239, 35)
        Font_NameTextBox.TabIndex = 15
        ' 
        ' SelectFontBtn
        ' 
        SelectFontBtn.Location = New Point(3, 275)
        SelectFontBtn.Name = "SelectFontBtn"
        SelectFontBtn.Size = New Size(331, 46)
        SelectFontBtn.TabIndex = 14
        SelectFontBtn.Text = "Select Font"
        SelectFontBtn.UseVisualStyleBackColor = True
        ' 
        ' ServerTextBox
        ' 
        ServerTextBox.Location = New Point(3, 405)
        ServerTextBox.Name = "ServerTextBox"
        ServerTextBox.Size = New Size(331, 39)
        ServerTextBox.TabIndex = 27
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Location = New Point(3, 180)
        Label2.Name = "Label2"
        Label2.Size = New Size(159, 32)
        Label2.TabIndex = 32
        Label2.Text = "Location(X/Y):"
        ' 
        ' Label8
        ' 
        Label8.AutoSize = True
        Label8.Location = New Point(3, 135)
        Label8.Name = "Label8"
        Label8.Size = New Size(76, 32)
        Label8.TabIndex = 31
        Label8.Text = "Color:"
        ' 
        ' Overlay_LocationX
        ' 
        Overlay_LocationX.Location = New Point(168, 180)
        Overlay_LocationX.Name = "Overlay_LocationX"
        Overlay_LocationX.Size = New Size(79, 39)
        Overlay_LocationX.TabIndex = 30
        ' 
        ' ComboBox1
        ' 
        ComboBox1.FormattingEnabled = True
        ComboBox1.Location = New Point(168, 135)
        ComboBox1.Name = "ComboBox1"
        ComboBox1.Size = New Size(166, 40)
        ComboBox1.TabIndex = 33
        ' 
        ' Overlay_LocationY
        ' 
        Overlay_LocationY.Location = New Point(255, 180)
        Overlay_LocationY.Name = "Overlay_LocationY"
        Overlay_LocationY.Size = New Size(79, 39)
        Overlay_LocationY.TabIndex = 34
        ' 
        ' CheckBox1
        ' 
        CheckBox1.AutoSize = True
        CheckBox1.Location = New Point(3, 500)
        CheckBox1.Name = "CheckBox1"
        CheckBox1.Size = New Size(200, 36)
        CheckBox1.TabIndex = 35
        CheckBox1.Text = "Run on Startup"
        CheckBox1.UseVisualStyleBackColor = True
        ' 
        ' SettingsForm
        ' 
        AutoScaleDimensions = New SizeF(13F, 32F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(896, 545)
        Controls.Add(CheckBox1)
        Controls.Add(Overlay_LocationY)
        Controls.Add(ComboBox1)
        Controls.Add(Label2)
        Controls.Add(Label8)
        Controls.Add(Overlay_LocationX)
        Controls.Add(ServerTextBox)
        Controls.Add(IntervalTextBox)
        Controls.Add(Label5)
        Controls.Add(Label4)
        Controls.Add(Label3)
        Controls.Add(Font_SizeTextBox)
        Controls.Add(Label6)
        Controls.Add(Label7)
        Controls.Add(Font_StyleTextBox)
        Controls.Add(Font_NameTextBox)
        Controls.Add(SelectFontBtn)
        Controls.Add(ListConnectionBtn)
        Controls.Add(StartButton)
        Controls.Add(ListBox1)
        FormBorderStyle = FormBorderStyle.FixedSingle
        Name = "SettingsForm"
        Text = "Settings"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents ListBox1 As ListBox
    Friend WithEvents StartButton As Button

    Friend WithEvents ListConnectionBtn As Button
    Friend WithEvents Timer1 As Timer
    Friend WithEvents IntervalTextBox As TextBox

    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Font_SizeTextBox As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Font_StyleTextBox As TextBox
    Friend WithEvents Font_NameTextBox As TextBox
    Friend WithEvents SelectFontBtn As Button
    Friend WithEvents ServerTextBox As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Overlay_LocationX As TextBox
    Friend WithEvents ComboBox1 As ComboBox
    Friend WithEvents Overlay_LocationY As TextBox
    Friend WithEvents CheckBox1 As CheckBox
End Class
