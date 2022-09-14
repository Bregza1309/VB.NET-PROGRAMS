Public Class balance

    Private Sub balance_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim balance As Integer
        Dim initialcash As Integer = 0

        balance = deposit.TextBox2.Text
        TextBox1.Text = balance
        deposit.TextBox3.Text = balance
        withdrawal.TextBox4.Text = balance





    End Sub
End Class