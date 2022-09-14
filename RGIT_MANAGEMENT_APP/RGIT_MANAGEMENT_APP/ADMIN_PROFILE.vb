Imports System.Data.Sql
Imports System.Data.SqlClient
Public Class ADMIN_PROFILE
    Private mycon As SqlConnection
    Private mycmd As SqlCommand
    Private myreader As SqlDataReader
    Private cmd As String

    Public Function edit_profile()
        mycon = New SqlConnection("Data Source = .\SQLEXPRESS;Initial Catalog = RGIT_DB;Integrated Security = SSPI")
        mycon.Open()
        cmd = "UPDATE ADMINSTRATORS SET FIRSTNAME = @F_NAME,LASTNAME = @L_NAME,PASSWORDS =@PASS,SECURITY_QUESTION = @SQ ,KEYWORD = @KEY WHERE FIRSTNAME = @Fname AND LASTNAME = @Lname"
        Using mycmd As New SqlCommand(cmd, mycon)
            mycmd.Parameters.AddWithValue("@F_NAME", TextBox1.Text.ToUpper())
            mycmd.Parameters.AddWithValue("@L_NAME", TextBox2.Text.ToUpper())
            mycmd.Parameters.AddWithValue("@PASS", TextBox3.Text)
            mycmd.Parameters.AddWithValue("@SQ", RichTextBox1.Text.ToUpper())
            mycmd.Parameters.AddWithValue("@KEY", TextBox4.Text.ToUpper())
            mycmd.Parameters.AddWithValue("@Fname", Label7.Text.ToUpper())
            mycmd.Parameters.AddWithValue("@Lname", Label8.Text.ToUpper())
            mycmd.ExecuteNonQuery()


        End Using
        mycon.Close()
        Label7.Text = TextBox1.Text
        Label8.Text = TextBox2.Text
        Return MsgBox("SUCCESSFULLY EDITED PROFILE")
    End Function
    Public Function retreive_profile()
        mycon = New SqlConnection("Data Source = .\SQLEXPRESS;Initial Catalog = RGIT_DB;Integrated Security = SSPI")
        mycon.Open()
        'RETREIVE NAME
        cmd = "SELECT FIRSTNAME FROM ADMINSTRATORS WHERE FIRSTNAME = @F_NAME AND LASTNAME = @L_NAME"
        Using mycmd As New SqlCommand(cmd, mycon)
            mycmd.Parameters.AddWithValue("F_NAME", Label7.Text.ToUpper())
            mycmd.Parameters.AddWithValue("L_NAME", Label8.Text.ToUpper())
            mycmd.ExecuteNonQuery()
            myreader = mycmd.ExecuteReader()
            If myreader.Read() Then
                TextBox1.Text = myreader(0)
                myreader.Close()
            End If
        End Using
        'RETREIVE SURNAME
        cmd = "SELECT LASTNAME FROM ADMINSTRATORS WHERE FIRSTNAME = @F_NAME AND LASTNAME = @L_NAME"
        Using mycmd As New SqlCommand(cmd, mycon)
            mycmd.Parameters.AddWithValue("F_NAME", Label7.Text.ToUpper())
            mycmd.Parameters.AddWithValue("L_NAME", Label8.Text.ToUpper())
            mycmd.ExecuteNonQuery()
            myreader = mycmd.ExecuteReader()
            If myreader.Read() Then
                TextBox2.Text = myreader(0)
                myreader.Close()
            End If
        End Using
        'RETREIVE PASSWORD
        cmd = "SELECT PASSWORDS FROM ADMINSTRATORS WHERE FIRSTNAME = @F_NAME AND LASTNAME = @L_NAME"
        Using mycmd As New SqlCommand(cmd, mycon)
            mycmd.Parameters.AddWithValue("F_NAME", Label7.Text.ToUpper())
            mycmd.Parameters.AddWithValue("L_NAME", Label8.Text.ToUpper())
            mycmd.ExecuteNonQuery()
            myreader = mycmd.ExecuteReader()
            If myreader.Read() Then
                TextBox3.Text = myreader(0)
                myreader.Close()
            End If
        End Using
        'RETREIVE SECURITY_QUESTION
        cmd = "SELECT SECURITY_QUESTION FROM ADMINSTRATORS WHERE FIRSTNAME = @F_NAME AND LASTNAME = @L_NAME"
        Using mycmd As New SqlCommand(cmd, mycon)
            mycmd.Parameters.AddWithValue("F_NAME", Label7.Text.ToUpper())
            mycmd.Parameters.AddWithValue("L_NAME", Label8.Text.ToUpper())
            mycmd.ExecuteNonQuery()
            myreader = mycmd.ExecuteReader()
            If myreader.Read() Then
                RichTextBox1.Text = myreader(0)
                myreader.Close()
            End If
        End Using
        'RETREIVE KEYWORD
        cmd = "SELECT KEYWORD FROM ADMINSTRATORS WHERE FIRSTNAME = @F_NAME AND LASTNAME = @L_NAME"
        Using mycmd As New SqlCommand(cmd, mycon)
            mycmd.Parameters.AddWithValue("F_NAME", Label7.Text.ToUpper())
            mycmd.Parameters.AddWithValue("L_NAME", Label8.Text.ToUpper())
            mycmd.ExecuteNonQuery()
            myreader = mycmd.ExecuteReader()
            If myreader.Read() Then
                TextBox4.Text = myreader(0)
                myreader.Close()
            End If

        End Using
    End Function
    Public Function reset()
        TextBox1.Clear()
        TextBox2.Clear()
        TextBox3.Clear()
        TextBox4.Clear()
        RichTextBox1.Clear()
        retreive_profile()
        Label7.Text = TextBox1.Text
        Label8.Text = TextBox2.Text
    End Function
    Private Sub ADMIN_PROFILE_Load(sender As Object, e As EventArgs) Handles MyBase.Load
   
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        edit_profile()
    End Sub

    Private Sub Panel2_Paint(sender As Object, e As PaintEventArgs) Handles Panel2.Paint

    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs)

    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Application.Exit()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        reset()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Me.reset()
        Me.Hide()
        ADMIN_MENU.Show()
    End Sub
End Class