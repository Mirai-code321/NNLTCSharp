using Bai3_TimSoFibonacci;

namespace Bai3_TimSoFibonacciTests
{
    public class UnitTest1
    {
        // Kiểm tra n = 9 thì Fibonacci lớn nhất nhỏ hơn 9 là 8
        [Fact]
        public void TimFibonacci_N9_TraVe8()
        {
            int ketQua = BT3.TimFibonacciNhoHon(9);

            Assert.Equal(8, ketQua);
        }

        // Kiểm tra n = 8 thì Fibonacci lớn nhất nhỏ hơn 8 là 5
        [Fact]
        public void TimFibonacci_N8_TraVe5()
        {
            int ketQua = BT3.TimFibonacciNhoHon(8);

            Assert.Equal(5, ketQua);
        }

        // Kiểm tra n = 10 thì Fibonacci lớn nhất nhỏ hơn 10 là 8
        [Fact]
        public void TimFibonacci_N10_TraVe8()
        {
            int ketQua = BT3.TimFibonacciNhoHon(10);

            Assert.Equal(8, ketQua);
        }

        // Kiểm tra n = 6 thì Fibonacci lớn nhất nhỏ hơn 6 là 5
        [Fact]
        public void TimFibonacci_N6_TraVe5()
        {
            int ketQua = BT3.TimFibonacciNhoHon(6);

            Assert.Equal(5, ketQua);
        }

        // Kiểm tra n = 5 thì Fibonacci lớn nhất nhỏ hơn 5 là 3
        [Fact]
        public void TimFibonacci_N5_TraVe3()
        {
            int ketQua = BT3.TimFibonacciNhoHon(5);

            Assert.Equal(3, ketQua);
        }

        // Kiểm tra n = 4 thì Fibonacci lớn nhất nhỏ hơn 4 là 3
        [Fact]
        public void TimFibonacci_N4_TraVe3()
        {
            int ketQua = BT3.TimFibonacciNhoHon(4);

            Assert.Equal(3, ketQua);
        }

        // Kiểm tra n = 3 thì Fibonacci lớn nhất nhỏ hơn 3 là 2
        [Fact]
        public void TimFibonacci_N3_TraVe2()
        {
            int ketQua = BT3.TimFibonacciNhoHon(3);

            Assert.Equal(2, ketQua);
        }

        // Kiểm tra n = 2 thì Fibonacci lớn nhất nhỏ hơn 2 là 1
        [Fact]
        public void TimFibonacci_N2_TraVe1()
        {
            int ketQua = BT3.TimFibonacciNhoHon(2);

            Assert.Equal(1, ketQua);
        }

        // Kiểm tra n = 1
        // Không có số Fibonacci dương nào nhỏ hơn 1 nên trả về 0
        [Fact]
        public void TimFibonacci_N1_TraVe0()
        {
            int ketQua = BT3.TimFibonacciNhoHon(1);

            Assert.Equal(0, ketQua);
        }

        // Kiểm tra n = 20 thì Fibonacci lớn nhất nhỏ hơn 20 là 13
        [Fact]
        public void TimFibonacci_N20_TraVe13()
        {
            int ketQua = BT3.TimFibonacciNhoHon(20);

            Assert.Equal(13, ketQua);
        }
    }
}