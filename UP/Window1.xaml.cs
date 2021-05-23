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
using System.Windows.Shapes;

namespace UP
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
            datagrid_addoffer.ItemsSource = MainWindow.db.Offers.ToList().Where(q => q.ID_Client == null);
            combo.ItemsSource = MainWindow.db.Sub_Offers.ToList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            var sel = combo.SelectedItem as Sub_Offers;

            Offers offers = new Offers()
            {

                ID_Broker = MainWindow.id_broker,
                ID_SubOffers = sel.ID,
                Price = int.Parse(priceBox.Text),
                Condition = false,

            };



            MainWindow.db.Offers.Add(offers);
            MainWindow.db.SaveChanges();

            datagrid_addoffer.ItemsSource = MainWindow.db.Offers.ToList().Where(q => q.ID_Client == null);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            new MainWindow().Show();
            Close();
        }

        private void priceBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Regex.IsMatch(priceBox.Text, "[^0-9]"))
            {
                MessageBox.Show("Ввод только числовых значений!");
                priceBox.Text = priceBox.Text.Remove(priceBox.Text.Length - 1);
                priceBox.SelectionStart = priceBox.Text.Length;
            }
            if (Regex.IsMatch(priceBox.Text, @"^\W"))
            {
                MessageBox.Show("Ввод только числовых значений!");
                priceBox.Text = priceBox.Text.Remove(priceBox.Text.Length - 1);
                priceBox.SelectionStart = priceBox.Text.Length;
            }
            if (priceBox.Text.Contains(@"\") || priceBox.Text.Contains(@"-"))
            {
                MessageBox.Show("Ввод только числовых значений!");
                priceBox.Text = priceBox.Text.Remove(priceBox.Text.Length - 1);
                priceBox.SelectionStart = priceBox.Text.Length;
            }
        }
    }
}
