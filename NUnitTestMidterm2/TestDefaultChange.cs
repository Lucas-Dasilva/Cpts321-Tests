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
    public class TestDefaultChange
    {
     
        //[TestCase("cscr")]

        /// <summary>
        /// Tests whether or not the area calculated is correct
        /// </summary>
        [Test]
        public void TestSizeChange()
        {
            double target = 0.0;
            double expected = 3433.59;
            ShapeFactory fact = new ShapeFactory();

            ShapeStructure shapeStruct = new ShapeStructure("c s c r", fact);

            double temp = fact.GetDefaultRadius();

            // Circle(5) = 78.54 | Square(5*2) = 100 | Circle (5*3) = 706.86 | Rectangle (4*3 * 4*4) = 192| = 1077.4

            // Circle(10) = 314.16 | Square(5*2) = 100 | Circle (10 * 3) = 2827.43 | Rectangle (4*3 * 4*4) = 192| = 3433.59
            temp = shapeStruct.CumulativeArea();

            temp = fact.GetDefaultRadius();

            fact.SetDefaultRadius(10);

            temp = fact.GetDefaultRadius();

            shapeStruct = new ShapeStructure("c s c r", fact);

            temp = shapeStruct.CumulativeArea();

            Assert.AreEqual(expected, temp);
        }
    }
}
