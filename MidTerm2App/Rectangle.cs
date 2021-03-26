//-----------------------------------------------------------------------
// <copyright file="Rectangle.cs" company="Lucas Da Silva 11631988">
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
    /// Holds attributes of a rectangle
    /// </summary>
    public class Rectangle : Shape
    {
        /// <summary>
        /// The default radius of circle
        /// </summary>
        private double length;

        /// <summary>
        /// The default radius of circle
        /// </summary>
        private double width;

        /// <summary>
        /// Initializes a new instance of the <see cref="Rectangle" /> class.
        /// </summary>
        /// <param name="length">the length of this rectangle</param>
        /// <param name="width">The width of this rectange</param>
        public Rectangle(double length, double width)
        {
            this.Name = "Rectangle";
            this.length = length;
            this.width = width;
        }

        /// <summary>
        /// Gets or sets the Name of the Rectangle
        /// </summary>
        private new string Name { get; set; }

        /// <summary>
        /// Calculate the area of the Rectangle
        /// </summary>
        /// <returns>The area of the Rectangle</returns>
        public override double Area()
        {
            return this.length * this.width;
        }

        /// <summary>
        /// Return the info of the shape
        /// </summary>
        public override void Info()
        {
            Console.WriteLine("Name: {0}\nDimensions: {1} X {2}\nArea: {3}\n", this.Name, this.width, this.length, this.length * this.width);
        }
    }
}
