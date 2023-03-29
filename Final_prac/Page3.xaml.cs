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
    public partial class Page3 : Page
    {
        StaffTableAdapter staff = new StaffTableAdapter();
        RoleTableAdapter role = new RoleTableAdapter();
        public Page3()
        {
            InitializeComponent();
            StaffGrid.ItemsSource = staff.GetData();
            StaffComboBox.ItemsSource = role.GetData();
            StaffComboBox.DisplayMemberPath = "role_name";
            StaffComboBox.SelectedValuePath = "id";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(StaffBox.Text) && !string.IsNullOrWhiteSpace(StaffBox2.Text) && !string.IsNullOrWhiteSpace(StaffBox3.Text))
            {
                int id = (int)StaffComboBox.SelectedValue;
                staff.InsertQuery(StaffBox.Text, StaffBox2.Text, StaffBox3.Text, id);
                StaffGrid.ItemsSource = staff.GetData();
                
            }
            else
            {
                MessageBox.Show("Данные не заполнены");
            }

               
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if( StaffGrid.SelectedItem != null)
            {
            int id = (int)(StaffComboBox.SelectedItem as DataRowView).Row[0];
            staff.DeleteQuery(id);
            StaffGrid.ItemsSource = staff.GetData();
            }

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (StaffGrid.SelectedItem != null)
            {
                int true_id = (int)(StaffGrid.SelectedItem as DataRowView).Row[0];
                int id = (int)StaffComboBox.SelectedValue;
                staff.UpdateQuery(StaffBox.Text, StaffBox2.Text, StaffBox3.Text, id, true_id);
                StaffGrid.ItemsSource = staff.GetData();
            }
        }

        private void StaffGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (StaffGrid.SelectedItem != null)
            {
                var item = StaffGrid.SelectedItem as DataRowView;
                StaffBox.Text = (string)item.Row[1];
                StaffBox2.Text = (string)item.Row[2];
                StaffBox3.Text = (string)item.Row[3];
                StaffComboBox.SelectedValue = (int)item.Row[4];
            }
        }
    }
}
