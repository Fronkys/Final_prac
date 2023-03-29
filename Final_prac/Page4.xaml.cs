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
using Final_prac.DataSet2TableAdapters;
using static Final_prac.DataSet2;

namespace Final_prac
{
    public partial class Page4 : Page
    {
        ClientTableAdapter client = new ClientTableAdapter();
        public Page4()
        {
            InitializeComponent();
            ClientGrid.ItemsSource = client.GetData();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            if(!string.IsNullOrWhiteSpace(ClientBox.Text) && !string.IsNullOrWhiteSpace(ClientBox2.Text) && !string.IsNullOrWhiteSpace(ClientBox3.Text) && !string.IsNullOrWhiteSpace(ClientBox4.Text))
            {
                 client.InsertQuery(ClientBox.Text, ClientBox2.Text, ClientBox3.Text, ClientBox4.Text);
                ClientGrid.ItemsSource = client.GetData();
            }
            else
            {
               
                MessageBox.Show("Данные не заполнены");
            }

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (ClientGrid.SelectedItem != null)
            {
                int id = (int)(ClientGrid.SelectedItem as DataRowView).Row[0];
                client.UpdateQuery(ClientBox.Text,ClientBox2.Text,ClientBox3.Text,ClientBox4.Text, id);
                ClientGrid.ItemsSource = client.GetData();
            }
        }
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (ClientGrid.SelectedItem != null)
            {
                int id = (int)(ClientGrid.SelectedItem as DataRowView).Row[0];
                client.DeleteQuery(id);
                ClientGrid.ItemsSource = client.GetData();
            }


        }

        private void ClientGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ClientGrid.SelectedItem != null)
            {
                var item = ClientGrid.SelectedItem as DataRowView;
                ClientBox.Text = (string)item.Row[1];
                ClientBox2.Text = (string)item.Row[2];
                ClientBox3.Text = (string)item.Row[3];
                ClientBox4.Text = (string)item.Row[4];
            }
        }
    }
}
