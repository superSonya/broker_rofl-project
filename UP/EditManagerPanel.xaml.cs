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
    /// Логика взаимодействия для EditManagerPanel.xaml
    /// </summary>
    public partial class EditManagerPanel : Page
    {
        public EditManagerPanel()
        {
            InitializeComponent();
            broker_combo.ItemsSource = MainWindow.db.Broker.ToList();
            subject_combo.ItemsSource = MainWindow.db.Sub_Offers.ToList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var brok = broker_combo.SelectedItem as Broker;
            var subject = subject_combo.SelectedItem as Sub_Offers;
            // подгружаем выбранный элемент
            var offers = MainWindow.db.Offers.ToList().Find(q => q.ID == OfferPage.id_offer);

            offers.ID_Broker = brok.ID;
            offers.ID_SubOffers = subject.ID;
            offers.Price = int.Parse(price.Text);

            MainWindow.db.SaveChanges();

            NavigationService.GoBack();

        }   
    }
}
