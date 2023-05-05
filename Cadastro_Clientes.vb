
Public Class Cadastro_Projetos
    Implements Obj_Func
    Public Ado_Base As ADODB.Recordset
    Public Bol_Salv As Boolean, Bol_Novo As Boolean

    Private Sub Cadastro_Clientes_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        Obj_Gene.Sub_Menu("SSSSSSN", "SSSSSSN", True)
    End Sub

    Private Sub Cadastro_Clientes_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Obj_Gene.Sub_Menu("NNNNNNN", "NNNNNNN")
        'Obj_Gene.Sub_Fech()
        Menus.Men_Clie.Enabled = True
    End Sub

    Private Sub Cadastro_Clientes_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If Bol_Salv Then Sub_Vsal()
    End Sub

    Private Sub Cadastro_Clientes_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Cria o recordset
        Glb_Pesq = "Select * from Clientes"
        Obj_Gene.Sub_Crec(Ado_Base, Glb_Pesq)

        Sub_Reda()
    End Sub
    Public Sub Sub_Dele() Implements Obj_Func.Sub_Dele
        Dim Ado_Auxi As New ADODB.Recordset
        Dim Res_Resp As MsgBoxResult

        If Bol_Novo = True Then Exit Sub
        If Trim(Txt_Clie.Text) = "" Or Bol_Novo = True Then Exit Sub
        If MsgBox("Deseja realmente excluir o registro?", MsgBoxStyle.Critical + MsgBoxStyle.YesNo, "Excluir registro") = MsgBoxResult.No Then Exit Sub
        'captura a resposta do usuario
        Res_Resp = MsgBox("Você deseja que os recibos deste cliente sejam apagados?" & vbCrLf & "(Se não apagá-los, poderão haver divergencias depois!)", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNoCancel, "Apagar registro")
        Select Case Res_Resp
            Case MsgBoxResult.Yes
                Glb_Pesq = "Delete * from Recibos Where Clie = '" & Obj_Gene.Fun_Nulo(Txt_Clie.Text) & "'"
                Ado_Conn.Execute(Glb_Pesq)
            Case MsgBoxResult.Cancel
                Exit Sub
        End Select
        'Começa a excluir
        Glb_Pesq = "Delete * from Clientes Where Clie = '" & Obj_Gene.Fun_Nulo(Txt_Clie.Text) & "'"
        Ado_Conn.Execute(Glb_Pesq)


        'Restaura os adodb
        Ado_Base.Requery()
        Sub_Reda()
        MsgBox("Registro apagado com sucesso!", MsgBoxStyle.Information, "")


    End Sub

    Public Sub Sub_Impr() Implements Obj_Func.Sub_Impr

    End Sub

    Public Sub Sub_Incl() Implements Obj_Func.Sub_Incl
        Dim Ado_Auxi As New ADODB.Recordset
        ''Reposiciona os dados
        For Each Txt_Campo As Object In GroupBox1.Controls
            If TypeOf (Txt_Campo) Is TextBox Then
                Obj_Gene.Sub_Trav(Txt_Campo, False, "")
            End If
        Next
        Obj_Gene.Sub_Trav(Txt_Clie, True, "")
        Obj_Gene.Sub_Trav(Msk_Nasc, False, "  /  /    ")
        Txt_Nome.Focus()
        'Opções de novo
        Bol_Salv = True
        Bol_Novo = True
    End Sub

    Public Sub Sub_Pesq() Implements Obj_Func.Sub_Pesq
        If Not Ado_Base.EOF Then
            Glb_Codi = ""
            Pesquisa_Gene.ShowDialog()
            If Not Glb_Codi = "" Then
                Ado_Base.Requery()
                Ado_Base.Find("Clie = '" & Glb_Codi & "'")
                Sub_Reda()
            End If
        Else
            MsgBox("Não há registros cadastrados ainda!", MsgBoxStyle.Information)
        End If
    End Sub

    Public Sub Sub_Salv() Implements Obj_Func.Sub_Salv
        Dim Bol_Erro As Boolean
        Dim Ado_Veri, Ado_Auxi As New ADODB.Recordset
        Dim Str_Codi As String
       


        'Verifica se os campos foram preenchidos
        If Obj_Gene.Fun_Erro(Txt_Nome.Text, 1, 1, Txt_Nome) Then Bol_Erro = True
        If Obj_Gene.Fun_Erro(Txt_Tele.Text, 1, 1, Txt_Tele) Then Bol_Erro = True
        If Obj_Gene.Fun_Erro(Msk_Nasc.Text, 1, 2, Msk_Nasc) Then Bol_Erro = True
        If Bol_Erro = True Then GoTo Err_Desc

        'Salva os registros

        If Bol_Novo = True Then
            Glb_Pesq = "Select * from Clientes"
            Obj_Gene.Sub_Crec(Ado_Auxi, Glb_Pesq)
            If Ado_Auxi.EOF Then
                Str_Codi = "0000001"
            Else
                Ado_Auxi.MoveLast()
                Str_Codi = Format$((CDbl(Obj_Gene.Fun_Nulo(Ado_Auxi("Clie").Value)) + 1), "0000000")
            End If
            Ado_Auxi.AddNew()
            Ado_Auxi("Clie").Value = Str_Codi
            Ado_Auxi.Update()
            Ado_Base.Requery()
            Ado_Base.Find("Clie = '" & Str_Codi & "'")
            Txt_Clie.Text = Obj_Gene.Fun_Nulo(Ado_Base("Clie").Value)
        End If
        Ado_Base("Nome").Value = Obj_Gene.Fun_Nulo(Txt_Nome.Text)
        Ado_Base("Tele").Value = Obj_Gene.Fun_Nulo(Txt_Tele.Text)
        Ado_Base("Ende").Value = Obj_Gene.Fun_Nulo(Txt_Ende.Text)
        Ado_Base("Bair").Value = Obj_Gene.Fun_Nulo(Txt_Bair.Text)
        Ado_Base("Nume").Value = Obj_Gene.Fun_Nulo(Txt_Nume.Text)
        Ado_Base("Cida").Value = Obj_Gene.Fun_Nulo(Txt_Cida.Text)
        Ado_Base("Dcrg").Value = Obj_Gene.Fun_Nulo(Txt_Dcrg.Text)
        Ado_Base("Dcpf").Value = Obj_Gene.Fun_Nulo(Txt_Dcpf.Text)
        Ado_Base("Esta").Value = Obj_Gene.Fun_Nulo(Txt_Esta.Text)
        Ado_Base("Obsv").Value = Obj_Gene.Fun_Nulo(Txt_Obsv.Text)
        If Not Trim(Msk_Nasc.Text) = "/  /" Then Ado_Base("Nasc").Value = Obj_Gene.Fun_Nulo(Msk_Nasc.Text)
        Ado_Base("Cepe").Value = Obj_Gene.Fun_Nulo(Txt_Cepe.Text)
        Ado_Base("Canc").Value = Chk_Canc.Checked
        Ado_Base("Fale").Value = Chk_Fale.Checked
        Ado_Base("Mudo").Value = Chk_Mudo.Checked

        Ado_Base.Update()
        Ado_Base.Requery()
        Ado_Base.Find("Clie = '" & Obj_Gene.Fun_Nulo(Txt_Clie.Text) & "'")
        Sub_Reda()

        'Fecha o registro
        Bol_Novo = False
        Bol_Salv = False
        MsgBox("Registro salvo com sucesso!", MsgBoxStyle.OkOnly + MsgBoxStyle.OkOnly, "Sucesso")
Err_Desc:
    End Sub
    Sub Sub_Prox() Implements Obj_Func.Sub_Prox
        Sub_Vsal()
        If Not Ado_Base.EOF Then
            Ado_Base.MoveNext()
            If Ado_Base.EOF Then
                Ado_Base.Requery()
                Ado_Base.MoveLast()
            End If
        End If
        Sub_Reda()
    End Sub
    Sub Sub_Ante() Implements Obj_Func.Sub_Ante
        Sub_Vsal()
        If Not Ado_Base.BOF Then
            Ado_Base.MovePrevious()
            If Ado_Base.BOF Then
                Ado_Base.Requery()
                Ado_Base.MoveFirst()
            End If
        End If
        Sub_Reda()
    End Sub
    Sub Sub_Vsal()
        If Bol_Salv Then
            If MsgBox("Deseja Salvar?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, Me.Text) = MsgBoxResult.Yes Then
                Sub_Salv()
            Else
                Bol_Salv = False
                Bol_Novo = False
            End If
        End If
    End Sub
    Public Sub Sub_Reda()
        Dim Ado_Auxi As New ADODB.Recordset
        Dim Int_Data As Integer = 0
        Dim Lst_Data As New List(Of Date)

        If Not Ado_Base.EOF Then
            Obj_Gene.Sub_Trav(Txt_Clie, True, Obj_Gene.Fun_Zero(Obj_Gene.Fun_Nulo(Ado_Base("Clie").Value), 7))
            Obj_Gene.Sub_Trav(Txt_Nome, False, Obj_Gene.Fun_Nulo(Ado_Base("Nome").Value))
            Obj_Gene.Sub_Trav(Txt_Bair, False, Obj_Gene.Fun_Nulo(Ado_Base("Bair").Value))
            Obj_Gene.Sub_Trav(Txt_Cida, False, Obj_Gene.Fun_Nulo(Ado_Base("Cida").Value))
            Obj_Gene.Sub_Trav(Txt_Ende, False, Obj_Gene.Fun_Nulo(Ado_Base("Ende").Value))
            Obj_Gene.Sub_Trav(Txt_Esta, False, Obj_Gene.Fun_Nulo(Ado_Base("Esta").Value))
            Obj_Gene.Sub_Trav(Txt_Nume, False, Obj_Gene.Fun_Nulo(Ado_Base("Nume").Value))
            Obj_Gene.Sub_Trav(Txt_Obsv, False, Obj_Gene.Fun_Nulo(Ado_Base("Obsv").Value))
            Obj_Gene.Sub_Trav(Txt_Tele, False, Obj_Gene.Fun_Nulo(Ado_Base("Tele").Value))
            Obj_Gene.Sub_Trav(Msk_Nasc, False, Obj_Gene.Fun_Nulo(Ado_Base("Nasc").Value))
            Obj_Gene.Sub_Trav(Txt_Cepe, False, Obj_Gene.Fun_Nulo(Ado_Base("Cepe").Value))
            Obj_Gene.Sub_Trav(Txt_Dcpf, False, Obj_Gene.Fun_Nulo(Ado_Base("Dcpf").Value))
            Obj_Gene.Sub_Trav(Txt_Dcrg, False, Obj_Gene.Fun_Nulo(Ado_Base("Dcrg").Value))
            ''Cancelado e etc
            If Obj_Gene.Fun_Nulo(Ado_Base("Canc").Value) = True Then
                Chk_Canc.Checked = True
            Else
                Chk_Canc.Checked = False
            End If
            If Obj_Gene.Fun_Nulo(Ado_Base("Mudo").Value) = True Then
                Chk_Mudo.Checked = True
            Else
                Chk_Mudo.Checked = False
            End If
            If Obj_Gene.Fun_Nulo(Ado_Base("Fale").Value) = True Then
                Chk_Fale.Checked = True
            Else
                Chk_Fale.Checked = False
            End If
        Else
            'Reposiciona os dados
            Obj_Gene.Sub_Trav(Txt_Clie, True, "")
            Obj_Gene.Sub_Trav(Txt_Nome, True, "")
            Obj_Gene.Sub_Trav(Txt_Bair, True, "")
            Obj_Gene.Sub_Trav(Txt_Cida, True, "")
            Obj_Gene.Sub_Trav(Txt_Ende, True, "")
            Obj_Gene.Sub_Trav(Txt_Esta, True, "")
            Obj_Gene.Sub_Trav(Txt_Nume, True, "")
            Obj_Gene.Sub_Trav(Txt_Obsv, True, "")
            Obj_Gene.Sub_Trav(Txt_Tele, True, "")
            Obj_Gene.Sub_Trav(Msk_Nasc, True, "")
            Obj_Gene.Sub_Trav(Txt_Cepe, True, "")
            Obj_Gene.Sub_Trav(Txt_Dcrg, True, "")
            Obj_Gene.Sub_Trav(Txt_Dcpf, True, "")
            Chk_Canc.Enabled = False
            Chk_Fale.Enabled = False
            Chk_Mudo.Enabled = False
        End If
    End Sub


    Public Sub Sub_Prim() Implements Obj_Func.Sub_Prim
        Sub_Vsal()
        If Not Ado_Base.EOF Then
            Ado_Base.Requery()
            Ado_Base.MoveFirst()
            Sub_Reda()
        End If
    End Sub

    Public Sub Sub_Ulti() Implements Obj_Func.Sub_Ulti
        Sub_Vsal()
        If Not Ado_Base.EOF Then
            Ado_Base.Requery()
            Ado_Base.MoveLast()
            Sub_Reda()
        End If
    End Sub

    Private Sub Txt_Cepe_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_Cepe.Leave

        If Not Obj_Gene.Fun_Nulo(Txt_Ende.Text) = "" Then Exit Sub
        If Not Obj_Gene.Fun_Nulo(Txt_Cida.Text) = "" Then Exit Sub
        If Not Obj_Gene.Fun_Nulo(Txt_Bair.Text) = "" Then Exit Sub
        If Not Obj_Gene.Fun_Nulo(Txt_Esta.Text) = "" Then Exit Sub

        If Obj_Gene.Fun_Inte("http://cep.republicavirtual.com.br/") Then
            Try
                Dim ds As New DataSet()
                Dim xml As String = "http://cep.republicavirtual.com.br/web_cep.php?cep=@cep&formato=xml".Replace("@cep", Txt_Cepe.Text)
                ds.ReadXml(xml)
                Txt_Ende.Text = ds.Tables(0).Rows(0)("logradouro").ToString()
                Txt_Bair.Text = ds.Tables(0).Rows(0)("bairro").ToString()
                Txt_Cida.Text = ds.Tables(0).Rows(0)("cidade").ToString()
                Txt_Esta.Text = ds.Tables(0).Rows(0)("uf").ToString()
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Erro")
            End Try
        End If

    End Sub

    'Private Sub TextBox1_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox1.LostFocus

    '    'If Obj_Gene.Fun_Inte("http://cep.republicavirtual.com.br/") Then
    '    '    Try
    '    '        Dim ds As New DataSet()
    '    '        Dim xml As String = "http://cep.republicavirtual.com.br/web_cep.php?cep=@cep&formato=xml".Replace("@cep", TextBox1.Text)
    '    '        ds.ReadXml(xml)
    '    '        Txt_Ende.Text = ds.Tables(0).Rows(0)("logradouro").ToString()
    '    '        Txt_Bair.Text = ds.Tables(0).Rows(0)("bairro").ToString()
    '    '        Txt_Cida.Text = ds.Tables(0).Rows(0)("cidade").ToString()
    '    '        Txt_Esta.Text = ds.Tables(0).Rows(0)("uf").ToString()
    '    '    Catch ex As Exception
    '    '        MessageBox.Show(ex.Message, "Erro")
    '    '    End Try
    '    'End If

    'End Sub

    Private Sub Txt_Cepe_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt_Cepe.TextChanged

    End Sub
End Class
