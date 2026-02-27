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
using Практическая_Работа_4_Кучеренко_Егурнова;

namespace Практическая_Работа_4_Кучеренко_Егурнова.Pages
{
    /// <summary>
    /// Логика взаимодействия для _1.xaml
    /// </summary>
    public partial class _1 : Page
    {
        private double x, y, z;
        public _1()
        {
            InitializeComponent();
        }

        private void yValue_TextChanged(object sender, TextChangedEventArgs e)
        {
            y = Convert.ToDouble(yValue.Text);
            ValuesEnable(); 
        }

        private void xValue_TextChanged(object sender, TextChangedEventArgs e)
        {
            x = Convert.ToDouble(xValue.Text);
            ValuesEnable();
            MessageBox.Show(x.ToString());
        }

        private void zValue_TextChanged(object sender, TextChangedEventArgs e)
        {
            z = Convert.ToDouble(zValue.Text);
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

        private void Next_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Pages._2());
        }

        private void Count_Click(object sender, RoutedEventArgs e)
        {
            z = Convert.ToDouble(zValue.Text);
            y = Convert.ToDouble(yValue.Text);
            x = Convert.ToDouble(xValue.Text);


            double numerator = 2 * Math.Cos(x - Math.PI / 6);
            double denominator = 0.5 + Math.Pow(Math.Sin(y), 2);
            double firstPart = numerator / denominator;

            double zSquare = Math.Pow(z, 2);
            double fraction = zSquare / (3 - zSquare / 5);
            double secondPart = 1 + fraction;

            double result = firstPart * secondPart;

            Otvet.Text = "Итог: " + result.ToString("F7");


        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            Otvet.Text = "Итог: ";

        }
    }
}
