Imports System.Data.SqlClient
Imports System.Security.Cryptography
Imports System.IO
Public Class deposit


    Private enc As System.Text.UTF8Encoding
    Private encryptor As ICryptoTransform
    Private decryptor As ICryptoTransform
    Private myConn As SqlConnection
    Private myConn As SqlConnection
    Private myCmd As SqlCommand
    Dim cmd As String
    Private myReader As SqlDataReader
    Dim results As Integer
    Dim cash As Integer
    Dim deposit As Integer
    Dim balances As Integer
    Dim initialcash As Integer = home.Label6.Text
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





    Private Sub deposit_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TextBox3.Text = home.Label6.Text


    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try


            Dim a1, a2, a3, a4, a5, a6, a7 As ListViewItem
            deposit = TextBox1.Text
            If deposit Mod 100 = 0 Then
                If deposit < 5000 Then
                    cash = deposit
                    Label3.Text = ("SUCCESSFULLY DEPOSITED R" & deposit & " INTO YOUR ACCOUNT")

                    balances = cash + initialcash
                    TextBox2.Text = balances
                    'update to the database
                    update_balance(balances)
                    home.Label6.Text = "R" & balances

                    withdrawal.TextBox4.Text = balances
                    'print receipt to the listview
                    a1 = ListView1.Items.Add("ACCOUNT-HOLDER :")
                    a1.SubItems.Add(home.Label1.Text)
                    a2 = ListView1.Items.Add("ACCOUNT-NUMBER :")
                    a2.SubItems.Add(home.Label7.Text)
                    a3 = ListView1.Items.Add("OPENING BALANCE :")
                    a3.SubItems.Add(TextBox3.Text)
                    a4 = ListView1.Items.Add("AMOUNT-DEPOSITED  :")
                    a4.SubItems.Add("R" & cash)

                    a5 = ListView1.Items.Add("=====================")
                    a5.SubItems.Add("===============")
                    a6 = ListView1.Items.Add("CLOSING-BALANCE")
                    a6.SubItems.Add("R" & balances)
                    a6 = ListView1.Items.Add("TIME :")
                    a6.SubItems.Add(DateAndTime.Now)
                    a7 = ListView1.Items.Add("===============")
                    a7.SubItems.Add("===============")
                Else
                    Label3.Text = "MAXIMUM DEPOSIT AMOUNT IS R5000"
                End If


            Else
                Label3.Text = "DEPOSIT AMOUNT IN MULTIPLES OF 100"
            End If
        Catch ex As Exception
            MsgBox("PLEASE ENTER DEPOSIT AMOUNT CORRECTLY")
        End Try


    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Me.Close()
        withdrawal.Show()

    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Me.Hide()
        home.Show()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        MsgBox("THANK YOU FOR USING OUR ATM")
        Application.Exit()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        'clear the listview
        Do While ListView1.Items.Count <> 0
            ListView1.Items.Remove(ListView1.Items(0))
            TextBox1.Clear()
            TextBox2.Clear()
            TextBox3.Text = home.Label6.Text
            Label3.Text = "Transaction-Results"


        Loop
    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click

    End Sub

    Private Sub GroupBox2_Enter(sender As Object, e As EventArgs) Handles GroupBox2.Enter

    End Sub
End Class