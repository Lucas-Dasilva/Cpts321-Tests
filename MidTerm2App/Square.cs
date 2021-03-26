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
        /// The default radius of circle
        /// </summary>
        private double length;

        /// <summary>
        /// Initializes a new instance of the <see cref="Square" /> class.
        /// </summary>
        /// <param name="index">The index of the sequence</param>
        public Square(double sideLength)
        {
            this.Name = "Square";
            this.length = sideLength;
        }

        /// <summary>
        /// Gets or sets the Name of the Rectangle
        /// </summary>
        private new string Name { get; set; }

        /// <summary>
        /// Calculate the area of the Square
        /// </summary>
        /// <returns>The area of the Square</returns>
        public override double Area()
        {
            return this.length * this.length;
        }

        /// <summary>
        /// Return the info of the shape
        /// </summary>
        public override void Info()
        {
            Console.WriteLine("Name: {0}\nDimensions: {1} X {2}\nArea: {3}\n", this.Name, this.length, this.length, this.length * this.length);
        }
    }
}
