using Microsoft.VisualStudio.TestTools.UnitTesting;
using Labs_CTP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labs_CTP.Tests
{
    [TestClass()]
    public class SetTests
    {
        [TestMethod()]
        public void TestFrac()
        {
            Set<FractionalNum> tset1 = new Set<FractionalNum>();
            tset1.Add(new FractionalNum(1, 2));
            tset1.Add(new FractionalNum(2, 3));
            tset1.Add(new FractionalNum(3, 4));
            Assert.AreEqual(tset1.ElementAt(0), new FractionalNum(1, 2));
            Assert.AreEqual(tset1.ElementAt(1), new FractionalNum(2, 3));
            Assert.AreEqual(tset1.ElementAt(2), new FractionalNum(3, 4));
        }

        [TestMethod()]
        public void TestClear()
        {
            Set<FractionalNum> tset1 = new Set<FractionalNum>();
            tset1.Add(new FractionalNum(1, 2));
            tset1.Add(new FractionalNum(2, 3));
            tset1.Add(new FractionalNum(3, 4));
            Assert.AreEqual(tset1.Show(), "1/2 2/3 3/4 ");

            tset1.Clear();
            Assert.AreEqual(tset1.Show(), "");
        }

        [TestMethod()]
        public void TestRemove()
        {
            Set<FractionalNum> tset1 = new Set<FractionalNum>();
            tset1.Add(new FractionalNum(1, 2));
            tset1.Add(new FractionalNum(2, 3));
            tset1.Add(new FractionalNum(3, 4));
            tset1.Remove(new FractionalNum(2, 3));
            Assert.AreEqual(tset1.Show(), "1/2 3/4 ");
        }

        [TestMethod()]
        public void TestIsClear()
        {
            Set<FractionalNum> tset1 = new Set<FractionalNum>();
            tset1.Add(new FractionalNum(1, 2));
            tset1.Add(new FractionalNum(2, 3));
            tset1.Add(new FractionalNum(3, 4));

            Assert.AreEqual(tset1.IsClear(), false);
        }

        [TestMethod()]
        public void TestContains()
        {
            Set<FractionalNum> tset1 = new Set<FractionalNum>();
            tset1.Add(new FractionalNum(1, 2));
            tset1.Add(new FractionalNum(2, 3));
            tset1.Add(new FractionalNum(3, 4));

            Assert.AreEqual(tset1.Contains(new FractionalNum(2, 3)), true);
        }

        [TestMethod()]
        public void TestContains2()
        {
            Set<FractionalNum> tset1 = new Set<FractionalNum>();
            tset1.Add(new FractionalNum(1, 2));
            tset1.Add(new FractionalNum(2, 3));
            tset1.Add(new FractionalNum(3, 4));

            Assert.AreEqual(tset1.Contains(new FractionalNum(2, 30)), false);
        }

        [TestMethod()]
        public void TestUnion()
        {
            Set<FractionalNum> tset1 = new Set<FractionalNum>();
            tset1.Add(new FractionalNum(1, 2));
            tset1.Add(new FractionalNum(2, 3));
            tset1.Add(new FractionalNum(3, 4));

            Set<FractionalNum> tset2 = new Set<FractionalNum>();
            tset2.Add(new FractionalNum(1, 2));
            tset2.Add(new FractionalNum(2, 3));
            tset2.Add(new FractionalNum(5, 5));


            Assert.AreEqual(tset1.Union(tset2).Show(), "1/2 2/3 3/4 1/1 ");
        }

        [TestMethod()]
        public void TestExcept()
        {
            Set<FractionalNum> tset1 = new Set<FractionalNum>();
            tset1.Add(new FractionalNum(1, 2));
            tset1.Add(new FractionalNum(2, 3));
            tset1.Add(new FractionalNum(3, 4));

            Set<FractionalNum> tset2 = new Set<FractionalNum>();
            tset2.Add(new FractionalNum(1, 2));
            tset2.Add(new FractionalNum(2, 3));
            tset2.Add(new FractionalNum(5, 5));


            Assert.AreEqual(tset1.Except(tset2).Show(), "3/4 ");
        }

        [TestMethod()]
        public void TestIntersect()
        {
            Set<FractionalNum> tset1 = new Set<FractionalNum>();
            tset1.Add(new FractionalNum(1, 2));
            tset1.Add(new FractionalNum(2, 3));
            tset1.Add(new FractionalNum(3, 4));

            Set<FractionalNum> tset2 = new Set<FractionalNum>();
            tset2.Add(new FractionalNum(1, 2));
            tset2.Add(new FractionalNum(2, 3));
            tset2.Add(new FractionalNum(5, 5));


            Assert.AreEqual(tset1.Intersect(tset2).Show(), "1/2 2/3 ");
        }

        [TestMethod()]
        public void TestCount()
        {
            Set<FractionalNum> tset1 = new Set<FractionalNum>();
            tset1.Add(new FractionalNum(1, 2));
            tset1.Add(new FractionalNum(2, 3));
            tset1.Add(new FractionalNum(3, 4));

            Assert.AreEqual(tset1.Count(), 3);
        }
    }
}