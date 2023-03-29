using Final_prac.DataSet2TableAdapters;
using MahApps.Metro.Controls;
using System;
using System.Collections.Generic;
using System.Data;
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
using static Final_prac.DataSet2;

namespace Final_prac
{
    /// <summary>
    /// Логика взаимодействия для Page5.xaml
    /// </summary>
    public partial class Page5 : Page
    {
        DeliveryTableAdapter delivery = new DeliveryTableAdapter();
        BookstoreTableAdapter bookstore = new BookstoreTableAdapter();
        public Page5()
        {
            InitializeComponent();
            DeliveryGrid.ItemsSource = delivery.GetData();
            DeliveryComboBox.ItemsSource = bookstore.GetData();
            DeliveryComboBox.DisplayMemberPath = "city_bookstore";
            DeliveryComboBox.SelectedValuePath = "id";
            
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(DeliveryBox.Text) && !string.IsNullOrWhiteSpace(DeliveryBox2.Text) && !string.IsNullOrWhiteSpace(DeliveryBox3.Text))
            {
                if (Int32.TryParse(DeliveryBox.Text, out int chislo) | Int32.TryParse(DeliveryBox3.Text, out int chislo2))
                {
                    if (chislo < 0 | chislo2 < 0)
                    {
                        MessageBox.Show("Вы ввели число меньше нуля");
                    }
                    else
                    {
                        int id = (int)DeliveryComboBox.SelectedValue;
                        delivery.InsertQuery(Convert.ToInt32(DeliveryBox.Text), DeliveryBox2.Text, Convert.ToInt32(DeliveryBox3.Text), id);
                        DeliveryGrid.ItemsSource = delivery.GetData();
                    }
                }
            }
            else {
               MessageBox.Show("Данные не заполнены");
            }

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (DeliveryGrid.SelectedItem != null)
            {
                int true_id = (int)(DeliveryGrid.SelectedItem as DataRowView).Row[0];
                int id = (int)DeliveryComboBox.SelectedValue;
                delivery.UpdateQuery(Convert.ToInt32(DeliveryBox.Text), DeliveryBox2.Text, Convert.ToInt32(DeliveryBox3.Text), id, true_id);
                DeliveryGrid.ItemsSource = delivery.GetData();
            }

        }
        private void DeliveryGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DeliveryGrid.SelectedItem != null)
            {
                var item = DeliveryGrid.SelectedItem as DataRowView;
                DeliveryBox.Text = Convert.ToString(item.Row[1]);
                DeliveryBox2.Text = (string)item.Row[2];
                DeliveryBox3.Text = Convert.ToString(item.Row[3]);
                DeliveryComboBox.SelectedValue = (int)item.Row[4];
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            int id = (int)(DeliveryGrid.SelectedItem as DataRowView).Row[0];
            delivery.DeleteQuery(id);
            DeliveryGrid.ItemsSource = delivery.GetData();
        }
    }
}
