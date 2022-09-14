Imports System.Data.Sql
Imports System.Data.SqlClient
Public Class FORGOT_PASSWORD
    Private mycon As SqlConnection
    Private mycmd As SqlCommand
    Private myreader As SqlDataReader
    Private cmd As String

    Public Function retreive_security_info()
    
            mycon = New SqlConnection("Data Source = .\SQLEXPRESS;Initial Catalog = RGIT_DB;Integrated Security = SSPI")
            mycon.Open()

            If AUTHENTICATION.RadioButton2.Checked Then
                cmd = "SELECT SECURITY_QUESTION FROM ADMINSTRATORS WHERE FIRSTNAME = @F_NAME AND LASTNAME = @L_NAME"
                Using mycmd As New SqlCommand(cmd, mycon)
                    mycmd.Parameters.AddWithValue("@F_NAME", AUTHENTICATION.TextBox1.Text.ToUpper())
                    mycmd.Parameters.AddWithValue("@L_NAME", AUTHENTICATION.TextBox2.Text.ToUpper())
                    mycmd.ExecuteNonQuery()
                    myreader = mycmd.ExecuteReader()
                    If myreader.Read() Then
                        Label3.Text = myreader(0)
                    End If
                End Using
            Else
                cmd = "SELECT SECURITY_QUESTION FROM USERS WHERE FIRSTNAME = @F_NAME AND LASTNAME = @L_NAME"
                Using mycmd As New SqlCommand(cmd, mycon)
                    mycmd.Parameters.AddWithValue("@F_NAME", AUTHENTICATION.TextBox1.Text.ToUpper())
                    mycmd.Parameters.AddWithValue("@L_NAME", AUTHENTICATION.TextBox2.Text.ToUpper())
                    mycmd.ExecuteNonQuery()
                    myreader = mycmd.ExecuteReader()
                    If myreader.Read() Then
                        Label3.Text = myreader(0)
                    End If
                End Using
            End If
            mycon.Close()
            Return MsgBox("ANSWER THE SECURITY QUESTION CORRECTLY TO RESET PASSWORD !-_-!")

     
    End Function
    Public Function validate_keyword()
        mycon = New SqlConnection("Data Source = .\SQLEXPRESS;Initial Catalog = RGIT_DB;Integrated Security = SSPI")
        mycon.Open()
        If AUTHENTICATION.RadioButton2.Checked Then
            cmd = "SELECT KEYWORD FROM ADMINSTRATORS WHERE FIRSTNAME = @F_NAME AND LASTNAME = @L_NAME"
            Using mycmd As New SqlCommand(cmd, mycon)
                mycmd.Parameters.AddWithValue("@F_NAME", AUTHENTICATION.TextBox1.Text.ToUpper())
                mycmd.Parameters.AddWithValue("@L_NAME", AUTHENTICATION.TextBox2.Text.ToUpper())
                mycmd.ExecuteNonQuery()
                myreader = mycmd.ExecuteReader()
                If myreader.Read() Then
                    If TextBox1.Text.ToUpper() = myreader(0) Then
                        MsgBox("YOU WILL NOW BE REDIRECTED TO YOUR PROFILE PAGE!")
                        ADMIN_PROFILE.retreive_profile()
                        Me.Hide()
                        ADMIN_PROFILE.Show()
                    Else
                        MsgBox("WRONG ANSWER TRY AGAIN")
                    End If
                End If
            End Using
        Else
            cmd = "SELECT KEYWORD FROM USERS WHERE FIRSTNAME = @F_NAME AND LASTNAME = @L_NAME"
            Using mycmd As New SqlCommand(cmd, mycon)
                mycmd.Parameters.AddWithValue("@F_NAME", AUTHENTICATION.TextBox1.Text.ToUpper())
                mycmd.Parameters.AddWithValue("@L_NAME", AUTHENTICATION.TextBox2.Text.ToUpper())
                mycmd.ExecuteNonQuery()
                myreader = mycmd.ExecuteReader()
                If myreader.Read() Then
                    If TextBox1.Text.ToUpper() = myreader(0) Then
                        MsgBox("YOU WILL NOW BE REDIRECTED TO YOUR PROFILE PAGE!")

                        Try
                            user_profile.retreive_profile()
                        Catch ex As Exception
                            user_profile.Show()
                        End Try
                        Me.Hide()
                        user_profile.Show()
                    Else
                        MsgBox("WRONG ANSWER TRY AGAIN")
                    End If
                End If
            End Using
        End If
        mycon.Close()
    End Function
    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        validate_keyword()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Application.Exit()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Hide()
        AUTHENTICATION.Show()
    End Sub

    Private Sub FORGOT_PASSWORD_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class