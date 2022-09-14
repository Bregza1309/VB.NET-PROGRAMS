Imports System.Data.SqlClient


Public Class cashier
    Private myconn As SqlConnection
    Private mycmd As SqlCommand
    Private myreader As SqlDataReader
    Dim cmd As String
    Dim results As String
    Dim names As String
    Public Function retreive(cmd)
        myconn = New SqlConnection("Data Source=.\SQLEXPRESS;Initial Catalog=FFO_DB;Integrated Security=True")
        myconn.Open()
        mycmd = New SqlCommand(cmd, myconn)
        Using mycmd
            mycmd.Parameters.AddWithValue("@FIRSTNAME", TextBox1.Text)
            mycmd.Parameters.AddWithValue("@LASTNAME", TextBox2.Text)
            mycmd.ExecuteNonQuery()
            myreader = mycmd.ExecuteReader()
            If myreader.Read() Then
                results = myreader.GetValue(0) & " " & myreader.GetValue(1)
            End If

        End Using
        Return results


    End Function
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click


        Dim cashier As String
        cashier = TextBox1.Text.ToUpper() & " " & TextBox2.Text.ToUpper()
        'retreive name and surname
        cmd = "SELECT FIRSTNAME,LASTNAME FROM CASHIERS WHERE FIRSTNAME = @FIRSTNAME AND LASTNAME = @LASTNAME"
        names = retreive(cmd)
        If names = cashier Then

            Form1.Label5.Text = cashier
            MsgBox("WELCOME BACK " & cashier)
            Me.Hide()
            Form1.Show()

        Else
            MsgBox("NOT YET REGISTERED INFORM YOUR MANAGER!")

        End If

    End Sub

    Private Sub cashier_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class