using System;
using System.Security.Cryptography.X509Certificates;

namespace DeveloperSample.Algorithms
{
    public static class Algorithms
    {
        public const string FACTORIAL_NOT_SUPPORTED = "Factorial less than 1 is not supported";
        public static int GetFactorial(int n)
        {
            if (n < 1)
            {
                // note: this may still interrupt the test, if so uncheck the "Break on this user-handled exception" option
                throw new InvalidOperationException(FACTORIAL_NOT_SUPPORTED);
            }

            int result = n;
            try
            {
                while (n > 1)
                {
                    checked
                    {
                        result *= (n - 1);
                    }
                    n--;
                }
            } catch (OverflowException e)
            {
                // note: this may still interrupt the test, if so uncheck the "Break on this user-handled exception" option
                throw e;
            }
            return result;
        }

        public static string FormatSeparators(params string[] items)
        {
            string formattedItems = "";
            var totalCount = items.Length;
            if (totalCount == 1)
            {
                return items[0];
            }
            for (int count = 0; count < totalCount; count++)
            {
                // if 2nd to last item then append with "and"
                if (count + 2 == totalCount)
                {
                    formattedItems += items[count] + " and ";
                } else if (count + 1 == totalCount)  // if last item just append value
                {
                    formattedItems += items[count];
                } else
                {
                    formattedItems += items[count] + ", "; // otherwise append value and comma
                }
            }
            return formattedItems;
        }
    }
}