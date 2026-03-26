using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Практическая_Работа_4_Кучеренко_Егурнова;
using Практическая_Работа_4_Кучеренко_Егурнова.Pages;


namespace UnitTestProject
{
    [TestClass]
    public class FirstFormulaTest
    {
        private _1 formula1;

        [TestInitialize]
        public void Setup()
        {
            formula1 = new _1();
        }

        [TestMethod]
        public void FirstFormula_Normal1_x1_y1_z1()
        {
            double result = formula1.funk1(1, 1, 1);
            Assert.AreEqual(1.996, result, 0.01);
        }

        [TestMethod]
        public void FirstFormula_Normal2_x2_y2_z2()
        {
            double result = formula1.funk1(2, 2, 2);
            // cos(2-0.5236)=cos(1.4764)=0.0998
            // numerator1=0.1996, sin(2)=0.9093, sin²=0.8268, denom1=1.3268, firstPart=0.1505
            // z²=4, denom2=3-0.8=2.2, fraction=1.8182, secondPart=2.8182
            // result=0.1505*2.8182=0.424
            Assert.AreEqual(0.424, result, 0.03);
        }

        [TestMethod]
        public void FirstFormula_Normal3_x0_y0_z0()
        {
            double result = formula1.funk1(0, 0, 0);
            Assert.AreEqual(3.464, result, 0.01);
        }

        [TestMethod]
        [ExpectedException(typeof(DivideByZeroException))]
        public void FirstFormula_Boundary_Z_Sqrt15()
        {
            double z = Math.Sqrt(15);
            formula1.funk1(0, 0, z);
        }

        [TestMethod]
        [ExpectedException(typeof(DivideByZeroException))]
        public void FirstFormula_Boundary_Z_NegSqrt15()
        {
            double z = -Math.Sqrt(15);
            formula1.funk1(0, 0, z);
        }

        [TestMethod]
        public void FirstFormula_Boundary_Z_BelowSqrt15()
        {
            double result = formula1.funk1(0, 0, 3.87);
            Assert.AreEqual(11235, result, 50);
        }

        [TestMethod]
        public void FirstFormula_Boundary_Z_AboveSqrt15()
        {
            double result = formula1.funk1(0, 0, 3.88);
            Assert.AreEqual(-4790, result, 50);
        }

        [TestMethod]
        public void FirstFormula_Boundary_X_Pi3()
        {
            double result = formula1.funk1(Math.PI / 3, 0, 1);
            Assert.AreEqual(4.702, result, 0.01);
        }

        [TestMethod]
        public void FirstFormula_Boundary_X_NegPi3()
        {
            double result = formula1.funk1(-Math.PI / 3, 0, 1);
            Assert.AreEqual(0, result, 0.001);
        }
    }

    [TestClass]
    public class SecondFormulaTest
    {
        private _2 formula2;

        [TestInitialize]
        public void Setup()
        {
            formula2 = new _2();
        }

        // Тесты для sh(x)
        [TestMethod]
        public void SecondFormula_Sh_XY_Positive_x2_y3()
        {
            double result = formula2.funk2(2, 3, 1);
            Assert.AreEqual(40.616, result, 0.01);
        }

        [TestMethod]
        public void SecondFormula_Sh_XY_Positive_x1_y0_3()
        {
            double result = formula2.funk2(1, 0.3, 1);
            Assert.AreEqual(1.5822, result, 0.01);
        }

        [TestMethod]
        public void SecondFormula_Sh_XY_Positive_x5_y6()
        {
            double result = formula2.funk2(5, 6, 1);
            Assert.AreEqual(6411.449, result, 0.05);
        }

        // Тесты для x²
        [TestMethod]
        public void SecondFormula_X2_XY_Positive_x2_y3()
        {
            double result = formula2.funk2(2, 3, 2);
            Assert.AreEqual(45.5359, result, 0.01);
        }

        [TestMethod]
        public void SecondFormula_X2_XY_Positive_x1_y0_3()
        {
            double result = formula2.funk2(1, 0.3, 2);
            Assert.AreEqual(1.1423, result, 0.01);
        }

        [TestMethod]
        public void SecondFormula_X2_XY_Positive_x5_y6()
        {
            double result = formula2.funk2(5, 6, 2);
            Assert.AreEqual(948.7526, result, 0.05);
        }

        // Тесты для e^x
        [TestMethod]
        public void SecondFormula_Exp_XY_Positive_x2_y3()
        {
            double result = formula2.funk2(2, 3, 3);
            Assert.AreEqual(103.222, result, 0.01);
        }

        [TestMethod]
        public void SecondFormula_Exp_XY_Positive_x1_y0_3()
        {
            double result = formula2.funk2(1, 0.3, 3);
            Assert.AreEqual(8.207, result, 0.01);
        }

        [TestMethod]
        public void SecondFormula_Exp_XY_Positive_x5_y6()
        {
            double result = formula2.funk2(5, 6, 3);
            Assert.AreEqual(23813.559, result, 0.05);
        }

        // Тесты для xy < 0
        [TestMethod]
        public void SecondFormula_XY_Negative_x2_y_3()
        {
            double result = formula2.funk2(2, -3, 1);
            Assert.AreEqual(3.692, result, 0.01);
        }

        // Тесты для xy = 0
        [TestMethod]
        public void SecondFormula_XY_Zero_x0_y5()
        {
            double result = formula2.funk2(0, 5, 1);
            Assert.AreEqual(26, result, 0.01);
        }

        [TestMethod]
        public void SecondFormula_XY_Zero_x5_y0()
        {
            double result = formula2.funk2(5, 0, 1);
            Assert.AreEqual(5507.116, result, 0.01);
        }

        [TestMethod]
        public void SecondFormula_XY_Zero_Both()
        {
            double result = formula2.funk2(0, 0, 1);
            Assert.AreEqual(1, result, 0.001);
        }

        // Граничные тесты
        [TestMethod]
        public void SecondFormula_Boundary_XY_Positive_Small()
        {
            double result = formula2.funk2(0.0001, 0.0001, 1);
            Assert.AreEqual(-0.00009996, result, 0.000001);
        }

        [TestMethod]
        public void SecondFormula_Boundary_XY_Negative_Small()
        {
            double result = formula2.funk2(0.0001, -0.0001, 1);
            Assert.AreEqual(0.0001, result, 0.000001);
        }
    }

    [TestClass]
    public class ThirdFormulaTest
    {
        private _3 formula3;

        [TestInitialize]
        public void Setup()
        {
            formula3 = new _3();
        }

        // ========== ТЕСТЫ ДЛЯ ОДНОЙ ТОЧКИ (funk3) ==========
        
        [TestMethod]
        public void ThirdFormula_SinglePoint_Normal1()
        {
            double result = formula3.funk3(1, 1, 1, 1);
            Assert.AreEqual(0.550302, result, 0.0001);
        }

        [TestMethod]
        public void ThirdFormula_SinglePoint_Normal2()
        {

            double result = formula3.funk3(4, 2, 3, 2);
            Assert.AreEqual(0.342795, result, 0.001);
        }

        [TestMethod]
        public void ThirdFormula_SinglePoint_Normal3()
        {
            double result = formula3.funk3(0, 5, 5, 1);
            Assert.AreEqual(1.25, result, 0.0001);
        }

        [TestMethod]
        public void ThirdFormula_SinglePoint_WithGivenValues_x1()
        {
            double result = formula3.funk3(1, 2, 3, 1);
            Assert.AreEqual(0.600302, result, 0.0001);
        }

        [TestMethod]
        public void ThirdFormula_SinglePoint_WithGivenValues_x3()
        {
            double result = formula3.funk3(1, 2, 3, 3);
            Assert.AreEqual(-0.140557, result, 0.0001);
        }

        [TestMethod]
        [ExpectedException(typeof(DivideByZeroException))]
        public void ThirdFormula_SinglePoint_X_Zero()
        {
            formula3.funk3(1, 1, 1, 0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ThirdFormula_SinglePoint_A_Negative()
        {
            formula3.funk3(-1, 1, 1, 1);
        }

        [TestMethod]
        public void ThirdFormula_SinglePoint_X_SmallPositive()
        {
            double result = formula3.funk3(1, 1, 1, 0.0001);
            Assert.AreEqual(100.999999995, result, 0.0001);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ThirdFormula_SinglePoint_X_SmallNegative()
        {
            // x = -0.0001 дает отрицательное подкоренное выражение (a³*x < 0)
            formula3.funk3(1, 1, 1, -0.0001);
        }

        // ========== ТЕСТЫ ДЛЯ ДИАПАЗОНА ЗНАЧЕНИЙ (CalculateRange) ==========
        
        [TestMethod]
        public void ThirdFormula_Range_Normal_Step1()
        {
            // x0=1, xk=5, dx=1
            var results = formula3.CalculateRange(1, 1, 1, 1, 5, 1);
            
            // Количество точек: (5-1)/1 + 1 = 5
            Assert.AreEqual(5, results.Count);
            Assert.IsTrue(results.ContainsKey(1));
            Assert.IsTrue(results.ContainsKey(5));
        }

        [TestMethod]
        public void ThirdFormula_Range_Step2()
        {
            // x0=1, xk=5, dx=2
            var results = formula3.CalculateRange(1, 1, 1, 1, 5, 2);
            
            // Количество точек: (5-1)/2 + 1 = 3
            Assert.AreEqual(3, results.Count);
            Assert.IsTrue(results.ContainsKey(1));
            Assert.IsTrue(results.ContainsKey(3));
            Assert.IsTrue(results.ContainsKey(5));
        }

        [TestMethod]
        public void ThirdFormula_Range_IncludesBoundaries()
        {
            // x0=1, xk=4, dx=3
            var results = formula3.CalculateRange(1, 1, 1, 1, 4, 3);
            
            // Количество точек: (4-1)/3 + 1 = 2
            Assert.AreEqual(2, results.Count);
            Assert.IsTrue(results.ContainsKey(1));
            Assert.IsTrue(results.ContainsKey(4));
        }

        [TestMethod]
        public void ThirdFormula_Range_WithGivenValues_FromScreenshot()
        {
            var results = formula3.CalculateRange(1, 2, 3, 1, 20, 2);
            

            Assert.IsTrue(results.Count >= 9);
            Assert.IsTrue(results.Count <= 11);
            
            if (results.ContainsKey(1))
                Assert.AreEqual(0.600302, results[1], 0.0001);
            if (results.ContainsKey(3))
                Assert.AreEqual(-0.140557, results[3], 0.0001);
            if (results.ContainsKey(5))
                Assert.AreEqual(-0.605273, results[5], 0.0001);
        }

        [TestMethod]
        public void ThirdFormula_Range_SkipInvalidPoints()
        {

            var results = formula3.CalculateRange(1, 1, 1, -1, 1, 1);

            Assert.IsFalse(results.ContainsKey(0), "Точка x=0 должна быть пропущена");

            Assert.IsTrue(results.ContainsKey(-1) || results.ContainsKey(1),
                "Должна быть хотя бы одна корректная точка");

            if (results.ContainsKey(-1))
            {
                double result = formula3.funk3(1, 1, 1, -1);
                Assert.AreEqual(result, results[-1], 0.000001,
                    "Значение в точке x=-1 не соответствует ожидаемому");
            }

            if (results.ContainsKey(1))
            {
                double result = formula3.funk3(1, 1, 1, 1);
                Assert.AreEqual(result, results[1], 0.000001,
                    "Значение в точке x=1 не соответствует ожидаемому");
            }
        }

        [TestMethod]
        public void ThirdFormula_Range_AllPointsValid()
        {
            var results = formula3.CalculateRange(1, 1, 1, 1, 10, 1);
            
            Assert.IsTrue(results.Count >= 9);
            
            foreach (var point in results)
            {
                Assert.IsFalse(double.IsNaN(point.Value));
                Assert.IsFalse(double.IsInfinity(point.Value));
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ThirdFormula_Range_InvalidX0GreaterXk()
        {
            formula3.CalculateRange(1, 1, 1, 5, 1, 1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ThirdFormula_Range_NegativeStep()
        {
            formula3.CalculateRange(1, 1, 1, 1, 5, -1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ThirdFormula_Range_ZeroStep()
        {
            formula3.CalculateRange(1, 1, 1, 1, 5, 0);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ThirdFormula_Range_AllPointsInvalid()
        {
            formula3.CalculateRange(-1, 1, 1, 1, 5, 1);
        }
    }

    [TestClass]
    public class IntegrationTests
    {
        private _1 formula1;
        private _2 formula2;
        private _3 formula3;

        [TestInitialize]
        public void Setup()
        {
            formula1 = new _1();
            formula2 = new _2();
            formula3 = new _3();
        }

        [TestMethod]
        public void Integration_AllFormulas_WithValidInputs_ShouldNotThrow()
        {
            double result1 = formula1.funk1(1, 1, 1);
            double result2 = formula2.funk2(1, 1, 1);
            double result3 = formula3.funk3(1, 1, 1, 1);

            Assert.IsFalse(double.IsNaN(result1));
            Assert.IsFalse(double.IsNaN(result2));
            Assert.IsFalse(double.IsNaN(result3));
        }

        [TestMethod]
        public void Integration_AllFormulas_WithInvalidInputs_ShouldThrow()
        {
            Assert.ThrowsException<DivideByZeroException>(() => formula1.funk1(0, 0, Math.Sqrt(15)));
            Assert.ThrowsException<DivideByZeroException>(() => formula3.funk3(1, 1, 1, 0));
            Assert.ThrowsException<ArgumentException>(() => formula3.funk3(-1, 1, 1, 1));
        }

        [TestMethod]
        public void Integration_AllFormulas_WithBoundaryValues_ShouldWork()
        {
            double result1 = formula1.funk1(0, 0, 3.87);
            Assert.IsFalse(double.IsNaN(result1));
            
            double result2 = formula2.funk2(0.0001, 0.0001, 1);
            Assert.IsFalse(double.IsNaN(result2));
            
            var results3 = formula3.CalculateRange(1, 1, 1, 0.1, 0.5, 0.1);
            Assert.IsTrue(results3.Count > 0);
        }
    }
}