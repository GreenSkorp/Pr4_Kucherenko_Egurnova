using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Практическая_Работа_4_Кучеренко_Егурнова;
using Практическая_Работа_4_Кучеренко_Егурнова.Pages;


namespace UnitTestProject
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethodPage_1()
        {
            var _1 = new _1();
            double x = 1;
            double y = 2;
            double z = 3;


            double siny = Math.Sin(y);
            double denominator1 = 0.5 + Math.Pow(siny, 2);

            double zsquare = Math.Pow(z, 2);
            double denominator2 = 3 - zsquare / 5;

            double numerator = 2 * Math.Cos(x - Math.PI / 6);
            double firstpart = numerator / denominator1;

            double fraction = zsquare / denominator2;
            double secondpart = 1 + fraction;
            double expected = firstpart * secondpart;

            double result = _1.funk1(x, y, z);

            Assert.AreEqual(expected, result, 0.001);

        }

        [TestMethod]
        public void TestMethodPage_2()
        {

        }
    }
}
