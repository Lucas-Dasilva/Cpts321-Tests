//-----------------------------------------------------------------------
// <copyright file="Program.cs" company="CompanyName">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace Midterm1App
{
    using System;
    using Newtonsoft.Json;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Opening Class of midterm project, where we initialize all objects
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Start of project
        /// </summary>
        /// <param name="args">arguments passed if any</param>
        public static void Main(string[] args)
        {
            Setup initialize = new Setup();
            initialize.Start();
        }
    }
}