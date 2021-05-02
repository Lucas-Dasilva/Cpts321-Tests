//-----------------------------------------------------------------------
// <copyright file="Pentagon.cs" company="Lucas Da Silva 11631988">
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
    public class Pentagon : Shape
    {
        /// <summary>
        /// The default side length of pentagon
        /// </summary>
        private double side;

        /// <summary>
        /// Default color of shape
        /// </summary>
        private string color;

        /// <summary>
        /// Default border style for shape
        /// </summary>
        private string border;

        /// <summary>
        /// Initializes a new instance of the <see cref="Pentagon" /> class.
        /// </summary>
        /// <param name="side">The side length of this pentagon</param>
        /// <param name="color">The Color of this shape</param>
        /// <param name="border">The Border of this shape</param> 
        public Pentagon(double side, string color, string border)
        {
            this.Name = "Pentagon";
            this.side = side;
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
            return "Pentagon";
        }

        /// <summary>
        /// Calculate the area of the pentagon
        /// </summary>
        /// <returns>The area of the Rectangle</returns>
        public override double Area()
        {
            return Math.Round(0.25 * Math.Sqrt(5 * (5 + (2 * Math.Sqrt(5)))) * (this.side * this.side), 2);
        }

        /// <summary>
        /// Return the info of the shape
        /// </summary>
        public override void Info()
        {
            Console.WriteLine("Name: {0}\nSide Length: {1}\nArea: {2}\nColor: {3}\nBorder: {4}\n", this.Name, this.side, this.Area(), this.color, this.border);
        }
    }
}
