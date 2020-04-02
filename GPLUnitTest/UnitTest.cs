using System;
using System.Windows.Forms;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace GPLUnitTest
{
    [TestClass]
    public class UnitTest
    {
        [TestMethod]
        public void TestDrawCircle()
        {
            try
            {
                //arrange
                float rad = 100;

                //act
                Graphical_PL_Application.Circle cc = new Graphical_PL_Application.Circle();
                cc.GetValues(0, 0, 0, rad);

                //Assert
                Assert.IsTrue(true);
            }
            catch
            {
                Assert.IsTrue(false);
            }
        }
        [TestMethod]
        public void TestDrawRectangle()
        {
            try
            {
                float width = 100;
                float height = 80;

                Graphical_PL_Application.Rectangle rect = new Graphical_PL_Application.Rectangle();
                rect.GetValues(width, height, 0, 0);

                Assert.IsTrue(true);
            }
            catch
            {
                Assert.IsTrue(false);
            }
        }
        [TestMethod]
        public void TestDrawTriangle()
        {
            try
            {
                float width = 75;
                float height = 90;
                float hypotenus = 80;

                Graphical_PL_Application.Triangle tangle = new Graphical_PL_Application.Triangle();
                tangle.GetValues(width, height, hypotenus, 0);

                Assert.IsTrue(true);
            }
            catch
            {
                Assert.IsTrue(false);
            }
        }
        [TestMethod]
        public void Checktriangle()
        {
            //arrange
            float width = 90;
            float height = 100;
            float hypotenus = 110;
            bool expected = true;
            //act
            Graphical_PL_Application.Triangle tangle = new Graphical_PL_Application.Triangle();
            tangle.GetValues(width, height, hypotenus, 0);
            bool actual = tangle.checkTriangleValidity();
            //assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void CommandValidationtest()
        {
            //arrange
            TextBox tb = new TextBox();
            tb.Text = "moveto 100,100";
            bool expected = true;

            //act
            Graphical_PL_Application.CommandValidations cmdval = new Graphical_PL_Application.CommandValidations(tb);
            cmdval.CheckCmdLineValidation(tb.Text);
            bool actual = cmdval.IsCmdValid;

            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void ParameterValidationtest()
        {
            //arrange
            TextBox tb = new TextBox();
            tb.Text = "circle 100";
            bool expected = true;

            //act
            Graphical_PL_Application.CommandValidations cmdval = new Graphical_PL_Application.CommandValidations(tb);
            cmdval.CheckCmdLineValidation(tb.Text);
            bool actual = cmdval.IsParameterValid;

            Assert.AreEqual(expected, actual);
        }
    }
}
