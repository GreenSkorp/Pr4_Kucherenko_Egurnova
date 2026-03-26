using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms.Integration;
using System.Windows.Forms.DataVisualization.Charting;
using System.Text;

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


        /// <summary>
        /// Вычисляет значение функции y = (10⁻²·b·c)/x + cos(√(a³·x))
        /// </summary>
        /// <param name="a">Параметр a. Определяет подкоренное выражение (a³·x). Должен быть ≥ 0</param>
        /// <param name="b">Параметр b. Участвует в первом слагаемом (10⁻²·b·c)/x</param>
        /// <param name="c">Параметр c. Участвует в первом слагаемом (10⁻²·b·c)/x</param>
        /// <param name="x">Аргумент x. Не может быть равен 0. Влияет на подкоренное выражение (a³·x)</param>
        /// <returns>Значение функции y</returns>
        /// <exception cref="DivideByZeroException">Выбрасывается, если x = 0</exception>
        /// <exception cref="ArgumentException">Выбрасывается, если подкоренное выражение (a³·x) отрицательное</exception>
        /// <exception cref="InvalidOperationException">Выбрасывается, если результат вычисления равен NaN или Infinity</exception>
        /// <exception cref="OverflowException">Выбрасывается, если аргумент косинуса слишком велик</exception>

        public double funk3(double a, double b, double c, double x)
        {
            if (x == 0)
                throw new DivideByZeroException("x не может быть равен 0");

            double firstTerm = (Math.Pow(10, -2) * b * c) / x;

            double argument = Math.Pow(a, 3) * x;
            if (argument < 0)
                throw new ArgumentException("Подкоренное выражение (a³·x) не может быть отрицательным");

            double sqrtArgument = Math.Sqrt(argument);
            double secondTerm = Math.Cos(sqrtArgument);

            double result = firstTerm + secondTerm;

            if (double.IsNaN(result) || double.IsInfinity(result))
                throw new InvalidOperationException("Результат не определен");

            return result;
        }

        // Метод для вычисления всех значений на отрезке
        public System.Collections.Generic.Dictionary<double, double> CalculateRange(
            double a, double b, double c, double x0, double xk, double dx)
        {
            var results = new System.Collections.Generic.Dictionary<double, double>();

            if (x0 > xk)
                throw new ArgumentException("x0 (начало отрезка) не может быть больше xk (конца отрезка)");

            if (dx <= 0)
                throw new ArgumentException("Шаг должен быть положительным числом");

            for (double currentX = x0; currentX <= xk + dx / 2; currentX += dx)
            {
                if (currentX > xk)
                    currentX = xk;

                try
                {
                    double result = funk3(a, b, c, currentX);
                    results.Add(currentX, result);
                }
                catch (Exception)
                {
                    // Пропускаем точки с ошибками
                    continue;
                }

                if (currentX >= xk)
                    break;
            }

            if (results.Count == 0)
                throw new InvalidOperationException("Не удалось вычислить ни одной точки");

            return results;
        }

        private void Count_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Получаем значения из текстовых полей
                if (!double.TryParse(x0Value.Text, out double x0))
                    throw new Exception("Введите корректное значение x0 (начало отрезка)");

                if (!double.TryParse(xkValue.Text, out double xk))
                    throw new Exception("Введите корректное значение xk (конец отрезка)");

                if (!double.TryParse(xValue.Text, out double dx))
                    throw new Exception("Введите корректное значение dx (шаг)");

                if (!double.TryParse(aValue.Text, out double a))
                    throw new Exception("Введите корректное значение a");

                if (!double.TryParse(bValue.Text, out double b))
                    throw new Exception("Введите корректное значение b");

                if (!double.TryParse(cValue.Text, out double c))
                    throw new Exception("Введите корректное значение c");

                // Проверка корректности границ
                if (x0 > xk)
                    throw new Exception("x0 (начало отрезка) не может быть больше xk (конца отрезка)");

                if (dx <= 0)
                    throw new Exception("Шаг должен быть положительным числом");

                // Очищаем предыдущие результаты
                ChartPayments.Series["y(x)"].Points.Clear();

                StringBuilder resultsBuilder = new StringBuilder();
                int pointCount = 0;

                // Вычисляем значения для всех точек на отрезке
                for (double currentX = x0; currentX <= xk + dx / 2; currentX += dx)
                {
                    if (currentX > xk)
                        currentX = xk;

                    try
                    {
                        double result = funk3(a, b, c, currentX);

                        // Добавляем точку на график
                        ChartPayments.Series["y(x)"].Points.AddXY(currentX, result);

                        // Форматируем вывод с разделительной строкой
                        if (pointCount > 0)
                        {
                            resultsBuilder.AppendLine("------------------");
                        }
                        resultsBuilder.AppendLine($"x={currentX:F4}, y={result:F6}");
                        pointCount++;
                    }
                    catch (Exception ex)
                    {
                        if (pointCount > 0)
                        {
                            resultsBuilder.AppendLine("------------------");
                        }
                        resultsBuilder.AppendLine($"x={currentX:F4}, Ошибка: {ex.Message}");
                    }

                    if (currentX >= xk)
                        break;
                }

                // Масштабируем график
                if (ChartPayments.Series["y(x)"].Points.Count > 0)
                    ChartPayments.ChartAreas[0].RecalculateAxesScale();

                if (pointCount == 0)
                {
                    Otvet.Text = "Не удалось вычислить ни одной точки";
                }
                else
                {
                    Otvet.Text = resultsBuilder.ToString().TrimEnd();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                Otvet.Text = "Ошибка: " + ex.Message;
            }
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            x0Value.Text = "";
            xkValue.Text = "";
            xValue.Text = "";
            aValue.Text = "";
            bValue.Text = "";
            cValue.Text = "";
            Otvet.Text = "";

            ChartPayments.Series["y(x)"].Points.Clear();
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Pages._2());
        }
    }
}