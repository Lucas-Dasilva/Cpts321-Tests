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
        /// default top side of trapezoid
        /// </summary>
        private double defaultTopSide = 5.0;

        /// <summary>
        /// Default bottom side length of trapezoid
        /// </summary>
        private double defaultBotSide = 6.0;

        /// <summary>
        /// Default height of trapezoid
        /// </summary>
        private double defaultHeight = 5.0;

        /// <summary>
        /// Default pentagon side lengths
        /// </summary>
        private double defaultPenside = 3.0;

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
        /// The default color
        /// </summary>
        private string defaultColor = "Red";

        /// <summary>
        /// The default border style
        /// </summary>
        private string defaultBorder = "Dashed";

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
                    return new Circle(index * this.defaultRadius, this.defaultColor, this.defaultBorder) { };
                case "s":
                    // Default side length * the index value
                    return new Square(index * this.defaultSideLength, this.defaultColor, this.defaultBorder) { };
                case "r":
                    // Default length and width * the index value
                    return new Rectangle(index * this.defaultLength, index * this.defaultWidth, this.defaultColor, this.defaultBorder) { };
                case "t":
                    // Default values for trapezium
                    return new Trapezium(index * this.defaultTopSide, index * this.defaultBotSide, index * this.defaultHeight, this.defaultColor, this.defaultBorder) { };
                case "p":
                    // Default values for pentagon
                    return new Pentagon(index * this.defaultPenside, this.defaultColor, this.defaultBorder) { };
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
        /// <returns>The default radius</returns>
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
        /// <returns>Default side length</returns>
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

        /// <summary>
        /// Gets the default color of shapes
        /// </summary>
        /// <returns>Default side length</returns>
        public string GetDefaultColor()
        {
            return this.defaultColor;
        }

        /// <summary>
        /// Sets the default color of the shapes
        /// </summary>
        /// <param name="newColor">New color from user</param>
        public void SetDefaultColor(string newColor)
        {
            this.defaultColor = newColor;
        }

        /// <summary>
        /// Gets the default border of shape
        /// </summary>
        /// <returns>Default side length</returns>
        public string GetDefaultBorder()
        {
            return this.defaultBorder;
        }

        /// <summary>
        /// Sets the default border of shapes
        /// </summary>
        /// <param name="newBorder">New border from user</param>
        public void SetDefaultBorder(string newBorder)
        {
            this.defaultBorder = newBorder;
        }

        /// <summary>
        /// Sets the default top side length of trapezoid
        /// </summary>
        /// <param name="newTopSide">New side length</param>
        public void SetDefaultTopSide(double newTopSide)
        {
            this.defaultTopSide = newTopSide;
        }

        /// <summary>
        /// Sets the default bottom side length of trapezoid
        /// </summary>
        /// <param name="newBotSide">New side length</param>
        public void SetDefaultBotSide(double newBotSide)
        {
            this.defaultBotSide = newBotSide;
        }

        /// <summary>
        /// Sets the default side length for pentagon
        /// </summary>
        /// <param name="newPenSide">New side length</param>
        public void SetDefaultPentagonSide(double newPenSide)
        {
            this.defaultPenside = newPenSide;
        }
    }
}
