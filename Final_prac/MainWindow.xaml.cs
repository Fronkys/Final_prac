using System;
using System.Collections.Generic;
using System.Deployment.Internal;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

    public partial class MainWindow : Window

    {
        EntryTableAdapter log = new EntryTableAdapter();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(Login.Text) && !string.IsNullOrWhiteSpace(Password.Password))
            {
                EntryDataTable foundEntry = log.GetEntryByLogin(Login.Text);

                if (foundEntry.Rows.Count != 0 && foundEntry.Rows[0]["password"].ToString() == Password.Password)
                {
                    int Role = (int)foundEntry[0]["Roleid"];
                    switch (Role)
                    {
                        case 1:

                            Window1 role = new Window1();
                            role.Show();
                            break;
                        case 2:
                            Window2 second = new Window2();
                            second.Show();
                            break;


                    }
                }
                if (foundEntry.Rows.Count == 0)
                {

                    MessageBox.Show("Пользователь не найден");
                }
                if (foundEntry.Rows[0]["password"].ToString() != Password.Password)
                {
                    MessageBox.Show("Неверный пароль");
                }
            }
            else
            {
                MessageBox.Show("Данные не заполнены"); 
            }
        }
    }   
}
