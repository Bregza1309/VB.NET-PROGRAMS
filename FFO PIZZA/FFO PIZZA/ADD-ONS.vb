Public Class ADD_ONS

    Dim softDrinks() As String = {"COKE", "SPRITE", "FANTA", "SPAR-LETTA", "AQUA-WATER", "TONIC-WATER"}
    Dim price As Integer
    Dim total As Integer = CInt(PIZZA.Label2.Text)
    Dim milkshakes() As String = {"CHOC-EXPLOSION", "MINTY", "VANILLA-ICING", "PLAIN-MILKY"}
    Dim shakePrice() As Integer = {25, 20, 22, 18}
    Dim iceCream() As String = {"VANILLA", "CHOC", "FRUITY"}
    Dim icePrice() As Integer = {10, 15, 18}
    Dim a1 As ListViewItem




    Private Sub Button15_Click(sender As Object, e As EventArgs) Handles Button15.Click
        Me.Hide()
        Form1.Show()
    End Sub

    Private Sub Button14_Click(sender As Object, e As EventArgs) Handles Button14.Click
        Me.Hide()
        CART.Show()

    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        a1 = CART.ListView1.Items.Add("MILKSHAKE : " & milkshakes(0))
        a1.SubItems.Add("R" & shakePrice(0))
        total += shakePrice(0)
        Label6.Text = "R" & total
        PIZZA.Label2.Text = "R" & total
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        price = 15
        a1 = CART.ListView1.Items.Add("1 litre " & softDrinks(0))
        a1.SubItems.Add("R" & price)
        total += price
        Label6.Text = "R" & total
        PIZZA.Label2.Text = "R" & total
    End Sub

    Private Sub ADD_ONS_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Label6.Text = PIZZA.Label2.Text

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        price = 15
        a1 = CART.ListView1.Items.Add("1 litre " & softDrinks(1))
        a1.SubItems.Add("R" & price)
        total += price
        Label6.Text = "R" & total
        PIZZA.Label2.Text = "R" & total
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        price = 15
        a1 = CART.ListView1.Items.Add("1 litre " & softDrinks(2))
        a1.SubItems.Add("R" & price)
        total += price
        Label6.Text = "R" & total
        PIZZA.Label2.Text = "R" & total
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        price = 15
        a1 = CART.ListView1.Items.Add("1 litre " & softDrinks(3))
        a1.SubItems.Add("R" & price)
        total += price
        Label6.Text = "R" & total
        PIZZA.Label2.Text = "R" & total
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        price = 10
        a1 = CART.ListView1.Items.Add("1 litre " & softDrinks(4))
        a1.SubItems.Add("R" & price)
        total += price
        Label6.Text = "R" & total
        PIZZA.Label2.Text = "R" & total
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        price = 15
        a1 = CART.ListView1.Items.Add("1 litre " & softDrinks(5))
        a1.SubItems.Add("R" & price)
        total += price
        Label6.Text = "R" & total
        PIZZA.Label2.Text = "R" & total
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        a1 = CART.ListView1.Items.Add("MILKSHAKE : " & milkshakes(1))
        a1.SubItems.Add("R" & shakePrice(1))
        total += shakePrice(1)
        Label6.Text = "R" & total
        PIZZA.Label2.Text = "R" & total
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        a1 = CART.ListView1.Items.Add("MILKSHAKE : " & milkshakes(2))
        a1.SubItems.Add("R" & shakePrice(2))
        total += shakePrice(2)
        Label6.Text = "R" & total
        PIZZA.Label2.Text = "R" & total
    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        a1 = CART.ListView1.Items.Add("MILKSHAKE : " & milkshakes(3))
        a1.SubItems.Add("R" & shakePrice(3))
        total += shakePrice(3)
        Label6.Text = "R" & total
        PIZZA.Label2.Text = "R" & total
    End Sub

    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click
        a1 = CART.ListView1.Items.Add("ICE-CREAM-FLAVOR: " & iceCream(0))
        a1.SubItems.Add("R" & icePrice(0))
        total += icePrice(0)
        Label6.Text = "R" & total
        PIZZA.Label2.Text = "R" & total
    End Sub

    Private Sub Button13_Click(sender As Object, e As EventArgs) Handles Button13.Click
        a1 = CART.ListView1.Items.Add("ICE-CREAM-FLAVOR: " & iceCream(1))
        a1.SubItems.Add("R" & icePrice(1))
        total += icePrice(1)
        Label6.Text = "R" & total
        PIZZA.Label2.Text = "R" & total
    End Sub

    Private Sub Button12_Click(sender As Object, e As EventArgs) Handles Button12.Click
        a1 = CART.ListView1.Items.Add("ICE-CREAM-FLAVOR: " & iceCream(2))
        a1.SubItems.Add("R" & icePrice(2))
        total += icePrice(2)
        Label6.Text = "R" & total
        PIZZA.Label2.Text = "R" & total
    End Sub

    Private Sub GroupBox4_Enter(sender As Object, e As EventArgs) Handles GroupBox4.Enter

    End Sub

    Private Sub Button16_Click(sender As Object, e As EventArgs) Handles Button16.Click
        Me.Hide()
        PIZZA.Show()
    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub
End Class