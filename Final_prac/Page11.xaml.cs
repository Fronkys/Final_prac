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
    /// <summary>
    /// Логика взаимодействия для Page11.xaml
    /// </summary>
    public partial class Page11 : Page
    {
        BookstoreTableAdapter store = new BookstoreTableAdapter();
        RegionTableAdapter region = new RegionTableAdapter();
        ProviderTableAdapter provider = new ProviderTableAdapter();
        
        public Page11()
        {
            InitializeComponent();
            StoreGrid.ItemsSource = store.GetData();
            ProviderComboBox.ItemsSource = provider.GetData();
            ProviderComboBox.DisplayMemberPath = "city_provider";
            ProviderComboBox.SelectedValuePath = "id";
            RegionComboBox.ItemsSource = region.GetData();
            RegionComboBox.DisplayMemberPath = "number";
            RegionComboBox.SelectedValuePath = "id";
        }



        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(StoreBox.Text) && !string.IsNullOrWhiteSpace(StoreBox2.Text))
            {
                int id_provider = (int)ProviderComboBox.SelectedValue;
                int id_region = (int)RegionComboBox.SelectedValue;
                store.InsertQuery(StoreBox.Text, StoreBox2.Text, id_region, id_provider);
                StoreGrid.ItemsSource = store.GetData();
            }
            else
            {
                MessageBox.Show("Данные не заполнены");
            }

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (StoreGrid.SelectedItem != null)
            {
                int true_id = (int)(StoreGrid.SelectedItem as DataRowView).Row[0];
                int id_provider = (int)ProviderComboBox.SelectedValue;
                int id_region = (int)RegionComboBox.SelectedValue;
                store.UpdateQuery(StoreBox.Text,StoreBox2.Text,id_region ,id_provider, true_id);
                StoreGrid.ItemsSource = store.GetData();
            }
        }
        private void StoreGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (StoreGrid.SelectedItem != null)
            {
                var item = StoreGrid.SelectedItem as DataRowView;
                StoreBox.Text = (string)item.Row[1];
                StoreBox2.Text = (string)item.Row[2];
                RegionComboBox.SelectedValue = (int)item.Row[3];
                ProviderComboBox.SelectedValue = (int)item.Row[4];
    
            }
        }
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (StoreGrid.SelectedItem != null)
            {
                int id = (int)(StoreGrid.SelectedItem as DataRowView).Row[0];
                store.DeleteQuery(id);
                StoreGrid.ItemsSource = store.GetData();
            }
 
        }
    }
}
