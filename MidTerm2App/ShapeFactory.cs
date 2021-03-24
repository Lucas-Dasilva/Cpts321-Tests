//-----------------------------------------------------------------------
// <copyright file="ShapeFactory.cs" company="Lucas Da Silva 11631988">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace MidTerm2App
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Creates the shape depending on the character input, and assigns the default size values
    /// </summary>
    public class ShapeFactory
    {
        /// <summary>
        /// Factory class for creating each shape depending on the character input and which order it comes in
        /// </summary>
        /// <param name="c">Shape character</param>
        /// <param name="index">Index value that determines the size of shape</param>
        /// <returns>Returns the shape Object</returns>
        public Shape CreateShape(string c, int index)
        {
            // picking case for shape to pick
            switch (c)
            {
                case "c":
                    // Default radius * the index value
                    return new Circle(index) { };
                case "s":
                    // Default side length * the index value
                    return new Square(index) { };
                case "r":
                    // Default length and width * the index value
                    return new Rectangle(index) { };
                default:
                    // if it is not any of the operators that we support, throw an exception:
                    throw new NotSupportedException("Shape " + c + " not supported yet!");
            }
        }
    }
}
