//-----------------------------------------------------------------------
// <copyright file="Square.cs" company="Lucas Da Silva 11631988">
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
    /// Holds attributes of a Square
    /// </summary>
    public class Square : Shape
    {
        /// <summary>
        /// Area of circle
        /// </summary>
        private double area;

        /// <summary>
        /// The default radius of circle
        /// </summary>
        private double length;

        /// <summary>
        /// Default color of shape
        /// </summary>
        private string color;

        /// <summary>
        /// Default border style for shape
        /// </summary>
        private string border;

        /// <summary>
        /// Initializes a new instance of the <see cref="Square" /> class.
        /// </summary>
        /// <param name="sideLength">The index of the sequence</param>
        /// <param name="color">The Color of this shape</param>
        /// <param name="border">The Border of this shape</param>
        public Square(double sideLength, string color, string border)
        {
            this.Name = "Square";
            this.length = sideLength;
            this.color = color;
            this.border = border;
            this.area = this.GetArea();
        }

        /// <summary>
        /// Gets or sets the Name of the square
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Get the area of shape
        /// </summary>
        public override double Area
        {
            get
            {
                return this.area;
            }
        }

        /// <summary>
        /// Gets or sets the length of square
        /// </summary>
        public double LengthSquare
        {
            get
            {
                return this.length;
            }

            set
            {
                this.length = value;
            }
        }

        /// <summary>
        /// Gets or sets the color of the shape
        /// </summary>
        /// <returns></returns>
        public override string Color
        {
            get
            {
                return this.color;
            }

            set
            {
                this.color = value;
            }
        }

        /// <summary>
        /// Gets or sets the border type of the shape
        /// </summary>
        /// <returns></returns>
        public override string Border
        {
            get
            {
                return this.border;
            }

            set
            {
                this.border = value;
            }
        }

        /// <summary>
        /// Gets the name of shape
        /// </summary>
        /// <returns>The string Square</returns>
        public override string GetName()
        {
            return "Square";
        }

        /// <summary>
        /// Calculate the area of the Square
        /// </summary>
        /// <returns>The area of the Square</returns>
        public double GetArea()
        {
            return this.length * this.length;
        }

        /// <summary>
        /// Return the info of the shape
        /// </summary>
        public override void Info()
        {
            Console.WriteLine("Name: {0}\nDimensions: {1} X {2}\nArea: {3}\nColor: {4}\nBorder: {5}\n", this.Name, this.length, this.length, this.length * this.length, this.color, this.border);
        }
    }
}
