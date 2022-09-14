Public Class ADMIN_MENU

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Hide()
        students.Show()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Hide()
        EMPLOYEE_MANAGEMENT.reset()
        EMPLOYEE_MANAGEMENT.Show()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.Hide()
        DISPLAY_USERS.reset()
        DISPLAY_USERS.Show()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Me.Hide()
        ADMIN_PROFILE.retreive_profile()
        ADMIN_PROFILE.Show()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        AUTHENTICATION.reset()
        Me.Hide()
        AUTHENTICATION.Show()
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Application.Exit()
    End Sub
End Class