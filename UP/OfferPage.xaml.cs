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
    /// Логика взаимодействия для OfferPage.xaml
    /// </summary>
    public partial class OfferPage : Page
    {
        public static int id_offer;
        public OfferPage()
        {
            InitializeComponent();
            datagrid_offer.ItemsSource = MainWindow.db.Offers.ToList();

            if (MainWindow.query_client != null)
            {
                edit.Visibility = Visibility.Hidden;
                delete.Visibility = Visibility.Hidden;
                datagrid_offer.ItemsSource = MainWindow.db.Offers.ToList().Where(q => q.ID_Client == null);
            }
        }

        private void edit_Click(object sender, RoutedEventArgs e)
        {
            var sel = datagrid_offer.SelectedItem as Offers;
            id_offer = sel.ID;
            NavigationService.Navigate(new EditManagerPanel());

        }

        private void delete_Click(object sender, RoutedEventArgs e)
        {
            var sel = datagrid_offer.SelectedItem as Offers;
            MainWindow.db.Offers.Remove(sel);
            MainWindow.db.SaveChanges();

            datagrid_offer.ItemsSource = MainWindow.db.Offers.ToList();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (MainWindow.query_client != null)
            {
                edit.Visibility = Visibility.Hidden;
                delete.Visibility = Visibility.Hidden;
                datagrid_offer.ItemsSource = MainWindow.db.Offers.ToList().Where(q => q.ID_Client == null);
            }
            else
            {
                datagrid_offer.ItemsSource = MainWindow.db.Offers.ToList();
            }
        }

        private void add_Click(object sender, RoutedEventArgs e)
        {
            var query = MainWindow.db.Offers.ToList().Find(q => q.ID_Client == null);
            query.ID_Client = MainWindow.id_client;

            Deal deal = new Deal()
            {

                ID = query.ID,
                Time = DateTime.Now
            };
            MainWindow.db.Deal.Add(deal);
            MainWindow.db.SaveChanges();

            datagrid_offer.ItemsSource = MainWindow.db.Offers.ToList().Where(q => q.ID_Client == null);

            MessageBox.Show($"Для дальнейшего оформления обратитесь к менеджеру и сообщите ему свой код: {query.ID}");
        }
    }
}
