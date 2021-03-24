//-----------------------------------------------------------------------
// <copyright file="Program.cs" company="Lucas Da Silva 11631988">
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
    /// Start of the midterm project
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Call the menu and initialize those variables
        /// </summary>
        /// <param name="args">command parameters</param>
        public static void Main(string[] args)
        {
            Shape[] shape = { new Circle(0), new Rectangle(1), new Square(2) };
            
            foreach (Shape s in shape)
            {
                s.Info();
            }

            Console.ReadKey();
        }
    }
}
