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
        public void TestMethod1()
        {
            var _1 = new _1();
            double x = 1;
            double y = 2;
            double z = 3;
            

            //double sinY = Math.Sin(y);
            //double denominator1 = 0.5 + Math.Pow(sinY, 2);

            //double zSquare = Math.Pow(z, 2);
            ////double denominator2 = 3 - zSquare / 5;

            ////double numerator = 2 * Math.Cos(x - Math.PI / 6);
            //double firstPart = numerator / denominator1;

            //double fraction = zSquare / denominator2;
            //double secondPart = 1 + fraction;

            double result = ((2 * Math.Cos(x - Math.PI / 6)) / (3 - (Math.Pow(z, 2)) / 5)) * (1 + (Math.Pow(z, 2) / (3 - (Math.Pow(z, 2)) / 5)));

            
        }
    }
}
