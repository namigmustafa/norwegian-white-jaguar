using System;
using System.Linq;

namespace NorwegianWhiteJaguar.Service.Common.Helper
{
    public class NumberGenerator
    {
        public static string Create(int range)
        {
            var random = new Random();

            var numberGeneratorChar = Constants.Constants.NumberGeneratorChar;

            var generatedNumbers = Enumerable.Range(0, range).Select(x => numberGeneratorChar[random.Next(0, numberGeneratorChar.Length)]);

            return new string(generatedNumbers.ToArray());
        }
    }
}
