Imports System.Data.SqlClient
Imports System.Data.Sql
Public Class EMPLOYEE_MANAGEMENT
    Private mycon As SqlConnection
    Private mycmd As SqlCommand
    Private myadapter As SqlDataAdapter
    Private ds As DataSet()
    Private cmd As String
    Private row As Integer
    Private msg As String
    'function to show lecturers employed
    Public Function show_lecturers()
        mycon = New SqlConnection("Data Source =.\SQLEXPRESS;Initial Catalog =RGIT_DB;Integrated Security = SSPI")
        mycon.Open()
        cmd = "SELECT EMPLOYEE_ID,FIRSTNAME,LASTNAME,ID_NUMBER,CELL_NUMBER,HOME_ADDRESS,EMAIL_ADDRESS,SALARY,SALARY_PAID,MONTHLY_SALARY FROM EMPLOYEES WHERE POSITION = 'LECTURER'"
        Using mycmd As New SqlCommand(cmd, mycon)
            mycmd.ExecuteNonQuery()
            Using myadapter As New SqlDataAdapter(mycmd)
                Using ds As New DataSet()
                    myadapter.Fill(ds)
                    DataGridView1.DataSource = ds.Tables(0)
                    row = DataGridView1.RowCount - 1
                    msg = CStr(row) + " LECTURERS EMPLOYED"
                End Using
            End Using
        End Using
        mycon.Close()
        Return MsgBox(msg)


    End Function
    'function to show managers employees
    Public Function show_managers()
        mycon = New SqlConnection("Data Source =.\SQLEXPRESS;Initial Catalog =RGIT_DB;Integrated Security = SSPI")
        mycon.Open()
        cmd = "SELECT EMPLOYEE_ID,FIRSTNAME,LASTNAME,ID_NUMBER,CELL_NUMBER,HOME_ADDRESS,EMAIL_ADDRESS,SALARY,SALARY_PAID,MONTHLY_SALARY FROM EMPLOYEES WHERE POSITION = 'MANAGER'"
        Using mycmd As New SqlCommand(cmd, mycon)
            mycmd.ExecuteNonQuery()
            Using myadapter As New SqlDataAdapter(mycmd)
                Using ds As New DataSet()
                    myadapter.Fill(ds)
                    DataGridView1.DataSource = ds.Tables(0)
                    row = DataGridView1.RowCount - 1
                    msg = CStr(row) + " MANAGERS EMPLOYED"
                End Using
            End Using
        End Using
        mycon.Close()
        Return MsgBox(msg)


    End Function
    'function to show reception employees
    Public Function show_reception()
        mycon = New SqlConnection("Data Source =.\SQLEXPRESS;Initial Catalog =RGIT_DB;Integrated Security = SSPI")
        mycon.Open()
        cmd = "SELECT EMPLOYEE_ID,FIRSTNAME,LASTNAME,ID_NUMBER,CELL_NUMBER,HOME_ADDRESS,EMAIL_ADDRESS,SALARY,SALARY_PAID,MONTHLY_SALARY FROM EMPLOYEES WHERE POSITION = 'RECEPTION'"
        Using mycmd As New SqlCommand(cmd, mycon)
            mycmd.ExecuteNonQuery()
            Using myadapter As New SqlDataAdapter(mycmd)
                Using ds As New DataSet()
                    myadapter.Fill(ds)
                    DataGridView1.DataSource = ds.Tables(0)
                    row = DataGridView1.RowCount - 1
                    msg = CStr(row) + " RECEPTION EMPLOYEES"
                End Using
            End Using
        End Using
        mycon.Close()
        Return MsgBox(msg)


    End Function
    'function to show SECURITY employeES
    Public Function show_security()
        mycon = New SqlConnection("Data Source =.\SQLEXPRESS;Initial Catalog =RGIT_DB;Integrated Security = SSPI")
        mycon.Open()
        cmd = "SELECT EMPLOYEE_ID,FIRSTNAME,LASTNAME,ID_NUMBER,CELL_NUMBER,HOME_ADDRESS,EMAIL_ADDRESS,SALARY,SALARY_PAID,MONTHLY_SALARY FROM EMPLOYEES WHERE POSITION = 'SECURITY'"
        Using mycmd As New SqlCommand(cmd, mycon)
            mycmd.ExecuteNonQuery()
            Using myadapter As New SqlDataAdapter(mycmd)
                Using ds As New DataSet()
                    myadapter.Fill(ds)
                    DataGridView1.DataSource = ds.Tables(0)
                    row = DataGridView1.RowCount - 1
                    msg = CStr(row) + " SECURITY EMPLOYEES"
                End Using
            End Using
        End Using
        mycon.Close()
        Return MsgBox(msg)


    End Function
    'function to show CASUAL/JANITORS employed
    Public Function show_casual_or_janitors()
        mycon = New SqlConnection("Data Source =.\SQLEXPRESS;Initial Catalog =RGIT_DB;Integrated Security = SSPI")
        mycon.Open()
        cmd = "SELECT EMPLOYEE_ID,FIRSTNAME,LASTNAME,ID_NUMBER,CELL_NUMBER,HOME_ADDRESS,EMAIL_ADDRESS,SALARY,SALARY_PAID,MONTHLY_SALARY FROM EMPLOYEES WHERE POSITION = 'CASUAL' OR POSITION = 'JANITOR'"
        Using mycmd As New SqlCommand(cmd, mycon)
            mycmd.ExecuteNonQuery()
            Using myadapter As New SqlDataAdapter(mycmd)
                Using ds As New DataSet()
                    myadapter.Fill(ds)
                    DataGridView1.DataSource = ds.Tables(0)
                    row = DataGridView1.RowCount - 1
                    msg = CStr(row) + " CASUAL/JANITOR EMPLOYEES"
                End Using
            End Using
        End Using
        mycon.Close()
        Return MsgBox(msg)


    End Function
    'function to SEARCH EMPLOYEES employed
    Public Function search()
        mycon = New SqlConnection("Data Source =.\SQLEXPRESS;Initial Catalog =RGIT_DB;Integrated Security = SSPI")
        mycon.Open()
        cmd = "SELECT EMPLOYEE_ID,FIRSTNAME,LASTNAME,ID_NUMBER,CELL_NUMBER,HOME_ADDRESS,EMAIL_ADDRESS,SALARY,SALARY_PAID,MONTHLY_SALARY FROM EMPLOYEES WHERE FIRSTNAME = @F_NAME AND LASTNAME = @L_NAME"
        Using mycmd As New SqlCommand(cmd, mycon)
            mycmd.Parameters.AddWithValue("F_NAME", TextBox1.Text.ToUpper())
            mycmd.Parameters.AddWithValue("L_NAME", TextBox2.Text.ToUpper())
            mycmd.ExecuteNonQuery()
            Using myadapter As New SqlDataAdapter(mycmd)
                Using ds As New DataSet()
                    myadapter.Fill(ds)
                    DataGridView1.DataSource = ds.Tables(0)
                    row = DataGridView1.RowCount - 1
                    If row = 0 Then
                        Return MsgBox("EMPLOYEE_NOT_FOUND")

                    End If
                    msg = " SUCCESSFULLY SEARCHED EMPLOYEE"
                End Using
            End Using
        End Using
        mycon.Close()
        Return MsgBox(msg)


    End Function
    'function to show all employees employed
    Public Function show_employees()
        mycon = New SqlConnection("Data Source =.\SQLEXPRESS;Initial Catalog =RGIT_DB;Integrated Security = SSPI")
        mycon.Open()
        cmd = "SELECT EMPLOYEE_ID,FIRSTNAME,LASTNAME,ID_NUMBER,CELL_NUMBER,HOME_ADDRESS,EMAIL_ADDRESS,SALARY,SALARY_PAID,MONTHLY_SALARY FROM EMPLOYEES ORDER BY REGISTRATION_DATE "
        Using mycmd As New SqlCommand(cmd, mycon)
            mycmd.ExecuteNonQuery()
            Using myadapter As New SqlDataAdapter(mycmd)
                Using ds As New DataSet()
                    myadapter.Fill(ds)
                    DataGridView1.DataSource = ds.Tables(0)
                    row = DataGridView1.RowCount - 1
                    msg = CStr(row) + "  EMPLOYEES"
                End Using
            End Using
        End Using
        mycon.Close()
        Return MsgBox(msg)


    End Function
    'function to reset
    Public Function reset()
        'reset datagridview 1 with employees
        show_employees()

        'clear the textbox controls
        TextBox1.Clear()
        TextBox2.Clear()

    End Function


    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        show_lecturers()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        show_managers()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        show_reception()
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        show_security()
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        show_casual_or_janitors()
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        reset()
    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        Application.Exit()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        search()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Hide()
        Try
            ADD_EMPLOYEES.Show()
        Catch ex As Exception
            ADD_EMPLOYEES.Show()
        End Try



    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click

        Me.Hide()
        ADMIN_MENU.Show()

    End Sub
End Class
