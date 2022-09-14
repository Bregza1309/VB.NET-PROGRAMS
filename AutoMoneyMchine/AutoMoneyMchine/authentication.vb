Imports System.Data.SqlClient
Imports System.Security.Cryptography
Imports System.IO
Imports System.Data.Sql
Public Class authentication
    Private enc As System.Text.UTF8Encoding
    Private encryptor As ICryptoTransform
    Private decryptor As ICryptoTransform
    Private myConn As SqlConnection
    Private myCmd As SqlCommand
    Dim cmd As String
    Private myReader As SqlDataReader
    Dim results As String



    Dim account As String
    Dim pin As String
    Dim balance As String
    Public Function decrypt(ciphertext As String)
        Dim cypherbytes As Byte() = Convert.FromBase64String(ciphertext)
        Dim plaintext As String
        Dim ms As MemoryStream = New MemoryStream(cypherbytes)
        Dim cs As CryptoStream = New CryptoStream(ms, Me.decryptor, CryptoStreamMode.Read)
        Dim plaintextbytes(cypherbytes.Length) As Byte
        Dim decryptedbytecount As Integer = cs.Read(plaintextbytes, 0, plaintextbytes.Length)
        ms.Close()
        cs.Close()
        plaintext = Me.enc.GetString(plaintextbytes, 0, decryptedbytecount)
        Return plaintext
    End Function
    Public Function encrypt(ByVal plaintext As String)
        Dim ciphertext As String
        If Not String.IsNullOrEmpty(plaintext) Then
            Dim ms As MemoryStream = New MemoryStream()
            Dim cs As CryptoStream
            cs = New CryptoStream(ms, encryptor, CryptoStreamMode.Write)
            cs.Write(Me.enc.GetBytes(plaintext), 0, plaintext.Length)
            cs.FlushFinalBlock()
            ciphertext = Convert.ToBase64String(ms.ToArray())

            ms.Close()
            cs.Close()

        End If

        Return ciphertext
    End Function

    Public Function retreive(cmd As String)
        'function to retreive data from database
        myConn = New SqlConnection("Data Source=.\SQLEXPRESS;Initial Catalog=GMZ_DB;Integrated Security=True")
        myConn.Open()
        account = TextBox1.Text
        account = encrypt(account)
        Using myCmd As New SqlCommand(cmd, myConn)
            myCmd.Parameters.AddWithValue("@ID", account)

            myCmd.ExecuteNonQuery()
            myReader = myCmd.ExecuteReader()
            If myReader.Read() Then
                results = myReader.GetValue(0)
            End If
            myReader.Close()


        End Using
        myConn.Close()
        Return results


    End Function

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try

            pin = TextBox2.Text

            Dim res_acc_enc As String
            Dim name As String
            Dim surname As String
            Dim password_enc As String
            Dim res_acc As String
            Dim password As String


            




            'retreveing account numbers
            cmd = "SELECT ACCOUNT_ID FROM ACCOUNTS WHERE ACCOUNT_ID = @ID"
            res_acc_enc = retreive(cmd)
            res_acc = decrypt(res_acc_enc)

            'retreive account_holder_name
            cmd = "SELECT FIRSTNAME FROM ACCOUNTS WHERE ACCOUNT_ID =@ID "
            name = retreive(cmd)
            name = decrypt(name)

            'retreive surname
            cmd = "SELECT LASTNAME FROM ACCOUNTS WHERE ACCOUNT_ID = @ID"
            surname = retreive(cmd)
            surname = decrypt(surname)
            'retreive balance
            cmd = "SELECT BALANCE FROM ACCOUNTS WHERE ACCOUNT_ID = @ID"
            balance = retreive(cmd)
            balance = decrypt(balance)
            'retreive password
            cmd = "SELECT PASSWORDS FROM ACCOUNTS WHERE ACCOUNT_ID = @ID"
            password_enc = retreive(cmd)
            password = decrypt(password_enc)



            If TextBox1.Text = res_acc And TextBox2.Text = password Then
                If password = "0" Then
                    PASSWORDS.Label5.Text = name & " " & surname
                    MsgBox("PLEASE UPDATE YOUR PASSWORD")
                    Me.Hide()
                    PASSWORDS.Show()
                Else


                    home.Label1.Text = name & " " & surname
                    home.Label6.Text = "R" & balance
                    home.Label7.Text = res_acc
                    Label3.ForeColor = Color.Green
                    Label2.ForeColor = Color.Green
                    MsgBox("AUTHENTIFICATION SUCCESSFUL")

                    Me.Hide()
                    home.Show()
                End If

            Else

                MsgBox("WRONG LOGIN DETAILS TRY AGAIN")
                Label3.ForeColor = Color.Red
                Label2.ForeColor = Color.Red


            End If

        Catch ex As Exception
            MsgBox("INPUT YOUR LOGIN DETAILS CORRECTLY")
        End Try







    End Sub

    Private Sub authentication_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim key_128 As Byte() = {42, 1, 52, 67, 231, 13, 94, 101, 123, 6, 0, 12, 32, 91, 4, 111, 31, 70, 21, 144, 123, 142, 234, 82, 95, 129, 187, 162, 12, 55, 98, 23}
        Dim iv_128 As Byte() = {234, 12, 52, 44, 214, 222, 200, 109, 2, 98, 45, 76, 88, 23, 23, 78}
        Dim symetricKey As RijndaelManaged = New RijndaelManaged()
        symetricKey.Mode = CipherMode.CBC
        Me.enc = New System.Text.UTF8Encoding
        Me.encryptor = symetricKey.CreateEncryptor(key_128, iv_128)
        Me.decryptor = symetricKey.CreateDecryptor(key_128, iv_128)
    End Sub
End Class