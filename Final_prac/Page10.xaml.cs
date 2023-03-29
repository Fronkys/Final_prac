using Final_prac.DataSet2TableAdapters;
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

    public partial class Page10 : Page
    {
        ProviderTableAdapter provider = new ProviderTableAdapter(); 
        public Page10()
        {
            InitializeComponent();
            ProviderGrid.ItemsSource = provider.GetData();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(ProviderBox.Text) && !string.IsNullOrWhiteSpace(ProviderBox2.Text))
            {
                provider.InsertQuery(ProviderBox.Text, ProviderBox2.Text);
                ProviderGrid.ItemsSource = provider.GetData();
            }
            else
            {
                MessageBox.Show("Данные не заполнены");
            }

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (ProviderGrid.SelectedItem != null)
            {
                int id = (int)(ProviderGrid.SelectedItem as DataRowView).Row[0];
                provider.DeleteQuery(id);
                ProviderGrid.ItemsSource = provider.GetData();
            }

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (ProviderGrid.SelectedItem != null)
            {
            int id = (int)(ProviderGrid.SelectedItem as DataRowView).Row[0];
            provider.UpdateQuery(ProviderBox.Text, ProviderBox2.Text, id);
            ProviderGrid.ItemsSource = provider.GetData();

            }

        }

        private void ProviderGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ProviderGrid.SelectedItem != null)
            {
                var item = ProviderGrid.SelectedItem as DataRowView;
                ProviderBox.Text = (string)item.Row[1];
                ProviderBox2.Text = (string)item.Row[2];
            }
        }
    }
}
