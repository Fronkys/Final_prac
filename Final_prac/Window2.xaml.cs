using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace Final_prac
{
    /// <summary>
    /// Логика взаимодействия для Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {
        public Window2()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            PageFrame.Content = new Page4();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            PageFrame.Content = new Page5();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            PageFrame.Content = new Page6();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            PageFrame.Content = new Page7();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            PageFrame.Content = new Page8();
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            PageFrame.Content = new Page9();
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            PageFrame.Content = new Page10();
        }

        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            PageFrame.Content = new Page11();
        }

        private void Button_Click_8(object sender, RoutedEventArgs e)
        {
            PageFrame.Content = new Page12();
        }

        private void Button_Click_9(object sender, RoutedEventArgs e)
        {
            PageFrame.Content = new Page13();
        }
    }
}
