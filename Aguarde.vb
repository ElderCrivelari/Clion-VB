Public Class Aguarde



    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Threading.Thread.Sleep(5000)
        Me.Close()
        Timer1.Enabled = False
    End Sub

    Private Sub Aguarde_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Timer1.Enabled = True
    End Sub

   
End Class