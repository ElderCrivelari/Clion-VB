Public Class Pesquisa_Gene
    Public Ado_Base As ADODB.Recordset
    Public Num_Pesq As Integer
    Dim Ado_Dset As New Data.DataSet
    Private Sub Pesquisa_Gene_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Ado_Dset.Reset()
        Glb_Pesq = "Select Clie as Codigo,Nome,Cepe as CEP,Nasc as Nascimento,Ende as Rua,Nume as Numero,Bair as Bairro,Cida as Cidade,Esta as UF,Tele as Telefones,Dcrg as RG,Dcpf as Documento,Canc as Cancelado,Fale as Falescido,Mudo as Mudou from Clientes"
        Obj_Gene.Sub_Crec(Ado_Base, Glb_Pesq)
        'Faz a pesquisa de dados
        Sub_Find() '(Glb_Pesq)
    End Sub

    Private Sub Grd_Pesq_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Grd_Pesq.DoubleClick
        Glb_Codi = Grd_Pesq.SelectedCells.Item(0).Value
        Me.Close()
    End Sub
    
    Private Sub Grd_Pesq_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Grd_Pesq.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            Glb_Codi = Grd_Pesq.SelectedCells.Item(0).Value
            Me.Close()
        End If
    End Sub
    Sub Sub_Filt()
        'Cria um filtro no form de pesquisa
    End Sub
    Sub Sub_Find() '(ByVal Str_Pesq As String)
        'Dim Ado_Dset As New Data.DataSet
        Dim Ado_Adap As New OleDb.OleDbDataAdapter

        'Preenche o adapter
        Ado_Adap.Fill(Ado_Dset, Ado_Base, "Clientes")
        'Me.Text = "Pesquisa por " & Glb_Capt
        'Preenche o grid    
        Grd_Pesq.DataSource = Ado_Dset.Tables("Clientes")
        Grd_Pesq.Refresh()
    End Sub

    Private Sub Txt_Clie_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt_Clie.TextChanged
        'If Not Obj_Gene.Fun_Nulo(Txt_Clie.Text) = "" Then
        Sub_Fitr()
        'End If
    End Sub

    Sub Sub_Fitr()
        Dim Str_Filt As String
        'Filtra os dados baseando no que está escrito na tela
        Str_Filt = ""
        'Cria a string de filto
        If Not Obj_Gene.Fun_Nulo(Txt_Clie.Text) = "" Then
            Str_Filt += " And Codigo like '%" & Obj_Gene.Fun_Nulo(Txt_Clie.Text) & "%'"
        End If
        If Not Obj_Gene.Fun_Nulo(Txt_Nome.Text) = "" Then
            Str_Filt += " And Nome like '%" & Obj_Gene.Fun_Nulo(Txt_Nome.Text) & "%'"
        End If
        If Not Obj_Gene.Fun_Nulo(Txt_Cepe.Text) = "" Then
            Str_Filt += " And CEP like '%" & Obj_Gene.Fun_Nulo(Txt_Cepe.Text) & "%'"
        End If
        If Not Obj_Gene.Fun_Nulo(Msk_Nasc.Text) = "/  /" Then
            Str_Filt += " And Nascimento = '" & Obj_Gene.Fun_Nulo(Msk_Nasc.Text) & "'"
        End If
        If Not Obj_Gene.Fun_Nulo(Txt_Ende.Text) = "" Then
            Str_Filt += " And Rua like '%" & Obj_Gene.Fun_Nulo(Txt_Ende.Text) & "%'"
        End If
        If Not Obj_Gene.Fun_Nulo(Txt_Nume.Text) = "" Then
            Str_Filt += " And Numero like '%" & Obj_Gene.Fun_Nulo(Txt_Nume.Text) & "%'"
        End If
        If Not Obj_Gene.Fun_Nulo(Txt_Bair.Text) = "" Then
            Str_Filt += " And Bairro like '%" & Obj_Gene.Fun_Nulo(Txt_Bair.Text) & "%'"
        End If
        If Not Obj_Gene.Fun_Nulo(Txt_Cida.Text) = "" Then
            Str_Filt += " And Cidade like '%" & Obj_Gene.Fun_Nulo(Txt_Cida.Text) & "%'"
        End If
        If Not Obj_Gene.Fun_Nulo(Txt_Esta.Text) = "" Then
            Str_Filt += " And UF like '%" & Obj_Gene.Fun_Nulo(Txt_Esta.Text) & "%'"
        End If
        If Not Obj_Gene.Fun_Nulo(Txt_Tele.Text) = "" Then
            Str_Filt += " And Telefones like '%" & Obj_Gene.Fun_Nulo(Txt_Tele.Text) & "%'"
        End If
        If Not Obj_Gene.Fun_Nulo(Txt_Dcrg.Text) = "" Then
            Str_Filt += " And RG like '%" & Obj_Gene.Fun_Nulo(Txt_Dcrg.Text) & "%'"
        End If
        If Not Obj_Gene.Fun_Nulo(Txt_Dcpf.Text) = "" Then
            Str_Filt += " And Documento like '%" & Obj_Gene.Fun_Nulo(Txt_Dcpf.Text) & "%'"
        End If
        If Chk_Canc.Checked Then
            Str_Filt += " And Cancelado = True"
        End If
        If Chk_Fale.Checked Then
            Str_Filt += " And Falescido = True"
        End If
        If Chk_Mudo.Checked Then
            Str_Filt += " And Mudou = True"
        End If


        'Filtra finalmente os resultados
        If Str_Filt = "" Then
            Ado_Dset.Tables(0).DefaultView.RowFilter = Nothing
        Else
            Str_Filt = Mid(Str_Filt, 5)
            Ado_Dset.Tables(0).DefaultView.RowFilter = Str_Filt
        End If
    End Sub

    Private Sub Txt_Nome_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt_Nome.TextChanged
        'If Not Obj_Gene.Fun_Nulo(Txt_Nome.Text) = "" Then
        Sub_Fitr()
        'End If
    End Sub

    Private Sub Txt_Cepe_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt_Cepe.TextChanged
        'If Not Obj_Gene.Fun_Nulo(Txt_Cepe.Text) = "" Then
        Sub_Fitr()
        ' End If
    End Sub

    Private Sub Msk_Nasc_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Msk_Nasc.LostFocus
        Sub_Fitr()
    End Sub

    Private Sub Txt_Ende_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt_Ende.TextChanged
        'If Not Obj_Gene.Fun_Nulo(Txt_Ende.Text) = "" Then
        Sub_Fitr()
        ' End If
    End Sub

    Private Sub Txt_Nume_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt_Nume.TextChanged
        'If Not Obj_Gene.Fun_Nulo(Txt_Nume.Text) = "" Then
        Sub_Fitr()
        'End If
    End Sub

    Private Sub Txt_Bair_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt_Bair.TextChanged
        ' If Not Obj_Gene.Fun_Nulo(Txt_Bair.Text) = "" Then
        Sub_Fitr()
        ' End If
    End Sub

    Private Sub Txt_Cida_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt_Cida.TextChanged
        ' If Not Obj_Gene.Fun_Nulo(Txt_Cida.Text) = "" Then
        Sub_Fitr()
        'End If
    End Sub

    Private Sub Txt_Esta_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt_Esta.TextChanged
        ' If Not Obj_Gene.Fun_Nulo(Txt_Esta.Text) = "" Then
        Sub_Fitr()
        ' End If
    End Sub

    Private Sub Txt_Tele_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt_Tele.TextChanged
        ' If Not Obj_Gene.Fun_Nulo(Txt_Tele.Text) = "" Then
        Sub_Fitr()
        ' End If
    End Sub

    Private Sub Chk_Canc_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Chk_Canc.CheckedChanged
        ' If Chk_Canc.Checked Then
        Sub_Fitr()
        ' End If
    End Sub

    Private Sub Chk_Mudo_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Chk_Mudo.CheckedChanged
        ' If Chk_Mudo.Checked Then
        Sub_Fitr()
        ' End If
    End Sub

    Private Sub Chk_Fale_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Chk_Fale.CheckedChanged
        ' If Chk_Fale.Checked Then
        Sub_Fitr()
        'End If
    End Sub

    Private Sub Txt_Dcrg_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt_Dcrg.TextChanged
        Sub_Fitr()
    End Sub

    Private Sub Txt_Dcpf_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt_Dcpf.TextChanged
        Sub_Fitr()
    End Sub
End Class