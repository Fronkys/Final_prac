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

    public partial class Page2 : Page
    {
        EntryTableAdapter entry = new EntryTableAdapter();
        RoleTableAdapter role = new RoleTableAdapter();
        public Page2()
        {
            InitializeComponent();
            EntryGrid.ItemsSource = entry.GetData();
            EntryComboBox.ItemsSource = role.GetData();
            EntryComboBox.DisplayMemberPath = "role_name";
            EntryComboBox.SelectedValuePath = "id";
        }



        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(EntryBox.Text) && !string.IsNullOrWhiteSpace(EntryBox2.Text))
            {
                int id = (int)EntryComboBox.SelectedValue;
                entry.InsertQuery(EntryBox.Text, EntryBox2.Text, id);
                EntryGrid.ItemsSource = entry.GetData();
                
            }
            else
            {
                MessageBox.Show("Данные не заполнены");
            }

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if( EntryGrid.SelectedItem != null)
            {
                int id = (int)(EntryComboBox.SelectedItem as DataRowView).Row[0];
                entry.DeleteQuery(id);
                EntryGrid.ItemsSource = entry.GetData();
            }

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (EntryGrid.SelectedItem != null)
            {
                int true_id = (int)(EntryGrid.SelectedItem as DataRowView).Row[0];
                int id = (int)EntryComboBox.SelectedValue;
                entry.UpdateQuery(EntryBox.Text, EntryBox2.Text, id, true_id);
                EntryGrid.ItemsSource = entry.GetData();
            }
        }

        private void EntryGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (EntryGrid.SelectedItem != null)
            {
                var item = EntryGrid.SelectedItem as DataRowView;
                EntryBox.Text = (string)item.Row[1];
                EntryBox2.Text = (string)item.Row[2];
                EntryComboBox.SelectedValue = (int)item.Row[3];
            }
        }
    }

}
