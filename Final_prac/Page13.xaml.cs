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
    
    public partial class Page13 : Page
    {
        BooksTableAdapter books = new BooksTableAdapter();
        Type_BookTableAdapter typebook = new Type_BookTableAdapter();

        public Page13()
        {
            InitializeComponent();
            BookGrid.ItemsSource = books.GetData();
            BookComboBox.ItemsSource = typebook.GetData();
            BookComboBox.DisplayMemberPath = "edition";
            BookComboBox.SelectedValuePath = "id";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(NameBox.Text) && !string.IsNullOrWhiteSpace(PageBox.Text) && !string.IsNullOrWhiteSpace(AuthorBox.Text))
            {
                if (Int32.TryParse(PageBox.Text, out int chislo))
                {
                    if (chislo < 0)
                    {
                        MessageBox.Show("Вы ввели число меньше нуля");
                    }
                    else
                    {
                        int id = (int)BookComboBox.SelectedValue;
                        books.InsertQuery(NameBox.Text, Convert.ToInt32(PageBox.Text),AuthorBox.Text , id);
                        BookGrid.ItemsSource = books.GetData();
                    }
                }

            }
            else
            {
                MessageBox.Show("Данные не заполнены");
            }

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (BookGrid.SelectedItem != null)
            {
                int true_id = (int)(BookGrid.SelectedItem as DataRowView).Row[0];
                int id = (int)BookComboBox.SelectedValue;
                books.UpdateQuery(NameBox.Text, Convert.ToInt32(PageBox.Text), AuthorBox.Text, id, true_id);
                BookGrid.ItemsSource = books.GetData();
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {   
            if (BookGrid.SelectedItem != null)
            {
                int id = (int)(BookGrid.SelectedItem as DataRowView).Row[0];
                books.DeleteQuery(id);
                BookGrid.ItemsSource = books.GetData(); 
            }
  
        }

        private void BookGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (BookGrid.SelectedItem != null)
            {
                var item = BookGrid.SelectedItem as DataRowView;
                NameBox.Text = (string)item.Row[1];
                PageBox.Text = Convert.ToString(item.Row[2]);
                AuthorBox.Text = (string)item.Row[3];
                BookComboBox.SelectedValue = (int)item.Row[4];
            }
        }
    }
}
