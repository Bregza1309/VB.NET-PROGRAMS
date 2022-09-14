Public Class CART
    Dim cash, balance, vat, checkout As Integer
    Dim a1, a2, a3, a4 As ListViewItem

    Private Sub ListBox1_SelectedIndexChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub CART_Load(sender As Object, e As EventArgs) Handles MyBase.Load


    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Hide()
        Form1.Show()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Do While ListView1.Items.Count <> 0
            ListView1.Items.Remove(ListView1.Items(0))
        Loop
        PIZZA.Label2.Text = 0
        ADD_ONS.Label6.Text = 0


        RichTextBox1.Clear()








    End Sub

    Private Sub Button13_Click(sender As Object, e As EventArgs) Handles Button13.Click
        Try
        vat = 5 / 100 * PIZZA.Label2.Text
        balance = PIZZA.Label2.Text + vat
        cash = RichTextBox1.Text
        If cash >= balance Then
            checkout = cash - balance
            a1 = ListView1.Items.Add("-------------------------------------------------------------------")
            a1.SubItems.Add("----------")
            a2 = ListView1.Items.Add("VAT")
            a2.SubItems.Add("5%")
            a3 = ListView1.Items.Add("TOTAL")
            a3.SubItems.Add("R" & balance)
            a2 = ListView1.Items.Add("AMOUNT-PAID")
            a2.SubItems.Add(cash)
            a2 = ListView1.Items.Add("CHANGE ")
            a2.SubItems.Add("R" & checkout)
            a2 = ListView1.Items.Add("CASHIER")
            a2.SubItems.Add(Form1.Label5.Text)
            a1 = ListView1.Items.Add("TIME")
            a1.SubItems.Add(DateAndTime.Now.ToString)
            a1 = ListView1.Items.Add("-------------------------------------------------------------------")
            a1.SubItems.Add("----------")
            MsgBox("THANK YOU FOR SHOPPING AT BLAZEAWAY")
        Else
            checkout = balance - cash
            MsgBox("INSUFFICIENT-FUNDS TO MAKE A PURCHASE ADD EXTRA R" & checkout)
        End If
        Catch ex As Exception
            MsgBox("PLEASE ENTER RECEIVED AMOUNT!")
        End Try
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.Hide()
        PIZZA.Show()

    End Sub
End Class