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
    public class ProcTests
    {
        [TestMethod()]
        public void ProcTestOperations()
        {
            Proc<FractionalNum> processor = new Proc<FractionalNum>(new FractionalNum(1, 3), new FractionalNum(1, 3));
            processor.OperationSet(1);
            processor.OperationRun();
            var otvet = new FractionalNum(2, 3);
            Assert.AreEqual(otvet.Denominator, processor.Lop_Res.Denominator);
            Assert.AreEqual(otvet.Numerator, processor.Lop_Res.Numerator);
            processor.OperationSet(2);
            processor.OperationRun();
            otvet = new FractionalNum(1, 3);
            Assert.AreEqual(otvet.Denominator, processor.Lop_Res.Denominator);
            Assert.AreEqual(otvet.Numerator, processor.Lop_Res.Numerator);
            processor.OperationSet(3);
            processor.OperationRun();
            otvet = new FractionalNum(1, 9);
            Assert.AreEqual(otvet.Denominator, processor.Lop_Res.Denominator);
            Assert.AreEqual(otvet.Numerator, processor.Lop_Res.Numerator);
            processor.OperationSet(4);
            processor.OperationRun();
            otvet = new FractionalNum(1, 3);
            Assert.AreEqual(otvet.Denominator, processor.Lop_Res.Denominator);
            Assert.AreEqual(otvet.Numerator, processor.Lop_Res.Numerator);
        }

        [TestMethod()]
        public void OperationSetRunTest()
        {
            Proc<int> processor = new Proc<int>(2, 5);
            processor.OperationSet(1);
            processor.OperationRun();
            Assert.AreEqual(7, processor.Lop_Res);
            processor.OperationSet(2);
            processor.OperationRun();
            Assert.AreEqual(2, processor.Lop_Res);
            processor.OperationSet(3);
            processor.OperationRun();
            Assert.AreEqual(10, processor.Lop_Res);
            processor.OperationSet(4);
            processor.OperationRun();
            Assert.AreEqual(2, processor.Lop_Res);
        }


        [TestMethod()]
        public void FunctionSetRunTest()
        {
            Proc<int> processor = new Proc<int>(2, 1);
            processor.FunctionSet(1);
            processor.FunctionRun();
            Assert.AreEqual(1, processor.Rop);
            processor.FunctionSet(2);
            processor.FunctionRun();
            Assert.AreEqual(1, processor.Rop);
        }

        [TestMethod()]
        public void FunctionGetTestFrac()
        {
            Proc<FractionalNum> processor = new Proc<FractionalNum>(new FractionalNum(1, 3), new FractionalNum(1, 3));
            processor.FunctionSet(1);
            processor.FunctionRun();
            var otvet = new FractionalNum(3, 1);
            Assert.AreEqual(otvet.Denominator, processor.Rop.Denominator);
            Assert.AreEqual(otvet.Numerator, processor.Rop.Numerator);
            processor.FunctionSet(2);
            processor.FunctionRun();
            otvet = new FractionalNum(9, 1);
            Assert.AreEqual(otvet.Denominator, processor.Rop.Denominator);
            Assert.AreEqual(otvet.Numerator, processor.Rop.Numerator);
        }
    }
}