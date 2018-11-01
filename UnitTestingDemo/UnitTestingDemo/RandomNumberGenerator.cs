using System;

namespace UnitTestingDemo
{
    public class RandomNumberGenerator : IRandomNumberGenerator
    {
        public int GenerateRandomInt()
        {
            var random = new Random();
            var value = random.Next(-1000000, 1000000);
            return value;
        }
    }
}
