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
    /// Логика взаимодействия для AddedOffersClient.xaml
    /// </summary>
    public partial class AddedOffersClient : Page
    {
        public AddedOffersClient()
        {
            InitializeComponent();
            datagrid.ItemsSource = MainWindow.db.Offers.Where(q=> q.ID_Client == MainWindow.id_client).ToList();
        }

        

        private void exit_Click_1(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
