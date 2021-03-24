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
        private double defaultLength = 3.0;        
        
        /// <summary>
        /// The default radius of circle
        /// </summary>
        private double defaultWidth = 4.0;

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
        /// <param name="index">The index of rectangle in the sequence</param>
        public Rectangle(int index)
        {
            this.Name = "Rectangle";
            this.length = this.defaultLength * index;
            this.width = this.defaultWidth * index;
        }

        /// <summary>
        /// Gets or sets the Name of the Rectangle
        /// </summary>
        private new string Name { get; set; }

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
