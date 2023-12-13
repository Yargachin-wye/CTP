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
    public class PNumberTests
    {
        [TestMethod()]
        public void PNumberTest()//Unfail
        {
            double a = 1011.1011;
            int b = 2;
            int c = 4;

            double extend = 1011.1011;
            PNumber iP = new PNumber(a, b, c);
            double result = iP.GetPNumber();
            Assert.AreEqual(extend, result);
        }

        [TestMethod()]
        public void PNumberTest1()//Fail
        {
            double a = 1011.1010;
            int b = 2;
            int c = -1;

            double extend = 0.0;
            PNumber iP = new PNumber(a, b, c);
            double result = iP.GetPNumber();
            Assert.AreEqual(extend, result);
        }

        [TestMethod()]
        public void PNumberTest2()//FailC
        {
            double a = 1011.1010;
            int b = 2;
            int c = -1;

            double extend = 0.0;
            PNumber iP = new PNumber(a, b, c);
            double result = iP.GetPNumber();
            Assert.AreEqual(extend, result);
        }

        [TestMethod()]
        public void AddTest2()
        {
            string a = "1110101,110101";
            string b = "2";
            string c = "6";
            string a1 = "111101,100001";
            string b1 = "2";
            string c1 = "6";

            string extend = "10110011,01011";
            PNumber iP = new PNumber(a, b, c);
            PNumber iP1 = new PNumber(a1, b1, c1);
            string result = iP.Add(iP1).GetPString();
            Assert.AreEqual(extend, result);
        }
        [TestMethod()]
        public void AddTest15()
        {
            string a = "1837A,342B";
            string b = "15";
            string c = "4";
            string a1 = "34C01,DDA1";
            string b1 = "15";
            string c1 = "4";

            string extend = "4D07C,22C6";
            PNumber iP = new PNumber(a, b, c);
            PNumber iP1 = new PNumber(a1, b1, c1);
            string result = iP.Add(iP1).GetPString();
            Assert.AreEqual(extend, result);
        }
        [TestMethod()]
        public void AddTestDiffBase()
        {
            string a = "1837A,342B";
            string b = "16";
            string c = "4";
            string a1 = "34C01,DDA1";
            string b1 = "15";
            string c1 = "4";

            string extend = "0,0";
            PNumber iP = new PNumber(a, b, c);
            PNumber iP1 = new PNumber(a1, b1, c1);
            string result = iP.Add(iP1).GetPString();
            Assert.AreEqual(extend, result);
        }
        [TestMethod()]
        public void AddTestDiffC()
        {
            string a = "1837A,342B";
            string b = "16";
            string c = "4";
            string a1 = "34C01,DDA1A";
            string b1 = "15";
            string c1 = "5";

            string extend = "0,0";
            PNumber iP = new PNumber(a, b, c);
            PNumber iP1 = new PNumber(a1, b1, c1);
            string result = iP.Add(iP1).GetPString();
            Assert.AreEqual(extend, result);
        }

        [TestMethod()]
        public void MultTest()
        {
            string a = "1283,22";
            string b = "15";
            string c = "2";
            string a1 = "34,34";
            string b1 = "15";
            string c1 = "2";

            string extend = "3C877,E8";
            PNumber iP = new PNumber(a, b, c);
            PNumber iP1 = new PNumber(a1, b1, c1);
            string result = iP.Mult(iP1).GetPString();
            Assert.AreEqual(extend, result);
        }

        [TestMethod()]
        public void SubstractTest()
        {
            string a = "1283,22";
            string b = "15";
            string c = "2";
            string a1 = "34,34";
            string b1 = "15";
            string c1 = "2";

            string extend = "124D,DE";
            PNumber iP = new PNumber(a, b, c);
            PNumber iP1 = new PNumber(a1, b1, c1);
            string result = iP.Substract(iP1).GetPString();
            Assert.AreEqual(extend, result);
        }

        [TestMethod()]
        public void DelTest()
        {
            string a = "1283,22";
            string b = "15";
            string c = "2";
            string a1 = "34,34";
            string b1 = "15";
            string c1 = "2";

            string extend = "55,36";
            PNumber iP = new PNumber(a, b, c);
            PNumber iP1 = new PNumber(a1, b1, c1);
            string result = iP.Del(iP1).GetPString();
            Assert.AreEqual(extend, result);
        }

        [TestMethod()]
        public void ReversTest()
        {
            string a = "1283,22";
            string b = "15";
            string c = "2";

            string extend = "0,0";
            PNumber iP = new PNumber(a, b, c);

            string result = iP.Revers().GetPString();
            Assert.AreEqual(extend, result);
        }

        [TestMethod()]
        public void SqrTest()
        {
            string a = "1283,22";
            string b = "15";
            string c = "2";

            string extend = "157D924,6D";
            PNumber iP = new PNumber(a, b, c);

            string result = iP.Sqr().GetPString();
            Assert.AreEqual(extend, result);
        }

        [TestMethod()]
        public void GetPNumberTest()
        {
            double a = 1011.1010;
            int b = 1;
            int c = 4;

            double extend = 0.0;
            PNumber iP = new PNumber(a, b, c);
            double result = iP.GetPNumber();
            Assert.AreEqual(extend, result);
        }

        [TestMethod()]
        public void GetPStringTest()
        {
            string a = "ABC123,435DC";
            string b = "16";
            string c = "5";

            string extend = "ABC123,435D2";
            PNumber iP = new PNumber(a, b, c);
            string result = iP.GetPString();
            Assert.AreEqual(extend, result);
        }

        [TestMethod()]
        public void GetSetСorrectnessNumberTest()
        {
            string a = "1283,22";
            string b = "15";
            string c = "2";

            int extend = 2;
            PNumber iP = new PNumber(a, b, c);

            iP.SetCorrectnessNumber(4);
            int result = iP.GetСorrectnessNumber();
            Assert.AreEqual(extend, result);
        }

        [TestMethod()]
        public void GetSetBaseNumberTest()
        {
            string a = "1283,22";
            string b = "15";
            string c = "2";

            int extend = 15;
            PNumber iP = new PNumber(a, b, c);

            iP.SetBaseNumber(2);
            int result = iP.GetBaseNumber();
            Assert.AreEqual(extend, result);
        }

    }
}