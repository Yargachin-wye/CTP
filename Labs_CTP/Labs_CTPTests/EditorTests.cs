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
    public class EditorTests
    {
        [TestMethod()]
        public void EditorTest()
        {
            ComplexNumberEditor editor = new ComplexNumberEditor();
            string output = "10,3+i*0,8";
            editor.WriteNumber(output);
            Assert.AreEqual(output, editor.ReadNumber());
        }

        [TestMethod()]
        public void IsZeroTest()
        {
            ComplexNumberEditor editor = new ComplexNumberEditor();
            editor.WriteNumber("12,36+i*12,35");
            Assert.IsFalse(editor.IsZero());
        }

        [TestMethod()]
        public void ToggleMinusTest()
        {
            ComplexNumberEditor editor = new ComplexNumberEditor();
            editor.WriteNumber("12,36+i*12,35");
            editor.ToggleMinus();
            string output = "-12,36+i*12,35";
            Assert.AreEqual(output, editor.ReadNumber());
        }

        [TestMethod()]
        public void AddNumberTest()
        {
            ComplexNumberEditor editor = new ComplexNumberEditor();
            editor.WriteNumber("0,36+i*1,4");
            editor.AddNumber(4);
            string output = "4,36+i*1,4";
            Assert.AreEqual(output, editor.ReadNumber());
        }

        [TestMethod()]
        public void AddZeroTest()
        {
            ComplexNumberEditor editor = new ComplexNumberEditor();
            editor.WriteNumber("-25,6-i*44,44");
            editor.AddNumber(0);
            string output = "-250,6-i*44,44";
            Assert.AreEqual(output, editor.ReadNumber());
        }
        [TestMethod()]
        public void Del2NumberTest1()
        {
            ComplexNumberEditor editor = new ComplexNumberEditor();
            editor.WriteNumber("0,4+i*44,44");
            editor.DelNumber();
            string output = "0,4+i*44,44";
            Assert.AreEqual(output, editor.ReadNumber());
        }
        [TestMethod()]
        public void DelNumberTest2()
        {
            ComplexNumberEditor editor = new ComplexNumberEditor();
            editor.WriteNumber("55,55-i*3,3");
            editor.ToggleMode();
            editor.DelNumber();
            string output = "55,55-i*0,3";
            Assert.AreEqual(output, editor.ReadNumber());
        }

        [TestMethod()]
        public void ClearTest()
        {
            ComplexNumberEditor editor = new ComplexNumberEditor();
            editor.WriteNumber("55,55-i*3,3");
            editor.Clear();
            string output = "0,+i*0,";
            Assert.AreEqual(output, editor.ReadNumber());
        }
    }
}