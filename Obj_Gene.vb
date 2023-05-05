Option Strict Off
Option Explicit On
Imports ADODB

Module Obj_Gene
    Private Declare Function GetSystemMetrics Lib "user32.dll" (ByVal nIndex As Long) As Long

    'Aqui estão todos os objetos e variáveis globais
    'Public Glb_User As String 'Usuário (Sigla)
    Public Obj_Cryp As Crypto
    Public Glb_File As String 'Arquivo SYS
    Public Glb_Pesq As String 'Pesquisa
    Public Ado_Conn As New ADODB.Connection 'conexão
    Public Ole_Conn As New OleDb.OleDbConnection
    Public Ado_Comm As New ADODB.Command
    'Public Sql_Conn As New SqlServerCe.SqlCeConnection
    'Public Frb_Conn As New FirebirdSql.Data.FirebirdClient.FbConnection
    'Public Ado_Base As New ADODB.Recordset
    Public Btn_Name As String
    'Public Glb_Alte As Boolean
    Public Glb_Login As Boolean
    Public Glb_Repo As String 'Report de impresão
    Public Glb_Path As String 'Caminho do banco
    Public Glb_Senh As String = "tdkcob8y" 'Senha do banco
    Public Glb_Usid As String = "admin" 'Usuario global do banco
    Public Glb_Banc As String = "Data.mdb" 'Nome do Banco
    Public Glb_Codi As String 'Código global
    Public Glb_Clie As String 'Código Cliente global
    Public Glb_Date As String 'Data Global
    Public Glb_Capt As String 'Caption global
    'Usuario logado 
    Public Glb_Sigl As String
    Public Glb_Maxm As String
    Public Glb_Gere As Boolean
    Public Glb_Conf As Boolean 'Confirmação de senhas gerenciais
    Public Glb_Usua As String 'Nome  do usuário
    'Dados do micro
    Public Glb_Proj As String 'Caminho da pasta de projetos
    Public Glb_Pext As Boolean 'Se o caminho foi definido
    Public Glb_Seri As String 'serial
    'Subs e afins 
    Public Culture As New System.Globalization.CultureInfo("pt-BR")

    Sub Sub_Crec(ByRef Ado_func As ADODB.Recordset, ByRef Str_Pesq As String, Optional ByRef Opt_GPva As Boolean = True)
        Ado_func = New ADODB.Recordset
        Ado_func.CursorLocation = ADODB.CursorLocationEnum.adUseClientBatch

        If Opt_GPva = True Then
            Ado_func.Open(Str_Pesq, Ado_Conn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
        Else
            Ado_func.Open(Str_Pesq, Ado_Conn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        End If
    End Sub

    Sub Sub_Csql(ByVal Ado_Csql As ADODB.Recordset, ByVal Str_Pesq As String)
        'Preenchimento GRID

        Ado_Csql.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        Ado_Csql.Open(Str_Pesq, Ado_Conn, ADODB.CursorTypeEnum.adOpenUnspecified, ADODB.LockTypeEnum.adLockOptimistic)

    End Sub

    Sub Sub_CBan()
Conecta:
        On Error GoTo Err_Cabr
        Ado_Conn.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Jet OLEDB:Database Password = " & Glb_Senh & ";Data Source = " & Glb_Path & Glb_Banc & ";"
        Ado_Conn.Open()
        Exit Sub

Err_Cabr:
        MsgBox(Err.Description, MsgBoxStyle.Critical, "Erro Fatal")
        End

        Exit Sub
    End Sub

    Sub Sub_Abre(ByVal Bol_Abre As Boolean, ByVal Frm_Chld As Form)

        If Bol_Abre Then
            Frm_Chld.MdiParent = Menus
            Frm_Chld.Show()
            Frm_Chld.StartPosition = FormStartPosition.CenterScreen
        Else
            Frm_Chld.Close()
        End If

    End Sub
    Sub Sub_Fech()
        'Fecha o form e tira todos os botões
        Menus.Cmd_Novo.Enabled = False
        Menus.Cmd_Salv.Enabled = False
        Menus.Cmd_Dele.Enabled = False
        Menus.Cmd_Ante.Enabled = False
        Menus.Cmd_Prox.Enabled = False
        Menus.Cmd_Pesq.Enabled = False
        Menus.Cmd_Prnt.Enabled = False
        Menus.Cmd_Novo.Visible = False
        Menus.Cmd_Salv.Visible = False
        Menus.Cmd_Dele.Visible = False
        Menus.Cmd_Ante.Visible = False
        Menus.Cmd_Prox.Visible = False
        Menus.Cmd_Pesq.Visible = False
        Menus.Cmd_Prnt.Visible = False

    End Sub
    ''' <summary>
    ''' Ativador de botões do menu principal
    ''' </summary>
    ''' <param name="Str_Camp">Acesso máximo de cada tela (1-Novo;2-Salv;3-Pesq,4-Del;5 e 6- - Naveg;7-Prnt)</param>
    ''' <param name="Str_Aces">Acesso permitido ao usuário</param>
    ''' <param name="Bol_Nave">Permitir visualização? </param>
    ''' <remarks></remarks>
    Sub Sub_Menu(ByVal Str_Camp As String, ByVal Str_Aces As String, Optional ByVal Bol_Nave As Boolean = True)
        Dim Ado_Auxi As New ADODB.Recordset
        'Str_Camp é a string com o nome do campo a sr utilizado, ja Str_Aces é usada para indicar as 
        'permissões maximas de cada tela

        ''Cria as strings comportadoras de permissões
        'If Not Str_Camp = "NNNNNNN" Then
        '    Obj_Gene.Sub_Crec(Ado_Auxi, Glb_Pesq, True)
        '    If Not Ado_Auxi.EOF And Glb_Sigl <> "ECT" Then
        '        Str_Camp = Obj_Gene.Fun_Nulo(Ado_Auxi(0).Value)
        '    End If
        'End If
        ''Verifica se é o usuario padrão
        'If Glb_Sigl = "ECT" Then
        '    Str_Camp = "SSSSS"
        'End If

        'Acerta os botões dos menus
        Menus.Cmd_Novo.Enabled = False
        Menus.Cmd_Salv.Enabled = False
        Menus.Cmd_Dele.Enabled = False
        Menus.Cmd_Ante.Enabled = False
        Menus.Cmd_Prox.Enabled = False
        Menus.Cmd_Pesq.Enabled = False
        Menus.Cmd_Prnt.Enabled = False
        Menus.Cmd_Prim.Enabled = False
        Menus.Cmd_Prim.Enabled = False
        Menus.Cmd_Novo.Visible = False
        Menus.Cmd_Salv.Visible = False
        Menus.Cmd_Dele.Visible = False
        Menus.Cmd_Ante.Visible = False
        Menus.Cmd_Prox.Visible = False
        Menus.Cmd_Pesq.Visible = False
        Menus.Cmd_Prnt.Visible = False
        Menus.Cmd_Prim.Visible = False
        Menus.Cmd_Ulti.Visible = False



        'Autoriza os botões
        'Novo
        If Mid$(Str_Camp, 1, 1) = "S" And Mid$(Str_Aces, 1, 1) = "S" Then
            Menus.Cmd_Novo.Enabled = True
            Menus.Cmd_Novo.Visible = True
        End If
        'Salvar
        If Mid$(Str_Camp, 2, 1) = "S" And Mid$(Str_Aces, 2, 1) = "S" Then
            Menus.Cmd_Salv.Enabled = True
            Menus.Cmd_Salv.Visible = True
        End If
        'Pesquisar
        If Mid$(Str_Camp, 3, 1) = "S" And Mid$(Str_Aces, 3, 1) = "S" Then
            Menus.Cmd_Pesq.Enabled = True
            Menus.Cmd_Pesq.Visible = True
        End If
        'apagar
        If Mid$(Str_Camp, 4, 1) = "S" And Mid$(Str_Aces, 4, 1) = "S" Then
            Menus.Cmd_Dele.Enabled = True
            Menus.Cmd_Dele.Visible = True
        End If
        'Imprimir  
        If Mid$(Str_Camp, 7, 1) = "S" And Mid$(Str_Aces, 7, 1) = "S" Then
            Menus.Cmd_Prnt.Enabled = True
            Menus.Cmd_Prnt.Visible = True
        End If
        'Anterior
        If Mid$(Str_Camp, 5, 1) = "S" And Mid$(Str_Aces, 5, 1) = "S" Then
            Menus.Cmd_Prim.Visible = True
            Menus.Cmd_Prim.Enabled = True
            Menus.Cmd_Ante.Enabled = True
            Menus.Cmd_Ante.Visible = True
        End If
        'Proximo
        If Mid$(Str_Camp, 6, 1) = "S" And Mid$(Str_Aces, 6, 1) = "S" Then
            Menus.Cmd_Ulti.Visible = True
            Menus.Cmd_Ulti.Enabled = True
            Menus.Cmd_Prox.Enabled = True
            Menus.Cmd_Prox.Visible = True
        End If

        If (Str_Aces = "NNNNNNN") And (Str_Camp = "NNNNNNN") Then
            Menus.Cmd_Novo.Visible = False
            Menus.Cmd_Salv.Visible = False
            Menus.Cmd_Dele.Visible = False
            Menus.Cmd_Ante.Visible = False
            Menus.Cmd_Prox.Visible = False
            Menus.Cmd_Pesq.Visible = False
            Menus.Cmd_Prnt.Visible = False
            Menus.Cmd_Novo.Enabled = False
            Menus.Cmd_Salv.Enabled = False
            Menus.Cmd_Dele.Enabled = False
            Menus.Cmd_Ante.Enabled = False
            Menus.Cmd_Prox.Enabled = False
            Menus.Cmd_Pesq.Enabled = False
            Menus.Cmd_Prnt.Enabled = False
        End If


    End Sub

    Sub Sub_Stat(ByVal Str_Info As String, ByVal Sta_Item As ToolStripStatusLabel)
        Sta_Item.Text = " -- " & Str_Info
        Sta_Item.ForeColor = Color.Red
        Sta_Item.Text = " -- " & Str_Info
    End Sub

    Sub Sub_Trav(ByVal Obj_Cont As Control, ByVal Bol_Trav As Boolean, ByVal Str_Text As String)
        If Bol_Trav Then
            Obj_Cont.BackColor = Color.AliceBlue
            Obj_Cont.Enabled = False
            Obj_Cont.ForeColor = Color.Red
            Obj_Cont.Text = Str_Text
        Else
            Obj_Cont.BackColor = Color.FromKnownColor(KnownColor.Window)
            Obj_Cont.ForeColor = Color.FromKnownColor(KnownColor.WindowText)
            Obj_Cont.Enabled = True
            Obj_Cont.Text = Str_Text
        End If
    End Sub

    Sub Sub_Kprs(ByVal E As KeyEventArgs)
        If (E.KeyValue = Keys.Enter) Then
            E.SuppressKeyPress = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Sub Sub_Asys()
        Glb_File = Application.StartupPath & "\System\Rsys.sys"
        Dim Obj_Read As New System.IO.StreamReader(Glb_File)
        Glb_Path = Obj_Read.ReadToEnd()
    End Sub

    Function Fun_Nulo(ByVal Str_Nulo) As String
        If IsDBNull(Str_Nulo) Then
            Fun_Nulo = ""
        Else
            Fun_Nulo = Trim$(Str_Nulo)
        End If
    End Function
    ''' <summary>
    ''' Trava e limpa os componentes do form
    ''' </summary>
    ''' <param name="Bol_Trav">True para travar</param>
    ''' <remarks></remarks>
    Sub Sub_Limp(ByVal Bol_Trav As Boolean)

        On Error Resume Next
        For Each txtbox As TextBox In Form.ActiveForm.ActiveMdiChild.Controls
            txtbox.Text = ""
            txtbox.Enabled = Bol_Trav
        Next
        For Each mskbox As MaskedTextBox In Form.ActiveForm.ActiveMdiChild.Controls
            mskbox.Text = mskbox.Mask
            mskbox.Enabled = Bol_Trav
        Next
        For Each listbox As ListBox In Form.ActiveForm.ActiveMdiChild.Controls
            listbox.Items.Clear()
            listbox.Enabled = Bol_Trav
        Next
        For Each combobox As ComboBox In Form.ActiveForm.ActiveMdiChild.Controls
            combobox.SelectedIndex = 0
            combobox.Enabled = Bol_Trav
        Next
    End Sub
    ''' <summary>
    ''' Procedimento de pesquisa
    ''' </summary>
    ''' <param name="Str_Pesq">Pesquisa SQL para a janela, usar campo AS CODI e nome as DSCR</param>
    ''' <param name="Str_Capt">Nome da janela de pesquisa</param>
    ''' <remarks></remarks>
    Sub Sub_Pesq(ByVal Str_Pesq As String, ByVal Str_Capt As String)
        Glb_Pesq = Str_Pesq
        Glb_Capt = Str_Capt
        Glb_Codi = ""
        Pesquisa_Gene.ShowDialog()
    End Sub

    Function Fun_Zero(ByVal Str_Item As String, ByVal Int_Zero As Integer)
        'Preenche com '0' pela quantidade desejada

        If Len(Str_Item) >= Int_Zero Then
            Fun_Zero = Str_Item
            Exit Function
        End If
        Do While Not Len(Str_Item) >= Int_Zero
            Str_Item = "0" & Str_Item
        Loop
        Fun_Zero = Str_Item
    End Function
    ''' <summary>
    ''' Gerador de erros
    ''' </summary>
    ''' <param name="Str_Font">Texto a verificar</param>
    ''' <param name="Str_Leng">Tamanho minimo do campo / Para datas,valor 2 significa não permitir data nula</param>
    ''' <param name="Int_Tipo">1 - Tamanho / 2 - Data /3 - Valor em R$</param>
    ''' <param name="Obj_Cont">Objeto onde será mostrado o erro</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function Fun_Erro(ByVal Str_Font As String, ByVal Str_Leng As String, ByVal Int_Tipo As Integer, ByVal Obj_Cont As Object) As Boolean
        Dim Int_Loop As Integer

        Menus.Err_Prov.SetError(Obj_Cont, "")
        Select Case Int_Tipo
            Case 1
                If Len(Str_Leng) > Len(Str_Font) Then
                    Menus.Err_Prov.SetError(Obj_Cont, "O campo deve ter no mínimo " & Str_Leng & IIf(Str_Leng <= 1, " caracter!", " caracteres!"))
                End If
            Case 2
                If Not Str_Leng = 2 Then If Trim(Str_Font) = "/  /" Then Exit Function
                If Len(Str_Font) < 10 Then GoTo Err_Data
                Str_Font = Obj_Gene.Fun_Form(Str_Font, TipoDado.Data)
                Exit Select
Err_Data:
                Menus.Err_Prov.SetError(Obj_Cont, "Data inválida!")
            Case 3
                For Int_Loop = 1 To Len(Str_Font)
                    If Not IsNumeric(Mid$(Str_Font, Int_Loop, 1)) And Not (Mid$(Str_Font, Int_Loop, 1) = ",") And Not (Mid$(Str_Font, Int_Loop, 1) = ".") Then
                        Menus.Err_Prov.SetError(Obj_Cont, "O valor é invalido!")
                    End If
                Next
                If Str_Font = "" Then Menus.Err_Prov.SetError(Obj_Cont, "O valor é invalido!")
        End Select
        If Not Menus.Err_Prov.GetError(Obj_Cont) = "" Then
            Fun_Erro = True
        Else
            Fun_Erro = False
        End If

    End Function
    ''' <summary>
    ''' Caminho do banco
    ''' </summary>
    ''' <returns>Retorna o caminho do banco de dados</returns>
    ''' <remarks></remarks>
    Function Fun_Banc()
        If FileIO.FileSystem.FileExists(Application.StartupPath & "\Data\" & Glb_Banc) Then
            Fun_Banc = Application.StartupPath & "\Data\" & Glb_Banc
            Exit Function
        End If
        If FileIO.FileSystem.FileExists(Mid$(Application.StartupPath, 1, 3) & "\Gerenciador de vendas\Data\" & Glb_Banc) Then
            Fun_Banc = Mid$(Application.StartupPath, 1, 3) & "\Gerenciador de vendas\Data\" & Glb_Banc
            Exit Function
        End If
        Return ""
        MsgBox("Não foi possível encontrar o banco de dados!", MsgBoxStyle.Critical, "Erro critico")
        End
    End Function
    ''' <summary>
    ''' Impressão geral
    ''' </summary>
    ''' <param name="Str_Nome">Nome do relatório</param>
    ''' <param name="Str_Sele">String de seleção(Filtro)</param>
    ''' <param name="Str_Form">Fórmulas do RPT(Jogar um valor via código)</param>
    ''' <param name="Bol_Dire">Impressão direta ou não</param>
    ''' <remarks></remarks>
    Sub Sub_Prnt(ByVal Str_Nome As String, ByVal Str_Sele As String, ByVal Str_Form As String, Optional ByVal Bol_Dire As Boolean = False) ', ByVal Ado_Crys As ADODB.Recordset)

        Dim LogonInfo As New CrystalDecisions.Shared.TableLogOnInfo
        Dim Table As CrystalDecisions.CrystalReports.Engine.Table
        Dim Crp_Repo As New CrystalDecisions.CrystalReports.Engine.ReportDocument
        Dim Crp_Conn As New CrystalDecisions.Shared.ConnectionInfo

        'limpa o rela

        'Imprime o relatório na pasta
        'Configuração de senha (ALTERAR)
        Crp_Conn.ServerName = Obj_Gene.Fun_Banc
        Crp_Conn.Password = Glb_Senh
        Crp_Conn.UserID = Glb_Usid
        Crp_Conn.DatabaseName = Glb_Banc
        'Configuração do rpt
        Dim Str_Report As String = Application.StartupPath & "\Report\" & Str_Nome & ".rpt"


        Crp_Repo.Load(Str_Report)
        Crp_Repo.Refresh()
        For Each Table In Crp_Repo.Database.Tables
            LogonInfo = Table.LogOnInfo
            LogonInfo.ConnectionInfo = Crp_Conn
            'LogonInfo.ConnectionInfo.UserID = "Admin"
            'LogonInfo.ConnectionInfo.Password = Glb_Senh
            Table.ApplyLogOnInfo(LogonInfo)
        Next Table
        'Define o arquivo de rpt
        With Impressao
            'Define o nome do relatório
            .Crp_Rela.ReportSource = Crp_Repo
            'Coloca a fórmula de seleção
            .Crp_Rela.SelectionFormula = Str_Sele
            .Crp_Rela.RefreshReport()
            'Coloca as fórmulas padrão
        End With
        Crp_Repo.Refresh()

        Crp_Repo.ReportOptions.EnableSaveDataWithReport = False

        'Imprimir direto?
        If Not Bol_Dire Then
            'Obj_Gene.Sub_Abre(True, Impressao)
            Impressao.Show()
        Else
            Impressao.Crp_Rela.PrintReport()
        End If
    End Sub

    Sub Sub_Syst()
        Dim Fso_File As New FileIO.FileSystem
        'Procura o arquivo de sistema
        If Not FileIO.FileSystem.FileExists(Application.StartupPath & "dwaoreg.dll") Then
            MsgBox("O sistema não pode encontrar o banco! Contacte o suporte.")
            End
        End If
    End Sub


    Public Enum TipoDado
        Data
        Numero
        Dinheiro
    End Enum


    Function Fun_Form(ByVal Str_Text As String, ByVal tipo As TipoDado) As String
        Select Case tipo
            Case TipoDado.Data
                Return DateTime.Parse(Str_Text).ToString("dd/MM/yyyy")
            Case TipoDado.Numero
                Return Double.Parse(Str_Text).ToString("N2")
            Case TipoDado.Dinheiro
                Return Decimal.Parse(Str_Text).ToString("#,##0.00")
            Case Else
                Return Str_Text
        End Select
    End Function
    ''' <summary>
    ''' Direção do texto
    ''' </summary>
    ''' <param name="Str_Text">O texto a ser analizado</param>
    ''' <param name="Int_Tama">Tamanho máximo do espaço a ocupar</param>
    ''' <param name="Bol_Dire">Posição dos espaços em branco. True para o texto cair na esquerda e False pra cair na direita</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function Fun_Posi(ByVal Str_Text As String, ByVal Int_Tama As Integer, ByVal Bol_Dire As Boolean)

        'Criada para posicionar o texto na string conforme a posição
        'Prepara a string
        Str_Text = Trim$(Str_Text)
        If Bol_Dire Then
            Do While Not Len(Str_Text) >= Int_Tama
                Str_Text = Str_Text & Space(1)
            Loop
        Else
            Do While Not Len(Str_Text) >= Int_Tama
                Str_Text = Space(1) & Str_Text
            Loop
        End If
        Fun_Posi = Str_Text
    End Function
    ''' <summary>
    ''' Centraliza o texto a analizar
    ''' </summary>
    ''' <param name="Str_Text">O texto para ser analizado</param>
    ''' <param name="Int_Tama">Que tamanho maximo deve ficar o texto para ser centralizado</param>
    ''' <returns>Retorna o texto com espaços em branco dos dois lados</returns>
    ''' <remarks></remarks>
    Function Fun_Cent(ByVal Str_Text As String, ByVal Int_Tama As Integer)
        Dim Bol_Lado As Boolean
        'Criado para centralizar o texto

        Do While Not Len(Str_Text) >= Int_Tama
            If Bol_Lado = True Then
                Str_Text = Str_Text & " "
                Bol_Lado = False
            Else
                Str_Text = " " & Str_Text
                Bol_Lado = True
            End If
        Loop
        Fun_Cent = Str_Text
    End Function
    Function SerialNumber(ByVal Str_Drive As String) As String
        'Pega o serial do micro
        Str_Drive = UCase(Str_Drive)
        SerialNumber = GetSerial(Str_Drive)
    End Function
    Private Function GetSerial(ByVal Str_Drive As String) As String
        Dim diskClass As New System.Management.ManagementClass("Win32_LogicalDisk")
        Dim disks As System.Management.ManagementObjectCollection = diskClass.GetInstances()
        Dim disk As System.Management.ManagementObject
        'Pega o Serial do pc

        For Each disk In disks
            If CStr(disk("Name")) = Trim$(Str_Drive) Then
                Return disk("VolumeSerialNumber").ToString()
            End If
        Next disk

        Return ""

    End Function
    ''' <summary>
    ''' Retorna o valor da posição do primeiro espaço antes da ultima palavra
    ''' </summary>
    '''<param name="Str_Text">Texto a verificar</param>
    ''' <param name="Int_Tota">Tamanho máximo do campo</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function Fun_Spac(ByVal Str_Text As String, ByVal Int_Tota As Integer) As Integer

        If Not Len(Str_Text) <= Int_Tota Then
            Fun_Spac = InStrRev(Mid$(Str_Text, 1, Int_Tota), " ")
        Else
            Fun_Spac = Len(Str_Text)
        End If

    End Function
    ''' <summary>
    ''' Analiza String e retorna somente os numeros
    ''' </summary>
    ''' <param name="Str_Nume">String a analizar</param>
    ''' <returns>Retorna a string com somente os números</returns>
    ''' <remarks></remarks>
    Function Fun_Nume(ByVal Str_Nume As String)
        Dim Int_Loop As Integer

        For Int_Loop = 1 To Len(Str_Nume)
            If Not IsNumeric(Mid$(Str_Nume, Int_Loop, 1)) Then
                Str_Nume = Replace(Str_Nume, Mid$(Str_Nume, Int_Loop, 1), "")
            End If
            If IsNumeric(Str_Nume) Then Exit For
        Next
        Fun_Nume = Str_Nume
    End Function

    ''' <summary>
    ''' Analiza String e retorna somente os numeros
    ''' </summary>
    ''' <param name="Str_Nume">String a analizar</param>
    ''' <returns>Retorna a string com somente os números</returns>
    ''' <remarks></remarks>
    Function Fun_Tele(ByVal Str_Nume As String)
        Dim Int_Loop As Integer

        For Int_Loop = 1 To Len(Str_Nume)
            If Not IsNumeric(Mid$(Str_Nume, Int_Loop, 1)) And Not Mid$(Str_Nume, Int_Loop, 1) = "-" And Not Mid$(Str_Nume, Int_Loop, 1) = "(" And Not Mid$(Str_Nume, Int_Loop, 1) = ")" Then
                Str_Nume = Replace(Str_Nume, Mid$(Str_Nume, Int_Loop, 1), "")
            End If
            If IsNumeric(Str_Nume) Then Exit For
        Next
        Fun_Tele = Str_Nume
    End Function
    ''' <summary>
    ''' Função principal que recolhe o valor e chama as duas funções
    ''' auxiliares para a parte inteira e para a parte decimal
    ''' </summary>
    ''' <param name="number">Número a converter para extenso (Reais)</param>
    ''' 
    Public Function Fun_Exte(ByVal number As Decimal) As String
        Dim cent As Integer
        Try
            ' se for =0 retorna 0 reais
            If number = 0 Then
                Return "Zero Reais"
            End If
            ' Verifica a parte decimal, ou seja, os centavos
            cent = Decimal.Round((number - Int(number)) * 100, MidpointRounding.ToEven)
            ' Verifica apenas a parte inteira
            number = Int(number)
            ' Caso existam centavos
            If cent > 0 Then
                ' Caso seja 1 não coloca "Reais" mas sim "Real"
                If number = 1 Then
                    Return "Um Real e " + getDecimal(cent) + "centavos"
                    ' Caso o valor seja inferior a 1 Real
                ElseIf number = 0 Then
                    Return getDecimal(cent) + "centavos"
                Else
                    Return getInteger(number) + " Reais e " + getDecimal(cent) + "centavos"
                End If
            Else
                ' Caso seja 1 não coloca "Reais" mas sim "Real"
                If number = 1 Then
                    Return "Um Real"
                Else
                    Return getInteger(number) + " Reais"
                End If
            End If
        Catch ex As Exception
            Return ""
        End Try
    End Function
    ''' <summary>
    ''' Função auxiliar - Parte decimal a converter
    ''' </summary>
    ''' <param name="number">Parte decimal a converter</param>
    Public Function getDecimal(ByVal number As Byte) As String
        Try
            Select Case number
                Case 0
                    Return ""
                Case 1 To 19
                    Dim strArray() As String =
                       {"Um", "Dois", "Três", "Quatro", "Cinco", "Seis",
                        "Sete", "Oito", "Nove", "Dez", "Onze",
                        "Doze", "Treze", "Quatorze", "Quinze",
                        "Dezesseis", "Dezessete", "Dezoito", "Dezenove"}
                    Return strArray(number - 1) + " "
                Case 20 To 99
                    Dim strArray() As String =
                        {"Vinte", "Trinta", "Quarenta", "Cinquenta",
                        "Sessenta", "Setenta", "Oitenta", "Noventa"}
                    If (number Mod 10) = 0 Then
                        Return strArray(number \ 10 - 2) + " "
                    Else
                        Return strArray(number \ 10 - 2) + " e " + getDecimal(number Mod 10) + " "
                    End If
                Case Else
                    Return ""
            End Select
        Catch ex As Exception
            Return ""
        End Try
    End Function
    ''' <summary>
    ''' Função auxiliar - Parte inteira a converter
    ''' </summary>
    ''' <param name="number">Parte inteira a converter</param>
    Public Function getInteger(ByVal number As Decimal) As String
        Try
            number = Int(number)
            Select Case number
                Case Is < 0
                    Return "-" & getInteger(-number)
                Case 0
                    Return ""
                Case 1 To 19
                    Dim strArray() As String =
                        {"Um", "Dois", "Três", "Quatro", "Cinco", "Seis",
                        "Sete", "Oito", "Nove", "Dez", "Onze", "Doze",
                        "Treze", "Quatorze", "Quinze", "Dezesseis",
                        "Dezessete", "Dezoito", "Dezenove"}
                    Return strArray(number - 1) + " "
                Case 20 To 99
                    Dim strArray() As String =
                        {"Vinte", "Trinta", "Quarenta", "Cinquenta",
                        "Sessenta", "Setenta", "Oitenta", "Noventa"}
                    If (number Mod 10) = 0 Then
                        Return strArray(number \ 10 - 2)
                    Else
                        Return strArray(number \ 10 - 2) + " e " + getInteger(number Mod 10)
                    End If
                Case 100
                    Return "Cem"
                Case 101 To 999
                    Dim strArray() As String =
                           {"Cento", "Duzentos", "Trezentos", "Quatrocentos", "Quinhentos",
                           "Seiscentos", "Setecentos", "Oitocentos", "Novecentos"}
                    If (number Mod 100) = 0 Then
                        Return strArray(number \ 100 - 1) + " "
                    Else
                        Return strArray(number \ 100 - 1) + " e " + getInteger(number Mod 100)
                    End If
                Case 1000 To 1999
                    Select Case (number Mod 1000)
                        Case 0
                            Return "Mil"
                        Case Is <= 100
                            Return "Mil e " + getInteger(number Mod 1000)
                        Case Else
                            Return "Mil, " + getInteger(number Mod 1000)
                    End Select
                Case 2000 To 999999
                    Select Case (number Mod 1000)
                        Case 0
                            Return getInteger(number \ 1000) & "Mil"
                        Case Is <= 100
                            Return getInteger(number \ 1000) & "Mil e " & getInteger(number Mod 1000)
                        Case Else
                            Return getInteger(number \ 1000) & "Mil, " & getInteger(number Mod 1000)
                    End Select
                Case 1000000 To 1999999
                    Select Case (number Mod 1000000)
                        Case 0
                            Return "Um Milhão"
                        Case Is <= 100
                            Return getInteger(number \ 1000000) + "Milhão e " & getInteger(number Mod 1000000)
                        Case Else
                            Return getInteger(number \ 1000000) + "Milhão, " & getInteger(number Mod 1000000)
                    End Select
                Case 2000000 To 999999999
                    Select Case (number Mod 1000000)
                        Case 0
                            Return getInteger(number \ 1000000) + " Milhões"
                        Case Is <= 100
                            Return getInteger(number \ 1000000) + "Milhões e " & getInteger(number Mod 1000000)
                        Case Else
                            Return getInteger(number \ 1000000) + "Milhões, " & getInteger(number Mod 1000000)
                    End Select
                Case 1000000000 To 1999999999
                    Select Case (number Mod 1000000000)
                        Case 0
                            Return "Um Bilhão"
                        Case Is <= 100
                            Return getInteger(number \ 1000000000) + "Bilhão e " + getInteger(number Mod 1000000000)
                        Case Else
                            Return getInteger(number \ 1000000000) + "Bilhão, " + getInteger(number Mod 1000000000)
                    End Select
                Case Else
                    Select Case (number Mod 1000000000)
                        Case 0
                            Return getInteger(number \ 1000000000) + " Bilhões"
                        Case Is <= 100
                            Return getInteger(number \ 1000000000) + "Bilhões e " + getInteger(number Mod 1000000000)
                        Case Else
                            Return getInteger(number \ 1000000000) + "Bilhões, " + getInteger(number Mod 1000000000)
                    End Select
            End Select
        Catch ex As Exception
            Return ""
        End Try
    End Function
    ''' <summary>
    ''' Cria um registro com o horário de entrada e saída 
    ''' </summary>
    ''' <param name="Str_Moti">Motivo da saída se estiver saindo do sistema</param>
    ''' <param name="Bol_Opti">True se estiver logando, False para logoff</param>
    ''' <remarks></remarks>
    Sub Sub_Hace(ByVal Str_Moti As String, ByVal Bol_Opti As Boolean)
        Dim Ado_Auxi As New ADODB.Recordset

        Glb_Pesq = "Select * from Hora_Acesso where Sigl = '" & Glb_Sigl & "' and Data = Cdate('" & DateAndTime.DateString & "') and isnull(Said) and Seri = '" & Glb_Seri & "'"
        Obj_Gene.Sub_Crec(Ado_Auxi, Glb_Pesq)

        If Bol_Opti = False And Not Ado_Auxi.EOF Then
            Ado_Auxi("Said").Value = DateAndTime.TimeString
            Ado_Auxi("Moti").Value = Str_Moti
            Ado_Auxi.Update()
        Else
            Ado_Auxi.AddNew()
            Ado_Auxi("Sigl").Value = Glb_Sigl
            Ado_Auxi("Entr").Value = DateAndTime.TimeString
            Ado_Auxi("Seri").Value = Glb_Seri
            Ado_Auxi("Data").Value = Obj_Gene.Fun_Form(DateAndTime.DateString, "dd/MM/yyyy")
            Ado_Auxi.Update()
        End If
    End Sub

    Public Sub Sub_Tags(ByVal Obj_Mose)

    End Sub
    ''' <summary>
    ''' Faz o número de 1 a 12 virar o mês correspondente por extenso
    ''' </summary>
    ''' <param name="Str_Mont">Mês em numeros de 1 a 12</param>
    ''' <returns>Nome do mês por extenso</returns>
    ''' <remarks></remarks>
    Public Function Fun_Dext(ByVal Str_Mont As String)
        Select Case Str_Mont
            Case 1
                Return "Janeiro"
            Case 2
                Return "Fevereiro"
            Case 3
                Return "Março"
            Case 4
                Return "Abril"
            Case 5
                Return "Maio"
            Case 6
                Return "Junho"
            Case 7
                Return "Julho"
            Case 8
                Return "Agosto"
            Case 9
                Return "Setembro"
            Case 10
                Return "Outubro"
            Case 11
                Return "Novembro"
            Case 12
                Return "Dezembro"
        End Select
    End Function
    ''' <summary>
    ''' Verifica se a data é válida
    ''' </summary>
    ''' <param name="Str_Date">Data a ser verificada</param>
    ''' <remarks></remarks>
    Public Function Fun_Date(ByVal Str_Date As String)
        'On Error GoTo Err_Date
        'Formato
        If Trim(Str_Date) = "/  /" Or Trim(Str_Date) = "__/__/____" Then GoTo Err_Date
        Str_Date = Obj_Gene.Fun_Form(Str_Date, "##/##/####")
        On Error GoTo Err_Date
        Str_Date = CDate(Str_Date)
        On Error GoTo 0
        Fun_Date = True
        Exit Function
Err_Date:

        Fun_Date = False
    End Function
    ''' <summary>
    ''' função usada para descobrir qual é o dia máximo que um mês pode ter
    ''' </summary>
    ''' <param name="Int_Data">Mês a ser verificado o ultimo dia</param>
    ''' <param name="Int_Anoh">Ano corrente do mês a verificar</param>
    ''' <returns>Retorna o ultimo dia possivel para o mês verificado </returns>
    ''' <remarks></remarks>
    Public Function Fun_Dmes(ByVal Int_Data As Integer, ByVal Int_Anoh As Integer)
        'Pega os meses e joga o dia
        Select Case Int_Data
            Case 1, 3, 5, 7, 8, 10, 12
                Return 31
            Case 2
                'vê se tem o dia 29 de fevereiro
                If Obj_Gene.Fun_Date("29/02/" & Int_Anoh) = False Then
                    Return 28
                Else
                    Return 29
                End If
            Case 4, 6, 9, 11
                Return 30
        End Select

    End Function
    Public Function Fun_Regi() As Boolean
        Dim Str_Valu As String
        On Error GoTo Final
        'Abre a chave do sistema
        Str_Valu = My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\WOW6432Node\ECT", Application.ProductName, "Nada")

        Str_Valu = Crypto.Decrypt(Glb_Seri)
        If Str_Valu = "" Or Str_Valu = "Nada" Then GoTo Final

        Str_Valu = Crypto.Decrypt(Str_Valu)

        If Str_Valu = Crypto.Decrypt(Glb_Seri) Then
            Return True
            Exit Function
        End If
Final:
        Return False
    End Function
    ''' <summary>
    ''' Retorna o serial da máquina
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Fun_Seri() As String
        'Retorna o seril da maquina
        Return Crypto.Encrypt(Obj_Gene.SerialNumber(Mid$(My.Computer.FileSystem.Drives(0).ToString, 1, 2)))

    End Function
    ''' <summary>
    ''' Pesquisa se há conexão com a internet
    ''' </summary>
    ''' <param name="url">Site a ser conferido</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Fun_Inte(ByVal url As String) As Boolean
        'Define uma URL valida para consultar
        Dim HomePage As New System.Uri(url)
        'Monta a requisisão HTTP
        Dim req As System.Net.WebRequest

        req = System.Net.WebRequest.Create(HomePage)

        'Tenta fazer a requisisão
        Try
            Dim resp As System.Net.WebResponse
            resp = req.GetResponse()
            resp.Close()
            req = Nothing
            'Tudo certo... Temos conexão com a Internet
            Return True
        Catch

            req = Nothing

            'Não há conexão
            Return False

        End Try
    End Function

    'Sub Sub_Fire(ByVal Str_Pesq As String)
    '    Dim Frb_Cobu As New FirebirdSql.Data.FirebirdClient.FbCommand(Str_Pesq, Frb_Conn)
    '    Dim Frb_Read As FirebirdSql.Data.FirebirdClient.FbDataReader

    '    Frb_Read = Frb_Cobu.ExecuteReader
    'End Sub

    Sub Sub_SetAll()
        'Application.CurrentCulture = Culture
        'Glb_Banc = Crypto.Decrypt(FileIO.FileSystem.ReadAllText(FileIO.FileSystem.CurrentDirectory & "\mscore.dll"))
    End Sub
    Function Fun_Dsql(ByVal Str_Date As Object)
        Dim Dat_Date As Date
        Dim Str_Resu As String
        Dat_Date = Obj_Gene.Fun_Nulo(Str_Date)

        Str_Resu = Obj_Gene.Fun_Form(Dat_Date.Day, "00") & Obj_Gene.Fun_Form(Dat_Date.Month, "00") & Obj_Gene.Fun_Form(Dat_Date.Year, "0000")
        Return Str_Resu
    End Function
    Function Fun_Libe()
        Dim Str_Regi As String
        Dim Str_Chav As String

        Str_Regi = Mid(Application.StartupPath, 1, 2)
        Str_Regi = Obj_Gene.GetSerial(Str_Regi)

        Str_Chav = Replace(Date.Now.Date, "/", "") & Obj_Gene.Fun_Form(Date.Now.TimeOfDay.Hours, "00") & Obj_Gene.Fun_Form(Date.Now.TimeOfDay.Minutes, "00") & Str_Regi
        For Count As Integer = 0 To 5
            Str_Chav = StrReverse(Str_Chav)
            Str_Chav = Crypto.Encrypt(Str_Chav)
        Next
        
        Return Str_Chav

    End Function
End Module