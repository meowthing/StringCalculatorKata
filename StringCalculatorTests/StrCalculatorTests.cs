using StringCalculator;

namespace StringCalculatorTests
{
    public class StrCalculatorTests
    {
        StrCalculator calculator;

        [SetUp]
        public void Setup()
        {
            calculator = new StrCalculator();
        }

        [Test]
        public void TestBlank()
        {
            Assert.That(calculator.Add(""), Is.EqualTo(0));
        }

        [Test]
        [TestCase("2", 2)]
        public void TestSingleNumber(string numberString, int result)
        {
            Assert.That(calculator.Add(numberString), Is.EqualTo(result));
        }

        [Test]
        [TestCase("1,2", 3)]
        public void TestAddTwoNumbers(string numberString, int result)
        {
            Assert.That(calculator.Add(numberString), Is.EqualTo(result));
        }

        [Test]
        [TestCase("3,6,10", 19)]
        [TestCase("1,1,2,3,10", 17)]
        [TestCase("1,1,2,3,1001", 7)]
        [TestCase("1,1,2,3,1000", 1007)]
        public void TestAddAnyNumbers(string numberString, int result)
        {
            Assert.That(calculator.Add(numberString), Is.EqualTo(result));
        }

        [Test]
        public void TestSpacesBetweenNumbers()
        {
            Assert.That(calculator.Add("1 2, 3, 4"), Is.EqualTo(10));
        }

        [Test]
        [TestCase("//;\n1;2", 3)]
        [TestCase("//[***]\n1***2***3", 6)]
        [TestCase("//[*][%]\n1*2%3", 6)]
        public void TestRandomDelimiters(string numbers, int result)
        {
            Assert.That(calculator.Add(numbers), Is.EqualTo(result));
        }

        [Test]
        public void TestNoNegativesAllowed()
        {
            Assert.That(() => calculator.Add("-2"), Throws.ArgumentException);
        }
    }
}