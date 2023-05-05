<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Impressao
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
        Me.Crp_Rela = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
        Me.SuspendLayout()
        '
        'Crp_Rela
        '
        Me.Crp_Rela.ActiveViewIndex = -1
        Me.Crp_Rela.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Crp_Rela.Cursor = System.Windows.Forms.Cursors.Default
        Me.Crp_Rela.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Crp_Rela.Location = New System.Drawing.Point(0, 0)
        Me.Crp_Rela.Name = "Crp_Rela"
        Me.Crp_Rela.Size = New System.Drawing.Size(587, 482)
        Me.Crp_Rela.TabIndex = 0
        Me.Crp_Rela.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
        '
        'Impressao
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(587, 482)
        Me.Controls.Add(Me.Crp_Rela)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "Impressao"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Impressão"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Crp_Rela As CrystalDecisions.Windows.Forms.CrystalReportViewer
End Class
