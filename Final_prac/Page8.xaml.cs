using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Security;
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
    
    public partial class Page8 : Page
    {
        Order_statusTableAdapter status = new Order_statusTableAdapter();
        public Page8()
        {
            InitializeComponent();
            OrderStatusGrid.ItemsSource = status.GetData();
        }



        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(StatusNameBox.Text))
            {
                status.InsertQuery(StatusNameBox.Text);
                OrderStatusGrid.ItemsSource = status.GetData();
            }
            else
            {

                MessageBox.Show("Данные не заполнены");
            }

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (OrderStatusGrid.SelectedItem != null)
            {
                int id = (int)(OrderStatusGrid.SelectedItem as DataRowView).Row[0];
                status.UpdateQuery(StatusNameBox.Text, id);
                OrderStatusGrid.ItemsSource = status.GetData();
            }
        }
        private void OrderStatusGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (OrderStatusGrid.SelectedItem != null)
            {
                var item = OrderStatusGrid.SelectedItem as DataRowView;
                StatusNameBox.Text = (string)item.Row[1];
            }
        }
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if(OrderStatusGrid.SelectedItem != null)
            {
                int id = (int)(OrderStatusGrid.SelectedItem as DataRowView).Row[0];
                status.DeleteQuery(id);
                OrderStatusGrid.ItemsSource = status.GetData();
            }

        }
    }
}
