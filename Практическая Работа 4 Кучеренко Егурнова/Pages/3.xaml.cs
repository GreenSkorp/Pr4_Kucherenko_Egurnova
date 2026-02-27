using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms.Integration;
using System.Windows.Forms.DataVisualization.Charting;

namespace Практическая_Работа_4_Кучеренко_Егурнова.Pages
{
    public partial class _3 : Page
    {
        public _3()
        {
            InitializeComponent();
            InitializeChart();
        }

        private void InitializeChart()
        {
            ChartPayments.Legends.Clear();

            ChartArea chartArea = new ChartArea();
            chartArea.AxisX.Title = "x";
            chartArea.AxisY.Title = "y";
            chartArea.AxisX.Minimum = 0;
            chartArea.AxisX.Maximum = 10;
            ChartPayments.ChartAreas.Add(chartArea);

            Series series = new Series
            {
                Name = "y(x)",
                ChartType = SeriesChartType.Line,
                BorderWidth = 3,
                Color = System.Drawing.Color.Blue
            };

            ChartPayments.Series.Add(series);
        }

        private void Count_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Получаем значения из текстовых полей
                if (!double.TryParse(xValue.Text, out double x))
                    throw new Exception("Введите корректное значение x");

                if (!double.TryParse(aValue.Text, out double a))
                    throw new Exception("Введите корректное значение a");

                if (!double.TryParse(bValue.Text, out double b))
                    throw new Exception("Введите корректное значение b");

                if (!double.TryParse(cValue.Text, out double c))
                    throw new Exception("Введите корректное значение c");

                // Проверка деления на ноль
                if (x == 0)
                    throw new Exception("x не может быть равен 0");

                // Вычисление по формуле: y = (10^(-2) * b * c) / x + cos(sqrt(a^3 * x))
                double firstTerm = (Math.Pow(10, -2) * b * c) / x;
                double sqrtArgument = Math.Sqrt(Math.Pow(a, 3) * x);
                double secondTerm = Math.Cos(sqrtArgument);

                double result = firstTerm + secondTerm;

                // Проверка на корректность результата
                if (double.IsNaN(result) || double.IsInfinity(result))
                    throw new Exception("Результат не определен (возможно подкоренное выражение отрицательно)");

                // Вывод результата
                Otvet.Text = result.ToString("F6");

                // Построение графика
                PlotGraph(a, b, c);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                Otvet.Text = "Ошибка";
            }
        }

        private void PlotGraph(double a, double b, double c)
        {
            ChartPayments.Series["y(x)"].Points.Clear();

            for (double x = 0.1; x <= 10; x += 0.1)
            {
                double firstTerm = (Math.Pow(10, -2) * b * c) / x;
                double sqrtArgument = Math.Sqrt(Math.Pow(a, 3) * x);
                double secondTerm = Math.Cos(sqrtArgument);

                double y = firstTerm + secondTerm;

                if (!double.IsNaN(y) && !double.IsInfinity(y))
                {
                    ChartPayments.Series["y(x)"].Points.AddXY(x, y);
                }
            }

            ChartPayments.ChartAreas[0].RecalculateAxesScale();
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            xValue.Text = "";
            aValue.Text = "";
            bValue.Text = "";
            cValue.Text = "";
            Otvet.Text = "";

            ChartPayments.Series["y(x)"].Points.Clear();
        }
    }
}