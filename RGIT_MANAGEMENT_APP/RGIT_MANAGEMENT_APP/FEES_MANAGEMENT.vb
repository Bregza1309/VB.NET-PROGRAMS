Imports System.Data.SqlClient
Imports System.Data.Sql
Public Class FEES_MANAGEMENT
    Private mycon As SqlConnection
    Private mycmd As SqlCommand
    Private myreader As SqlDataReader
    Private myadapter As SqlDataAdapter
    Private results As String
    Private cmd As String
    Dim current_date As String = DateAndTime.Now
    Dim course As String
    Dim amount_due As Integer
    Dim balance As Integer
    Dim ds As DataSet




    'function retreiving student information
    Public Function retreive_student_info()
        Try

      
        mycon = New SqlConnection("Data Source = .\SQLEXPRESS;Initial Catalog = RGIT_DB;Integrated Security = SSPI")
        mycon.Open()
        cmd = "SELECT STUDENT_ID FROM STUDENTS WHERE FIRSTNAME = @f_name AND LASTNAME =@l_name "
        Using mycmd As New SqlCommand(cmd, mycon)
            mycmd.Parameters.AddWithValue("@f_name", TextBox1.Text.ToUpper())
            mycmd.Parameters.AddWithValue("@l_name", TextBox2.Text.ToUpper())
            mycmd.ExecuteNonQuery()
            myreader = mycmd.ExecuteReader()
            If myreader.Read() Then
                results = myreader(0)
                TextBox3.Text = results
                myreader.Close()
            
            End If
        End Using
        cmd = "SELECT FEES FROM STUDENTS WHERE FIRSTNAME = @f_name AND LASTNAME =@l_name "
        Using mycmd As New SqlCommand(cmd, mycon)
            mycmd.Parameters.AddWithValue("@f_name", TextBox1.Text.ToUpper())
            mycmd.Parameters.AddWithValue("@l_name", TextBox2.Text.ToUpper())
            mycmd.ExecuteNonQuery()
            myreader = mycmd.ExecuteReader()
            If myreader.Read() Then
                results = myreader(0)
                amount_due = CInt(results)
                myreader.Close()
           
            End If
        End Using
        cmd = "SELECT COURSE FROM STUDENTS WHERE FIRSTNAME = @f_name AND LASTNAME =@l_name "
        Using mycmd As New SqlCommand(cmd, mycon)
            mycmd.Parameters.AddWithValue("@f_name", TextBox1.Text.ToUpper())
            mycmd.Parameters.AddWithValue("@l_name", TextBox2.Text.ToUpper())
            mycmd.ExecuteNonQuery()
            myreader = mycmd.ExecuteReader()
            If myreader.Read() Then
                results = myreader(0)
                course = results
                myreader.Close()
            
            End If
        End Using
        mycon.Close()
            Return MsgBox("SUCCESSFULLY SEARCHED A STUDENT")

        Catch ex As InvalidOperationException
            MsgBox("ENTER CORRECT STUDENT NAME AND SURNAME")

        End Try
    End Function
    'FUNCTION TO UPDATE TRANSACTION_DATA
    Public Function update_transaction_data()
        Try

    
        mycon = New SqlConnection("Data Source = .\SQLEXPRESS;Initial Catalog = RGIT_DB;Integrated Security = SSPI")
        mycon.Open()
        cmd = "INSERT INTO TRANSACTIONS VALUES(@TRANSACTION_ID,@STUDENT_ID,@FIRSTNAME,@LASTNAME,@AMOUNT,@BALANCE,@COURSE,@DATE,@TYPE)"
        Using mycmd As New SqlCommand(cmd, mycon)
            mycmd.Parameters.AddWithValue("@TRANSACTION_ID", TextBox4.Text)
            mycmd.Parameters.AddWithValue("@STUDENT_ID", TextBox3.Text)
            mycmd.Parameters.AddWithValue("@FIRSTNAME", TextBox1.Text.ToUpper())
            mycmd.Parameters.AddWithValue("@LASTNAME", TextBox2.Text.ToUpper())
            mycmd.Parameters.AddWithValue("@AMOUNT", TextBox5.Text)
            mycmd.Parameters.AddWithValue("@BALANCE", amount_due - CInt(TextBox5.Text))
            mycmd.Parameters.AddWithValue("@COURSE", course.ToUpper())
            mycmd.Parameters.AddWithValue("@DATE", current_date)
            mycmd.Parameters.AddWithValue("@TYPE", ComboBox1.Text.ToUpper())
            mycmd.ExecuteNonQuery()



        End Using

        cmd = "UPDATE  STUDENTS SET FEES = @BALANCE WHERE FIRSTNAME = @FIRSTNAME AND LASTNAME = @LASTNAME"
        Using mycmd As New SqlCommand(cmd, mycon)

            mycmd.Parameters.AddWithValue("@FIRSTNAME", TextBox1.Text.ToUpper())
            mycmd.Parameters.AddWithValue("@LASTNAME", TextBox2.Text.ToUpper())

            mycmd.Parameters.AddWithValue("@BALANCE", amount_due - CInt(TextBox5.Text))

            mycmd.ExecuteNonQuery()



        End Using
        mycon.Close()
            Return MsgBox("SUCCESSFULLY UPDATED STUDENT FEES")

        Catch ex As InvalidCastException
            MsgBox("FILL IN MISSING DETAILS")

        End Try
    End Function
    'FUNCTION TO DISPLAY_TRANSACTIONS() 
    Public Function display_transactions()
        mycon = New SqlConnection("Data Source = .\SQLEXPRESS;Initial Catalog = RGIT_DB;Integrated Security = SSPI")
        mycon.Open()
        cmd = "SELECT TRANSACTION_ID,STUDENT_ID,FIRSTNAME,LASTNAME,AMOUNT,BALANCE,COURSE,PAYMENT_TYPE,TRANSACTION_DATE FROM TRANSACTIONS ORDER BY TRANSACTION_DATE "
        Using mycmd As New SqlCommand(cmd, mycon)
            mycmd.ExecuteNonQuery()
            Using myadapter As New SqlDataAdapter(mycmd)
                Using ds As New DataSet()
                    myadapter.Fill(ds)
                    DataGridView1.DataSource = ds.Tables(0)
                End Using
            End Using
        End Using
        mycon.Close()
        Return MsgBox("DATABASE REFRESHED")

    End Function


    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub GroupBox1_Enter(sender As Object, e As EventArgs) Handles GroupBox1.Enter

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim transaction_id As Integer = CInt(Math.Floor(3909999 - 3900000 + 5) * Rnd()) + 3900000






        TextBox4.Text = transaction_id
        retreive_student_info()



    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        update_transaction_data()
        display_transactions()
    End Sub

    Private Sub FEES_MANAGEMENT_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        display_transactions()

        ComboBox1.Items.Add("CASH")
        ComboBox1.Items.Add("DEPOSIT")
        ComboBox1.Items.Add("EFT")

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.Hide()
        Form1.Show()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Me.Hide()
        students.Show()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        TextBox1.Clear()
        TextBox2.Clear()
        TextBox3.Clear()
        TextBox4.Clear()
        TextBox5.Clear()
        ComboBox1.ResetText()
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Application.Exit()
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        Me.Hide()
        COURSE_MANAGEMENT.Show()
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

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub
End Class