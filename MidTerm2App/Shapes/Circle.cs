//-----------------------------------------------------------------------
// <copyright file="Circle.cs" company="Lucas Da Silva 11631988">
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
    /// Holds attributes of a circle
    /// </summary>
    public class Circle : Shape
    {
        /// <summary>
        /// The default radius of circle
        /// </summary>
        private double radius;
        
        /// <summary>
        /// Default color of shape
        /// </summary>
        private string color;

        /// <summary>
        /// Default border style for shape
        /// </summary>
        private string border;

        /// <summary>
        /// Initializes a new instance of the <see cref="Circle" /> class.
        /// </summary>
        /// <param name="radius">Updated radius of circle</param>
        /// <param name="color">The Color of this shape</param>
        /// <param name="border">The Border of this shape</param>
        public Circle(double radius, string color, string border)
        {
            this.Name = "Circle";
            this.radius = radius;
            this.color = color;
            this.border = border;
        }      
        
        /// <summary>
        /// Gets or sets the Name of the circle
        /// </summary>
        public string Name { get; set; }

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
        /// <returns>The string circle</returns>
        public override string GetName()
        {
            return "Circle";
        }

        /// <summary>
        /// Calculate the area of the circle
        /// </summary>
        /// <returns>The area of the circle</returns>
        public override double Area()
        {
            return Math.Round(Math.PI * Math.Pow(this.radius, 2.0), 2);
        }

        /// <summary>
        /// Return the info of the shape
        /// </summary>
        public override void Info()
        {
            Console.WriteLine("Name: {0}\nRadius: {1}\nArea: {2:f2}\nColor: {3}\nBorder: {4}\n", this.Name, this.radius, Math.PI * Math.Pow(this.radius, 2.0), this.color, this.border);
        }
    }
}
