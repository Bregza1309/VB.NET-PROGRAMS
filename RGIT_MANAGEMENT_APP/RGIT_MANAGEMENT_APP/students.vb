Imports System.Data.SqlClient
Imports System.Data.Sql
Public Class students
    Private mycon As SqlConnection
    Private mycmd As SqlCommand
    Private myreader As SqlDataReader
    Private myadapter As SqlDataAdapter
    Private command As String
    Dim ds As DataSet
    Dim row As Integer
    Dim msg As String


    Public Function search()
        'connection string to sql database
        mycon = New SqlConnection("Data Source= .\SQLEXPRESS;Initial Catalog=RGIT_DB;Integrated Security = SSPI")
        mycon.Open()
        'sql command to search data using name and surname
        command = "SELECT STUDENT_ID,FIRSTNAME,LASTNAME,ID_NUMBER,COURSE,FEES,GENDER,REGISTRATION_DATE FROM STUDENTS WHERE FIRSTNAME = @f_name AND LASTNAME =@l_name"


        Using mycmd As New SqlCommand(command, mycon)
            mycmd.Parameters.AddWithValue("@f_name", TextBox1.Text.ToUpper())
            mycmd.Parameters.AddWithValue("@l_name", TextBox2.Text.ToUpper())
            mycmd.ExecuteNonQuery()
            Using myadapter As New SqlDataAdapter(mycmd)
                Using ds As New DataSet()
                    myadapter.Fill(ds)
                    DataGridView1.DataSource = ds.Tables(0)
                    row = DataGridView1.RowCount - 1
                    If row = 0 Then
                        Return MsgBox(" STUDENT_NOT_FOUND")
                        

                    End If



                End Using
            End Using
        End Using
        mycon.Close()

        Return MsgBox("SUCCESSFULLY SEARCHED STUDENT")
    End Function

    Public Function display_IT_students()
        'connection string to sql database
        mycon = New SqlConnection("Data Source= .\SQLEXPRESS;Initial Catalog=RGIT_DB;Integrated Security = SSPI")
        mycon.Open()
        'sql command to search data using name and surname
        command = "SELECT STUDENT_ID,FIRSTNAME,LASTNAME,ID_NUMBER,COURSE,FEES,GENDER,REGISTRATION_DATE FROM STUDENTS WHERE COURSE = 'BSC INFORMATION TECHNOLOGY'"


        Using mycmd As New SqlCommand(command, mycon)

            'EXECUTE SQL QUERY
            mycmd.ExecuteNonQuery()
            Using myadapter As New SqlDataAdapter(mycmd)
                Using ds As New DataSet()
                    myadapter.Fill(ds)
                    DataGridView1.DataSource = ds.Tables(0)
                    row = DataGridView1.RowCount - 1

                    msg = CStr(row) + " BSC_INFORMATION_TECHNOLOGY REGISTERED STUDENTS"



                End Using
            End Using
        End Using
        mycon.Close()

        Return MsgBox(msg)
    End Function
    'function to display is_student()
    Public Function display_IS_students()
        'connection string to sql database
        mycon = New SqlConnection("Data Source= .\SQLEXPRESS;Initial Catalog=RGIT_DB;Integrated Security = SSPI")
        mycon.Open()
        'sql command to search data using name and surname
        command = "SELECT STUDENT_ID,FIRSTNAME,LASTNAME,ID_NUMBER,COURSE,FEES,GENDER,REGISTRATION_DATE FROM STUDENTS WHERE COURSE = 'BSC INFORMATION SYSTEMS'"


        Using mycmd As New SqlCommand(command, mycon)

            'EXECUTE SQL QUERY
            mycmd.ExecuteNonQuery()
            Using myadapter As New SqlDataAdapter(mycmd)
                Using ds As New DataSet()
                    myadapter.Fill(ds)
                    DataGridView1.DataSource = ds.Tables(0)
                    row = DataGridView1.RowCount - 1

                    msg = CStr(row) + " BSC_INFORMATION_SYSTEMS REGISTERED STUDENTS"



                End Using
            End Using
        End Using
        mycon.Close()

        Return MsgBox(msg)
    End Function
    'function to display PS_student()
    Public Function display_PS_students()
        'connection string to sql database
        mycon = New SqlConnection("Data Source= .\SQLEXPRESS;Initial Catalog=RGIT_DB;Integrated Security = SSPI")
        mycon.Open()
        'sql command to search data using name and surname
        command = "SELECT STUDENT_ID,FIRSTNAME,LASTNAME,ID_NUMBER,COURSE,FEES,GENDER,REGISTRATION_DATE FROM STUDENTS WHERE COURSE = 'BSC POLITICAL SCIENCE'"


        Using mycmd As New SqlCommand(command, mycon)

            'EXECUTE SQL QUERY
            mycmd.ExecuteNonQuery()
            Using myadapter As New SqlDataAdapter(mycmd)
                Using ds As New DataSet()
                    myadapter.Fill(ds)
                    DataGridView1.DataSource = ds.Tables(0)
                    row = DataGridView1.RowCount - 1

                    msg = CStr(row) + " BSC_POLITICAL_SCIENCE REGISTERED STUDENTS"



                End Using
            End Using
        End Using
        mycon.Close()

        Return MsgBox(msg)
    End Function
    'function to display MECH_student()
    Public Function display_MEC_students()
        'connection string to sql database
        mycon = New SqlConnection("Data Source= .\SQLEXPRESS;Initial Catalog=RGIT_DB;Integrated Security = SSPI")
        mycon.Open()
        'sql command to search data using name and surname
        command = "SELECT STUDENT_ID,FIRSTNAME,LASTNAME,ID_NUMBER,COURSE,FEES,GENDER,REGISTRATION_DATE FROM STUDENTS WHERE COURSE = 'BENG MECHANICAL ENGINEERING'"


        Using mycmd As New SqlCommand(command, mycon)

            'EXECUTE SQL QUERY
            mycmd.ExecuteNonQuery()
            Using myadapter As New SqlDataAdapter(mycmd)
                Using ds As New DataSet()
                    myadapter.Fill(ds)
                    DataGridView1.DataSource = ds.Tables(0)
                    row = DataGridView1.RowCount - 1

                    msg = CStr(row) + " BENG_MECHANICAL_ENGINEERING_REGISTERED_STUDENTS"



                End Using
            End Using
        End Using
        mycon.Close()

        Return MsgBox(msg)
    End Function
    'function to display BIO-TECH_student()
    Public Function display_BT_students()
        'connection string to sql database
        mycon = New SqlConnection("Data Source= .\SQLEXPRESS;Initial Catalog=RGIT_DB;Integrated Security = SSPI")
        mycon.Open()
        'sql command to search data using name and surname
        command = "SELECT STUDENT_ID,FIRSTNAME,LASTNAME,ID_NUMBER,COURSE,FEES,GENDER,REGISTRATION_DATE FROM STUDENTS WHERE COURSE = 'BSC BIO-TECHNOLOGY'"


        Using mycmd As New SqlCommand(command, mycon)

            'EXECUTE SQL QUERY
            mycmd.ExecuteNonQuery()
            Using myadapter As New SqlDataAdapter(mycmd)
                Using ds As New DataSet()
                    myadapter.Fill(ds)
                    DataGridView1.DataSource = ds.Tables(0)
                    row = DataGridView1.RowCount - 1

                    msg = CStr(row) + " BSC BIO-TECHNOLOGY_REGISTERED_STUDENTS"



                End Using
            End Using
        End Using
        mycon.Close()

        Return MsgBox(msg)
    End Function
    'function to display DIT-IT_student()
    Public Function display_DIT_students()
        'connection string to sql database
        mycon = New SqlConnection("Data Source= .\SQLEXPRESS;Initial Catalog=RGIT_DB;Integrated Security = SSPI")
        mycon.Open()
        'sql command to search data using name and surname
        command = "SELECT STUDENT_ID,FIRSTNAME,LASTNAME,ID_NUMBER,COURSE,FEES,GENDER,REGISTRATION_DATE FROM STUDENTS WHERE COURSE = 'DIT INFORMATION TECHNOLOGY'"


        Using mycmd As New SqlCommand(command, mycon)

            'EXECUTE SQL QUERY
            mycmd.ExecuteNonQuery()
            Using myadapter As New SqlDataAdapter(mycmd)
                Using ds As New DataSet()
                    myadapter.Fill(ds)
                    DataGridView1.DataSource = ds.Tables(0)
                    row = DataGridView1.RowCount - 1

                    msg = CStr(row) + " DIT INFORMATION TECHNOLOGY _REGISTERED_STUDENTS"



                End Using
            End Using
        End Using
        mycon.Close()

        Return MsgBox(msg)
    End Function
    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        display_DIT_students()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        'ASSIGN SEARCH() TO SEARCH_BUTTON
        search()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        'ASSIGN display_it_students() TO SEARCH_BUTTON
        display_IT_students()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.Hide()
        Form1.Show()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        'assign display_is_students() TO bsc_Is_BUTTON
        display_IS_students()
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        'assign display_PS_students() TO bsc_PS_BUTTON
        display_PS_students()
    End Sub

    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click
        display_MEC_students()
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        display_BT_students()
    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click

        Form1.display_students()

        TextBox1.Clear()
        TextBox2.Clear()
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        Application.Exit()
    End Sub

    Private Sub Button12_Click(sender As Object, e As EventArgs) Handles Button12.Click
        Me.Hide()
        FEES_MANAGEMENT.Show()

    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
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