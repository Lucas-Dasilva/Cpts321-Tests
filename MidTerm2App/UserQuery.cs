//-----------------------------------------------------------------------
// <copyright file="UserQuery.cs" company="Lucas Da Silva 11631988">
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
    /// This class is used to perform queries such as filter, search, delete
    /// </summary>
    public class UserQuery
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UserQuery" /> class.
        /// </summary>
        public UserQuery()
        {
            // Ask user for a sequence and pass to shape struct
            this.AskForSequence();
        }

        /// <summary>
        /// Ask the user to input sequence
        /// </summary>
        /// <returns>String they input</returns>
        private string AskForSequence()
        {
            Console.WriteLine("Please enter a sequence of shapes ('c','r','s'): ");
            string seq = Console.ReadLine();
            return seq;
        }
    }
}
