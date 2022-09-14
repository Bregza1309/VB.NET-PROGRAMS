Imports System.Data.Sql
Imports System.Data.SqlClient

Public Class EMPLOYEE_MANAGEMENT_APP3
    Private mycon As SqlConnection
    Private myreader As SqlDataReader
    Private mycmd As SqlCommand
    Private myadapter As SqlDataAdapter
    Private cmd As String
    Dim default_password As String = "employee@123"
    Dim employee_id As Integer
    Dim salary As Integer
    Dim monthly_salary As Integer
 
    Dim gender As String
 

    Public Function update_employees()
        ' CONNECTION STRING TO DATABASE
        mycon = New SqlConnection("Data Source = .\SQLEXPRESS;Initial Catalog=RGIT_DB;Integrated Security=SSPI")
        mycon.Open()
        cmd = "UPDATE EMPLOYEES SET EMPLOYEE_ID= @E_ID,FIRSTNAME = @FIRSTNAME , LASTNAME =@LASTNAME,ID_NUMBER = @ID ,HOME_ADDRESS = @HOME_ADDRESS , EMAIL_ADDRESS=@EMAIL_ADDRESS ,POSITION = @POSITION,SALARY = @SALARY,GENDER = @GENDER"


        'UPDATING THE DATABASE USING SQL QUERY 'cmd as string' and mycon and parameters

        Using mycmd As New SqlCommand(cmd, mycon)
            mycmd.Parameters.AddWithValue("@POSITION", ComboBox1.Text)
            mycmd.Parameters.AddWithValue("@FIRSTNAME", RichTextBox1.Text.ToUpper())
            mycmd.Parameters.AddWithValue("@LASTNAME", RichTextBox2.Text.ToUpper())
            mycmd.Parameters.AddWithValue("@CELL_NUMBER", RichTextBox6.Text.ToUpper())
            mycmd.Parameters.AddWithValue("@GENDER", gender)
            mycmd.Parameters.AddWithValue("@E_ID", employee_id)
            mycmd.Parameters.AddWithValue("@HOME_ADDRESS", RichTextBox6.Text.ToUpper())
            mycmd.Parameters.AddWithValue("@EMAIL_ADDRESS", RichTextBox7.Text.ToUpper())
            mycmd.Parameters.AddWithValue("@ID", RichTextBox3.Text.ToUpper())
            mycmd.Parameters.AddWithValue("@SALARY", salary)
            mycmd.ExecuteNonQuery()



        End Using
        mycon.Close()
        Return (MsgBox("SUCCESSFULLY UPDATED THE EMPLOYEE-DATABASE"))



    End Function
    'FUNCTION TO RESET FORM CONTROLS
    Public Function clear_controls()
        RichTextBox1.Clear()
        RichTextBox2.Clear()
        RichTextBox3.Clear()
        RichTextBox4.Clear()
        RichTextBox5.Clear()
        RichTextBox6.Clear()
        RichTextBox7.Clear()
        RichTextBox8.Clear()
        RichTextBox9.Clear()
        RichTextBox10.Clear()
        ComboBox1.ResetText()

    End Function
    Public Function add_employees()
        'CHECK WHICH RADIO BUTTON IS CHECKED TO CHOOSE GENDER
        If RadioButton1.Checked Then
            gender = "FEMALE"
        ElseIf RadioButton2.Checked Then
            gender = "MALE"
        End If

        'CHOOSE SALARY ACCORDING TO CHOSEN POSITION/ROLE
        If ComboBox1.Text = "LECTURER" Then
            monthly_salary = 20000
            salary = 12 * monthly_salary

        ElseIf ComboBox1.Text = "JANITOR" Then
            monthly_salary = 4000
            salary = 12 * monthly_salary
        ElseIf ComboBox1.Text = "MANAGER" Then
            monthly_salary = 24000
            salary = 12 * monthly_salary
        ElseIf ComboBox1.Text = "RECEPTION" Then
            monthly_salary = 8000
            salary = 12 * monthly_salary
        ElseIf ComboBox1.Text = "CASUAL" Then
            monthly_salary = 3000
            salary = 12 * monthly_salary
        ElseIf ComboBox1.Text = "SECURITY" Then
            monthly_salary = 10000
            salary = 12 * monthly_salary
        End If

        'insert into database
        mycon = New SqlConnection("Data Source = .\SQLEXPRESS;Initial Catalog = RGIT_DB;Integrated Security = SSPI")
        mycon.Open()
        cmd = "INSERT INTO EMPLOYEES VALUES(@E_ID,@F_NAME,@L_NAME,@ID,@H_ADDRESS,@CELL,@E_ADDRESS,@POSITION,@SALARY,0,@GENDER,@DATE,@PASSWORDS,@M_SALARY)"
        Using mycmd As New SqlCommand(cmd, mycon)
            mycmd.Parameters.AddWithValue("@E_ID", CInt(RichTextBox4.Text))
            mycmd.Parameters.AddWithValue("@F_NAME", RichTextBox1.Text.ToUpper())
            mycmd.Parameters.AddWithValue("@L_NAME", RichTextBox2.Text.ToUpper())
            mycmd.Parameters.AddWithValue("@ID", RichTextBox3.Text.ToUpper())
            mycmd.Parameters.AddWithValue("@H_ADDRESS", RichTextBox5.Text.ToUpper())
            mycmd.Parameters.AddWithValue("@CELL", RichTextBox6.Text.ToUpper())
            mycmd.Parameters.AddWithValue("@E_ADDRESS", RichTextBox7.Text.ToUpper())
            mycmd.Parameters.AddWithValue("@POSITION", ComboBox1.Text.ToUpper())
            mycmd.Parameters.AddWithValue("@GENDER", gender.ToUpper())
            mycmd.Parameters.AddWithValue("@SALARY", salary)
            mycmd.Parameters.AddWithValue("@M_SALARY", monthly_salary)
            mycmd.Parameters.AddWithValue("@PASSWORDS", default_password.ToUpper())
            mycmd.Parameters.AddWithValue("@DATE", DateAndTime.Now)
            mycmd.ExecuteNonQuery()


        End Using
        mycon.Close()
        Return MsgBox("SUCCESSFULLY ADDED EMPLOYEE")
    End Function
    'function to delete_employees
    Public Function delete_employee()
        mycon = New SqlConnection("Data Source = .\SQLEXPRESS;Initial Catalog = RGIT_DB;Integrated Security = SSPI")
        mycon.Open()
        cmd = "DELETE FROM EMPLOYEES WHERE FIRSTNAME = @F_NAME AND LASTNAME = @L_NAME"
        Using mycmd As New SqlCommand(cmd, mycon)

            mycmd.Parameters.AddWithValue("@F_NAME", RichTextBox9.Text.ToUpper())
            mycmd.Parameters.AddWithValue("@L_NAME", RichTextBox10.Text.ToUpper())

            mycmd.ExecuteNonQuery()


        End Using
        mycon.Close()
        Return MsgBox("SUCCESSFULLY DELETED EMPLOYEE")
    End Function
    'FUNCTION TO SEARCH EMPLOYEES
    Public Function search_employee()
        mycon = New SqlConnection("Data Source = .\SQLEXPRESS;Initial Catalog = RGIT_DB;Integrated Security = SSPI")
        mycon.Open()
        'retreive name

        cmd = "SELECT FIRSTNAME FROM EMPLOYEES WHERE FIRSTNAME = @F_NAME AND LASTNAME = @L_NAME"
        Using mycmd As New SqlCommand(cmd, mycon)

            mycmd.Parameters.AddWithValue("@F_NAME", RichTextBox9.Text.ToUpper())
            mycmd.Parameters.AddWithValue("@L_NAME", RichTextBox10.Text.ToUpper())

            mycmd.ExecuteNonQuery()
            myreader = mycmd.ExecuteReader()
            If myreader.Read() Then
                RichTextBox1.Text = myreader(0)
                myreader.Close()
            End If



        End Using
        'retreive SURNAME

        cmd = "SELECT LASTNAME FROM EMPLOYEES WHERE FIRSTNAME = @F_NAME AND LASTNAME = @L_NAME"
        Using mycmd As New SqlCommand(cmd, mycon)

            mycmd.Parameters.AddWithValue("@F_NAME", RichTextBox9.Text.ToUpper())
            mycmd.Parameters.AddWithValue("@L_NAME", RichTextBox10.Text.ToUpper())

            mycmd.ExecuteNonQuery()
            myreader = mycmd.ExecuteReader()
            If myreader.Read() Then
                RichTextBox2.Text = myreader(0)
                myreader.Close()
            End If



        End Using
        'retreive EMPLOYEE_ID_NUMBER

        cmd = "SELECT ID_NUMBER FROM EMPLOYEES WHERE FIRSTNAME = @F_NAME AND LASTNAME = @L_NAME"
        Using mycmd As New SqlCommand(cmd, mycon)

            mycmd.Parameters.AddWithValue("@F_NAME", RichTextBox9.Text.ToUpper())
            mycmd.Parameters.AddWithValue("@L_NAME", RichTextBox10.Text.ToUpper())

            mycmd.ExecuteNonQuery()
            myreader = mycmd.ExecuteReader()
            If myreader.Read() Then
                RichTextBox3.Text = myreader(0)
                myreader.Close()
            End If



        End Using
        'retreive EMPLOYEE_ID

        cmd = "SELECT EMPLOYEE_ID FROM EMPLOYEES WHERE FIRSTNAME = @F_NAME AND LASTNAME = @L_NAME"
        Using mycmd As New SqlCommand(cmd, mycon)

            mycmd.Parameters.AddWithValue("@F_NAME", RichTextBox9.Text.ToUpper())
            mycmd.Parameters.AddWithValue("@L_NAME", RichTextBox10.Text.ToUpper())

            mycmd.ExecuteNonQuery()
            myreader = mycmd.ExecuteReader()
            If myreader.Read() Then
                RichTextBox4.Text = myreader(0)
                myreader.Close()
            End If



        End Using
        'retreive HOME_ADDRESS

        cmd = "SELECT HOME_ADDRESS FROM EMPLOYEES WHERE FIRSTNAME = @F_NAME AND LASTNAME = @L_NAME"
        Using mycmd As New SqlCommand(cmd, mycon)

            mycmd.Parameters.AddWithValue("@F_NAME", RichTextBox9.Text.ToUpper())
            mycmd.Parameters.AddWithValue("@L_NAME", RichTextBox10.Text.ToUpper())

            mycmd.ExecuteNonQuery()
            myreader = mycmd.ExecuteReader()
            If myreader.Read() Then
                RichTextBox5.Text = myreader(0)
                myreader.Close()
            End If



        End Using
        'retreive CELL_NUMBER

        cmd = "SELECT CELL_NUMBER FROM EMPLOYEES WHERE FIRSTNAME = @F_NAME AND LASTNAME = @L_NAME"
        Using mycmd As New SqlCommand(cmd, mycon)

            mycmd.Parameters.AddWithValue("@F_NAME", RichTextBox9.Text.ToUpper())
            mycmd.Parameters.AddWithValue("@L_NAME", RichTextBox10.Text.ToUpper())

            mycmd.ExecuteNonQuery()
            myreader = mycmd.ExecuteReader()
            If myreader.Read() Then
                RichTextBox6.Text = myreader(0)
                myreader.Close()
            End If



        End Using
        'retreive EMAIL_ADDRESS

        cmd = "SELECT EMAIL_ADDRESS FROM EMPLOYEES WHERE FIRSTNAME = @F_NAME AND LASTNAME = @L_NAME"
        Using mycmd As New SqlCommand(cmd, mycon)

            mycmd.Parameters.AddWithValue("@F_NAME", RichTextBox9.Text.ToUpper())
            mycmd.Parameters.AddWithValue("@L_NAME", RichTextBox10.Text.ToUpper())

            mycmd.ExecuteNonQuery()
            myreader = mycmd.ExecuteReader()
            If myreader.Read() Then
                RichTextBox7.Text = myreader(0)
                myreader.Close()
            End If



        End Using
        'retreive position

        cmd = "SELECT POSITION FROM EMPLOYEES WHERE FIRSTNAME = @F_NAME AND LASTNAME = @L_NAME"
        Using mycmd As New SqlCommand(cmd, mycon)

            mycmd.Parameters.AddWithValue("@F_NAME", RichTextBox9.Text.ToUpper())
            mycmd.Parameters.AddWithValue("@L_NAME", RichTextBox10.Text.ToUpper())

            mycmd.ExecuteNonQuery()
            myreader = mycmd.ExecuteReader()
            If myreader.Read() Then
                ComboBox1.Text = myreader(0)
                myreader.Close()
            End If



        End Using
        'retreive salary

        cmd = "SELECT SALARY FROM EMPLOYEES WHERE FIRSTNAME = @F_NAME AND LASTNAME = @L_NAME"
        Using mycmd As New SqlCommand(cmd, mycon)

            mycmd.Parameters.AddWithValue("@F_NAME", RichTextBox9.Text.ToUpper())
            mycmd.Parameters.AddWithValue("@L_NAME", RichTextBox10.Text.ToUpper())

            mycmd.ExecuteNonQuery()
            myreader = mycmd.ExecuteReader()
            If myreader.Read() Then
                RichTextBox8.Text = myreader(0)
                myreader.Close()
            End If



        End Using
        mycon.Close()
        Return MsgBox("SUCCESSFULLY SEARCHED EMPLOYEE")
    End Function


    Private Sub Button6_Click(sender As Object, e As EventArgs)






    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        'GENERATE RANDOM EMPLOYEE_ID
        employee_id = CInt(Math.Floor((4209999 - 4200000 + 1) * Rnd())) + 4200000
        RichTextBox4.Text = employee_id
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click

        EMPLOYEE_MANAGEMENT.reset()
        Me.Hide()
        EMPLOYEE_MANAGEMENT.Show()
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        delete_employee()
    End Sub

    Private Sub Panel2_Paint(sender As Object, e As PaintEventArgs) Handles Panel2.Paint

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        add_employees()



    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        update_employees()
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        clear_controls()
    End Sub

    Private Sub EMPLOYEE_MANAGEMENT_APP3_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ComboBox1.Items.Add("LECTURER")
        ComboBox1.Items.Add("JANITOR")
        ComboBox1.Items.Add("SECURITY")
        ComboBox1.Items.Add("RECEPTION")
        ComboBox1.Items.Add("MANAGER")
        ComboBox1.Items.Add("CASUAL")


    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        Application.Exit()
    End Sub

    Private Sub Button7_Click_1(sender As Object, e As EventArgs) Handles Button7.Click
        search_employee()
    End Sub
End Class
