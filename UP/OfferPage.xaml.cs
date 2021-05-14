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
            SizeChanged += OfferPage_SizeChanged; ;
            InitializeComponent();
            datagrid_offer.ItemsSource = MainWindow.db.Offers.ToList();

            if (MainWindow.query_client != null)
            {
                edit.Visibility = Visibility.Hidden;
                delete.Visibility = Visibility.Hidden;
                datagrid_offer.ItemsSource = MainWindow.db.Offers.ToList().Where(q => q.ID_Client == null);
            }
        }

        private void OfferPage_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            Height = 800; Width = 300; WindowWidth = 300; WindowHeight = 800;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var query = MainWindow.db.Offers.ToList().Find(q=> q.ID_Client == null);
            query.ID_Client = MainWindow.id_client;

            Deal deal = new Deal() {

                ID = query.ID,
                Time = DateTime.Now
            };
            MainWindow.db.Deal.Add(deal);
            MainWindow.db.SaveChanges();

            datagrid_offer.ItemsSource = MainWindow.db.Offers.ToList().Where(q => q.ID_Client == null);

            MessageBox.Show($"Для дальнейшего оформления обратитесь к менеджеру и сообщите ему свой код: {query.ID}");
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
    }
}
