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
using System.Windows.Shapes;

namespace UP
{
    /// <summary>
    /// Логика взаимодействия для OfferWindow.xaml
    /// </summary>
    public partial class OfferWindow : Window
    {
        public static int id_offer;
        public OfferWindow()
        {
            InitializeComponent();

            if (MainWindow.query_client != null)
            {
                edit.Visibility = Visibility.Hidden;
                delete.Visibility = Visibility.Hidden;
                addOffer.Visibility = Visibility.Hidden;
                datagrid_offer.ItemsSource = MainWindow.db.Offers.ToList().Where(q => q.ID_Client == null);
            }
            if (MainWindow.query_broker != null)
            {
                datagrid_offer.ItemsSource = MainWindow.db.Offers.ToList().Where(q => q.ID_Broker == MainWindow.query_broker.ID);
                add.Visibility = Visibility.Hidden;
                edit.Visibility = Visibility.Hidden;
                delete.Visibility = Visibility.Hidden;
                added.Visibility = Visibility.Hidden;
            }
        }

        private void Myframe_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            Height = 330; Width = 450;
        }

        private void edit_Click(object sender, RoutedEventArgs e)
        {
            var sel = datagrid_offer.SelectedItem as Offers;
            id_offer = sel.ID;
            //NavigationService.Navigate(new EditManagerPanel());

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
            else if (MainWindow.query_broker != null)
            {
                datagrid_offer.ItemsSource = MainWindow.db.Offers.ToList().Where(q => q.ID_Broker == MainWindow.query_broker.ID);
            }
        }

        private void add_Click(object sender, RoutedEventArgs e)
        {

            var query = datagrid_offer.SelectedItem as Offers;
            query.ID_Client = MainWindow.id_client;

            Deal deal = new Deal()
            {
                ID = query.ID,
                TimeOffers = DateTime.Now
            };
            MainWindow.db.Deal.Add(deal);
            MainWindow.db.SaveChanges();

            datagrid_offer.ItemsSource = MainWindow.db.Offers.ToList().Where(q => q.ID_Client == null);

            MessageBox.Show($"Для дальнейшего оформления обратитесь к менеджеру и сообщите ему свой код: {query.ID}");
        }

        private void exit_Click(object sender, RoutedEventArgs e)
        {
            new MainWindow().Show();
            Close();
        }

        private void addOffer_Click(object sender, RoutedEventArgs e)
        {
            new Window1().Show();
            Close();
        }

        private void added_Click(object sender, RoutedEventArgs e)
        {
            new AddedOffersClientWindow().Show();
            Close();
           
        }
    }
}
