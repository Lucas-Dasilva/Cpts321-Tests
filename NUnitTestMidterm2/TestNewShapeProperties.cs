//-----------------------------------------------------------------------
// <copyright file="TestNewShapeProperties.cs" company="Lucas Da Silva 11631988">
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
    public class TestNewShapeProperties
    {
        [Test]
        [TestCase("tptp")]

        /// <summary>
        /// Tests whether new shape areas are implemented correctly
        /// </summary>
        /// <param name="expression">The string expression</param>
        public void TestNewShapeAreas(string expression)
        {
            double[] target = new double[4];

            double[] expected = new double[] { 27.5, 61.94, 247.5, 247.75 };

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
