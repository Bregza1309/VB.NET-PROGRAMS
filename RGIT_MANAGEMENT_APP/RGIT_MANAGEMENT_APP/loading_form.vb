Public Class loading_form

    Public Function load_project()
        ProgressBar1.Value = ProgressBar1.Value + 1
        If ProgressBar1.Value = 100 Then
            Timer1.Enabled = False
            Label1.Text = "APPLICATION_LOADED_SUCCESSFULLY"
            Label4.Text = "VISUAL_BASIC.NET"
            Label5.Text = "SQL_EXPRESS"
            Label7.Text = "BRENDON_MUCHESA"
            MsgBox("WELCOME PRESS OK TO LOGIN")
            Me.Hide()
            AUTHENTICATION.Show()

        End If
  

      
    End Function

    Private Sub GroupBox1_Enter(sender As Object, e As EventArgs) Handles GroupBox1.Enter

    End Sub

    Private Sub loading_form_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Timer1.Enabled = True
        ProgressBar1.Maximum = 100
        ProgressBar1.Minimum = 0
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        load_project()
    End Sub
End Class