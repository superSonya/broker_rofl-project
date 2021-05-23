using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace UP
{
    /// <summary>
    /// Логика взаимодействия для RegistrationWindow.xaml
    /// </summary>
    public partial class RegistrationWindow : Window
    {
        public static broker_copyEntities1 db = new broker_copyEntities1();
        public RegistrationWindow()
        {
            InitializeComponent();
        }

        private void registration_Click(object sender, RoutedEventArgs e)
        {
            if (login.Text == "" || password.Text == "")
            {
                Empty("*Ошибка, заполните поля!");
            }
            else
            {
                db.Client.Add(new Client() { 
                
                    Login = login.Text.Trim().TrimStart().TrimEnd(),
                    Password = password.Text.Trim().TrimStart().TrimEnd()
                
                });
                MessageBox.Show("Пользователь успешно зарегистрирован!");
                db.SaveChanges();
            }
        }
        public void Empty(string message) { error.Content = message; }
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Regex.IsMatch(login.Text, "[^А-Я-а-я---a-z-A-Z- -]"))
            {
                Empty("*Вводите только строковые символы!");
                login.Text = login.Text.Remove(login.Text.Length - 1);
                login.SelectionStart = login.Text.Length;
            }
            if (Regex.IsMatch(login.Text, @"^\W"))
            {
                Empty("*Вводите только строковые символы!");
                login.Text = login.Text.Remove(login.Text.Length - 1);
                login.SelectionStart = login.Text.Length;
            }
            if (login.Text.Contains(@"\") || login.Text.Contains(@"-"))
            {
                Empty("*Вводите только строковые символы!");
                login.Text = login.Text.Remove(login.Text.Length - 1);
                login.SelectionStart = login.Text.Length;
            }
        }

        private void TextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {
            if (Regex.IsMatch(password.Text, "[^А-Я-а-я---a-z-A-Z- -]"))
            {
                Empty("*Вводите только строковые символы!");
                password.Text = password.Text.Remove(password.Text.Length - 1);
                password.SelectionStart = password.Text.Length;
            }
            if (Regex.IsMatch(password.Text, @"^\W"))
            {
                Empty("*Вводите только строковые символы!");
                password.Text = password.Text.Remove(password.Text.Length - 1);
                password.SelectionStart = password.Text.Length;
            }
            if (password.Text.Contains(@"\") || login.Text.Contains(@"-"))
            {
                Empty("*Вводите только строковые символы!");
                password.Text = password.Text.Remove(password.Text.Length - 1);
                password.SelectionStart = password.Text.Length;
            }
        }

        private void login_GotFocus(object sender, RoutedEventArgs e)
        {
            Empty("");
        }

        private void password_GotFocus(object sender, RoutedEventArgs e)
        {
            Empty("");
        }
    }
}
