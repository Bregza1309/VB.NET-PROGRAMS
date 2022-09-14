Imports System.Data.SqlClient
Imports System.Data.Sql
Public Class DISPLAY_USERS
    Private mycon As SqlConnection
    Private mycmd As SqlCommand
    Private myadapter As SqlDataAdapter
    Private ds As DataSet
    Private cmd As String
    Private row As Integer
    Dim msg As String

    'function to list users
    Public Function display_users()
        mycon = New SqlConnection("Data Source = .\SQLEXPRESS;Initial Catalog = RGIT_DB;Integrated Security = SSPI")
        mycon.Open()
        cmd = "SELECT USER_ID,FIRSTNAME,LASTNAME FROM USERS"
        Using mycmd As New SqlCommand(cmd, mycon)
            mycmd.ExecuteNonQuery()
            Using myadapter As New SqlDataAdapter(mycmd)
                Using ds As New DataSet()
                    myadapter.Fill(ds)
                    DataGridView1.DataSource = ds.Tables(0)
                    row = DataGridView1.RowCount - 1
                    msg = CStr(row) + " USERS REGISTERED"


                End Using
            End Using
        End Using
        mycon.Close()
        Return MsgBox(msg)
    End Function
    Public Function search()
        mycon = New SqlConnection("Data Source = .\SQLEXPRESS;Initial Catalog = RGIT_DB;Integrated Security = SSPI")
        mycon.Open()

        cmd = "SELECT USER_ID ,FIRSTNAME,LASTNAME FROM USERS WHERE FIRSTNAME = @F_NAME AND LASTNAME = @L_NAME"
        Using mycmd As New SqlCommand(cmd, mycon)
            mycmd.Parameters.AddWithValue("@F_NAME", TextBox1.Text.ToUpper())
            mycmd.Parameters.AddWithValue("@L_NAME", TextBox2.Text.ToUpper())
            mycmd.ExecuteNonQuery()
            Using myadapter As New SqlDataAdapter(mycmd)
                Using ds As New DataSet()
                    myadapter.Fill(ds)
                    DataGridView1.DataSource = ds.Tables(0)
                    row = DataGridView1.RowCount - 1
                    If row = 0 Then
                        Return MsgBox("USER NOT FOUND")
                    End If

                End Using
            End Using
        End Using
        mycon.Close()
        Return MsgBox("SUCCESSFULLY SEARCHED USER")
    End Function
    Public Function reset()
        TextBox1.Clear()
        TextBox2.Clear()
        display_users()
    End Function

    Private Sub DISPLAY_USERS_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        display_users()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        reset()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        search()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Hide()
        ADMINSTRATORS.reset()
        ADMINSTRATORS.Show()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Application.Exit()

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.Hide()
        Me.reset()
        ADMIN_MENU.Show()
    End Sub
End Class
