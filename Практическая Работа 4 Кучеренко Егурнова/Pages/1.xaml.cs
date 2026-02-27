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
    public partial class _1 : Page
    {
        private double x, y, z;

        public _1()
        {
            InitializeComponent();
        }

        private void yValue_TextChanged(object sender, TextChangedEventArgs e)
        {
            TryParseValue(yValue, ref y);
            ValuesEnable();
        }

        private void xValue_TextChanged(object sender, TextChangedEventArgs e)
        {
            TryParseValue(xValue, ref x);
            ValuesEnable();
        }

        private void zValue_TextChanged(object sender, TextChangedEventArgs e)
        {
            TryParseValue(zValue, ref z);
            ValuesEnable();
        }

        private bool TryParseValue(TextBox textBox, ref double value)
        {
            if (string.IsNullOrWhiteSpace(textBox.Text))
                return false;

            if (double.TryParse(textBox.Text, out double result))
            {
                value = result;
                return true;
            }
            return false;
        }

        private void ValuesEnable()
        {
            bool xValid = double.TryParse(xValue.Text, out _);
            bool yValid = double.TryParse(yValue.Text, out _);
            bool zValid = double.TryParse(zValue.Text, out _);

            Count.IsEnabled = xValid && yValid && zValid;
        }

        private void Next_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Pages._2());
        }

        private void Count_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(xValue.Text))
                    throw new Exception("Введите значение X");

                if (string.IsNullOrWhiteSpace(yValue.Text))
                    throw new Exception("Введите значение Y");

                if (string.IsNullOrWhiteSpace(zValue.Text))
                    throw new Exception("Введите значение Z");

                if (!double.TryParse(xValue.Text, out x))
                    throw new Exception("Введите корректное числовое значение X");

                if (!double.TryParse(yValue.Text, out y))
                    throw new Exception("Введите корректное числовое значение Y");

                if (!double.TryParse(zValue.Text, out z))
                    throw new Exception("Введите корректное числовое значение Z");

                if (double.IsNaN(x) || double.IsInfinity(x))
                    throw new Exception("X содержит некорректное значение");

                if (double.IsNaN(y) || double.IsInfinity(y))
                    throw new Exception("Y содержит некорректное значение");

                if (double.IsNaN(z) || double.IsInfinity(z))
                    throw new Exception("Z содержит некорректное значение");

                double sinY = Math.Sin(y);
                double denominator1 = 0.5 + Math.Pow(sinY, 2);

                if (denominator1 == 0)
                    throw new Exception("Знаменатель (0.5 + sin²(y)) не может быть равен 0");

                double zSquare = Math.Pow(z, 2);
                double denominator2 = 3 - zSquare / 5;

                if (denominator2 == 0)
                    throw new Exception("Знаменатель (3 - z²/5) не может быть равен 0. Решение: z² ≠ 15");

                if (double.IsInfinity(zSquare / 5))
                    throw new Exception("Значение z² слишком велико");

                double numerator = 2 * Math.Cos(x - Math.PI / 6);
                double firstPart = numerator / denominator1;

                double fraction = zSquare / denominator2;
                double secondPart = 1 + fraction;

                double result = firstPart * secondPart;

                if (double.IsNaN(result) || double.IsInfinity(result))
                    throw new Exception("Результат вычисления не определен");

                Otvet.Text = result.ToString("F7");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                Otvet.Text = "Ошибка";
            }
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            xValue.Text = string.Empty;
            yValue.Text = string.Empty;
            zValue.Text = string.Empty;

            Otvet.Text = "";


        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            foreach (char c in e.Text)
            {
                if (!char.IsDigit(c) && c != '.' && c != '-' && c != ',')
                {
                    e.Handled = true;
                    return;
                }
            }
        }

        private void TextBox_Pasting(object sender, DataObjectPastingEventArgs e)
        {
            if (e.DataObject.GetDataPresent(typeof(string)))
            {
                string text = (string)e.DataObject.GetData(typeof(string));
                foreach (char c in text)
                {
                    if (!char.IsDigit(c) && c != '.' && c != '-' && c != ',')
                    {
                        e.CancelCommand();
                        return;
                    }
                }
            }
        }
    }
}