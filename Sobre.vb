Public Class Sobre


    Private Sub Sobre_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        Lbl_Vers.Text = My.Application.Info.Version.ToString
        Lbl_Prod.Text = "Produto: " & Trim$(My.Application.Info.Title)
        Lbl_Seri.Text = "Número de série : " & Crypto.Decrypt(Glb_Seri)
        Obj_Gene.Sub_Menu("NNNNNNN", "NNNNNNN", False)

    End Sub

    Private Sub Label1_Click(sender As System.Object, e As System.EventArgs)

    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        ' Define o link que será aberto no navegador


        ' Define a propriedade LinkVisited como True
        LinkLabel1.LinkVisited = True

        ' Define a propriedade LinkColor como Purple
        LinkLabel1.LinkColor = Color.Purple

        ' Abre o link no navegador padrão do sistema
        Process.Start(LinkLabel1.Text)
    End Sub
End Class