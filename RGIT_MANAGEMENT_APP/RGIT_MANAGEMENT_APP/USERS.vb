Imports System.Data.Sql
Imports System.Data.SqlClient

Public Class ADMINSTRATORS
    Private mycon As SqlConnection
    Private myreader As SqlDataReader
    Private mycmd As SqlCommand
    Private myadapter As SqlDataAdapter
    Private cmd As String
    Dim user_id As Integer
    Dim default_password As String = "employee@123"



    Public Function add_user()
        If RichTextBox1.Text = "" And RichTextBox2.Text = "" Then
            If RichTextBox3.Text = "" Then
                MsgBox("fill in missing details")
       
            End If
        Else
            ' CONNECTION STRING TO DATABASE
            mycon = New SqlConnection("Data Source = .\SQLEXPRESS;Initial Catalog=RGIT_DB;Integrated Security=SSPI")
            mycon.Open()


            'UPDATING THE DATABASE USING SQL QUERY 'cmd as string' and mycon and parameters
            cmd = "INSERT INTO USERS VALUES(@ID,@F_NAME,@L_NAME,@password,'','')"
            Using mycmd As New SqlCommand(cmd, mycon)
                mycmd.Parameters.AddWithValue("@ID", RichTextBox3.Text.ToUpper())
                mycmd.Parameters.AddWithValue("@F_NAME", RichTextBox1.Text.ToUpper())
                mycmd.Parameters.AddWithValue("@L_NAME", RichTextBox2.Text.ToUpper())
                mycmd.Parameters.AddWithValue("@password", default_password)

                mycmd.ExecuteNonQuery()



            End Using
            mycon.Close()
            Return (MsgBox("SUCCESSFULLY ADDED USER "))
        End If
       



    End Function
    Public Function edit_user()
        If RichTextBox5.Text = "" And RichTextBox6.Text = "" Then
            MsgBox("SEARCH USER TO EDIT")
        Else
            ' CONNECTION STRING TO DATABASE
            mycon = New SqlConnection("Data Source = .\SQLEXPRESS;Initial Catalog=RGIT_DB;Integrated Security=SSPI")
            mycon.Open()


            'UPDATING THE DATABASE USING SQL QUERY 'cmd as string' and mycon and parameters
            cmd = "UPDATE USERS SET USER_ID = @ID,FIRSTNAME = @F_NAME,LASTNAME = @L_NAME WHERE FIRSTNAME = @Fname AND LASTNAME = @Lname"
            Using mycmd As New SqlCommand(cmd, mycon)
                mycmd.Parameters.AddWithValue("@ID", RichTextBox3.Text.ToUpper())
                mycmd.Parameters.AddWithValue("@F_NAME", RichTextBox1.Text.ToUpper())
                mycmd.Parameters.AddWithValue("@L_NAME", RichTextBox2.Text.ToUpper())
                mycmd.Parameters.AddWithValue("@Fname", RichTextBox5.Text.ToUpper())
                mycmd.Parameters.AddWithValue("@Lname", RichTextBox6.Text.ToUpper())


                mycmd.ExecuteNonQuery()



            End Using
            mycon.Close()
            Return (MsgBox("SUCCESSFULLY UPDATED USER DATABASE"))
        End If
  



    End Function
    Public Function delete_user()
        If RichTextBox5.Text = "" And RichTextBox6.Text = "" Then
            MsgBox("SEARCH USER TO DELETE")
        Else
            ' CONNECTION STRING TO DATABASE
            mycon = New SqlConnection("Data Source = .\SQLEXPRESS;Initial Catalog=RGIT_DB;Integrated Security=SSPI")
            mycon.Open()


            'UPDATING THE DATABASE USING SQL QUERY 'cmd as string' and mycon and parameters
            cmd = "DELETE FROM USERS WHERE FIRSTNAME = @F_NAME AND LASTNAME = @L_NAME"
            Using mycmd As New SqlCommand(cmd, mycon)
                mycmd.Parameters.AddWithValue("@F_NAME", RichTextBox5.Text.ToUpper())
                mycmd.Parameters.AddWithValue("@L_NAME", RichTextBox6.Text.ToUpper())


                mycmd.ExecuteNonQuery()



            End Using
            mycon.Close()
            Return (MsgBox("SUCCESSFULLY DELETED USER "))
        End If


    End Function
    Public Function search_user()
        Try

            If RichTextBox5.Text = "" And RichTextBox6.Text = "" Then
                Return MsgBox("FILL IN USER NAME AND SURNAME")
            Else
                ' CONNECTION STRING TO DATABASE
                mycon = New SqlConnection("Data Source = .\SQLEXPRESS;Initial Catalog=RGIT_DB;Integrated Security=SSPI")
                mycon.Open()


                'UPDATING THE DATABASE USING SQL QUERY 'cmd as string' and mycon and parameters
                cmd = "SELECT FIRSTNAME FROM USERS WHERE FIRSTNAME = @F_NAME AND LASTNAME = @L_NAME"
                Using mycmd As New SqlCommand(cmd, mycon)
                    mycmd.Parameters.AddWithValue("@F_NAME", RichTextBox5.Text.ToUpper())
                    mycmd.Parameters.AddWithValue("@L_NAME", RichTextBox6.Text.ToUpper())
                    mycmd.ExecuteNonQuery()
                    myreader = mycmd.ExecuteReader()
                    If myreader.Read() Then
                        RichTextBox1.Text = myreader(0)
                        myreader.Close()
                    End If


                End Using


                'UPDATING THE DATABASE USING SQL QUERY 'cmd as string' and mycon and parameters
                cmd = "SELECT LASTNAME FROM USERS WHERE FIRSTNAME = @F_NAME AND LASTNAME = @L_NAME"
                Using mycmd As New SqlCommand(cmd, mycon)
                    mycmd.Parameters.AddWithValue("@F_NAME", RichTextBox5.Text.ToUpper())
                    mycmd.Parameters.AddWithValue("@L_NAME", RichTextBox6.Text.ToUpper())
                    mycmd.ExecuteNonQuery()
                    myreader = mycmd.ExecuteReader()
                    If myreader.Read() Then
                        RichTextBox2.Text = myreader(0)
                        myreader.Close()
                    End If


                End Using
                'UPDATING THE DATABASE USING SQL QUERY 'cmd as string' and mycon and parameters
                cmd = "SELECT USER_ID FROM USERS WHERE FIRSTNAME = @F_NAME AND LASTNAME = @L_NAME"
                Using mycmd As New SqlCommand(cmd, mycon)
                    mycmd.Parameters.AddWithValue("@F_NAME", RichTextBox5.Text.ToUpper())
                    mycmd.Parameters.AddWithValue("@L_NAME", RichTextBox6.Text.ToUpper())
                    mycmd.ExecuteNonQuery()
                    myreader = mycmd.ExecuteReader()
                    If myreader.Read() Then
                        RichTextBox3.Text = myreader(0)
                        myreader.Close()
                    End If


                End Using
                mycon.Close()
                Return (MsgBox("SUCCESSFULLY SEARCHED USER "))
            End If
           
        Catch ex As System.InvalidOperationException
            MsgBox("USER NOT FOUND")
        End Try



    End Function
    Public Function reset()
        RichTextBox1.Clear()
        RichTextBox2.Clear()
        RichTextBox3.Clear()

        RichTextBox5.Clear()
        RichTextBox6.Clear()
    End Function


    Private Sub Button6_Click(sender As Object, e As EventArgs)
    

    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs)
       
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Me.Hide()
        reset()
        DISPLAY_USERS.reset()
        DISPLAY_USERS.Show()
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs)
       

    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        delete_user()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        add_user()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        edit_user()
    End Sub

    Private Sub Panel2_Paint(sender As Object, e As PaintEventArgs) Handles Panel2.Paint

    End Sub

    Private Sub Button5_Click_1(sender As Object, e As EventArgs) Handles Button5.Click
        'GENERATE RANDOM USER_ID
        user_id = CInt(Math.Floor((2309999 - 2300000 + 1) * Rnd())) + 2300000
        RichTextBox3.Text = user_id
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        Application.Exit()
    End Sub

    Private Sub Button7_Click_1(sender As Object, e As EventArgs) Handles Button7.Click
        reset()
    End Sub

    Private Sub Button6_Click_1(sender As Object, e As EventArgs) Handles Button6.Click
        search_user()
    End Sub

    Private Sub Button8_Click_1(sender As Object, e As EventArgs) Handles Button8.Click

        Me.Hide()
        ADMIN_MENU.Show()

    End Sub

    Private Sub ADMINSTRATORS_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class
