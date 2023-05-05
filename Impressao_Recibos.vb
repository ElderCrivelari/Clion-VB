Public Class Impressao_Recibos
    Implements Obj_Func

    Private Sub Impressao_Recibos_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        Obj_Gene.Sub_Menu("NNNNNNS", "NNNNNNS", False)
    End Sub

    Private Sub Impressao_Recibos_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Obj_Gene.Sub_Menu("NNNNNNN", "NNNNNNN")
        Menus.Men_Irec.Enabled = True
    End Sub

    Private Sub Impressao_Recibos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Msk_Dede.Text = "  /  /    "
        Msk_Date.Text = "  /  /    "
        Msk_Dede.Focus()
    End Sub

    Public Sub Sub_Ante() Implements Obj_Func.Sub_Ante

    End Sub

    Public Sub Sub_Dele() Implements Obj_Func.Sub_Dele

    End Sub

    Public Sub Sub_Impr() Implements Obj_Func.Sub_Impr
        Dim Str_Sele As String
        'Cria a string de seleção
        Str_Sele = ""
        If Not Obj_Gene.Fun_Nulo(Msk_Dede.Text) = "/  /" Then
            If Not Obj_Gene.Fun_Erro(Msk_Dede.Text, 2, 2, Msk_Dede) Then
                Str_Sele = Str_Sele & "And {Recibos.Data} >= Cdate('" & Msk_Dede.Text & "') "
            End If
        End If

        If Not Obj_Gene.Fun_Nulo(Msk_Date.Text) = "/  /" Then
            If Not Obj_Gene.Fun_Erro(Msk_Date.Text, 2, 2, Msk_Date) Then
                Str_Sele = Str_Sele & "And {Recibos.Data} <= Cdate('" & Msk_Date.Text & "')"
            End If
        End If
        If Not Str_Sele = "" Then Str_Sele = Mid(Str_Sele, 5)
        'imprime o relatorio
        Obj_Gene.Sub_Prnt("Rpt_Rere", Str_Sele, "", False)
    End Sub

    Public Sub Sub_Incl() Implements Obj_Func.Sub_Incl

    End Sub

    Public Sub Sub_Pesq() Implements Obj_Func.Sub_Pesq

    End Sub

    Public Sub Sub_Prim() Implements Obj_Func.Sub_Prim

    End Sub

    Public Sub Sub_Prox() Implements Obj_Func.Sub_Prox

    End Sub

    Public Sub Sub_Salv() Implements Obj_Func.Sub_Salv

    End Sub

    Public Sub Sub_Ulti() Implements Obj_Func.Sub_Ulti

    End Sub
End Class