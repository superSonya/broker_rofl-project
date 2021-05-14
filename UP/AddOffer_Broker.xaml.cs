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
    /// Логика взаимодействия для AddOffer_Broker.xaml
    /// </summary>
    public partial class AddOffer_Broker : Page
    {
        public AddOffer_Broker()
        {
            InitializeComponent();


            datagrid_addoffer.ItemsSource = MainWindow.db.Offers.ToList().Where(q => q.ID_Client == null);
            combo.ItemsSource = MainWindow.db.Sub_Offers.ToList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            var sel = combo.SelectedItem as Sub_Offers;

            Offers offers = new Offers() {

                ID_Broker = MainWindow.id_broker,
                ID_SubOffers = sel.ID,
                Price = int.Parse(priceBox.Text)
            };



            MainWindow.db.Offers.Add(offers);
            MainWindow.db.SaveChanges();

            datagrid_addoffer.ItemsSource = MainWindow.db.Offers.ToList().Where(q => q.ID_Client == null);
        }
    }
}
