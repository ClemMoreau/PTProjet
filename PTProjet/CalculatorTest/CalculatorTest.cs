using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PTProjetTest
{
    [TestClass]
    public class CalculatorTest
    {

        [TestMethod]
        public void TestAdd()
        {
            Assert.AreEqual(3, PTProjet.Calculator.Add(1,2));
        }

        [TestMethod]
        public void TestSubstract()
        {
            Assert.AreEqual(3, PTProjet.Calculator.Substract(5, 2));
        }

        [TestMethod]
        public void TestMultiply()
        {
            Assert.AreEqual(10, PTProjet.Calculator.Multiply(2,5));
        }

        [TestMethod]
        public void TestDivide()
        {
            Assert.AreEqual(2, PTProjet.Calculator.Divide(4, 2));
        }

    };
}