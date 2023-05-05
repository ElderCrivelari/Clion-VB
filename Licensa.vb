Imports System.Linq
Imports System.Threading

Public Class Licensa


    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        If MsgBox("Deseja mesmo cancelar?", MsgBoxStyle.YesNo + MsgBoxStyle.Information, "Licensa") = MsgBoxResult.Yes Then
            ' Encerra o aplicativo
            Application.Exit()
        End If

    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        Dim Str_Chav As String
        Dim Ado_Auxi As New ADODB.Recordset

        'Valida a chave do programa
        Str_Chav = Crypto.Decrypt(Glb_Seri) & Obj_Gene.Fun_Zero(Date.Now.Day, 2) & Obj_Gene.Fun_Zero(Date.Now.Month, 2) & Obj_Gene.Fun_Zero(Date.Now.Year, 4) & Obj_Gene.Fun_Zero(Date.Now.Hour, 2) & "BASIC" & "CLION"

        'Arrebenta a chave
        For int_loop As Integer = 0 To 1
            Str_Chav = Crypto.Encrypt(Str_Chav)
            Str_Chav = StrReverse(Str_Chav)
        Next


        If Trim(Txt_Chav.Text) = Trim(Str_Chav) Then
            'Dim Fil_File As New System.IO.FileAttributes
            FileIO.FileSystem.WriteAllText(Application.StartupPath & "\adodb29.dll", Str_Chav, False)
            Glb_Pesq = "Select * from Dados_Empresa"
            Obj_Gene.Sub_Crec(Ado_Auxi, Glb_Pesq)
            If Ado_Auxi.EOF Then
                Ado_Auxi.AddNew()
            End If
            Ado_Auxi("Dcad").Value = Date.Now.Date
            Ado_Auxi.Update()
            MessageBox.Show("Obrigado por Registrar!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.Close()
        Else
            MsgBox("Chave inválida, tente novamente!", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Erro")
            Txt_Chav.Text = ""
        End If
    End Sub

    Private Sub Licensa_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Txt_Chav.Text = ""
        Lbl_Seri.Text = Crypto.Decrypt(Glb_Seri)
    End Sub

    Private Sub Lbl_Seri_Click(sender As Object, e As EventArgs) Handles Lbl_Seri.Click
        Clipboard.SetText(Lbl_Seri.Text)
        MessageBox.Show("O texto foi copiado para a área de transferência com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub
End Class