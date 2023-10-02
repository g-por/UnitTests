using Microsoft.VisualStudio.TestTools.UnitTesting;
using Polynom_lab1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polynom_lab1.Tests
{
    [TestClass()]
    public class PolynomTests
    {

        [TestMethod()]
        public void CalcPolTest_СalculationValueOfThePolynomial()
        {
            //Arrange
            int[] coef = { 1, 3, 2 };
            Polynom p1 = new Polynom(coef);
            //Action
            int result = p1.CalcPol(2);
            //Assert
            Assert.AreEqual(15, result);
        }

        [TestMethod()]
        public void IsEqualPol_PolynomialsAreEqual_ReturnsTrue()
        {
            //Arrange
            int[] coef1 = { 1, 2, 3 };
            Polynom p1 = new Polynom(coef1);
            Polynom p2 = new Polynom(p1);
            // Act
            bool result = p1.IsEqualPol(p2);
            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod()]
        public void IsEqualPol_PolynomialsAreNotEqual_ReturnsFalse()
        {
            // Arrange
            int[] coef1 = { 1, 2, 3 };
            int[] coef2 = { 1, 2, 4 };
            Polynom p1 = new Polynom(coef1);
            Polynom p2 = new Polynom(coef2);
            // Action
            bool result = p1.IsEqualPol(p2);
            // Assert
            Assert.IsFalse(result);
        }
        [TestMethod()]
        public void IsEqualPol_PolynomialsHaveDifferentSizes_ReturnsFalse()
        {
            // Arrange
            int[] coef1 = { 1, 2, 3 };
            int[] coef2 = { 1, 2, 3, 4 };
            Polynom p1 = new Polynom(coef1);
            Polynom p2 = new Polynom(coef2);
            // Action
            bool result = p1.IsEqualPol(p2);
            // Assert
            Assert.IsFalse(result);
        }


        [TestMethod()]
        public void MultNumTest_MultiplicationPolynomAtNumber()
        {
            // Arrange
            int[] coef = { 4, 5, 6 };
            Polynom p = new Polynom(coef);
            int number = 2;
            // Action
            Polynom result = p.MultNum(number);
            int[] expectedCoef = { 4 * 2, 5 * 2, 6 * 2 };
            Polynom expectedResult = new Polynom(expectedCoef);
            // Assert
            Assert.IsTrue(result.IsEqualPol(expectedResult));
        }

        [TestMethod()]
        public void SubNumTest_SubtractingNumberFromPolynomial()
        {
            // Arrange
            int[] coef = { 3, 7, 9 };
            Polynom p = new Polynom(coef);
            int number = 2;
            // Action
            Polynom result = p.SubNum(p, number);
            int[] expectedCoef = { 3 - 2, 7, 9 };
            // Assert
            Assert.AreEqual(expectedCoef.Length, result.head.Size); 
            Node currentNode = result.head;
            for (int i = 0; i < expectedCoef.Length; i++)
            {
                Assert.AreEqual(expectedCoef[i], currentNode.Coef); 
                currentNode = currentNode.PointerNext;
            }
        }

        [TestMethod()]
        public void SumNumTest_AddedNumberToPolynomial()
        {
            // Arrange
            int[] coef = { 2, 7, 1 };
            Polynom p = new Polynom(coef);
            int number = 2;
            // Action
            Polynom result = p.SumNum(p, number);
            int[] expectedCoef = { 2 + 2, 7, 1 };
            Polynom expectedResult = new Polynom(expectedCoef);
            // Assert
            Assert.IsTrue(result.IsEqualPol(expectedResult));
        }

        [TestMethod()]
        public void AddTermTest_TestsOfAddingNodesToLists()
        {
            // Arrange
            Polynom p = new Polynom();
            // Action
            p.AddTerm(2);
            p.AddTerm(3);
            p.AddTerm(1);
            // Assert
            Assert.AreEqual(3, p.head.Size); 
            Assert.AreEqual(2, p.head.Coef);
            Assert.AreEqual(3, p.head.PointerNext.Coef); 
            Assert.AreEqual(1, p.head.PointerNext.PointerNext.Coef);
        }

        [TestMethod()]
        public void SumPolTest_differentSizes_SumOfPolynomialsDifferentSizes()
        {
            // Arrange
            int[] coef1 = { 1, 2, 3 };
            int[] coef2 = { 4, 5, 6, 7 };
            Polynom p1 = new Polynom(coef1);
            Polynom p2 = new Polynom(coef2);
            // Action
            Polynom result = p1.SumPol(p2);
            // Assert
            int[] expectedCoef = { 1 + 4, 2 + 5, 3 + 6, 7 + 0 }; 
            Polynom expectedResult = new Polynom(expectedCoef);
            Assert.IsTrue(result.IsEqualPol(expectedResult));
        }

        [TestMethod()]
        public void SumPolTest_sameSizes_SumOfPolynomialsSameSizes()
        {
            int[] coef = { 1, 2, 3 };
            Polynom p1 = new Polynom(coef);
            Polynom p2 = new Polynom(3, coef);
            // Action
            Polynom result = p1.SumPol(p2);
            // Assert
            int[] expectedCoef = { 1 + 1, 2 + 2, 3 + 3};
            Polynom expectedResult = new Polynom(expectedCoef);
            Assert.IsTrue(result.IsEqualPol(expectedResult));

        }

        [TestMethod()]
        public void SubPolTest_SameSize_SubstractionOfPolynomialsSameSizes()
        {
            // Arrange
            int[] coef1 = { 3, 7, 9 };
            int[] coef2 = { 1, 2, 3 };
            Polynom p1 = new Polynom(coef1);
            Polynom p2 = new Polynom(coef2);

            // Action
            Polynom result = p1.SubPol(p2);
            int[] expectedCoef = { 3 - 1, 7 - 2, 9 - 3 };
            Polynom expectedResult = new Polynom(expectedCoef);

            // Assert
            Assert.AreEqual(expectedResult.head.Size, result.head.Size);
            Node currentNode = result.head;

            for (int i = 0; i < expectedCoef.Length; i++)
            {
                Assert.AreEqual(expectedCoef[i], currentNode.Coef);
                currentNode = currentNode.PointerNext;
            }
        }

        [TestMethod()]
        public void SubPolTest_SameSize_SubstractionOfPolynomialsDifferentSizes()
        {
            // Arrange
            int[] coef1 = { 3, 7, 9 };
            int[] coef2 = { 1, 2, 3, 6 };
            Polynom p1 = new Polynom(coef1);
            Polynom p2 = new Polynom(coef2);

            // Action
            Polynom result = p1.SubPol(p2);
            int[] expectedCoef = { 3 - 1, 7 - 2, 9 - 3 , 0 - 6};
            Polynom expectedResult = new Polynom(expectedCoef);

            // Assert
            Assert.AreEqual(expectedResult.head.Size, result.head.Size);
            Node currentNode = result.head;

            for (int i = 0; i < expectedCoef.Length; i++)
            {
                Assert.AreEqual(expectedCoef[i], currentNode.Coef);
                currentNode = currentNode.PointerNext;
            }
        }

        [TestMethod()]
        public void SubPolTest_SameSize_SubstractionOfPolynomialsNegativeValue()
        {
            // Arrange
            int[] coef1 = { 0, -2, 1, -2 };
            int[] coef2 = { -1, -2, -3, 6 };
            Polynom p1 = new Polynom(coef1);
            Polynom p2 = new Polynom(coef2);

            // Action
            Polynom result = p1.SubPol(p2);
            int[] expectedCoef = { 0 - (-1), -2 - (-2), 1 -(-3), - 2 - 6 };
            Polynom expectedResult = new Polynom(expectedCoef);

            // Assert
            Assert.AreEqual(expectedResult.head.Size, result.head.Size);
            Node currentNode = result.head;

            for (int i = 0; i < expectedCoef.Length; i++)
            {
                Assert.AreEqual(expectedCoef[i], currentNode.Coef);
                currentNode = currentNode.PointerNext;
            }
        }

        [TestMethod()]
        public void MultPolTest_MultiplicactionOfPolynomials()
        {
            //Arrange
            int[] coef1 = { 1, 2, 3 }; // Перший поліном: 1 + 2x + 3x^2
            int[] coef2 = { 4, 5 };    // Другий поліном: 4 + 5x

            Polynom p1 = new Polynom(coef1);
            Polynom p2 = new Polynom(coef2);

            // Act
            Polynom result = p1 * p2; // Використовуємо оператор множення

            // Assert
            int[] expectedCoefs = { 4, 13, 22, 15 }; // Результат множення: 4 + 13x + 22x^2 + 15x^3
            Polynom expected = new Polynom(expectedCoefs);

            Node currentNode = result.head; // Отримуємо початковий вузол результату

            for (int i = 0; i < expectedCoefs.Length; i++)
            {
                Assert.AreEqual(expectedCoefs[i], currentNode.Coef); // Порівнюємо кожен коефіцієнт
                currentNode = currentNode.PointerNext; // Переходимо до наступного вузла
            }
        }
        [TestMethod()]
        public void ToString_ReturnsCorrectString()
        {
            // Arrange
            int[] coef = { 1, 2, 3 }; // Поліном: 1 + 2x + 3x^2
            Polynom p = new Polynom(coef);
            // Act
            string result = p.ToString(); 
            // Assert
            string expected = "1 + 2x + 3x^2"; 
            Assert.AreEqual(expected, result);
        }


    }
}