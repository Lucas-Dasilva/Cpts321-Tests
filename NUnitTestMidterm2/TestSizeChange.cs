//-----------------------------------------------------------------------
// <copyright file="TestSizeChange.cs" company="Lucas Da Silva 11631988">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace MidTerm2App
{
    using System;
    using System.Text.RegularExpressions;
    using NUnit.Framework;

    /// <summary>
    /// Tests for Expression Tree
    /// </summary>
    [TestFixture]
    public class TestSizeChange
    {
        [Test]
        [TestCase("cscr")]

        /// <summary>
        /// Tests whether or not the default size changes based on the index of the array
        /// </summary>
        /// <param name="expression">The string expression</param>
        public void TestDefaultSizeChange(string expression)
        {
            double[] target = new double[4];
            double[] expected = new double[] { 78.54, 100, 706.86, 192 };

            ShapeFactory factory = new ShapeFactory();
            int i = 0;
            foreach (char c in expression)
            {
                i++;
                Shape shape = factory.CreateShape(c.ToString(), i);
                target[i - 1] = shape.Area;
            }

            Assert.AreEqual(expected, target);
        }
    }
}
