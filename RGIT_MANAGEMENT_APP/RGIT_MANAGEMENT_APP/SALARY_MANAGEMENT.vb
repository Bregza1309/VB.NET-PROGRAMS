Imports System.Data.SqlClient

Public Class SALARY_MANAGEMENT
    Private mycon As SqlConnection
    Private mycmd As SqlCommand
    Private myreader As SqlDataReader
    Private myadapter As SqlDataAdapter
    Private cmd As String
    Dim salary_due As Integer
    Dim salary_paid As Integer
    Private ds As DataSet
    Private row As Integer

    'function to search and retreive employee details for transactions
    Public Function search_employee_details()
        Try
            If TextBox1.Text = "" And TextBox2.Text = "" Then
                Return MsgBox("SEARCH DETAILS MISSING ")
            Else
                mycon = New SqlConnection("Data Source = .\SQLEXPRESS;Initial Catalog = RGIT_DB;Integrated Security = SSPI")
                mycon.Open()
                'retreive employee_id
                cmd = "SELECT EMPLOYEE_ID FROM EMPLOYEES WHERE FIRSTNAME = @F_NAME AND LASTNAME = @L_NAME"
                Using mycmd As New SqlCommand(cmd, mycon)
                    mycmd.Parameters.AddWithValue("@F_NAME", TextBox1.Text.ToUpper())
                    mycmd.Parameters.AddWithValue("@L_NAME", TextBox2.Text.ToUpper())
                    mycmd.ExecuteNonQuery()
                    myreader = mycmd.ExecuteReader()
                    If myreader.Read() Then
                        TextBox3.Text = myreader(0)
                        myreader.Close()
                    End If
                End Using
                'retreive EMPLOYEE_ROLE
                cmd = "SELECT POSITION FROM EMPLOYEES WHERE FIRSTNAME = @F_NAME AND LASTNAME = @L_NAME"
                Using mycmd As New SqlCommand(cmd, mycon)
                    mycmd.Parameters.AddWithValue("@F_NAME", TextBox1.Text.ToUpper())
                    mycmd.Parameters.AddWithValue("@L_NAME", TextBox2.Text.ToUpper())
                    mycmd.ExecuteNonQuery()
                    myreader = mycmd.ExecuteReader()
                    If myreader.Read() Then
                        TextBox5.Text = myreader(0)
                        myreader.Close()
                    End If

                End Using
                'retreive salary
                cmd = "SELECT SALARY FROM EMPLOYEES WHERE FIRSTNAME = @F_NAME AND LASTNAME = @L_NAME"
                Using mycmd As New SqlCommand(cmd, mycon)
                    mycmd.Parameters.AddWithValue("@F_NAME", TextBox1.Text.ToUpper())
                    mycmd.Parameters.AddWithValue("@L_NAME", TextBox2.Text.ToUpper())
                    mycmd.ExecuteNonQuery()
                    myreader = mycmd.ExecuteReader()
                    If myreader.Read() Then
                        salary_due = CInt(myreader(0))
                        myreader.Close()
                    End If

                End Using
                'retreive SALARY_PAID
                cmd = "SELECT SALARY_PAID FROM EMPLOYEES WHERE FIRSTNAME = @F_NAME AND LASTNAME = @L_NAME"
                Using mycmd As New SqlCommand(cmd, mycon)
                    mycmd.Parameters.AddWithValue("@F_NAME", TextBox1.Text.ToUpper())
                    mycmd.Parameters.AddWithValue("@L_NAME", TextBox2.Text.ToUpper())
                    mycmd.ExecuteNonQuery()
                    myreader = mycmd.ExecuteReader()
                    If myreader.Read() Then
                        salary_paid = CInt(myreader(0))
                        myreader.Close()
                    End If

                End Using
                'retreive MONTHLY_SALARY
                cmd = "SELECT MONTHLY_SALARY FROM EMPLOYEES WHERE FIRSTNAME = @F_NAME AND LASTNAME = @L_NAME"
                Using mycmd As New SqlCommand(cmd, mycon)
                    mycmd.Parameters.AddWithValue("@F_NAME", TextBox1.Text.ToUpper())
                    mycmd.Parameters.AddWithValue("@L_NAME", TextBox2.Text.ToUpper())
                    mycmd.ExecuteNonQuery()
                    myreader = mycmd.ExecuteReader()
                    If myreader.Read() Then
                        TextBox6.Text = CInt(myreader(0))
                        myreader.Close()
                    End If

                End Using
                mycon.Close()
                'ADD TRANSACTION_ID
                Dim transaction_id As Integer = CInt(Math.Floor(2909999 - 2900000 + 1) * Rnd()) + 2900000
                TextBox4.Text = transaction_id
                Return MsgBox("SUCCESSFULLY SEARCHED EMPLOYEE")
            End If
          
        Catch ex As InvalidOperationException
            MsgBox("EMPLOYEE_NOT_FOUND('_')")

        End Try

    End Function
    'function to update database after employee has been paid
    Public Function checkout()
        Try

       
        'update employee_salary details
        mycon = New SqlConnection("Data Source = .\SQLEXPRESS;Initial Catalog = RGIT_DB;Integrated Security = SSPI")
        mycon.Open()
        cmd = "UPDATE EMPLOYEES SET SALARY = @SALARY, SALARY_PAID = @S_PAID WHERE FIRSTNAME = @F_NAME AND LASTNAME = @L_NAME"
        Using mycmd As New SqlCommand(cmd, mycon)
            mycmd.Parameters.AddWithValue("@SALARY", salary_due - CInt(TextBox6.Text))
            mycmd.Parameters.AddWithValue("@S_PAID", salary_paid + CInt(TextBox6.Text))
            mycmd.Parameters.AddWithValue("@F_NAME", TextBox1.Text.ToUpper())
            mycmd.Parameters.AddWithValue("@L_NAME", TextBox2.Text.ToUpper())
            mycmd.ExecuteNonQuery()
        End Using

        cmd = "INSERT INTO SALARY_TRANSACTIONS VALUES(@T_ID,@F_NAME,@L_NAME,@E_ID,@AMOUNT,@BALANCE,@ROLE,@TYPE,@DATE)"
        Using mycmd As New SqlCommand(cmd, mycon)
            mycmd.Parameters.AddWithValue("@BALANCE", salary_due - CInt(TextBox6.Text))
            mycmd.Parameters.AddWithValue("@AMOUNT", CInt(TextBox6.Text))
            mycmd.Parameters.AddWithValue("@F_NAME", TextBox1.Text.ToUpper())
            mycmd.Parameters.AddWithValue("@L_NAME", TextBox2.Text.ToUpper())
            mycmd.Parameters.AddWithValue("@ROLE", TextBox5.Text.ToUpper())
            mycmd.Parameters.AddWithValue("@T_ID", CInt(TextBox4.Text))
            mycmd.Parameters.AddWithValue("@E_ID", CInt(TextBox3.Text))
            mycmd.Parameters.AddWithValue("@TYPE", ComboBox1.Text.ToUpper())
            mycmd.Parameters.AddWithValue("@DATE", DateAndTime.Now)


            mycmd.ExecuteNonQuery()
        End Using
        show_transactions()

        mycon.Close()

            Return MsgBox("EMPLOYEE_PAID_SUCCESSFULLY")
        Catch ex As InvalidCastException
            MsgBox("ENTER ALL DETAILS")

        End Try



    End Function
    'FUNCTION TO SEARCH TRANSACTION DETAILS
    Public Function search_transaction_details()
        mycon = New SqlConnection("Data Source = .\SQLEXPRESS;Initial Catalog = RGIT_DB;Integrated Security = SSPI")
        mycon.Open()
        'retreive employee_id
        cmd = "SELECT TRANSACTION_ID,FIRSTNAME,LASTNAME,EMPLOYEE_ID,AMOUNT,BALANCE,TRANSACTION_DATE,PAYMENT_TYPE FROM SALARY_TRANSACTIONS WHERE FIRSTNAME = @F_NAME AND LASTNAME = @L_NAME"
        Using mycmd As New SqlCommand(cmd, mycon)
            mycmd.Parameters.AddWithValue("@F_NAME", TextBox8.Text.ToUpper())
            mycmd.Parameters.AddWithValue("@L_NAME", TextBox7.Text.ToUpper())
            mycmd.ExecuteNonQuery()
            Using myadapter As New SqlDataAdapter(mycmd)
                Using ds As New DataSet()
                    myadapter.Fill(ds)
                    DataGridView1.DataSource = ds.Tables(0)
                    row = DataGridView1.RowCount - 1
                    If row = 0 Then
                        Return MsgBox("TRANSACTIONS NOT FOUND")
                    End If

                End Using

            End Using

        End Using
        mycon.Close()
        Return MsgBox("SUCCESSFULLY SEARCHED TRANSACTIONS")

    End Function
    Public Function show_transactions()
        mycon = New SqlConnection("Data Source = .\SQLEXPRESS;Initial Catalog = RGIT_DB;Integrated Security = SSPI")
        mycon.Open()
        'SHOW TRANSACTIONS
        cmd = "SELECT TRANSACTION_ID,FIRSTNAME,LASTNAME,EMPLOYEE_ID,AMOUNT,BALANCE,TRANSACTION_DATE,PAYMENT_TYPE FROM SALARY_TRANSACTIONS"
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

    End Function
    'function to reset controls
    Public Function reset()
        TextBox1.Clear()
        TextBox2.Clear()
        TextBox3.Clear()
        TextBox4.Clear()
        TextBox5.Clear()
        TextBox6.Clear()
        TextBox7.Clear()
        TextBox8.Clear()
        ComboBox1.ResetText()
        show_transactions()
    End Function

    Private Sub SALARY_MANAGEMENT_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ComboBox1.Items.Add("EFT")
        ComboBox1.Items.Add("CASH")
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        search_employee_details()
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        checkout()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        EMPLOYEE_MANAGEMENT.reset()
        Me.reset()
        Me.Hide()
        EMPLOYEE_MANAGEMENT.Show()
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        search_transaction_details()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        reset()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.reset()
        Me.Hide()
        ADMIN_MENU.Show()

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.reset()
        Me.Hide()
        EMPLOYEE_MANAGEMENT.reset()
        EMPLOYEE_MANAGEMENT.Show()
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        Me.reset()
        Me.Hide()
        SALARIES.reset()
        SALARIES.Show()
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        Application.Exit()
    End Sub
End Class
