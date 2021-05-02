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
        /// Default color of shape
        /// </summary>
        private string color;

        /// <summary>
        /// Default border style for shape
        /// </summary>
        private string border;

        /// <summary>
        /// Initializes a new instance of the <see cref="Rectangle" /> class.
        /// </summary>
        /// <param name="length">the length of this rectangle</param>
        /// <param name="width">The width of this rectangle</param>
        /// <param name="color">The Color of this rectangle</param>
        /// <param name="border">The Border of this rectangle</param>
        public Rectangle(double length, double width, string color, string border)
        {
            this.Name = "Rectangle";
            this.length = length;
            this.width = width;
            this.color = color;
            this.border = border;
        }

        /// <summary>
        /// Gets or sets the Name of the Rectangle
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Return the color of the shape
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
        /// return the border type of the shape
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
        /// <returns>The string Rectangle</returns>
        public override string GetName()
        {
            return "Rectangle";
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
            Console.WriteLine("Name: {0}\nDimensions: {1} X {2}\nArea: {3}\nColor: {4}\nBorder: {5}\n", this.Name, this.width, this.length, this.length * this.width, this.color, this.border);
        }
    }
}
