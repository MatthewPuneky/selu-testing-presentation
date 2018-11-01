namespace UnitTestingDemo
{
    // ReSharper disable once InconsistentNaming
    public class ComplicatedMath_WithLogger
    {
        private readonly ILogger _logger;

        public ComplicatedMath_WithLogger(ILogger logger)
        {
            _logger = logger;
        }

        public int AddTwoNumbers(int x, int y)
        {
            _logger.Log(x, y);
            return x + y;
        }
    }

    // ReSharper disable once InconsistentNaming
    public class ComplicatedMath_WithRandomThirdNumber
    {
        private readonly IRandomNumberGenerator _randomNumberGenerator;

        public ComplicatedMath_WithRandomThirdNumber(
            IRandomNumberGenerator randomNumberGenerator)
        {
            _randomNumberGenerator = randomNumberGenerator;
        }

        public int AddThreeNumbersWithThirdNumberRandom(int x, int y)
        {
            var thirdNumber = _randomNumberGenerator.GenerateRandomInt();
            return x + y + thirdNumber;
        }
    }
}
