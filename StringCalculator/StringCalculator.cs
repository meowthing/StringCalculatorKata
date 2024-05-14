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

            // Sanitize input by only having signed numbers and commas
            numbers = Regex.Replace(numbers, "[^0-9-,]", ",");
            List<int> splitNumbers = numbers.Split(",").Select(numbers => !string.IsNullOrEmpty(numbers) ? int.Parse(numbers) : 0).ToList();

            // Negatives are not allowed
            if (splitNumbers.Any(number => number < 0))
            {
                string negatives = splitNumbers
                    .Where(number => number < 0)
                    .Select(number => number.ToString())
                    .Aggregate((numberA, numberB) => string.Format("{0}, {1}", numberA, numberB));
                throw new ArgumentException($"negatives not allowed {negatives}");
            }

            // Numbers over 1000 are ignored
            int result = splitNumbers.Where(number => number <= 1000).Sum();
            return result;
        }
    }
}
