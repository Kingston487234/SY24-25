Class MainWindow
    Private Sub Button_Click(sender As Object, e As RoutedEventArgs)
        cheese.Visibility = Visibility.Visible
        meatball.Visibility = Visibility.Hidden
        barbuque.Visibility = Visibility.Hidden
        label1.Content = "cheese pizza"
        label2.Content = "over 500 years old"
        label3.Content = "The us consums about 3 billion cheese pizza each year"
        label4.Content = "Raffaele Esposito made cheese pizza"
    End Sub

    Private Sub Button_Click_1(sender As Object, e As RoutedEventArgs)
        cheese.Visibility = Visibility.Hidden
        meatball.Visibility = Visibility.Visible
        barbuque.Visibility = Visibility.Hidden
        label1.Content = " meat lovers pizza"
        label2.Content = "Raffaele Esposito also made meat lovers pizza"
        label3.Content = " has 16% of protein"
        label4.Content = "One of the most consumed pizzas in the US"
    End Sub

    Private Sub Button_Click_2(sender As Object, e As RoutedEventArgs)
        cheese.Visibility = Visibility.Hidden
        meatball.Visibility = Visibility.Hidden
        barbuque.Visibility = Visibility.Visible
        label1.Content = "barbuque pizza"
        label2.Content = "Horest Coletta at Coletta's restrunt"
        label3.Content = "one of the most underated pizza"
        label4.Content = "My favorite type of pizza"
    End Sub
End Class
