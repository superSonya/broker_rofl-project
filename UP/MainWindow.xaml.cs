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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace UP
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static broker_copyEntities1 db = new broker_copyEntities1();
        public static int id_client;
        public static int id_broker;
        public static int id_manager;
        public static Client query_client;
        public static Broker query_broker;
        public static Manager query_manager;

        public MainWindow()
        {
            InitializeComponent();
        }


        public void Empty(string message) { error.Content = message; }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (login.Text == "" || password.Text == "")
            {
                Empty("*Ошибка, заполните поля!");
            }
            else
            {
                Empty("");

                query_client = MainWindow.db.Client.ToList().Find(q => q.Login == login.Text && q.Password == password.Text);
                query_broker = MainWindow.db.Broker.ToList().Find(q => q.Login == login.Text && q.Password == password.Text);
                query_manager = MainWindow.db.Manager.ToList().Find(q => q.Login == login.Text && q.Password == password.Text);
                if (query_client != null)
                {
                    new OfferWindow().Show();
                    Close();

                    id_client = query_client.ID;
                }
                else
                {
                    Empty("*Такого пользователя не существует!");
                }

                if (query_broker != null)
                {
                    new OfferWindow().Show();
                    Close();
                    id_broker = query_broker.ID;

                }
                else
                {
                    Empty("*Такого пользователя не существует!");
                }

                if (query_manager != null)
                {


                    new ManagerWindow().Show();
                    Close();
                    id_manager = query_manager.ID;

                }
                else
                {
                    Empty("*Такого пользователя не существует!");
                }
            }
        }


        private void exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        #region Focus
        private void login_GotFocus(object sender, RoutedEventArgs e)
        {
            Empty("");
        }

        private void password_GotFocus(object sender, RoutedEventArgs e)
        {
            Empty("");
        }
        #endregion

        #region TextChanged
        private void login_TextChanged(object sender, TextChangedEventArgs e)
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

        private void password_TextChanged(object sender, TextChangedEventArgs e)
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
            if (password.Text.Contains(@"\") || password.Text.Contains(@"-"))
            {
                Empty("*Вводите только строковые символы!");
                password.Text = password.Text.Remove(password.Text.Length - 1);
                password.SelectionStart = password.Text.Length;
            }
        }
        #endregion

    }
}
