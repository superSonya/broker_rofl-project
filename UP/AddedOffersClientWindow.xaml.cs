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
    /// Логика взаимодействия для AddedOffersClientWindow.xaml
    /// </summary>
    public partial class AddedOffersClientWindow : Window
    {
        public AddedOffersClientWindow()
        {
            InitializeComponent();
            datagrid.ItemsSource = MainWindow.db.Offers.Where(q => q.ID_Client == MainWindow.id_client && q.Condition == true).ToList();
        }



        private void exit_Click_1(object sender, RoutedEventArgs e)
        {
            new OfferWindow().Show();
            Close();
        }
    }
}
