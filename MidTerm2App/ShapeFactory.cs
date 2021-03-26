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
        /// The default radius of circle
        /// </summary>
        private double defaultRadius = 5.0;

        /// <summary>
        /// The default length of rectangle
        /// </summary>
        private double defaultLength = 3.0;

        /// <summary>
        /// The default width of rectangle
        /// </summary>
        private double defaultWidth = 4.0;

        /// <summary>
        /// The default size of square side
        /// </summary>
        private double defaultSideLength = 5.0;

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
                    return new Circle(index * this.defaultRadius) { };
                case "s":
                    // Default side length * the index value
                    return new Square(index * this.defaultSideLength) { };
                case "r":
                    // Default length and width * the index value
                    return new Rectangle(index * this.defaultLength, index * this.defaultWidth) { };
                default:
                    // if it is not any of the operators that we support, throw an exception:
                    throw new NotSupportedException("Shape " + c + " not supported yet!");
            }
        }

        /// <summary>
        /// Gets or sets the area of the circle
        /// </summary>
        /// <param name="newRadius">New radius from user</param>
        public void SetDefaultRadius(double newRadius)
        {
            this.defaultRadius = newRadius;
        }

        /// <summary>
        /// Gets or sets the area of the circle
        /// </summary>
        /// <param name="newRadius">New radius from user</param>
        public double GetDefaultRadius()
        {
            return this.defaultRadius;
        }

        /// <summary>
        /// Sets the length of the square
        /// </summary>
        /// <param name="newLength">New length from user</param>
        public void SetDefaultSideLength(double newLength)
        {
            this.defaultSideLength = newLength;
        }        
        
        /// <summary>
        /// Gets the length of the square
        /// </summary>
        public double GetDefaultSideLength()
        {
            return this.defaultSideLength;
        }

        /// <summary>
        /// Sets the length of the Rectangle
        /// </summary>
        /// <param name="newLength">New length from user</param>
        public void SetDefaultLength(double newLength)
        {
            this.defaultLength = newLength;
        }

        /// <summary>
        /// Sets the width of the rectangle
        /// </summary>
        /// <param name="newWidth">New width from user</param>
        public void SetDefaultWidth(double newWidth)
        {
            this.defaultWidth = newWidth;
        }
    }


}
