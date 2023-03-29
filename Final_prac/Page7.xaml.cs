using System;
using System.Collections.Generic;
using System.Data;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Final_prac.DataSet2TableAdapters;
using static Final_prac.DataSet2;

namespace Final_prac
{
    
    public partial class Page7 : Page
    {
        OrderTableAdapter order = new OrderTableAdapter();
        Order_statusTableAdapter status = new Order_statusTableAdapter();
        DeliveryTableAdapter delivery = new DeliveryTableAdapter();
        ClientTableAdapter client = new ClientTableAdapter();

        public Page7()
        {
            InitializeComponent();
            OrderGrid.ItemsSource = order.GetData();
            OrderStatusComboBox.ItemsSource = status.GetData();
            OrderStatusComboBox.DisplayMemberPath = "status_order";
            OrderStatusComboBox.SelectedValuePath = "id";
            DeliveryComboBox.ItemsSource = delivery.GetData();
            DeliveryComboBox.DisplayMemberPath = "cost_delivery";
            DeliveryComboBox.SelectedValuePath = "id";
            ClientComboBox.ItemsSource = client.GetData();
            ClientComboBox.DisplayMemberPath = "name_client";
            ClientComboBox.SelectedValuePath = "id";

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(DateBox.Text) && !string.IsNullOrWhiteSpace(TimeBox.Text) && !string.IsNullOrWhiteSpace(SumBox.Text))
            {
                //Regex regex = new Regex("^\\d{4}-{1}\\d{2}-{1}\\d{2}$");
                Regex regex = new Regex("^\\d{2}.{1}\\d{2}.{1}\\d{4}$");
                Regex regex1 = new Regex("^\\d{2}:{1}\\d{2}:{1}\\d{2}$");
                string text = Convert.ToString(DateBox.Text);
                string text1 = Convert.ToString(TimeBox.Text);
                string pattern = Convert.ToString(regex);
                string pattern1 = Convert.ToString(regex1);
                if (Regex.IsMatch(text, pattern, RegexOptions.IgnoreCase) && Regex.IsMatch(text1, pattern1, RegexOptions.IgnoreCase))
                {
                    if (Int32.TryParse(SumBox.Text, out int chislo))
                {
                    if (chislo < 0)
                    {
                        MessageBox.Show("Вы ввели число меньше нуля");
                    }
                    else
                    {
                     
                        int id_status = (int)OrderStatusComboBox.SelectedValue;
                        int id_delivery = (int)DeliveryComboBox.SelectedValue;
                        int id_client = (int)ClientComboBox.SelectedValue;
                        order.InsertQuery(DateBox.Text, TimeBox.Text, Convert.ToInt32(SumBox.Text), id_status, id_delivery, id_client);
                        OrderGrid.ItemsSource = order.GetData();
                    }
                }
                }
                else
                {
                    MessageBox.Show("Вы указали неправильный формат для даты");
                }

            }
            else
            {
                MessageBox.Show("Данные не заполнены");
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (OrderGrid.SelectedItem != null)
            {
                int true_id = (int)(OrderGrid.SelectedItem as DataRowView).Row[0];
                int id_status = (int)OrderStatusComboBox.SelectedValue;
                int id_delivery = (int)DeliveryComboBox.SelectedValue;
                int id_client = (int)ClientComboBox.SelectedValue;
                order.UpdateQuery(DateBox.Text,TimeBox.Text, Convert.ToInt32(SumBox.Text), id_status, id_delivery, id_client, true_id);
                OrderGrid.ItemsSource = order.GetData();
            }
        }
        private void OrderGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (OrderGrid.SelectedItem != null)
            {
                var item = OrderGrid.SelectedItem as DataRowView;
                DateBox.Text = Convert.ToString(item.Row[1]);
                TimeBox.Text = Convert.ToString(item.Row[2]);
                SumBox.Text = Convert.ToString(item.Row[3]);
                OrderStatusComboBox.SelectedValue = (int)item.Row[4];
                DeliveryComboBox.SelectedValue = (int)item.Row[5];
                ClientComboBox.SelectedValue = (int)item.Row[6];
            }
        }
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if(OrderGrid.SelectedItem != null)
            {
                int id = (int)(OrderGrid.SelectedItem as DataRowView).Row[0];
                order.DeleteQuery(id);
                OrderGrid.ItemsSource = order.GetData();
            }
 
        }
    }
}
