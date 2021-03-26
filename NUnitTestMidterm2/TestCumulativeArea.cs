//-----------------------------------------------------------------------
// <copyright file="TestCumulativeArea.cs" company="Lucas Da Silva 11631988">
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
    public class TestCumulativeArea
    {
        [Test]
        [TestCase("c s c r")]
        [TestCase("cscr")]

        /// <summary>
        /// Tests whether or not the area calculated is correct
        /// </summary>
        /// <param name="expression">The string expression</param>
        public void TestArea(string expression)
        {
            double target = 0.0;
            double expected = 1077.4;

            // ShapeStructure shapeStruct = new ShapeStructure(expression);

            // target = shapeStruct.CumulativeArea();

            Assert.AreEqual(expected, target);
        }
    }
}
