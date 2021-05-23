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
    /// Логика взаимодействия для ManagerWindow.xaml
    /// </summary>
    public partial class ManagerWindow : Window
    {
        public ManagerWindow()
        {
            InitializeComponent();

            datagrid.ItemsSource = MainWindow.db.Offers.ToList().Where(q => q.ID_Client != null && q.Condition == false);
        }

        private void exit_Click(object sender, RoutedEventArgs e)
        {
            Close();
            new MainWindow().Show();
        }

        private void accept_Click(object sender, RoutedEventArgs e)
        {
            var query = datagrid.SelectedItem as Offers;

            if (query != null)
            {
                query.Condition = true;

                var deal = MainWindow.db.Deal.ToList().Find(q => q.ID == query.ID);

                deal.BeginTime = DateTime.Now;
                deal.EndTime = DateTime.Now.AddDays(90);


                MainWindow.db.SaveChanges();

                MessageBox.Show("ok");

                datagrid.ItemsSource = MainWindow.db.Offers.ToList().Where(q => q.ID_Client != null && q.Condition == false);
            }
            else { MessageBox.Show("Что-то пошло не так..."); }
        }
    }
}
