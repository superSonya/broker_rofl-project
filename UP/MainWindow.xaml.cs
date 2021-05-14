using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
        public static broker_copyEntities db = new broker_copyEntities();
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            query_client = MainWindow.db.Client.ToList().Find(q => q.Login == login.Text && q.Password == password.Text);
            query_broker = MainWindow.db.Broker.ToList().Find(q => q.Login == login.Text && q.Password == password.Text);
            query_manager = MainWindow.db.Manager.ToList().Find(q => q.Login == login.Text && q.Password == password.Text);
            if (query_client != null)
            {
                myframe.NavigationService.Navigate(new OfferPage());

                id_client = query_client.ID;


                Hidden();
            }
            if (query_broker != null)
            {
                myframe.NavigationService.Navigate(new AddOffer_Broker());

                id_broker = query_broker.ID;


                Hidden();
            }

            if (query_manager != null)
            {
                myframe.NavigationService.Navigate(new ManagerPage());

                id_manager = query_manager.ID;


                Hidden();
            }
        }

        public void Hidden()
        {
            Stack.Visibility = Visibility.Hidden;
        }
    }
}
