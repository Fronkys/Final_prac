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
    /// <summary>
    /// Логика взаимодействия для Page6.xaml
    /// </summary>
    public partial class Page6 : Page
    {
        BooksTableAdapter books = new BooksTableAdapter();
        CheckTableAdapter check = new CheckTableAdapter();
        OrderTableAdapter order = new OrderTableAdapter();
        StaffTableAdapter staff = new StaffTableAdapter();
        public Page6()
        {
            InitializeComponent();
            CheckGrid.ItemsSource = check.GetData();
            OrderComboBox.ItemsSource = order.GetData();
            OrderComboBox.DisplayMemberPath = "sum_order";
            OrderComboBox.SelectedValuePath = "id";
            BookComboBox.ItemsSource = books.GetData();
            BookComboBox.DisplayMemberPath = "name_book";
            BookComboBox.SelectedValuePath = "id";
            StaffComboBox.ItemsSource = staff.GetData();
            StaffComboBox.DisplayMemberPath = "staff_name";
            StaffComboBox.SelectedValuePath = "id";
        }



        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int id_order = (int)OrderComboBox.SelectedValue;
            int id_books = (int)BookComboBox.SelectedValue;
            int id_staff = (int)StaffComboBox.SelectedValue;
            check.InsertQuery(id_books,id_order, id_staff);
            CheckGrid.ItemsSource = check.GetData();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (CheckGrid.SelectedItem != null)
            {
                int true_id = (int)(CheckGrid.SelectedItem as DataRowView).Row[0];
                int id_order = (int)OrderComboBox.SelectedValue;
                int id_books = (int)BookComboBox.SelectedValue;
                int id_staff = (int)StaffComboBox.SelectedValue;
                check.UpdateQuery(id_books,id_order,id_staff,true_id);
                CheckGrid.ItemsSource = check.GetData();

            }
        }
        private void CheckGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CheckGrid.SelectedItem != null)
            {
                var item = CheckGrid.SelectedItem as DataRowView;
                BookComboBox.SelectedValue = (int)item.Row[1];
                OrderComboBox.SelectedValue = (int)item.Row[2];
                StaffComboBox.SelectedValue = (int)item.Row[3];
            }
        }
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if(CheckGrid.SelectedItem != null)
            {
                int id = (int)(CheckGrid.SelectedItem as DataRowView).Row[0];
                check.DeleteQuery(id);
                CheckGrid.ItemsSource = check.GetData();
            }
 
        }
    }
}
