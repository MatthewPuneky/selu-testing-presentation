using System;
using Moq;
using NUnit.Framework;
using UnitTestingDemo;

namespace UnitTestingDemoTests
{
    [TestFixture]
    public class ComplicatedMathTests
    {
        #region Example2
        [Test]
        public void AddTwoNumbers_GivenTwoIntegers_ReturnsProductOfGivenIntegers_WithIntegratedLogger()
        {
            // Arrange
            var firstNumber = 4;
            var secondNumber = 7;

            var classToTest = new ComplicatedMath_WithLogger(new Logger());

            // Act
            var result = classToTest.AddTwoNumbers(firstNumber, secondNumber);

            // Assert
            var expectedResult = firstNumber + secondNumber;
            Assert.AreEqual(expectedResult, result);
        }
        #endregion

        #region Example3
        public class StubLogger : ILogger
        {
            public void Log(params object[] values)
            {
                // does nothing, making the test go faster
            }
        }

        [Test]
        public void AddTwoNumbers_GivenTwoIntegersAndAStubLogger_ReturnsProductOfGivenIntegers()
        {
            // Arrange
            var firstNumber = 4;
            var secondNumber = 7;

            var classToTest = new ComplicatedMath_WithLogger(new StubLogger());

            // Act
            var result = classToTest.AddTwoNumbers(firstNumber, secondNumber);

            // Assert
            var expectedResult = firstNumber + secondNumber;
            Assert.AreEqual(expectedResult, result);
        }
        #endregion

        #region Example4
        [Test]
        public void AddTwoNumbers_EnsuresLoggerWasCalledWithCorrectParams()
        {
            // Arrange
            var mockLogger = new Mock<ILogger>();
            mockLogger.Setup(x => x.Log(It.IsAny<object[]>()));

            var firstNumber = 4;
            var secondNumber = 7;

            var classToTest = new ComplicatedMath_WithLogger(mockLogger.Object);

            // Act
            classToTest.AddTwoNumbers(firstNumber, secondNumber);

            // Assert
            mockLogger.Verify(x => 
                x.Log(It.Is<object[]>(values => 
                    (int)values[0] == firstNumber
                    && (int)values[1] == secondNumber)),
                Times.Once);
        }
        #endregion

        #region Example5
        [Test]
        public void AddTwoNumbers_GivenTwoIntegers_ReturnsProductOfGivenIntegersAndRandomThirdNumber_Broken()
        {
            // Arrange
            var firstNumber = 4;
            var secondNumber = 7;

            var classToTest = new ComplicatedMath_WithRandomThirdNumber(new RandomNumberGenerator());

            // Act
            var result = classToTest.AddThreeNumbersWithThirdNumberRandom(firstNumber, secondNumber);

            // Assert
            //var expectedResult = firstNumber + secondNumber + ????;
            //Assert.AreEqual(expectedResult, result);
        }
        #endregion

        #region Example6
        [Test]
        public void AddTwoNumbers_GivenTwoIntegers_ReturnsProductOfGivenIntegersAndRandomThirdNumber_Working()
        {
            // Arrange
            var firstNumber = 4;
            var secondNumber = 7;
            var randomThirdNumber = 42;

            var mockRandomGenerator = new Mock<IRandomNumberGenerator>();

            mockRandomGenerator
                .Setup(x => x.GenerateRandomInt())
                .Returns(randomThirdNumber);

            var classToTest = new ComplicatedMath_WithRandomThirdNumber(mockRandomGenerator.Object);

            // Act
            var result = classToTest.AddThreeNumbersWithThirdNumberRandom(firstNumber, secondNumber);

            // Assert
            var expectedResult = firstNumber + secondNumber + randomThirdNumber;
            Assert.AreEqual(expectedResult, result);
        }
        #endregion
    }
}
