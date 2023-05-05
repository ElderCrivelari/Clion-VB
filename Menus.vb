Imports System.Threading

Public Class Menus
    Private Thr_Back As Thread = Nothing
    Dim Bol_Thrd As Boolean
    Dim Str_Thrd As String
    Private Declare Sub Sleep Lib "kernel32" Alias "Sleep" (ByVal dwMilliseconds As Long)
    Private Sub SobreToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SobreToolStripMenuItem.Click
        Obj_Gene.Sub_Abre(True, Sobre)
    End Sub

    Private Sub Menus_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Dim Bol_Fech As Boolean

        If Not Bol_Fech Then
            'Obj_Gene.Sub_Hace("O sistema foi encerrado pelo usuário", False)
            Bol_Fech = True
        End If
    End Sub

    Private Sub Menus_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim Ado_Auxi As New ADODB.Recordset
        Dim Fol_Diag As New FolderBrowserDialog
        Dim Dst_Teste As New DataSet
        Dim Str_Chav As String


        

        'Pega o serial da maquina
        If Not Obj_Gene.SerialNumber(Mid$(My.Computer.FileSystem.Drives(0).ToString, 1, 2)) = "" Then
            Glb_Seri = Crypto.Encrypt(Obj_Gene.SerialNumber(Mid$(My.Computer.FileSystem.Drives(0).ToString, 1, 2)))
        End If
        If Obj_Gene.Fun_Nulo(Glb_Seri) = "" Then
            MsgBox("Erro critico de sistema! Não foi possivel localizar o número de série da máquina. Por favor contacte o suporte.", MsgBoxStyle.Critical, "Erro fatal")
            End
        End If


        'Testa se existe o banco no caminho da pasta
        If FileIO.FileSystem.FileExists(Application.StartupPath & "\Data\" & Glb_Banc) = True Then
            Glb_Path = Application.StartupPath & "\Data\"
        Else
            If FileIO.FileSystem.FileExists(Application.StartupPath & "\Server.dll") = True Then
                Glb_Path = FileIO.FileSystem.ReadAllText(Application.StartupPath & "\Server.dll")
            Else
                MsgBox("Não foi possível encontrar o banco de dados. Favor reinstalar o aplicativo!.", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Erro crítico")
                End
            End If
            ' MsgBox("Não foi possível encontrar o banco de dados. Favor reinstalar o aplicativo!.", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Erro crítico")
            ' End
        End If

        
        'Conecta o banco
        Obj_Gene.Sub_CBan()

Lic_Veri:
        'Procura a dll de registro
        If FileIO.FileSystem.FileExists(Application.StartupPath & "\adodb29.dll") Then
            'Tira a encriptação da chave
            Str_Chav = FileIO.FileSystem.ReadAllText(Application.StartupPath & "\adodb29.dll")
            For int_loop As Integer = 0 To 1
                Str_Chav = StrReverse(Str_Chav)
                Str_Chav = Crypto.Decrypt(Str_Chav)
            Next

            Str_Chav = Mid(Str_Chav, 1, Len(Crypto.Decrypt(Glb_Seri)))

            If Not Str_Chav = Crypto.Decrypt(Glb_Seri) Then
                'MsgBox(Crypto.Decrypt(Glb_Seri))
                MsgBox("Problema ao validar licensa, por favor contacte o suporte!", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Erro fatal")
                On Error Resume Next
                FileIO.FileSystem.DeleteFile(Application.StartupPath & "\adodb29.dll")
                End
            End If
        Else
            Licensa.ShowDialog()
            GoTo Lic_Veri
        End If


Err_Next:

        'Arruma os botões
        Obj_Gene.Sub_Stat(Me.Text, Sta_Bar1) 'Serve para colocar o nome bonitinho na status bar
        For Each Botao As ToolStripButton In Tsp_Btns.Items
            Tsp_Btns.Items(Botao.Name).Enabled = False
            Tsp_Btns.Items(Botao.Name).Visible = False
        Next
        Men_Fech.Enabled = False

        'Cria o thread do teste de internet
        CheckForIllegalCrossThreadCalls = False '-----------------> Isso aqui serve pra evitar que o thread ilegal aconteça!
        Thr_Back = New Thread(AddressOf ThreadTask) 'Identifica qual será o procedimento a executar em segundoplano
        Thr_Back.IsBackground = True 'Diz que ele será executado em segundo plano
        Thr_Back.Start() 'dispara o incio do thread
        'só para liberação do cadastro de clientes
        'Men_Reci.Enabled = False
        'Men_Reci.Visible = False
    End Sub


    Private Sub ArquivoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ArquivoToolStripMenuItem.Click
        On Error GoTo Err_Fech
        Men_Fech.Enabled = ActiveMdiChild.Enabled
        Exit Sub
Err_Fech:
        Men_Fech.Enabled = False
    End Sub

    Private Sub SairToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SairToolStripMenuItem.Click
        End
    End Sub

    Private Sub Men_Fech_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Men_Fech.Click
        On Error Resume Next
        Obj_Gene.Sub_Abre(False, ActiveMdiChild)
        Obj_Gene.Sub_Fech()
        Men_Fech.Enabled = ActiveMdiChild.Enabled
    End Sub


    Private Sub Cmd_Novo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Novo.Click
        Dim activeForm = TryCast(ActiveMdiChild, Obj_Func)

        If activeForm IsNot Nothing Then
            activeForm.Sub_Incl()
        End If
    End Sub

    Private Sub Cmd_Salv_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Salv.Click
        Dim activeForm = TryCast(ActiveMdiChild, Obj_Func)

        If activeForm IsNot Nothing Then
            activeForm.Sub_Salv()
        End If
    End Sub


    Private Sub Cmd_Prox_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Cmd_Prox.Click
        Dim activeForm = TryCast(ActiveMdiChild, Obj_Func)

        If activeForm IsNot Nothing Then
            activeForm.Sub_Prox()
        End If
    End Sub

    Private Sub Cmd_Ante_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Cmd_Ante.Click
        Dim activeForm = TryCast(ActiveMdiChild, Obj_Func)

        If activeForm IsNot Nothing Then
            activeForm.Sub_Ante()
        End If
    End Sub

    Private Sub Cmd_Dele_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Cmd_Dele.Click
        Dim activeForm = TryCast(ActiveMdiChild, Obj_Func)

        If activeForm IsNot Nothing Then
            activeForm.Sub_Dele()
        End If
    End Sub

    Private Sub Cmd_Prnt_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Cmd_Prnt.Click
        Dim activeForm = TryCast(ActiveMdiChild, Obj_Func)

        If activeForm IsNot Nothing Then
            activeForm.Sub_Impr()
        End If
    End Sub

    'Private Sub MudarFundoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Dim Ado_Auxi As New ADODB.Recordset
    '    Dim Str_Path As String

    '    'Muda o fundo de tela
    '    Glb_Pesq = "Select * from Dados_Visual where Seri = '" & Glb_Seri & "'"
    '    Obj_Gene.Sub_Crec(Ado_Auxi, Glb_Pesq)

    '    Opn_File.FileName = ""
    '    Opn_File.Filter = "Todas as imagens suportadas|*.jpg;*.bmp;*.jpeg;*.png;"
    '    Opn_File.Title = "Abrir imagem..."
    '    If Opn_File.ShowDialog() = Windows.Forms.DialogResult.OK Then
    '        If Trim$(Opn_File.FileName) = "" Then Exit Sub
    '        Str_Path = Opn_File.FileName
    '        If Not FileIO.FileSystem.FileExists(Str_Path) Then
    '            MsgBox("Arquivo inexistente!", MsgBoxStyle.Information, Me.Text)
    '            Exit Sub
    '        End If

    '        If Ado_Auxi.EOF Then
    '            Ado_Auxi.AddNew()
    '        End If
    '        FileIO.FileSystem.CopyFile(Str_Path, Application.StartupPath & "\Image\" & Glb_Seri & ".Jpg", True)
    '        Str_Path = Application.StartupPath & "\Image\" & Glb_Seri & ".Jpg"
    '        Ado_Auxi("Imag").Value = Str_Path
    '        Ado_Auxi("Seri").Value = Glb_Seri
    '        Ado_Auxi.Update()

    '        Me.BackgroundImage = Image.FromFile(Ado_Auxi(0).Value)
    '        Me.Refresh()


    '        MsgBox("Imagem alterada com êxito!", MsgBoxStyle.Information, Me.Text)
    '    End If
    'End Sub


    'Private Sub RemoverFundoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Dim Ado_Auxi As New ADODB.Recordset
    '    Dim Str_File As String

    '    If Me.BackgroundImage Is Nothing Then Exit Sub

    '    Me.BackgroundImage = Nothing
    '    Me.Refresh()

    '    'Apaga a imagem de fundo da pasta

    '    Str_File = Application.StartupPath & "\Image\" & Glb_Seri & ".Jpg"

    '    If FileIO.FileSystem.FileExists(Str_File) Then FileIO.FileSystem.DeleteFile(Str_File)

    '    'remove o fundo de tela
    '    Glb_Pesq = "Delete * from Dados_Visual where Seri = '" & Glb_Seri & "'"
    '    Ado_Conn.Execute(Glb_Pesq)



    '    MsgBox("Imagem removida com êxito!", MsgBoxStyle.Information, Me.Text)
    'End Sub

    Private Sub Cmd_Pesq_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Pesq.Click
        Dim activeForm = TryCast(ActiveMdiChild, Obj_Func)

        If activeForm IsNot Nothing Then
            activeForm.Sub_Pesq()
        End If
    End Sub

    Private Sub Menus_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.MouseHover
        Obj_Gene.Sub_Tags(sender)
    End Sub


    Private Sub Cmd_Prim_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Prim.Click
        Dim activeForm = TryCast(ActiveMdiChild, Obj_Func)

        If activeForm IsNot Nothing Then
            activeForm.Sub_Prim()
        End If
    End Sub

    Private Sub Cmd_Ulti_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Ulti.Click
        Dim activeForm = TryCast(ActiveMdiChild, Obj_Func)

        If activeForm IsNot Nothing Then
            activeForm.Sub_Ulti()
        End If
    End Sub

    Private Sub Men_Clie_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Men_Clie.Click
        Men_Clie.Enabled = False
        Obj_Gene.Sub_Abre(True, Cadastro_Projetos)
    End Sub


    Sub ThreadTask()
        'Verifica a conexão com a internet
        Do
            If Obj_Gene.Fun_Inte("http://cep.republicavirtual.com.br/") Then
                Tst_Internet.ForeColor = Color.Green
                Tst_Internet.Text = "Conexão com a internet ativa"
                Tst_Internet.ToolTipText = ""
            Else
                Tst_Internet.ForeColor = Color.Red
                Tst_Internet.Text = "Conexão da internet perdida"
                Tst_Internet.ToolTipText = "Talvez alguns itens não estejam disponíveis, como por exemplo a consulta de CEP."
            End If
            Thread.Sleep(1000)
        Loop
    End Sub

    Private Sub Men_Reci_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Men_Reci.Click
        Men_Reci.Enabled = False
        Obj_Gene.Sub_Abre(True, Recibos)
    End Sub

    Private Sub Men_Empr_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Men_Empr.Click
        Men_Empr.Enabled = False
        Obj_Gene.Sub_Abre(True, Dados_Empresa)
    End Sub

    Private Sub Men_Irec_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Men_Irec.Click
        Men_Irec.Enabled = False
        Obj_Gene.Sub_Abre(True, Impressao_Recibos)
    End Sub

    Private Sub AtualizaçãoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AtualizaçãoToolStripMenuItem.Click
        MsgBox("Serviço ainda não disponível." & vbCrLf & "Favor verificar as atualizações manualmente no site do desenvolvedor", MsgBoxStyle.Information, "Não disponível")
        'Atualizar.ShowDialog()
    End Sub
End Class
