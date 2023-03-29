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
using ControlzEx.Standard;
using Final_prac.DataSet2TableAdapters;

namespace Final_prac
{
    
    public partial class Page9 : Page
    {
        RegionTableAdapter region = new RegionTableAdapter();
        public Page9()
        {
            InitializeComponent();
            RegionGrid.ItemsSource = region.GetData();
        }



        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(NumberBox.Text) && !string.IsNullOrWhiteSpace(RegionBox.Text))
            {
                region.InsertQuery(Convert.ToInt32(NumberBox.Text), RegionBox.Text);
                RegionGrid.ItemsSource = region.GetData();
            }
            else
            {

                MessageBox.Show("Данные не заполнены");
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (RegionGrid.SelectedItem != null)
            {
                int id = (int)(RegionGrid.SelectedItem as DataRowView).Row[0];
                region.UpdateQuery(Convert.ToInt32(NumberBox.Text), RegionBox.Text, id);
                RegionGrid.ItemsSource = region.GetData();
            }
        }
        private void RegionGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (RegionGrid.SelectedItem != null)
            {
                var item = RegionGrid.SelectedItem as DataRowView;
                NumberBox.Text = Convert.ToString(item.Row[1]);
                RegionBox.Text = (string)item.Row[2];
            }
        }
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (RegionGrid.SelectedItem != null)
            {
                int id = (int)(RegionGrid.SelectedItem as DataRowView).Row[0];
                region.DeleteQuery(id);
                RegionGrid.ItemsSource = region.GetData();
            }

        }
    }
}
