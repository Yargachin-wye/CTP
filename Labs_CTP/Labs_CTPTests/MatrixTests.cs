using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Labs_CTP.Tests
{
    [TestClass()]
    public class MatrixTests
    {
        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void OutOfBounds_i()
        {
            Matrix a = new Matrix(0, 4);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void OutOfBounds_j()
        {
            Matrix a = new Matrix(4, -1);
        }

        [TestMethod]
        public void Sum()
        {
            Matrix a = new Matrix(2, 2);
            a[0, 0] = 1;
            a[0, 1] = 1;
            a[1, 0] = 1;
            a[1, 1] = 1;
            Matrix b = new Matrix(2, 2);
            b[0, 0] = 2;
            b[0, 1] = 2;
            b[1, 0] = 2;
            b[1, 1] = 2;
            Matrix expect = new Matrix(2, 2);
            expect[0, 0] = 3;
            expect[0, 1] = 3;
            expect[1, 0] = 3;
            expect[1, 1] = 3;
            Matrix actual = new Matrix(2, 2);
            actual = a + b;
            Assert.IsTrue(actual == expect);
        }
        [TestMethod]
        public void Diff()
        {
            Matrix a = new Matrix(2, 2);
            a[0, 0] = 1;
            a[0, 1] = 1;
            a[1, 0] = 1;
            a[1, 1] = 1;
            Matrix b = new Matrix(2, 2);
            b[0, 0] = 2;
            b[0, 1] = 2;
            b[1, 0] = 2;
            b[1, 1] = 2;
            Matrix expect = new Matrix(2, 2);
            expect[0, 0] = 1;
            expect[0, 1] = 1;
            expect[1, 0] = 1;
            expect[1, 1] = 1;
            Matrix actual = new Matrix(2, 2);
            actual = b - a;
            Assert.IsTrue(actual == expect);
        }
        [TestMethod()]
        public void Mult()
        {
            Matrix a = new Matrix(2, 2);
            a[0, 0] = 3;
            a[0, 1] = 3;
            a[1, 0] = 3;
            a[1, 1] = 3;
            Matrix b = new Matrix(2, 2);
            b[0, 0] = 2;
            b[0, 1] = 2;
            b[1, 0] = 2;
            b[1, 1] = 2;
            Matrix expect = new Matrix(2, 2);
            expect[0, 0] = 12;
            expect[0, 1] = 12;
            expect[1, 0] = 12;
            expect[1, 1] = 12;
            Matrix actual = new Matrix(2, 2);
            actual = a * b;
            Assert.IsTrue(actual == expect);
        }

        [TestMethod()]
        public void TranspTest()
        {
            Matrix a = new Matrix(2, 2);
            a[0, 0] = 1;
            a[0, 1] = 2;
            a[1, 0] = 3;
            a[1, 1] = 4;
            Matrix actual = a.Transp();
            Matrix expect = new Matrix(2, 2);
            expect[0, 0] = 1;
            expect[0, 1] = 3;
            expect[1, 0] = 2;
            expect[1, 1] = 4;
            Assert.IsTrue(actual == expect);
        }

        [TestMethod()]
        public void MinTest()
        {
            Matrix a = new Matrix(2, 2);
            a[0, 0] = 4;
            a[0, 1] = 3;
            a[1, 0] = 2;
            a[1, 1] = 1;
            int actual = a.Min();
            int expect = 1;
            Assert.IsTrue(actual == expect);
        }

        [TestMethod()]
        public void MatrixStrTest()
        {
            Matrix a = new Matrix(2, 2);
            a[0, 0] = 1;
            a[0, 1] = 2;
            a[1, 0] = 3;
            a[1, 1] = 4;
            string actual = a.MatrixStr();
            string expect = "{{ 1 2 }{ 3 4 }}";
            Assert.IsTrue(actual == expect);
        }

        [TestMethod()]
        public void TakeElemTest()
        {
            Matrix a = new Matrix(2, 2);
            a[0, 0] = 4;
            a[0, 1] = 3;
            a[1, 0] = 2;
            a[1, 1] = 1;
            int actual = a.TakeElem(1, 0);
            int expect = 2;
            Assert.IsTrue(actual == expect);
        }

        [TestMethod()]
        public void Write_elemTest()
        {
            Matrix actual = new Matrix(2, 2);
            actual[0, 0] = 1;
            actual[0, 1] = 2;
            actual[1, 0] = 3;
            actual[1, 1] = 4;
            actual.WriteElem(1, 0, 8);
            Matrix expect = new Matrix(2, 2);
            expect[0, 0] = 1;
            expect[0, 1] = 2;
            expect[1, 0] = 8;
            expect[1, 1] = 4;
            Assert.IsTrue(actual == expect);
        }

        [TestMethod()]
        public void Equal()
        {
            Matrix a = new Matrix(2, 2);
            a[0, 0] = 1;
            a[0, 1] = 2;
            a[1, 0] = 3;
            a[1, 1] = 4;
            Matrix b = new Matrix(2, 2);
            b[0, 0] = 1;
            b[0, 1] = 2;
            b[1, 0] = 3;
            b[1, 1] = 4;
            bool res = a == b;
            Assert.IsTrue(res);
        }
    }
}