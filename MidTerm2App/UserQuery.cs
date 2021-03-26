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
        /// A dictionary, where the key holds the sequence and the value is the list of
        /// shapes created from the sequence.
        /// </summary>
        private Dictionary<string, ShapeStructure> structDict = new Dictionary<string, ShapeStructure>();

        /// <summary>
        /// The shape factory, we only need one instance so we create it in this class
        /// </summary>
        private ShapeFactory shapeFact = new ShapeFactory();

        /// <summary>
        /// Initializes a new instance of the <see cref="UserQuery" /> class.
        /// </summary>
        public UserQuery()
        {
            // First thing is to ask user for a new sequence
            this.AskForSequence();
        }

        /// <summary>
        /// Ask the user to input sequence
        /// </summary>
        public void AskForSequence()
        {
            Console.Clear();
            Console.WriteLine("Please enter a sequence of shapes ('c','r','s'): ");
            string seq = Console.ReadLine();

            // Ask user for a sequence and pass to shape struct
            ShapeStructure shapeStruct = new ShapeStructure(seq, shapeFact);

            // Add the sequence and the shape structure into dictionary
            this.structDict.Add(seq, shapeStruct);
        }

        /// <summary>
        /// Change default size of a shape
        /// </summary>
        public void ChangeDefaultSize()
        {
            Console.Clear();
            Console.WriteLine("Which shape would you like to change size for? ('c','r','s'): ");
            string seq = Console.ReadLine();

            // Error check for right shape character
            do
            {
                Console.WriteLine("Not a valid shape entry! ('c','r','s'): ");
                seq = Console.ReadLine();
            } 
            while (seq != "c" || seq != "r" || seq != "s");

            if (seq == "c")
            {
                Console.WriteLine("Please enter new Circle Radius: ");
                double radius = Convert.ToDouble(Console.ReadLine());

                // Error check
                do
                {
                    Console.WriteLine("Try again (Must be positive double): ");
                    radius = Convert.ToDouble(Console.ReadLine());
                }
                while (radius <= 0.0);
                this.shapeFact.SetDefaultRadius(radius);
            }
        }
    }
}
