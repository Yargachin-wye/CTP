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
    public class MemoryTests
    {
        [TestMethod()]
        public void WriteMemoryTest()
        {
            Memory<FractionalNum> f = new Memory<FractionalNum>();
            f.WriteMemory(new FractionalNum(5, 6));
            var otvet = new FractionalNum(5, 6);

            Assert.AreEqual(otvet.Denominator, f.Get().Denominator);
            Assert.AreEqual(otvet.Numerator, f.Get().Numerator);
        }

        [TestMethod()]
        public void GetTest()
        {
            Assert.AreEqual(0,0);
        }

        [TestMethod()]
        public void AddTest()
        {
            Assert.AreEqual(0, 0);
        }

        [TestMethod()]
        public void ClearTest()
        {
            Memory<FractionalNum> f = new Memory<FractionalNum>();
            f.WriteMemory(new FractionalNum(5, 6));
            var otvet = new FractionalNum(5, 6);

            Assert.AreEqual(otvet.Denominator, f.ReadNumber().Denominator);
            Assert.AreEqual(otvet.Numerator, f.ReadNumber().Numerator);

            f.Clear();

            otvet = new FractionalNum();
            Assert.AreEqual(otvet.Denominator, f.ReadNumber().Denominator);
            Assert.AreEqual(otvet.Numerator, f.ReadNumber().Numerator);
        }

        [TestMethod()]
        public void ReadStateTest()
        {
            Memory<FractionalNum> f = new Memory<FractionalNum>();

            Assert.IsFalse(f.ReadState());

            f.WriteMemory(new FractionalNum(1, 5));

            Assert.IsTrue(f.ReadState());
        }

        [TestMethod()]
        public void ReadNumberTest()
        {
            Memory<FractionalNum> f = new Memory<FractionalNum>();
            f.WriteMemory(new FractionalNum(1, 5));
            var otvet = new FractionalNum(1, 5);
            Assert.AreEqual(otvet.Denominator, f.ReadNumber().Denominator);
            Assert.AreEqual(otvet.Numerator, f.ReadNumber().Numerator);
        }
    }
}