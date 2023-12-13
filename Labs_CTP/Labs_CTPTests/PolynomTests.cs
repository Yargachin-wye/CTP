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
    public class PolynomTests
    {
        [TestMethod()]
        public void PolynomTest()
        {
            // Arrange & Act
            Polynom polynom = new Polynom();

            // Assert
            Assert.IsNotNull(polynom);
            Assert.AreEqual(1, polynom.Members.Count);
        }
        [TestMethod()]
        public void AddTest()
        {
            Polynom poly = new Polynom();
            poly.Members.Add(new MemberPolynom(1, 0));
            poly.Members.Add(new MemberPolynom(1, 1));
            Assert.AreEqual(poly.Show(), "1x^1+1x^0");
        }

        [TestMethod()]
        public void MulTest()
        {
            Polynom poly = new Polynom();
            Polynom newtpoly = new Polynom();
            poly.Members.Add(new MemberPolynom(1, 0));
            poly.Members.Add(new MemberPolynom(1, 1));
            newtpoly.Members.Add(new MemberPolynom(1, 0));
            newtpoly.Members.Add(new MemberPolynom(1, 1));

            Polynom addpoly = poly.Add(newtpoly);
            addpoly = poly.Mul(newtpoly);

            Assert.AreEqual(addpoly.Show(), "1x^2+2x^1+1x^0");
        }

        [TestMethod()]
        public void RevTest()
        {
            Polynom tpoly1 = new Polynom();
            tpoly1.Members.Add(new MemberPolynom(11, 1));
            tpoly1.Members.Add(new MemberPolynom(22, 3));
            tpoly1.Members.Add(new MemberPolynom(20, 2));

            Assert.AreEqual(tpoly1.Rev().Show(), "-22x^3-20x^2-11x^1");
        }

        [TestMethod()]
        public void RetDegreeTest()
        {
            Polynom tpoly1 = new Polynom();
            tpoly1.Members.Add(new MemberPolynom(11, 11));
            tpoly1.Members.Add(new MemberPolynom(22, 22));

            Assert.AreEqual(tpoly1.RetDegree(), 22);
        }

        [TestMethod()]
        public void RetCoeffTest()
        {
            Polynom tpoly1 = new Polynom();
            tpoly1.Members.Add(new MemberPolynom(11, 11));
            tpoly1.Members.Add(new MemberPolynom(22, 33));
            tpoly1.Members.Add(new MemberPolynom(20, 33));

            Assert.AreEqual(tpoly1.RetCoeff(33), 42);

        }

        [TestMethod()]
        public void EqualsTest()
        {
            Polynom tpoly1 = new Polynom();
            tpoly1.Members.Add(new MemberPolynom(1, 2));

            Polynom tpoly2 = new Polynom();
            tpoly2.Members.Add(new MemberPolynom(0, 2));


            Assert.AreEqual(tpoly1.Equals(tpoly2), false);
        }

        [TestMethod()]
        public void DiffTest()
        {
            Polynom tpoly1 = new Polynom();
            tpoly1.Members.Add(new MemberPolynom(1, 3));

            Assert.AreEqual(tpoly1.Diff().Show(), "3x^2");
        }

        [TestMethod()]
        public void CalculateTest()
        {
            Polynom poly = new Polynom();
            poly.Members.Add(new MemberPolynom(1, 2));
            poly.Members.Add(new MemberPolynom(3, 3));
            poly.Members.Add(new MemberPolynom(4, 2));

            Assert.AreEqual(poly.Calculate(2), 44);
        }

        [TestMethod()]
        public void ClearTest()
        {
            Polynom tpoly = new Polynom();
            tpoly.Members.Add(new MemberPolynom(1, 0));
            tpoly.Clear();
            Assert.AreEqual(tpoly.Show(), "");
        }

        [TestMethod()]
        public void ElementAtTest()
        {
            Polynom tpoly1 = new Polynom();
            tpoly1.Members.Add(new MemberPolynom(11, 11));
            tpoly1.Members.Add(new MemberPolynom(22, 22));

            Assert.AreEqual(new Tuple<int, int>(11, 11), tpoly1.ElementAt(1));
        }
    }
}