using System.Reflection.Metadata.Ecma335;
using System.Text.RegularExpressions;

namespace StringCalculator
{
    public class StrCalculator
    {
        public StrCalculator() { }

        public int Add(string numbers)
        {
            if (string.IsNullOrEmpty(numbers))
            {
                return 0;
            }

            // Sanitize input by only having numbers and commas
            numbers = Regex.Replace(numbers, "[^0-9-,]", ",");
            List<string> splitNumbersStr = numbers.Split(",").ToList();
            splitNumbersStr.RemoveAll(s => string.IsNullOrEmpty(s));

            List<int> splitNumbersInt = splitNumbersStr.Select(number => int.Parse(number)).ToList();

            // Negatives are not allowed
            List<int> negatives = splitNumbersInt.Where(number => number < 0).ToList();
            if (negatives.Any())
            {
                throw new ArgumentException($"negatives not allowed {negatives.Select(number => number)}");
            }

            // Numbers over 1000 are ignored
            int result = splitNumbersInt.Where(number => number <= 1000).Sum();
            return result;

        }
    }
}
