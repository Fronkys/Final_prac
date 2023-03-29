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
    /// Логика взаимодействия для Page12.xaml
    /// </summary>
    public partial class Page12 : Page

    

    {
        Type_BookTableAdapter typebook = new Type_BookTableAdapter();
        public Page12()
        {
            InitializeComponent();
            GridTypeBook.ItemsSource = typebook.GetData();
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(CoverBox.Text) && !string.IsNullOrWhiteSpace(EditionBox.Text) && !string.IsNullOrWhiteSpace(TransBox.Text))
            {
                typebook.InsertQuery(CoverBox.Text,EditionBox.Text,TransBox.Text);
                GridTypeBook.ItemsSource = typebook.GetData();
            }
            else
            {
                MessageBox.Show("Данные не заполнены");
            }

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (GridTypeBook.SelectedItem != null)
            {
                int id = (int)(GridTypeBook.SelectedItem as DataRowView).Row[0];
                typebook.UpdateQuery(CoverBox.Text, EditionBox.Text, TransBox.Text, id);
                GridTypeBook.ItemsSource = typebook.GetData();
            }
        }
        private void GridTypeBook_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (GridTypeBook.SelectedItem != null)
            {
                var item = GridTypeBook.SelectedItem as DataRowView;
                CoverBox.Text = (string)item.Row[1];
                EditionBox.Text = (string)item.Row[2];
                TransBox.Text = (string)item.Row[3];
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {   
            if(GridTypeBook.SelectedItem != null)
            {
            int id = (int)(GridTypeBook.SelectedItem as DataRowView).Row[0];
            typebook.DeleteQuery(id);
            GridTypeBook.ItemsSource = typebook.GetData();
            }

        }
    }
}
