//-----------------------------------------------------------------------
// <copyright file="Trapezium.cs" company="Lucas Da Silva 11631988">
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
    public class Trapezium : Shape
    {
        /// <summary>
        /// Area of circle
        /// </summary>
        private double area;

        /// <summary>
        /// The default side1 of Trapezium
        /// </summary>
        private double a;

        /// <summary>
        /// The default side2 of Trapezium
        /// </summary>
        private double b;

        /// <summary>
        /// Default height of trapezium
        /// </summary>
        private double height;

        /// <summary>
        /// Default color of shape
        /// </summary>
        private string color;

        /// <summary>
        /// Default border style for shape
        /// </summary>
        private string border;

        /// <summary>
        /// Initializes a new instance of the <see cref="Trapezium" /> class.
        /// </summary>
        /// <param name="side1">the side of this shape</param>
        /// <param name="side2">The side of this shape</param>
        /// <param name="height">The height of this shape</param>
        /// <param name="color">The Color of this trapezium</param>
        /// <param name="border">The Border of this trapezium</param>
        public Trapezium(double side1, double side2, double height, string color, string border)
        {
            this.Name = "Trapezium";
            this.a = side1;
            this.b = side2;
            this.height = height;
            this.color = color;
            this.border = border;
            this.area = this.GetArea();
        }

        /// <summary>
        /// Gets or sets the Name of the Rectangle
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
        /// Gets or sets the bottom side of trapezoid
        /// </summary>
        public double TopSide
        {
            get
            {
                return this.a;
            }

            set
            {
                this.a = value;
            }
        }

        /// <summary>
        /// Gets or sets the bottom side of trapezoid
        /// </summary>
        public double BottomSide
        {
            get
            {
                return this.b;
            }

            set
            {
                this.b = value;
            }
        }

        /// <summary>
        /// Gets or sets the height
        /// </summary>
        public double Height
        {
            get
            {
                return this.height;
            }

            set
            {
                this.height = value;
            }
        }

        /// <summary>
        /// Gets or sets the color
        /// </summary>
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
            return "Trapezium";
        }

        /// <summary>
        /// Calculate the area of the Rectangle
        /// </summary>
        /// <returns>The area of the Rectangle</returns>
        public double GetArea()
        {
            return Math.Round(0.5 * (this.a + this.b) * this.height, 2);
        }

        /// <summary>
        /// Return the info of the shape
        /// </summary>
        public override void Info()
        {
            Console.WriteLine("Name: {0}\nSide 1: {1}\nSide 2: {2}\nHeight: {3}\nArea: {4}\nColor: {5}\nBorder: {6}\n", this.Name, this.a, this.b, this.height, this.Area, this.color, this.border);
        }
    }
}
