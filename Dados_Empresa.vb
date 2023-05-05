Public Class Dados_Empresa
    Implements Obj_Func
    Public Ado_Base As ADODB.Recordset
    Public Bol_Salv As Boolean, Bol_Novo As Boolean


    Private Sub Dados_Empresa_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        Obj_Gene.Sub_Menu("NSNNNNN", "NSNNNNN", False)
    End Sub

    Private Sub Dados_Empresa_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Obj_Gene.Sub_Menu("NNNNNNN", "NNNNNNN")
        'Obj_Gene.Sub_Fech()
        Menus.Men_Empr.Enabled = True
    End Sub

    Private Sub Dados_Empresa_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If Bol_Salv Then Sub_Vsal()
    End Sub

    Private Sub Cadastro_Clientes_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Cria o recordset
        Glb_Pesq = "Select * from Dados_Empresa"
        Obj_Gene.Sub_Crec(Ado_Base, Glb_Pesq)

        Sub_Reda()
    End Sub
    Public Sub Sub_Dele() Implements Obj_Func.Sub_Dele

    End Sub

    Public Sub Sub_Impr() Implements Obj_Func.Sub_Impr

    End Sub

    Public Sub Sub_Incl() Implements Obj_Func.Sub_Incl
        
    End Sub

    Public Sub Sub_Pesq() Implements Obj_Func.Sub_Pesq
        
    End Sub

    Public Sub Sub_Salv() Implements Obj_Func.Sub_Salv
        Dim Bol_Erro As Boolean
        Dim Ado_Veri, Ado_Auxi As New ADODB.Recordset
        Dim Str_Codi As String



        'Verifica se os campos foram preenchidos
        If Obj_Gene.Fun_Erro(Txt_Nome.Text, 1, 1, Txt_Nome) Then Bol_Erro = True
        If Obj_Gene.Fun_Erro(Txt_Tele.Text, 1, 1, Txt_Tele) Then Bol_Erro = True
        'If Obj_Gene.Fun_Erro(Msk_Nasc.Text, 2, 2, Msk_Nasc) Then Bol_Erro = True
        If Bol_Erro = True Then GoTo Err_Desc

        'Salva os registros
        If Ado_Base.EOF Then Ado_Base.AddNew()
        Ado_Base("Nome").Value = Obj_Gene.Fun_Nulo(Txt_Nome.Text)
        Ado_Base("Tele").Value = Obj_Gene.Fun_Nulo(Txt_Tele.Text)
        Ado_Base("Ende").Value = Obj_Gene.Fun_Nulo(Txt_Ende.Text)
        Ado_Base("Bair").Value = Obj_Gene.Fun_Nulo(Txt_Bair.Text)
        Ado_Base("Nume").Value = Obj_Gene.Fun_Nulo(Txt_Nume.Text)
        Ado_Base("Cida").Value = Obj_Gene.Fun_Nulo(Txt_Cida.Text)
        ' Ado_Base("Docu").Value = Obj_Gene.Fun_Nulo(Txt_Dcrg.Text)
        Ado_Base("Docu").Value = Obj_Gene.Fun_Nulo(Txt_Dcpf.Text)
        Ado_Base("Esta").Value = Obj_Gene.Fun_Nulo(Txt_Esta.Text)
        ' Ado_Base("Obsv").Value = Obj_Gene.Fun_Nulo(Txt_Obsv.Text)
        ' Ado_Base("Nasc").Value = Obj_Gene.Fun_Nulo(Msk_Nasc.Text)
        Ado_Base("Cepe").Value = Obj_Gene.Fun_Nulo(Txt_Cepe.Text)
        'Ado_Base("Canc").Value = Chk_Canc.Checked
        'Ado_Base("Fale").Value = Chk_Fale.Checked
        'Ado_Base("Mudo").Value = Chk_Mudo.Checked

        Ado_Base.Update()
        Ado_Base.Requery()
        'Ado_Base.Find("Clie = '" & Obj_Gene.Fun_Nulo(Txt_Clie.Text) & "'")
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
            ' Obj_Gene.Sub_Trav(Txt_Clie, True, Obj_Gene.Fun_Nulo(Ado_Base("Clie").Value))
            Obj_Gene.Sub_Trav(Txt_Nome, False, Obj_Gene.Fun_Nulo(Ado_Base("Nome").Value))
            Obj_Gene.Sub_Trav(Txt_Bair, False, Obj_Gene.Fun_Nulo(Ado_Base("Bair").Value))
            Obj_Gene.Sub_Trav(Txt_Cida, False, Obj_Gene.Fun_Nulo(Ado_Base("Cida").Value))
            Obj_Gene.Sub_Trav(Txt_Ende, False, Obj_Gene.Fun_Nulo(Ado_Base("Ende").Value))
            Obj_Gene.Sub_Trav(Txt_Esta, False, Obj_Gene.Fun_Nulo(Ado_Base("Esta").Value))
            Obj_Gene.Sub_Trav(Txt_Nume, False, Obj_Gene.Fun_Nulo(Ado_Base("Nume").Value))
            'Obj_Gene.Sub_Trav(Txt_Obsv, False, Obj_Gene.Fun_Nulo(Ado_Base("Obsv").Value))
            Obj_Gene.Sub_Trav(Txt_Tele, False, Obj_Gene.Fun_Nulo(Ado_Base("Tele").Value))
            'Obj_Gene.Sub_Trav(Msk_Nasc, False, Obj_Gene.Fun_Dsql(Ado_Base("Nasc").Value))
            Obj_Gene.Sub_Trav(Txt_Cepe, False, Obj_Gene.Fun_Nulo(Ado_Base("Cepe").Value))
            Obj_Gene.Sub_Trav(Txt_Dcpf, False, Obj_Gene.Fun_Nulo(Ado_Base("Docu").Value))
            'Obj_Gene.Sub_Trav(Txt_Dcrg, False, Obj_Gene.Fun_Nulo(Ado_Base("Dcrg").Value))
            Lbl_Regi.Text = Obj_Gene.Fun_Nulo(Ado_Base("Dcad").Value)
            ''Cancelado e etc

        Else
            'Reposiciona os dados
            'Obj_Gene.Sub_Trav(Txt_Clie, True, "")
            Obj_Gene.Sub_Trav(Txt_Nome, False, "")
            Obj_Gene.Sub_Trav(Txt_Bair, False, "")
            Obj_Gene.Sub_Trav(Txt_Cida, False, "")
            Obj_Gene.Sub_Trav(Txt_Ende, False, "")
            Obj_Gene.Sub_Trav(Txt_Esta, False, "")
            Obj_Gene.Sub_Trav(Txt_Nume, False, "")
            'Obj_Gene.Sub_Trav(Txt_Obsv, True, "")
            Obj_Gene.Sub_Trav(Txt_Tele, False, "")
            'Obj_Gene.Sub_Trav(Msk_Nasc, True, "")
            Obj_Gene.Sub_Trav(Txt_Cepe, False, "")
            'Obj_Gene.Sub_Trav(Txt_Dcrg, True, "")
            Obj_Gene.Sub_Trav(Txt_Dcpf, False, "")
            'Chk_Canc.Enabled = False
            'Chk_Fale.Enabled = False
            'Chk_Mudo.Enabled = False
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

End Class