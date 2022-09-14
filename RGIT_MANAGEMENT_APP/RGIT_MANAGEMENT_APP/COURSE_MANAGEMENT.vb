Imports System.Data.SqlClient
Imports System.Data.Sql

Public Class COURSE_MANAGEMENT
    Private mycon As SqlConnection
    Private mycmd As SqlCommand
    Private myreader As SqlDataReader
    Private myadapter As SqlDataAdapter
    Private ds As DataSet
    Private dt As DataTable
    Private cmd As String
    Private results As String
    Dim i As Integer



    'function to add new courses
    Public Function add_course()
        Try

   
        mycon = New SqlConnection("Data Source = .\SQLEXPRESS;Initial Catalog = RGIT_DB;Integrated Security = SSPI")
        mycon.Open()
        cmd = "INSERT INTO COURSES VALUES(@COURSE_ID,@NAME,@FEES,@DURATION,@DATE,'')"
        Using mycmd As New SqlCommand(cmd, mycon)
            mycmd.Parameters.AddWithValue("@COURSE_ID", CInt(TextBox2.Text))
            mycmd.Parameters.AddWithValue("@NAME", TextBox1.Text.ToUpper())
            mycmd.Parameters.AddWithValue("@FEES", CInt(TextBox3.Text))
            mycmd.Parameters.AddWithValue("@DURATION", CInt(ComboBox2.Text))
            mycmd.Parameters.AddWithValue("@DATE", DateAndTime.Now)
            mycmd.ExecuteNonQuery()

        End Using
        mycon.Close()
            Return MsgBox("SUCCESSFULLY ADDED COURSE")
        Catch ex As InvalidCastException
            MsgBox("FILL IN MISSING DETAILS")
        End Try
    End Function
    'FUNCTION TO RETREIVE AVAILABEL COURSES
    Public Function available_courses()
        mycon = New SqlConnection("Data Source = .\SQLEXPRESS;Initial Catalog = RGIT_DB;Integrated Security = SSPI")
        mycon.Open()
        cmd = "SELECT COURSE_NAME FROM COURSES "
        Using mycmd As New SqlCommand(cmd, mycon)
            mycmd.ExecuteNonQuery()
            myreader = mycmd.ExecuteReader()
            Do While myreader.Read()
                ComboBox1.Items.Add(myreader.GetValue(0))


            Loop


           





            myreader.Close()
        End Using
        mycon.Close()

    End Function
    ' function get course details
    Public Function get_course_details()
        If ComboBox1.Text = "" Then
            MsgBox("SELECT COURSE TO RETREIVE ")
        Else
            mycon = New SqlConnection("Data Source = .\SQLEXPRESS;Initial Catalog = RGIT_DB;Integrated Security = SSPI")
            mycon.Open()
            'retreive name
            cmd = "SELECT COURSE_NAME FROM COURSES WHERE COURSE_NAME = @name"
            Using mycmd As New SqlCommand(cmd, mycon)
                mycmd.Parameters.AddWithValue("@name", ComboBox1.Text)
                mycmd.ExecuteNonQuery()
                myreader = mycmd.ExecuteReader()
                If myreader.Read() Then
                    TextBox1.Text = myreader(0)

                End If
                myreader.Close()
            End Using
            'retreive id
            cmd = "SELECT COURSE_ID FROM COURSES WHERE COURSE_NAME = @name"
            Using mycmd As New SqlCommand(cmd, mycon)
                mycmd.Parameters.AddWithValue("@name", ComboBox1.Text)
                mycmd.ExecuteNonQuery()
                myreader = mycmd.ExecuteReader()
                If myreader.Read() Then
                    TextBox2.Text = myreader.GetValue(0)

                End If
                myreader.Close()
            End Using
            'retreive FEES
            cmd = "SELECT COURSE_FEES FROM COURSES WHERE COURSE_NAME = @name"
            Using mycmd As New SqlCommand(cmd, mycon)
                mycmd.Parameters.AddWithValue("@name", ComboBox1.Text)
                mycmd.ExecuteNonQuery()
                myreader = mycmd.ExecuteReader()
                If myreader.Read() Then
                    TextBox3.Text = myreader(0)

                End If
                myreader.Close()
            End Using
            'retreive DURATION
            cmd = "SELECT COURSE_DURATION FROM COURSES WHERE COURSE_NAME = @name"
            Using mycmd As New SqlCommand(cmd, mycon)
                mycmd.Parameters.AddWithValue("@name", ComboBox1.Text)
                mycmd.ExecuteNonQuery()
                myreader = mycmd.ExecuteReader()
                If myreader.Read() Then
                    ComboBox2.Text = myreader(0)

                End If
                myreader.Close()
            End Using
            mycon.Close()
            Return MsgBox("SUCCESSFULLY RETREIVED COURSE DETAILS")

        End If
     
    End Function
    'function to edit_courses
    Public Function edit_course()
        Try

     
        mycon = New SqlConnection("Data Source = .\SQLEXPRESS;Initial Catalog = RGIT_DB;Integrated Security = SSPI")
        mycon.Open()
        cmd = "UPDATE COURSES SET COURSE_NAME = @NAME,COURSE_ID = @ID ,COURSE_FEES=@FEES,COURSE_DURATION = @DURATION WHERE COURSE_NAME = @C_NAME"
        Using mycmd As New SqlCommand(cmd, mycon)
            mycmd.Parameters.AddWithValue("@NAME", TextBox1.Text.ToUpper())
            mycmd.Parameters.AddWithValue("@ID", CInt(TextBox2.Text))
            mycmd.Parameters.AddWithValue("@FEES", CInt(TextBox3.Text))
            mycmd.Parameters.AddWithValue("@DURATION", CInt(ComboBox2.Text))
            mycmd.Parameters.AddWithValue("@C_NAME", ComboBox1.Text.ToUpper())
            mycmd.ExecuteNonQuery()


        End Using
        mycon.Close()
            Return MsgBox("SUCCESSFULLY UPDATED COURSE")
        Catch ex As InvalidCastException
            MsgBox("FILL IN MISSING DETAILS")
        End Try
    End Function
    'function delete_course() to delete courses
    Public Function delete_course()
        If ComboBox1.Text = "" Then
            MsgBox("SELECT COURSE TO DELETE")
        Else
            mycon = New SqlConnection("Data Source= .\SQLEXPRESS;Initial catalog = RGIT_DB;Integrated Security = SSPI")
            mycon.Open()
            cmd = "DELETE FROM COURSES WHERE COURSE_NAME = @NAME"
            Using mycmd As New SqlCommand(cmd, mycon)
                mycmd.Parameters.AddWithValue("@NAME", ComboBox1.Text.ToUpper())
                mycmd.ExecuteNonQuery()

            End Using
            mycon.Close()
            Return MsgBox("SUCCESSFULLY DELETED COURSE")
        End If
        
    End Function


    Private Sub GroupBox1_Enter(sender As Object, e As EventArgs) Handles GroupBox1.Enter

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        get_course_details()
    End Sub

    Private Sub GroupBox2_Enter(sender As Object, e As EventArgs) Handles GroupBox2.Enter

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        add_course()
        ComboBox1.Items.Clear()
        available_courses()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim course_id As Integer = CInt(Math.Floor(3129999 - 3120000 + 1) * Rnd()) + 3120000
        TextBox2.Text = course_id
    End Sub

    Private Sub COURSE_MANAGEMENT_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        i = 1
        While i < 10
            ComboBox2.Items.Add(i)
            i += 1
        End While
        available_courses()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        edit_course()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        delete_course()
        ComboBox1.Items.Clear()
        available_courses()
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        ComboBox1.ResetText()
        ComboBox2.ResetText()
        TextBox1.Clear()
        TextBox2.Clear()
        TextBox3.Clear()

    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Application.Exit()
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        If AUTHENTICATION.RadioButton2.Checked Then
            Me.Hide()
            ADMIN_MENU.Show()
        Else
            Me.Hide()
            USER_MENU.Show()
        End If
    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub
End Class