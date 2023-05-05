Imports System.Text
Imports System.Security.Cryptography
''' <summary> 
''' Encriptação simples usando TripleDES 
''' (Triple Data Encryption Standard) 
''' </summary> 
Public Class Crypto
    Private Shared TripleDES As New TripleDESCryptoServiceProvider
    Private Shared MD5 As New MD5CryptoServiceProvider
    ' Definição da chave de encriptação/desencriptação 
    Private Const key As String = "2mteybbh"
    ''' <summary> 
    ''' Calcula o MD5 Hash  
    ''' </summary> 
    ''' <param name="value">Chave</param> 
    Public Shared Function MD5Hash(ByVal value As String) As Byte()
        ' Converte a chave para um array de bytes  
        Dim byteArray() As Byte = ASCIIEncoding.ASCII.GetBytes(value)
        Return MD5.ComputeHash(byteArray)
    End Function
    ''' <summary> 
    ''' Encripta uma string com base em uma chave 
    ''' </summary> 
    ''' <param name="stringToEncrypt">String a encriptar</param> 
    Public Shared Function Encrypt(ByVal stringToEncrypt As String) As String
        Try
            ' Definição da chave e da cifra (que neste caso é Electronic 
            ' Codebook, ou seja, encriptação individual para cada bloco) 
            TripleDES.Key = Crypto.MD5Hash(key)
            TripleDES.Mode = CipherMode.ECB
            ' Converte a string para bytes e encripta 
            Dim Buffer As Byte() = ASCIIEncoding.ASCII.GetBytes(stringToEncrypt)
            Return Convert.ToBase64String(TripleDES.CreateEncryptor().TransformFinalBlock(Buffer, 0, Buffer.Length))
        Catch ex As Exception
            MessageBox.Show(ex.Message, My.Application.Info.Title, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return String.Empty
        End Try
    End Function

    ''' <summary> 
    ''' Desencripta uma string com base em uma chave 
    ''' </summary> 
    ''' <param name="encryptedString">String a decriptar</param> 
    Public Shared Function Decrypt(ByVal encryptedString As String) As String
        Try
            ' Definição da chave e da cifra 
            TripleDES.Key = Crypto.MD5Hash(key)
            TripleDES.Mode = CipherMode.ECB
            ' Converte a string encriptada para bytes e decripta 
            Dim Buffer As Byte() = Convert.FromBase64String(encryptedString)
            Return ASCIIEncoding.ASCII.GetString(TripleDES.CreateDecryptor().TransformFinalBlock(Buffer, 0, Buffer.Length))
        Catch ex As Exception
            MessageBox.Show(ex.Message, My.Application.Info.Title, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return String.Empty
        End Try
    End Function
End Class