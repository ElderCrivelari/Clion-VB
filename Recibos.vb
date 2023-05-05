Public Class Recibos

    Implements Obj_Func
    Public Ado_Base As ADODB.Recordset
    Public Ado_Reci As New ADODB.Recordset
    Public Ado_Dset As New Data.DataSet
    Public Bol_Salv As Boolean, Bol_Novo As Boolean
    Public Str_Reci As String
    Private Sub Recibos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Cria o recordset
        Glb_Pesq = "Select * from Clientes"
        Obj_Gene.Sub_Crec(Ado_Base, Glb_Pesq)

        Sub_Reda()
    End Sub
    Private Sub Recibos_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        Obj_Gene.Sub_Menu("NNSNNNS", "NNSNNNS", True)
    End Sub

    Private Sub Recibos_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Obj_Gene.Sub_Menu("NNNNNNN", "NNNNNNN")
        'Obj_Gene.Sub_Fech()
        Menus.Men_Reci.Enabled = True
    End Sub

    Private Sub Recibos_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If Bol_Salv Then Sub_Vsal()
    End Sub

    Public Sub Sub_Dele() Implements Obj_Func.Sub_Dele
        Dim Ado_Auxi As New ADODB.Recordset

        If Bol_Novo = True Then Exit Sub
        If Trim(Txt_Clie.Text) = "" Or Bol_Novo = True Then Exit Sub
        If MsgBox("Deseja realmente excluir o registro?", MsgBoxStyle.Critical + MsgBoxStyle.YesNo, "Excluir registro") = MsgBoxResult.No Then Exit Sub

        'Começa a excluir
        Glb_Pesq = "Delete * from Recibos Where Reci = '" & Obj_Gene.Fun_Nulo(Grd_Reci.SelectedCells.Item(0).Value) & "'"
        Ado_Conn.Execute(Glb_Pesq)

        Glb_Pesq = "Select Reci as Codigo,Dscr as Descricao,Valo as Valor,Data as Vencimento from Recibos Where Clie = '" & Obj_Gene.Fun_Nulo(Txt_Clie.Text) & "'"
        Obj_Gene.Sub_Crec(Ado_Auxi, Glb_Pesq)
        If Not Ado_Auxi.EOF Then
            Grd_Reci.Enabled = True
            Sub_Find(Ado_Auxi)
        Else
            Grd_Reci.Enabled = False
        End If

        MsgBox("Registro apagado com sucesso!", MsgBoxStyle.Information, "")

    End Sub

    Public Sub Sub_Impr() Implements Obj_Func.Sub_Impr
        Dim Ado_Auxi As New ADODB.Recordset
        Dim Ado_Temp As New ADODB.Recordset

        If Grd_Reci.RowCount <= 0 Then Exit Sub
        
        Glb_Pesq = "Select * from Temp_Recibos"
        Obj_Gene.Sub_Crec(Ado_Temp, Glb_Pesq)
        'Apaga o temp 
        Glb_Pesq = "Delete * from Temp_Recibos"
        Ado_Conn.Execute(Glb_Pesq)
        Ado_Temp.Requery()
        Do While True
            If Ado_Temp.EOF Then Exit Do
        Loop
        'Gera a Tabela temporária:
        Glb_Pesq = "Select * from Recibos where Reci = '" & Grd_Reci.SelectedCells.Item(0).Value & "'"
        Obj_Gene.Sub_Crec(Ado_Auxi, Glb_Pesq)
        If Not Ado_Auxi.EOF Then
            Do While Not Ado_Auxi.EOF
                Ado_Temp.AddNew()
                Ado_Temp("Reci").Value = Ado_Auxi("Reci").Value
                Ado_Temp("Dscr").Value = Ado_Auxi("dscr").Value
                Ado_Temp("Valo").Value = Ado_Auxi("valo").Value
                Ado_Temp("Data").Value = Ado_Auxi("Data").Value
                Ado_Temp("Clie").Value = Ado_Auxi("Clie").Value
                Ado_Temp("Exte").Value = Obj_Gene.Fun_Exte(Ado_Auxi("Valo").Value)
                Ado_Temp.Update()
                Ado_Auxi.MoveNext()
            Loop

            Obj_Gene.Sub_Prnt("Rpt_Reci", "", "")
        Else
            MsgBox("Ocoreu um erro ao gerar este recibo! Favor entre em contato com o suporte!", MsgBoxStyle.Critical, "Erro")
            Exit Sub
        End If


    End Sub

    Public Sub Sub_Incl() Implements Obj_Func.Sub_Incl
        Dim Ado_Auxi As New ADODB.Recordset
        
        Obj_Gene.Sub_Trav(Txt_Valo, False, "")
        Obj_Gene.Sub_Trav(Msk_Data, False, "  /  /    ")
        Obj_Gene.Sub_Trav(Txt_Dscr, False, "")
        Grd_Reci.Enabled = False
        Txt_Valo.Focus()
        'Opções de novo
        Bol_Salv = True
        Bol_Novo = True
    End Sub

    Public Sub Sub_Pesq() Implements Obj_Func.Sub_Pesq
        If Bol_Novo Then Exit Sub
        If Not Ado_Base.EOF Then
            Glb_Codi = ""
            Pesquisa_Gene.ShowDialog()
            If Not Glb_Codi = "" Then
                Txt_Clie.Text = Glb_Codi
                Sub_List()
            End If
        Else
            MsgBox("Não há registros cadastrados ainda!", MsgBoxStyle.Information)
        End If
    End Sub

    Public Sub Sub_Salv() Implements Obj_Func.Sub_Salv
        Dim Ado_Auxi As New ADODB.Recordset
        Dim Str_Codi As String

        If Obj_Gene.Fun_Erro(Msk_Data.Text, 2, 2, Msk_Data) Then Exit Sub
        If Obj_Gene.Fun_Erro(Txt_Valo.Text, 1, 3, Txt_Valo) Then Exit Sub
        If Obj_Gene.Fun_Erro(Txt_Dscr.Text, 1, 1, Txt_Dscr) Then Exit Sub
        If Obj_Gene.Fun_Form(Obj_Gene.Fun_Nulo(Txt_Valo.Text), "#,##0.00") = "0,00" Then
            MsgBox("Valor inválido!", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Erro")
            Exit Sub
        End If
        Glb_Pesq = "Select * from Recibos"
        Obj_Gene.Sub_Crec(Ado_Auxi, Glb_Pesq)

        If Bol_Novo = True Then
            If Ado_Auxi.EOF Then
                Str_Codi = "0000001"
            Else
                Ado_Auxi.MoveLast()
                Str_Codi = Format$((CDbl(Obj_Gene.Fun_Nulo(Ado_Auxi("Reci").Value)) + 1), "0000000")
            End If
            Ado_Auxi.AddNew()
            Ado_Auxi("Reci").Value = Str_Codi

            Ado_Auxi.Update()
            Ado_Auxi.Requery()
            Str_Reci = Str_Codi
            'Ado_Auxi.Find("Reci = '" & Str_Codi & "'")
        End If
        Ado_Auxi.Find("Reci = '" & Str_Reci & "'")
        'Ado_Auxi("Valo").Value = Obj_Gene.Fun_Form(Obj_Gene.Fun_Nulo(Txt_Valo.Text), "#.##0,00")
        Ado_Auxi("Valo").Value = Obj_Gene.Fun_Form(Obj_Gene.Fun_Nulo(Txt_Valo.Text), "#,##0.00")
        Ado_Auxi("Data").Value = Obj_Gene.Fun_Nulo(Msk_Data.Text)
        Ado_Auxi("Dscr").Value = Obj_Gene.Fun_Nulo(Txt_Dscr.Text)
        Ado_Auxi("Clie").Value = Obj_Gene.Fun_Nulo(Txt_Clie.Text)


        Ado_Auxi.Update()
        Ado_Auxi.Requery()

        Grd_Reci.Enabled = True


        Glb_Pesq = "Select Reci as Codigo,Dscr as Descricao,Valo as Valor,Data as Vencimento from Recibos Where Clie = '" & Obj_Gene.Fun_Nulo(Txt_Clie.Text) & "'"
        Obj_Gene.Sub_Crec(Ado_Auxi, Glb_Pesq)
        If Not Ado_Auxi.EOF Then Sub_Find(Ado_Auxi)
        Obj_Gene.Sub_Trav(Txt_Valo, True, "")
        Obj_Gene.Sub_Trav(Msk_Data, True, "")
        Obj_Gene.Sub_Trav(Txt_Dscr, True, "")
        Bol_Novo = False
        Bol_Salv = False
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
        For Each Txt_Campo As Object In GroupBox1.Controls
            If TypeOf (Txt_Campo) Is TextBox Then
                Obj_Gene.Sub_Trav(Txt_Campo, True, "")
            End If
        Next
        For Each Txt_Campo As Object In GroupBox2.Controls
            If TypeOf (Txt_Campo) Is TextBox Then
                Obj_Gene.Sub_Trav(Txt_Campo, True, "")
            End If
        Next
        Obj_Gene.Sub_Trav(Msk_Data, True, "  /  /    ")
        Obj_Gene.Sub_Trav(Txt_Clie, False, "")
        Grd_Reci.Enabled = False

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

    Private Sub Grd_Reci_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Grd_Reci.DoubleClick
        Dim Ado_Auxi As ADODB.Recordset
        If Grd_Reci.RowCount < 1 Then Exit Sub
        Glb_Pesq = "Select * from Recibos where Reci ='" & Grd_Reci.SelectedCells.Item(0).Value & "'"
        Obj_Gene.Sub_Crec(Ado_Auxi, Glb_Pesq)
        If Not Ado_Auxi.EOF Then
            Obj_Gene.Sub_Trav(Txt_Valo, False, Obj_Gene.Fun_Form(Obj_Gene.Fun_Nulo(Ado_Auxi("Valo").Value), "#,##0.00"))
            Obj_Gene.Sub_Trav(Txt_Dscr, False, Ado_Auxi("Dscr").Value)
            Obj_Gene.Sub_Trav(Msk_Data, False, Ado_Auxi("Data").Value)
            Str_Reci = Grd_Reci.SelectedCells.Item(0).Value
            Grd_Reci.Enabled = False
        End If

    End Sub

    Sub Sub_Find(ByVal Ado_Grid As ADODB.Recordset) '(ByVal Str_Pesq As String)
        'Dim Ado_Dset As New Data.DataSet
        Dim Ado_Adap As New OleDb.OleDbDataAdapter

        Ado_Dset.Reset()
        'Preenche o adapter
        Ado_Adap.Fill(Ado_Dset, Ado_Grid, "Recibos")
        'Me.Text = "Pesquisa por " & Glb_Capt
        'Preenche o grid 

        Grd_Reci.DataSource = Ado_Dset.Tables("Recibos")
        Grd_Reci.Refresh()

    End Sub


    Private Sub Txt_Clie_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Txt_Clie.KeyUp
        If e.KeyCode = Keys.Enter Then
            Txt_Clie.Text = Obj_Gene.Fun_Zero(Txt_Clie.Text, 7)
            Sub_List()
        End If
    End Sub
    Sub Sub_List()
        Dim Ado_Auxi As ADODB.Recordset
        Dim Str_Oops As String = ""


        Do While Not Grd_Reci.RowCount <= 0
            Grd_Reci.Rows.Remove(Grd_Reci.Rows(0))
        Loop
        Glb_Pesq = "Select * from Clientes Where Clie = '" & Obj_Gene.Fun_Nulo(Txt_Clie.Text) & "'"
        Obj_Gene.Sub_Crec(Ado_Auxi, Glb_Pesq)
        If Not Ado_Auxi.EOF Then
            'Joga os dados na tela
            If Ado_Auxi("Canc").Value = True Then Str_Oops += " Cancelado "
            If Ado_Auxi("Fale").Value = True Then Str_Oops += " Falescido "
            If Ado_Auxi("Mudo").Value = True Then Str_Oops += " Mudou-se "
            If Not Str_Oops = "" Then
                If MsgBox("Opa! este cliente foi marcado como:" & Str_Oops & ". Deseja continuar assim mesmo?", MsgBoxStyle.Information + MsgBoxStyle.YesNo, "Atenção") = MsgBoxResult.No Then
                    Txt_Clie.Text = ""
                    Exit Sub
                End If
            End If
            Txt_Nome.Text = Obj_Gene.Fun_Nulo(Ado_Auxi("Nome").Value)
            Txt_Ende.Text = Obj_Gene.Fun_Nulo(Ado_Auxi("Ende").Value)
            Txt_Nume.Text = Obj_Gene.Fun_Nulo(Ado_Auxi("Nume").Value)
            Txt_Bair.Text = Obj_Gene.Fun_Nulo(Ado_Auxi("Bair").Value)
            Txt_Cida.Text = Obj_Gene.Fun_Nulo(Ado_Auxi("Cida").Value)
            Txt_Esta.Text = Obj_Gene.Fun_Nulo(Ado_Auxi("Esta").Value)
            Txt_Tele.Text = Obj_Gene.Fun_Nulo(Ado_Auxi("Tele").Value)
            Obj_Gene.Sub_Trav(Txt_Valo, True, "0")
            Obj_Gene.Sub_Trav(Txt_Dscr, True, "")
            Obj_Gene.Sub_Trav(Msk_Data, True, "  /  /    ")

            'verifica se há recibos no nome do cliente
            Glb_Pesq = "Select Reci as Codigo,Dscr as Descricao,Valo as Valor,Data as Vencimento from Recibos Where Clie = '" & Obj_Gene.Fun_Nulo(Txt_Clie.Text) & "'"
            Obj_Gene.Sub_Crec(Ado_Auxi, Glb_Pesq)
            If Not Ado_Auxi.EOF Then
                Grd_Reci.Enabled = True
                Sub_Find(Ado_Auxi)
            Else
                Grd_Reci.Enabled = False
            End If

        End If
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Sub_Salv()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Sub_Incl()
    End Sub

    Private Sub Txt_Valo_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_Valo.LostFocus
        Txt_Valo.Text = Obj_Gene.Fun_Form(Txt_Valo.Text, "#,##0.00")
    End Sub

    Private Sub Txt_Valo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt_Valo.TextChanged
        Txt_Valo.Text = Obj_Gene.Fun_Nume(Txt_Valo.Text)
        Txt_Valo.SelectionStart = Len(Txt_Valo.Text)
    End Sub

    Private Sub Grd_Reci_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Grd_Reci.KeyUp
        If e.KeyCode = Keys.Delete Then
            Sub_Dele()
        End If
    End Sub

    Private Sub Msk_Data_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles Msk_Data.Enter
        Msk_Data.SelectAll()
    End Sub

   
End Class


