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

            // use special character (Unicode 0) as initial delimiter in case there are commas in the strings we are joining
            var specialDelimiter = "\0";
            var formattedItems = String.Join(specialDelimiter, items);
            // replace the last special delimiter with " and "
            int lastPosition = formattedItems.LastIndexOf(specialDelimiter, StringComparison.OrdinalIgnoreCase);
            if (lastPosition > 0) {
                formattedItems = formattedItems.Remove(lastPosition, specialDelimiter.Length).Insert(lastPosition, " and ");
            }
            // replace remaining special characters with ", "
            formattedItems = formattedItems.Replace(specialDelimiter, ", ");
            return formattedItems;
        }
    }
}