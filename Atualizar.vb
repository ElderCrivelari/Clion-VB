Public Class Atualizar

    Private Sub Atualizar_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim Thr_Back As System.Threading.Thread

        'Cria o thread do teste de internet
        CheckForIllegalCrossThreadCalls = False '-----------------> Isso aqui serve pra evitar que o thread ilegal aconteça!
        Thr_Back = New System.Threading.Thread(AddressOf Sub_Atua) 'Identifica qual será o procedimento a executar em segundoplano
        Thr_Back.IsBackground = True 'Diz que ele será executado em segundo plano
        Thr_Back.Start() 'dispara o incio do thread
        'Verifica se tem o arquivo de versão


    End Sub
    Sub Sub_Atua()
        Dim Web_Atua As New System.Net.WebClient
        Dim Bol_Atua As Boolean

        Web_Atua.DownloadFile("https://www.dropbox.com/s/6w70e69ns9w3itd/Introdu%C3%A7%C3%A3o.pdf", "intro.pdf")
    End Sub
End Class