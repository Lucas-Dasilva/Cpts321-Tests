//-----------------------------------------------------------------------
// <copyright file="Shape.cs" company="Lucas Da Silva 11631988">
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
    /// Abstract class that creates the different shapes
    /// </summary>
    public abstract class Shape
    {
        /// <summary>
        /// Gets or sets Color of shape, anything really
        /// </summary>
        /// <returns></returns>
        public abstract string Color { get; set; }

        /// <summary>
        /// Gets or sets Border of shape..Solid line, Dotted line, Dashed line
        /// </summary>
        /// <returns></returns>
        public abstract string Border { get; set; }

        /// <summary>
        /// Gets area of shape
        /// </summary>
        public abstract double Area { get; }

        /// <summary>
        /// Gets the name of shape
        /// </summary>
        /// <returns>The string of the shape name</returns>
        public abstract string GetName();

        /// <summary>
        /// Prints out the info of each shape to console
        /// </summary>
        public abstract void Info();
    }
}
