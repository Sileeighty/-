using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;

namespace PZww
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        // Разрешаем вводить только буквы и пробелы в поле ФИО
        private void FullNameTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !Regex.IsMatch(e.Text, @"^[а-яА-Яa-zA-Z\s]+$");
            if (e.Handled)
            {
                ResultTextBlock.Text = "ФИО может содержать только буквы";
                ResultTextBlock.Foreground = System.Windows.Media.Brushes.Red;
            }
            else
            {
                ResultTextBlock.Text = "";
            }
        }

        // Разрешаем вводить только цифры в поле Номер телефона
        private void PhoneTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !Regex.IsMatch(e.Text, @"^\d+$");
            if (e.Handled)
            {
                ResultTextBlock.Text = "Номер телефона должен содержать только цифры";
                ResultTextBlock.Foreground = System.Windows.Media.Brushes.Red;
            }
            else
            {
                ResultTextBlock.Text = "";
            }
        }

        // Обработка кнопки "Купить билет"
        private void BuyTicketButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(FullNameTextBox.Text) || string.IsNullOrWhiteSpace(PhoneTextBox.Text))
            {
                ResultTextBlock.Text = "Пожалуйста, заполните все поля";
                ResultTextBlock.Foreground = System.Windows.Media.Brushes.Red;
            }
            else
            {
                ResultTextBlock.Text = "Спасибо за покупку!";
                ResultTextBlock.Foreground = System.Windows.Media.Brushes.Green;
            }
        }
    }
}
