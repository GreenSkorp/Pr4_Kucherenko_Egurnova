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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Практическая_Работа_4_Кучеренко_Егурнова.Pages
{
    /// <summary>
    /// Логика взаимодействия для _1.xaml
    /// </summary>
    public partial class _1 : Page
    {
        public _1()
        {
            InitializeComponent();
        }

        private void yValue_TextChanged(object sender, TextChangedEventArgs e)
        {
            ValuesEnable(); 
        }

        private void xValue_TextChanged(object sender, TextChangedEventArgs e)
        {
            ValuesEnable();
        }

        private void zValue_TextChanged(object sender, TextChangedEventArgs e)
        {
            ValuesEnable(); 
        }

        private void ValuesEnable()
        {
            if (xValue.Text.Length > 0 && yValue.Text.Length > 0 && zValue.Text.Length > 0)
            {
                Count.IsEnabled = true;
            }
            else { Count.IsEnabled = false; }
        }

        private void Count_Click(object sender, RoutedEventArgs e)
        {


            Clear.IsEnabled = true;
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {

            Clear.IsEnabled = false;
        }
    }
}
