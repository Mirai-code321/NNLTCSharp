using Bai4_Fibonacci;

namespace Bai4_FibonacciTest
{
    public class UnitTest1
    {
        // n = 9: các số Fibonacci nhỏ hơn 9 là 1, 1, 2, 3, 5, 8
        [Fact]
        public void KiemTraN9()
        {
            TimSoFibonacci fibonacci = new TimSoFibonacci();

            Assert.Equal(8, fibonacci.TimSo(9));
        }

        // n = 10 thì số Fibonacci lớn nhất nhỏ hơn 10 là 8
        [Fact]
        public void KiemTraN10()
        {
            TimSoFibonacci fibonacci = new TimSoFibonacci();

            Assert.Equal(8, fibonacci.TimSo(10));
        }

        // n = 8 thì không lấy 8 vì đề yêu cầu phải nhỏ hơn n
        [Fact]
        public void KiemTraN8()
        {
            TimSoFibonacci fibonacci = new TimSoFibonacci();

            Assert.Equal(5, fibonacci.TimSo(8));
        }

        // n = 20 thì 13 nhỏ hơn 20, còn 21 lớn hơn 20
        [Fact]
        public void KiemTraN20()
        {
            TimSoFibonacci fibonacci = new TimSoFibonacci();

            Assert.Equal(13, fibonacci.TimSo(20));
        }

        // n = 2 thì số Fibonacci lớn nhất nhỏ hơn 2 là 1
        [Fact]
        public void KiemTraN2()
        {
            TimSoFibonacci fibonacci = new TimSoFibonacci();

            Assert.Equal(1, fibonacci.TimSo(2));
        }

        // n = 1 thì không có số Fibonacci dương nào nhỏ hơn 1
        [Fact]
        public void KiemTraN1()
        {
            TimSoFibonacci fibonacci = new TimSoFibonacci();

            Assert.Equal(0, fibonacci.TimSo(1));
        }
    }
}