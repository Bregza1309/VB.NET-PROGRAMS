Imports System.Data.SqlClient
Imports System.Data.Sql
Public Class Form1
    Private mycon As SqlConnection
    Private mycmd As SqlCommand
    Private myreader As SqlDataReader
    Private myadapter As SqlDataAdapter
    Dim cmd As String
    Dim gender As String
    Dim fees As Integer
    Dim reg_date As String = DateAndTime.Now
    Dim default_pwd As String = "STUDENT@123"
    Private command As String
    Private results As String
    Dim ds As DataSet

    'function to add new students to the sql database  
    Public Function add_student()
        Try

            'SELECT GENDER
            If RadioButton1.Checked Then
                gender = "MALE"
            ElseIf RadioButton2.Checked Then
                gender = "FEMALE"

            End If

        'call course_fees() function
        course_fees()

        'CONNECTION STRING 
        mycon = New SqlConnection("Data Source = .\SQLEXPRESS;Initial Catalog = RGIT_DB;Integrated Security=SSPI")
        mycon.Open()
        'SQL COMMAND TO ADD STUDENT
        command = "INSERT INTO STUDENTS VALUES (@student_id,@f_name,@l_name,@password,@id,@cell,@home_address,@email_address,@fees,@gender,@course,@date)"
        Using mycmd As New SqlCommand(command, mycon)
            ' ADD PARAMETERS TO THE SQL COMMAND
            mycmd.Parameters.AddWithValue("@f_name", TextBox3.Text.ToUpper())
            mycmd.Parameters.AddWithValue("@l_name", TextBox4.Text.ToUpper())
            mycmd.Parameters.AddWithValue("@id", TextBox5.Text.ToUpper())
            mycmd.Parameters.AddWithValue("@student_id", CInt(TextBox6.Text))
            mycmd.Parameters.AddWithValue("@gender", gender)
            mycmd.Parameters.AddWithValue("@home_address", RichTextBox1.Text.ToUpper())
            mycmd.Parameters.AddWithValue("@cell", TextBox7.Text.ToUpper())
            mycmd.Parameters.AddWithValue("@email_address", RichTextBox2.Text.ToUpper())
            mycmd.Parameters.AddWithValue("@course", ComboBox1.Text.ToUpper())
            mycmd.Parameters.AddWithValue("@fees", fees)
            mycmd.Parameters.AddWithValue("@date", reg_date)
            mycmd.Parameters.AddWithValue("@password", default_pwd)
            mycmd.ExecuteNonQuery()

        End Using

        mycon.Close()
            Return MsgBox("STUDENT REGISTERED SUCCESSFULLY")
        Catch ex As InvalidCastException
            MsgBox("FILL IN MISSING DETAILS")
        End Try

    End Function
    'function to retreive_student information
    Public Function search_student()
        Try

            If TextBox1.Text = "" And TextBox2.Text = "" Then
                Return MsgBox("FILL IN STUDENT'S NAME AND SURNAME ")
            Else
                mycon = New SqlConnection("Data Source = .\SQLEXPRESS;Initial Catalog = RGIT_DB;Integrated Security = SSPI")
                mycon.Open()
                'retreive name

                cmd = "SELECT FIRSTNAME FROM STUDENTS WHERE FIRSTNAME = @F_NAME AND LASTNAME = @L_NAME"
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
                'retreive SURNAME

                cmd = "SELECT LASTNAME FROM STUDENTS WHERE FIRSTNAME = @F_NAME AND LASTNAME = @L_NAME"
                Using mycmd As New SqlCommand(cmd, mycon)

                    mycmd.Parameters.AddWithValue("@F_NAME", TextBox1.Text.ToUpper())
                    mycmd.Parameters.AddWithValue("@L_NAME", TextBox2.Text.ToUpper())


                    mycmd.ExecuteNonQuery()
                    myreader = mycmd.ExecuteReader()
                    If myreader.Read() Then
                        TextBox4.Text = myreader(0)
                        myreader.Close()
                    End If



                End Using
                'retreive EMPLOYEE_ID_NUMBER

                cmd = "SELECT ID_NUMBER FROM STUDENTS WHERE FIRSTNAME = @F_NAME AND LASTNAME = @L_NAME"
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
                'retreive EMPLOYEE_ID

                cmd = "SELECT STUDENT_ID FROM STUDENTS WHERE FIRSTNAME = @F_NAME AND LASTNAME = @L_NAME"
                Using mycmd As New SqlCommand(cmd, mycon)


                    mycmd.Parameters.AddWithValue("@F_NAME", TextBox1.Text.ToUpper())
                    mycmd.Parameters.AddWithValue("@L_NAME", TextBox2.Text.ToUpper())

                    mycmd.ExecuteNonQuery()
                    myreader = mycmd.ExecuteReader()
                    If myreader.Read() Then
                        TextBox6.Text = myreader(0)
                        myreader.Close()
                    End If



                End Using
                'retreive HOME_ADDRESS

                cmd = "SELECT HOME_ADDRESS FROM STUDENTS WHERE FIRSTNAME = @F_NAME AND LASTNAME = @L_NAME"
                Using mycmd As New SqlCommand(cmd, mycon)


                    mycmd.Parameters.AddWithValue("@F_NAME", TextBox1.Text.ToUpper())
                    mycmd.Parameters.AddWithValue("@L_NAME", TextBox2.Text.ToUpper())

                    mycmd.ExecuteNonQuery()
                    myreader = mycmd.ExecuteReader()
                    If myreader.Read() Then
                        RichTextBox1.Text = myreader(0)
                        myreader.Close()
                    End If



                End Using
                'retreive CELL_NUMBER

                cmd = "SELECT CELL_NUMBER FROM STUDENTS WHERE FIRSTNAME = @F_NAME AND LASTNAME = @L_NAME"
                Using mycmd As New SqlCommand(cmd, mycon)


                    mycmd.Parameters.AddWithValue("@F_NAME", TextBox1.Text.ToUpper())
                    mycmd.Parameters.AddWithValue("@L_NAME", TextBox2.Text.ToUpper())

                    mycmd.ExecuteNonQuery()
                    myreader = mycmd.ExecuteReader()
                    If myreader.Read() Then
                        TextBox7.Text = myreader(0)
                        myreader.Close()
                    End If



                End Using
                'retreive EMAIL_ADDRESS

                cmd = "SELECT EMAIL_ADDRESS FROM STUDENTS WHERE FIRSTNAME = @F_NAME AND LASTNAME = @L_NAME"
                Using mycmd As New SqlCommand(cmd, mycon)

                    mycmd.Parameters.AddWithValue("@F_NAME", TextBox1.Text.ToUpper())
                    mycmd.Parameters.AddWithValue("@L_NAME", TextBox2.Text.ToUpper())

                    mycmd.ExecuteNonQuery()
                    myreader = mycmd.ExecuteReader()
                    If myreader.Read() Then
                        RichTextBox2.Text = myreader(0)
                        myreader.Close()
                    End If



                End Using
                'retreive course

                cmd = "SELECT COURSE FROM STUDENTS WHERE FIRSTNAME = @F_NAME AND LASTNAME = @L_NAME"
                Using mycmd As New SqlCommand(cmd, mycon)


                    mycmd.Parameters.AddWithValue("@F_NAME", TextBox1.Text.ToUpper())
                    mycmd.Parameters.AddWithValue("@L_NAME", TextBox2.Text.ToUpper())

                    mycmd.ExecuteNonQuery()
                    myreader = mycmd.ExecuteReader()
                    If myreader.Read() Then
                        ComboBox1.Text = myreader(0)
                        myreader.Close()
                    End If



                End Using
                'retreive fees

                cmd = "SELECT FEES FROM STUDENTS WHERE FIRSTNAME = @f_name AND LASTNAME = @l_name"
                Using mycmd As New SqlCommand(cmd, mycon)
                    mycmd.Parameters.AddWithValue("@F_NAME", TextBox1.Text.ToUpper())
                    mycmd.Parameters.AddWithValue("@L_NAME", TextBox2.Text.ToUpper())


                    mycmd.ExecuteNonQuery()
                    myreader = mycmd.ExecuteReader()
                    If myreader.Read() Then
                        TextBox8.Text = myreader(0)
                        myreader.Close()
                    End If
                End Using
                'retreive GENDER

                cmd = "SELECT GENDER FROM STUDENTS WHERE FIRSTNAME = @f_name AND LASTNAME = @l_name"
                Using mycmd As New SqlCommand(cmd, mycon)
                    mycmd.Parameters.AddWithValue("@F_NAME", TextBox1.Text.ToUpper())
                    mycmd.Parameters.AddWithValue("@L_NAME", TextBox2.Text.ToUpper())


                    mycmd.ExecuteNonQuery()
                    myreader = mycmd.ExecuteReader()
                    If myreader.Read() Then
                        If myreader(0) = "MALE" Then
                            RadioButton1.Checked = True
                        ElseIf myreader(0) = "FEMALE" Then
                            RadioButton2.Checked = True
                        End If
                        myreader.Close()
                    End If
                End Using
                mycon.Close()
                Return MsgBox("SUCCESSFULLY SEARCHED STUDENT")
            End If
         
        Catch ex As InvalidOperationException
            MsgBox("STUDENT_NOT_FOUND")

        End Try
    End Function
    'function to UPDATE  students to the sql database  
    Public Function update_student()
        Try

    
            If TextBox1.Text = "" And TextBox2.Text = "" Then
                MsgBox("SEARCH STUDENT TO EDIT")
            Else
                'SELECT GENDER
                If RadioButton1.Checked Then
                    gender = "MALE"
                ElseIf RadioButton2.Checked Then
                    gender = "FEMALE"

                End If
                'call course_fees() function
                course_fees()

                'CONNECTION STRING 
                mycon = New SqlConnection("Data Source = .\SQLEXPRESS;Initial Catalog = RGIT_DB;Integrated Security=SSPI")
                mycon.Open()
                'SQL COMMAND TO UPDATE STUDENT
                command = "UPDATE STUDENTS SET FIRSTNAME = @f_name,LASTNAME=@l_name,STUDENT_ID = @student_id,ID_NUMBER = @id,GENDER = @gender,HOME_ADDRESS =@home_address,EMAIL_ADDRESS =@email_address,CELL_NUMBER = @cell,COURSE = @course,FEES = @fees WHERE FIRSTNAME = @Fname AND LASTNAME =@Lname"
                Using mycmd As New SqlCommand(command, mycon)
                    ' ADD PARAMETERS TO THE SQL COMMAND
                    mycmd.Parameters.AddWithValue("@f_name", TextBox3.Text.ToUpper())
                    mycmd.Parameters.AddWithValue("@l_name", TextBox4.Text.ToUpper())
                    mycmd.Parameters.AddWithValue("@id", TextBox5.Text.ToUpper())
                    mycmd.Parameters.AddWithValue("@student_id", CInt(TextBox6.Text))
                    mycmd.Parameters.AddWithValue("@gender", gender)
                    mycmd.Parameters.AddWithValue("@home_address", RichTextBox1.Text.ToUpper())
                    mycmd.Parameters.AddWithValue("@cell", TextBox7.Text.ToUpper())
                    mycmd.Parameters.AddWithValue("@email_address", RichTextBox2.Text.ToUpper())
                    mycmd.Parameters.AddWithValue("@course", ComboBox1.Text.ToUpper())
                    mycmd.Parameters.AddWithValue("@fees", fees)
                    mycmd.Parameters.AddWithValue("@Fname", TextBox1.Text.ToUpper())
                    mycmd.Parameters.AddWithValue("@Lname", TextBox2.Text.ToUpper())
                    mycmd.ExecuteNonQuery()

                End Using

                mycon.Close()
                Return MsgBox("STUDENT UPDATED SUCCESSFULLY")
            End If
        Catch ex As InvalidCastException
            MsgBox("FILL IN MISSING DETAILS")
        Catch ex As SqlException
            MsgBox("SOME DETAILS MISSING")
        End Try



    End Function
    Public Function delete_student()
        If TextBox1.Text = "" And TextBox2.Text = "" Then
            MsgBox("SEARCH STUDENT TO DELETE")
        Else

            mycon = New SqlConnection("Data Source = .\SQLEXPRESS;Initial Catalog = RGIT_DB;Integrated Security = SSPI")
            mycon.Open()
            command = "DELETE FROM STUDENTS WHERE FIRSTNAME=@f_name AND LASTNAME = @l_name"
            Using mycmd As New SqlCommand(command, mycon)
                mycmd.Parameters.AddWithValue("@f_name", TextBox1.Text.ToUpper())
                mycmd.Parameters.AddWithValue("@l_name", TextBox2.Text.ToUpper())
                mycmd.ExecuteNonQuery()

            End Using
            mycon.Close()
            Return MsgBox("SUCCESSFULLY DELETED STUDENT")
        End If

    End Function
    Public Function display_students()
        mycon = New SqlConnection("Data Source = .\SQLEXPRESS;Initial Catalog =RGIT_DB;Integrated Security= SSPI")
        Dim row As Integer
        Dim msg As String
        mycon.Open()
        command = "SELECT STUDENT_ID,FIRSTNAME,LASTNAME,ID_NUMBER,COURSE,FEES,GENDER FROM STUDENTS "
        Using mycmd As New SqlCommand(command, mycon)
            mycmd.ExecuteNonQuery()
            Using myadapter As New SqlDataAdapter(mycmd)
                Using ds As New DataSet()
                    myadapter.Fill(ds)
                    students.DataGridView1.DataSource = ds.Tables(0)
                    row = students.DataGridView1.RowCount - 1
                    msg = CStr(row) & " STUDENTS REGISTERED"
                End Using
            End Using
        End Using
        Me.Hide()
        students.Show()
        mycon.Close()

        Return MsgBox(msg)

    End Function
    'FUNCTION TO RETREIVE COURSE FEES
    Public Function course_fees()
        mycon = New SqlConnection("Data Source = .\SQLEXPRESS;Initial Catalog = RGIT_DB;Integrated Security = SSPI")
        mycon.Open()
        cmd = "SELECT COURSE_FEES FROM COURSES WHERE COURSE_NAME = @NAME "
        Using mycmd As New SqlCommand(cmd, mycon)
            mycmd.Parameters.AddWithValue("@NAME", ComboBox1.Text.ToUpper())
            mycmd.ExecuteNonQuery()
            myreader = mycmd.ExecuteReader()
            If myreader.Read() Then
                fees = CInt(myreader(0))
            End If
        End Using
        mycon.Close()

    End Function
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
    Public Function reset()
        TextBox1.Clear()
        TextBox2.Clear()
        TextBox3.Clear()
        TextBox4.Clear()
        TextBox5.Clear()
        TextBox6.Clear()
        TextBox7.Clear()
        TextBox8.Clear()
        RichTextBox1.Clear()
        RichTextBox2.Clear()
        ComboBox1.ResetText()
        RadioButton1.Checked = False
        RadioButton2.Checked = False
    End Function
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        available_courses()

    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        Dim student_id As Integer = CInt(Math.Floor(950999999 - 950000000 + 1) * Rnd()) + 950000000
        TextBox6.Text = student_id


    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
       
        

        'call add_student() function
        add_student()

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click


        search_student()



    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        'SELECT GENDER
        If RadioButton1.Checked Then
            gender = "MALE"
        ElseIf RadioButton2.Checked Then
            gender = "FEMALE"

        End If

        'FEES STRUCTURE ACCORDING TO COURSE
        If ComboBox1.Text = "BSC INFORMATION TECHNOLOGY" Or ComboBox1.Text = "BSC INFORMATION SYSTEMS" Or ComboBox1.Text = "BSC BENG MECHANICAL ENGINEERING" Then
            fees = 35000
        ElseIf ComboBox1.Text = "BSC POLITICAL SCIENCE" Or ComboBox1.Text = "BSC BIO-TECHNOLOGY" Then
            fees = 30000
        ElseIf ComboBox1.Text = "DIT INFORMATION TECHNOLOGY" Then
            fees = 25000

        End If
        'CALL UPDATE FUNCTION
        update_student()
    End Sub

    Private Sub TextBox8_TextChanged(sender As Object, e As EventArgs) Handles TextBox8.TextChanged

    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        delete_student()
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        reset()
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        Application.Exit()

    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        display_students()
    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        Me.reset()
        Me.Hide()
        FEES_MANAGEMENT.Show()
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        Me.reset()
        If AUTHENTICATION.RadioButton2.Checked Then
            Me.Hide()
            ADMIN_MENU.Show()
        Else
            Me.Hide()
            USER_MENU.Show()
        End If
    End Sub
End Class
