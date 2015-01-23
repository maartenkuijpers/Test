using NSubstitute;
using NUnit.Framework;
using UnitTestProject1.Interfaces;

namespace UnitTestProject1.NSubstitute
{
    [TestFixture]
    public class TestNSubstitute
    {
        private ICalculator calculator;

        [SetUp]
        public void TestInit()
        {
            calculator = Substitute.For<ICalculator>();
        }

        [Test]
        public void TestCalculatorAdd()
        {
            calculator.Add(1, 2).Returns(3);
            Assert.That(calculator.Add(1, 2), Is.EqualTo(3));
        }

        [Test]
        public void TestCalculatorInvalidAdd()
        {
            calculator.Add(1, 2);
            calculator.Received().Add(1, 2);
            calculator.DidNotReceive().Add(5, 7);
        }

        [Test]
        public void TestCalculatorMode()
        {
            calculator.Mode.Returns("DEC");
            Assert.That(calculator.Mode, Is.EqualTo("DEC"));

            calculator.Mode = "HEX";
            Assert.That(calculator.Mode, Is.EqualTo("HEX"));
        }

        [Test]
        public void TestCalculatorAddIntegerTypes()
        {
            calculator.Add(10, -5);
            calculator.Received().Add(10, Arg.Any<int>());
            calculator.Received().Add(10, Arg.Is<int>(x => x < 0));
        }

        [Test]
        public void TestCalculatorAddLogic()
        {
            calculator.Add(Arg.Any<int>(), Arg.Any<int>()).Returns(x => (int)x[0] + (int)x[1]);
            Assert.That(calculator.Add(5, 10), Is.EqualTo(15));
        }

        [Test]
        public void TestCalculatorMultipleModes()
        {
            calculator.Mode.Returns("HEX", "DEC", "BIN");
            Assert.That(calculator.Mode, Is.EqualTo("HEX"));
            Assert.That(calculator.Mode, Is.EqualTo("DEC"));
            Assert.That(calculator.Mode, Is.EqualTo("BIN"));
        }

        [Test]
        public void TestCalculatorRaiseEvents()
        {
            var eventWasRaised = false;
            calculator.PoweringUp += (sender, args) => eventWasRaised = true;
            calculator.PoweringUp += Raise.Event();
            Assert.That(eventWasRaised);
        }
    }
}
