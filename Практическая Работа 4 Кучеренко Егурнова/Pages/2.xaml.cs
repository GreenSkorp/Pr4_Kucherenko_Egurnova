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
    /// Логика взаимодействия для _2.xaml
    /// </summary>
    public partial class _2 : Page
    {
        public _2()
        {
            InitializeComponent();
        }

        private double FuncSh(double x)
        {
            return Math.Sinh(x); // гиперболический синус
        }

        private double FuncX2(double x)
        {
            return x * x; // x в квадрате
        }

        private double FuncExp(double x)
        {
            return Math.Exp(x); // e^x
        }

        // Получение выбранной функции
        private double GetSelectedFunction(double x)
        {
            if (rbSh.IsChecked == true)
                return FuncSh(x);
            else if (rbX2.IsChecked == true)
                return FuncX2(x);
            else if (rbExp.IsChecked == true)
                return FuncExp(x);
            else
                return 0; // по умолчанию
        }

 
        private void Count_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Получаем значения x и y
                if (!double.TryParse(xValue.Text, out double x))
                    throw new Exception("Введите корректное значение X");

                if (!double.TryParse(yValue.Text, out double y))
                    throw new Exception("Введите корректное значение Y");

                // Вычисляем f(x)
                double fx = GetSelectedFunction(x);

                // Произведение xy для определения условия
                double xy = x * y;

                // Базовое слагаемое (f(x) + y)^2
                double basePart = Math.Pow(fx + y, 2);

                double result;

                // Выбор ветки по условию
                if (xy > 0)
                {
                    // (f(x) + y)^2 - sqrt(f(x) * y)
                    result = basePart - Math.Sqrt(fx * y);
                }
                else if (xy < 0)
                {
                    // (f(x) + y)^2 + sqrt(|f(x) * y|)
                    result = basePart + Math.Sqrt(Math.Abs(fx * y));
                }
                else // xy == 0
                {
                    // (f(x) + y)^2 + 1
                    result = basePart + 1;
                }

                Otvet.Text = result.ToString("F6");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                Otvet.Text = "Ошибка";
            }
        }

        // Обработчик кнопки "Очистить"
        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            Otvet.Text = "0.000";
        }
        private void Next_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Pages._3());
        }
    }

}

