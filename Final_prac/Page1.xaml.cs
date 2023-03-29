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

namespace Final_prac
{

    public partial class Page1 : Page
    {
        RoleTableAdapter role = new RoleTableAdapter();

        public Page1()
        {
            InitializeComponent();
            RoleGrid.ItemsSource = role.GetData();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(RoleBox.Text))
            {
                role.InsertQuery(RoleBox.Text);
                RoleGrid.ItemsSource = role.GetData();
            }
            else
            {
               
                MessageBox.Show("Данные не заполнены");
            }

        } 

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (RoleGrid.SelectedItem != null)
            {
               int id = (int)(RoleGrid.SelectedItem as DataRowView).Row[0];
               role.UpdateQuery(RoleBox.Text, id);
               RoleGrid.ItemsSource = role.GetData();
            }
        }        
        private void RoleGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
            if(RoleGrid.SelectedItem != null)
            {
                var item = RoleGrid.SelectedItem as DataRowView;
                RoleBox.Text = (string)item.Row[1];
            }
        }        
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
                int id = (int)(RoleGrid.SelectedItem as DataRowView).Row[0];
                role.DeleteQuery(id);
                RoleGrid.ItemsSource = role.GetData();   
        }


    }
}

