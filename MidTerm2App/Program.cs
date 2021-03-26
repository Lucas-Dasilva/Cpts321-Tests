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
            Setup initialize = new Setup();
            initialize.Start();
        }
    }
}
