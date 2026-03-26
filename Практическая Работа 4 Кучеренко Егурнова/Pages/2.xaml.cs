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
    public partial class _2 : Page
    {
        public _2()
        {
            InitializeComponent();
        }

        private double FuncSh(double x)
        {
            return Math.Sinh(x);
        }

        private double FuncX2(double x)
        {
            return x * x;
        }

        private double FuncExp(double x)
        {
            return Math.Exp(x);
        }

        private double GetSelectedFunction(double x)
        {
            if (rbSh.IsChecked == true)
                return FuncSh(x);
            else if (rbX2.IsChecked == true)
                return FuncX2(x);
            else if (rbExp.IsChecked == true)
                return FuncExp(x);
            else
                return 0;
        }

        /// <summary>
        /// Вычисляет значение функции a = (f(x) + y)² ± √(|f(x)·y|) в зависимости от знака xy
        /// </summary>
        /// <param name="x">Аргумент x для функции f(x). Может принимать любые вещественные значения</param>
        /// <param name="y">Аргумент y. Влияет на знак выражения xy и подкоренное выражение</param>
        /// <param name="functionType">Тип функции f(x): 1 - sh(x), 2 - x², 3 - eˣ</param>
        /// <returns>Значение функции a</returns>
        /// <exception cref="ArgumentException">Выбрасывается, если functionType не равен 1, 2 или 3</exception>
        /// <exception cref="InvalidOperationException">Выбрасывается, если при xy > 0 подкоренное выражение отрицательное</exception>
        public double funk2(double x, double y, int functionType)
        {
            double fx;

            if (functionType == 1)
                fx = Math.Sinh(x);
            else if (functionType == 2)
                fx = x * x;
            else if (functionType == 3)
                fx = Math.Exp(x);
            else
                fx = 0;

            double xy = x * y;
            double basePart = Math.Pow(fx + y, 2);
            double result;

            if (xy > 0)
            {
                result = basePart - Math.Sqrt(fx * y);
            }
            else if (xy < 0)
            {
                result = basePart + Math.Sqrt(Math.Abs(fx * y));
            }
            else
            {
                result = basePart + 1;
            }

            return result;
        }

        private void Count_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!double.TryParse(xValue.Text, out double x))
                    throw new Exception("Введите корректное значение X");

                if (!double.TryParse(yValue.Text, out double y))
                    throw new Exception("Введите корректное значение Y");

                int functionType;
                if (rbSh.IsChecked == true)
                    functionType = 1;
                else if (rbX2.IsChecked == true)
                    functionType = 2;
                else if (rbExp.IsChecked == true)
                    functionType = 3;
                else
                    throw new Exception("Выберите функцию");

                double result = funk2(x, y, functionType);

                if (double.IsNaN(result) || double.IsInfinity(result))
                    throw new Exception("Результат вычисления не определен");

                Otvet.Text = result.ToString("F6");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                Otvet.Text = "Ошибка";
            }
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            xValue.Text = "";
            yValue.Text = "";
            Otvet.Text = "";
        }

        private void Next_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Pages._3());
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Pages._1());

        }
    }
}