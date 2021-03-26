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
        /// Initializes a new instance of the <see cref="Circle" /> class.
        /// </summary>
        /// <param name="index">Index of sequence</param>
        public Circle(double radius)
        {
            this.Name = "Circle";
            this.radius = radius;
        }      
        
        /// <summary>
        /// Gets or sets the Name of the circle
        /// </summary>
        private new string Name { get; set; }


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
            Console.WriteLine("Name: {0}\nRadius: {1}\nArea: {2:f2}\n", this.Name, this.radius, Math.PI * Math.Pow(this.radius, 2.0));
        }
    }
}
