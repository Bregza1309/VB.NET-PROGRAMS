Imports System.Data.SqlClient
Imports System.Security.Cryptography
Imports System.IO
Public Class eWallet
    Private enc As System.Text.UTF8Encoding
    Private encryptor As ICryptoTransform
    Private decryptor As ICryptoTransform
    Private myConn As SqlConnection
    Private myConn As SqlConnection
    Private myCmd As SqlCommand
    Dim cmd As String
    Private myReader As SqlDataReader
    Dim results As Integer
    Dim amount, balance, cell As Integer
    Dim msg As String
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
    Public Function update_balance(balance As Integer)
        'function to update balance
        myConn = New SqlConnection("Data Source=.\SQLEXPRESS;Initial Catalog=AMM_DB;Integrated Security=True")
        myConn.Open()
        cmd = "UPDATE ACCOUNTS SET BALANCE = @BALANCE WHERE ACCOUNT_ID = @ID"
        Using myCmd As New SqlCommand(cmd, myConn)
            myCmd.Parameters.AddWithValue("@BALANCE", balance)
            myCmd.Parameters.AddWithValue("@ID", home.Label7.Text)
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


            cell = TextBox1.Text
            amount = TextBox2.Text
            If amount Mod 10 = 0 And amount > 50 And amount < 1500 Then
                If home.Label6.Text >= amount Then
                    balance = home.Label6.Text - amount
                    msg = "YOU HAVE SENT R" & amount & " to 0" & cell
                    home.Label6.Text = "R" & balance
                    Label6.Text = balance
                    update_balance(balance)
                    MsgBox(msg)
                Else
                    MsgBox("YOU HAVE INSUFICIENT FUNDS PLEASE MAKE A DEPOSIT")
                End If




            Else
                MsgBox("AMOUNT SHOULD BE IN MULTIPLES OF 10 AND GREATER THAN R50,BUT LESS THAN R1500")
            End If


        Catch ex As Exception
            MsgBox("ENTER ALL INPUT FIELDS CORRECTLY")
        End Try

    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs)



    End Sub

    Private Sub GroupBox1_Enter(sender As Object, e As EventArgs)

    End Sub

    Private Sub Button11_Click(sender As Object, e As EventArgs)


    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs)


    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs)

    End Sub


    Private Sub Button4_Click(sender As Object, e As EventArgs)





    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs)



    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs)


    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Button12_Click(sender As Object, e As EventArgs)


    End Sub

    Private Sub Button13_Click(sender As Object, e As EventArgs) Handles Button13.Click
        TextBox1.Clear()
        TextBox2.Clear()


    End Sub

    Private Sub eWallet_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Hide()
        home.Show()
    End Sub

    Private Sub GroupBox1_Enter_1(sender As Object, e As EventArgs) Handles GroupBox1.Enter
        Label6.Text = home.Label6.Text
    End Sub
End Class