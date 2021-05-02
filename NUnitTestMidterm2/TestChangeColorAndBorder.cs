//-----------------------------------------------------------------------
// <copyright file="TestChangeColorAndBorder.cs" company="Lucas Da Silva 11631988">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace MidTerm2App
{
    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;
    using NUnit.Framework;

    /// <summary>
    /// Tests for Expression Tree
    /// </summary>
    [TestFixture]
    public class TestChangeColorAndBorder
    {
        [Test]
        [TestCase("crtp")]

        /// <summary>
        /// Tests whether or not the default size changes based on the index of the array
        /// </summary>
        /// <param name="expression">The string expression</param>
        public void TestChangeColor(string expression)
        {
            string target = string.Empty;
            string expected = "Blue";

            ShapeFactory factory = new ShapeFactory();

            List<Shape> shapeList = new List<Shape>();
            int i = 0;
            foreach (char c in expression)
            {
                i++;
                Shape shape = factory.CreateShape(c.ToString(), i);
                shapeList.Add(shape);
            }

            // Change color of each shape created
            foreach (Shape shape in shapeList)
            {
                shape.Color = "Blue";
            }

            target = shapeList[0].Color;
            Assert.AreEqual(expected, target);
        }
    }
}
