Imports System.Data.SqlClient
Public Class SALARIES
    Private mycon As SqlConnection
    Private mycmd As SqlCommand
    Private cmd As String
    Private msg As String

    'fuction to update monthly
    Public Function update_monthly_salary()
        Try

     
        mycon = New SqlConnection("Data Source =.\SQLEXPRESS;Initial Catalog = RGIT_DB;Integrated Security = SSPI")
        mycon.Open()
        cmd = "UPDATE EMPLOYEES SET MONTHLY_SALARY = @SALARY WHERE POSITION = @ROLE"
        Using mycmd As New SqlCommand(cmd, mycon)
            mycmd.Parameters.AddWithValue("@SALARY", CInt(TextBox1.Text))
            mycmd.Parameters.AddWithValue("@ROLE", ComboBox1.Text.ToUpper())

            mycmd.ExecuteNonQuery()
        End Using

        mycon.Close()
        msg = "SUCCESSFULLY UPDATED " + CStr(ComboBox1.Text) + " SALARY"
            Return MsgBox(msg)

        Catch ex As InvalidCastException
            MsgBox("MISSING DETAILS")
        End Try

    End Function
    'function to reset
    Public Function reset()
        ComboBox1.ResetText()
        TextBox1.Clear()
    End Function

    Private Sub GroupBox1_Enter(sender As Object, e As EventArgs) Handles GroupBox1.Enter

    End Sub

    Private Sub SALARIES_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ComboBox1.Items.Add("LECTURER")
        ComboBox1.Items.Add("JANITOR")
        ComboBox1.Items.Add("SECURITY")
        ComboBox1.Items.Add("RECEPTION")
        ComboBox1.Items.Add("MANAGER")
        ComboBox1.Items.Add("CASUAL")
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        update_monthly_salary()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        reset()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        EMPLOYEE_MANAGEMENT.reset()
        Me.reset()
        Me.Hide()
        EMPLOYEE_MANAGEMENT.Show()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        SALARY_MANAGEMENT.reset()
        Me.reset()
        Me.Hide()
        SALARY_MANAGEMENT.Show()
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Application.Exit()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Me.reset()
        Me.Hide()
        ADMIN_MENU.Show()

    End Sub
End Class
