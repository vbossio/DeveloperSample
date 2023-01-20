using System;
using Xunit;

namespace DeveloperSample.Algorithms
{
    public class AlgorithmTest
    {
        [Fact]
        public void CanGetFactorial()
        {
            Assert.Equal(24, Algorithms.GetFactorial(4));
            Assert.Equal(3628800, Algorithms.GetFactorial(10));
            Assert.Equal(479001600, Algorithms.GetFactorial(12));
        }
        [Fact]
        public void ExceptionFactorialLessThanOne()
        {
            var exception = Record.Exception(() => Algorithms.GetFactorial(-4));
            Assert.NotNull(exception); 
            Assert.IsType<InvalidOperationException>(exception);
            Assert.Equal(Algorithms.FACTORIAL_NOT_SUPPORTED, exception.Message);
        }

        [Fact]
        public void ExceptionInvalidFactorialForInt()
        {

            var exception = Record.Exception(() => Algorithms.GetFactorial(13));
            Assert.NotNull(exception);
            Assert.IsType<OverflowException>(exception);
            exception = Record.Exception(() => Algorithms.GetFactorial(int.MaxValue));
            Assert.NotNull(exception);
            Assert.IsType<OverflowException>(exception);
        }

        [Fact]
        public void CanFormatSeparators()
        {
            Assert.Equal("a, b and c", Algorithms.FormatSeparators("a", "b", "c"));
            Assert.Equal("a and b", Algorithms.FormatSeparators("a", "b"));
            Assert.Equal("a", Algorithms.FormatSeparators("a"));
            Assert.Equal("", Algorithms.FormatSeparators(""));
            Assert.Equal("a, b, c and d", Algorithms.FormatSeparators("a", "b", "c", "d"));
            Assert.Equal("Me,first, Me,second and Me,third/last", Algorithms.FormatSeparators("Me,first", "Me,second", "Me,third/last"));
            Assert.Equal("a,b,c and d,e,f", Algorithms.FormatSeparators("a,b,c", "d,e,f"));
            Assert.Equal(",", Algorithms.FormatSeparators(","));
            Assert.Equal(", and ,", Algorithms.FormatSeparators(",",","));
            Assert.Equal(",, , and ,", Algorithms.FormatSeparators(",", ",",","));
        }
    }
}