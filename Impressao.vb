Public Class Impressao


    Private Sub Impressao_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Crp_Rela.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
        Aguarde.ShowDialog()
        'Threading.Thread.Sleep(5000)
        Me.WindowState = FormWindowState.Maximized
        Crp_Rela.RefreshReport()
    End Sub
End Class