Imports System.Data.Sql
Imports System.Data.SqlClient
Public Class AUTHENTICATION
    Private mycon As SqlConnection
    Private mycmd As SqlCommand
    Private myreader As SqlDataReader
    Private cmd As String


    Public Function authenticate()
        mycon = New SqlConnection("Data Source = .\SQLEXPRESS;Initial Catalog = RGIT_DB;Integrated Security = SSPI")
        mycon.Open()
        If RadioButton2.Checked Then
            cmd = "SELECT PASSWORDS FROM ADMINSTRATORS WHERE FIRSTNAME = @F_NAME AND LASTNAME = @L_NAME"
            Using mycmd As New SqlCommand(cmd, mycon)
                mycmd.Parameters.AddWithValue("@F_NAME", TextBox1.Text.ToUpper())
                mycmd.Parameters.AddWithValue("@L_NAME", TextBox2.Text.ToUpper())
                mycmd.ExecuteNonQuery()
                myreader = mycmd.ExecuteReader()
                If myreader.Read() Then
                    If TextBox3.Text = myreader(0) Then
                      
                        MsgBox("SUCCESSFULLY LOGGED IN")
                        ADMIN_PROFILE.Label7.Text = TextBox1.Text.ToUpper()
                        ADMIN_PROFILE.Label8.Text = TextBox2.Text.ToUpper()
                        Me.Hide()
                        ADMIN_MENU.Show()
                    Else
                        MsgBox("INCORRECT PASSWORD")
                    End If
                Else
                    MsgBox("WRONG LOGIN DETAILS")
                End If
            End Using
        Else
            cmd = "SELECT PASSWORDS FROM USERS WHERE FIRSTNAME = @F_NAME AND LASTNAME = @L_NAME"
            Using mycmd As New SqlCommand(cmd, mycon)
                mycmd.Parameters.AddWithValue("@F_NAME", TextBox1.Text.ToUpper())
                mycmd.Parameters.AddWithValue("@L_NAME", TextBox2.Text.ToUpper())
                mycmd.ExecuteNonQuery()
                myreader = mycmd.ExecuteReader()
                If myreader.Read() Then
                    If TextBox3.Text = myreader(0) Then
                        If myreader(0) = "employee@123" Then
                            MsgBox("SEEMS LIKE YOU USING DEFAULT_PASSWORD! YOU WILL BE REDIRECTED TO CHANGE PASSWORD")
                            user_profile.Label7.Text = TextBox1.Text.ToUpper()
                            user_profile.Label8.Text = TextBox2.Text.ToUpper()
                            user_profile.retreive_profile()
                            Me.Hide()
                            user_profile.Show()
                        Else
                            MsgBox("SUCCESSFULLY LOGGED IN")
                            user_profile.Label7.Text = TextBox1.Text.ToUpper()
                            user_profile.Label8.Text = TextBox2.Text.ToUpper()
                            Me.Hide()
                            USER_MENU.Show()
                        End If
                       

                    Else
                        MsgBox("INCORRECT PASSWORD")
                    End If
                Else
                    MsgBox("WRONG LOGIN DETAILS")
                End If
            End Using
        End If
        mycon.Close()
    End Function
    Public Function reset()
        TextBox1.Clear()
        TextBox2.Clear()
        TextBox3.Clear()
        RadioButton2.Checked = False

    End Function
    Private Sub Button1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        authenticate()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Application.Exit()
    End Sub

    Private Sub AUTHENTICATION_Load(sender As Object, e As EventArgs) Handles MyBase.Load
   
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click

        If TextBox1.Text = "" And TextBox2.Text = "" Then
            MsgBox("ENTER NAME AND SURNAME TO RESET PASSWORD!")
        Else
            If RadioButton2.Checked Then
                ADMIN_PROFILE.Label7.Text = TextBox1.Text.ToUpper()
                ADMIN_PROFILE.Label8.Text = TextBox2.Text.ToUpper()
            Else
                user_profile.Label7.Text = TextBox1.Text.ToUpper()
                user_profile.Label8.Text = TextBox2.Text.ToUpper()
            End If
            Me.Hide()
            FORGOT_PASSWORD.retreive_security_info()
            FORGOT_PASSWORD.Show()
        End If
     
    End Sub
End Class