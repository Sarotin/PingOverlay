<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Overlay
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
        PingThread = New Timer(components)
        Label1 = New Label()
        SuspendLayout()
        ' 
        ' PingThread
        ' 
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(0, 0)
        Label1.Name = "Label1"
        Label1.Size = New Size(66, 32)
        Label1.TabIndex = 0
        Label1.Text = "5555"
        ' 
        ' Overlay
        ' 
        AutoScaleDimensions = New SizeF(13F, 32F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(10, 10)
        Controls.Add(Label1)
        FormBorderStyle = FormBorderStyle.None
        Name = "Overlay"
        Text = "Overlay"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents PingThread As Timer
    Friend WithEvents Label1 As Label
End Class
