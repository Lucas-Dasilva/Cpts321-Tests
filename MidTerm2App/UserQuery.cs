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
        /// A Stack, that holds the struct of shapes
        /// shapes created from the sequence.
        /// </summary>
        private List<ShapeStructure> structList = new List<ShapeStructure>();

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
            string line;
            Console.WriteLine("Please enter a sequence of shapes ('c','r','s'): ");
            // Ask for input until, they enter one that is part of the list
            while (true)
            {

                // get the user input for every iteration, allowing to exit at will
                line = Console.ReadLine();
                if (CheckInput(line))
                {
                    break; 
                }
                Console.Clear();
                Console.Write("Please try again, only 'c', 's', and 'r' characters are allowed:");

                // this is what will happen in the loop body since we didn't exit
                // put whatever note stuff you want to execute again and again in here
            }

            // Ask user for a sequence and pass to shape struct
            ShapeStructure shapeStruct = new ShapeStructure(line, this.shapeFact);

            // Add the sequence and the shape structure into the stack
            this.structList.Add(shapeStruct);
        }

        /// <summary>
        /// Filters all the sequences, and displays only the shapes with the right criteria
        /// </summary>
        public void Filter()
        {
            Console.Clear();
            int pick = -1;

            // Scroll through stack of structs
            Console.WriteLine("1) Filter by shape name\n2) Filter by area\n3) Back to menu");

            // Ask for input until, they enter one that is part of the list
            while ((!int.TryParse(Console.ReadLine(), out pick)) || pick <= 0 || pick > 3)
            {
                Console.Write("Try again (Digit must represent one of these sequences): ");
            }

            // If they want to filter by shape name
            // They want to filter by area
            if (pick == 1)
            {
                Console.Clear();

                // Scroll through stack of structs
                Console.WriteLine("1) Circles\n2) Rectangles\n3) Squares");

                // Ask for input until, they enter one that is part of the list
                while ((!int.TryParse(Console.ReadLine(), out pick)) || pick <= 0 || pick > 3)
                {
                    Console.Write("Try again (Digit must represent one of these sequences): ");
                }

                Console.Clear();

                // If we want to display all Circles
                // If we want to display all rectangles
                // Else, we display all squares
                if (pick == 1)
                {
                    // Scroll through stack of structs
                    foreach (var l in this.structList)
                    {
                        // Find shapes with area less than user input
                        IEnumerable<Shape> shapes = l.ShapeList.Where(t => t.GetName() == "Circle");

                        foreach (var s in shapes)
                        {
                            s.Info();
                        }
                    }

                    Console.Write("\nPress any key to go back to menu...");
                    Console.ReadKey(true);
                }
                else if (pick == 2)
                {
                    // Scroll through stack of structs
                    foreach (var l in this.structList)
                    {
                        // Find shapes with area less than user input
                        IEnumerable<Shape> shapes = l.ShapeList.Where(t => t.GetName() == "Rectangle");

                        foreach (var s in shapes)
                        {
                            s.Info();
                        }
                    }

                    Console.Write("\nPress any key to go back to menu...");
                    Console.ReadKey(true);
                }
                else
                {
                    // Scroll through stack of structs
                    foreach (var l in this.structList)
                    {
                        // Find shapes with area less than user input
                        IEnumerable<Shape> shapes = l.ShapeList.Where(t => t.GetName() == "Square");

                        foreach (var s in shapes)
                        {
                            s.Info();
                        }
                    }

                    Console.Write("\nPress any key to go back to menu...");
                    Console.ReadKey(true);
                }
            }
            else if (pick == 2)
            {
                Console.Clear();
                double input;

                // Scroll through stack of structs
                Console.WriteLine("Print all shapes with area less than or equal to: ");

                // Ask for input until, they enter one that is part of the list
                while ((!double.TryParse(Console.ReadLine(), out input)) || input == 0)
                {
                    Console.Write("Try again (Digit must represent one of these sequences): ");
                }

                // Scroll through stack of structs
                foreach (var l in this.structList)
                {
                    // Find shapes with area less than user input
                    IEnumerable<Shape> shapes = l.ShapeList.Where(t => t.Area() <= input);

                    foreach (var s in shapes)
                    {
                        s.Info();
                    }
                }

                Console.Write("\nPress any key to go back to menu...");
                Console.ReadKey(true);
            }
            else
            {
                return;
            }
        }

        /// <summary>
        /// Print the cumulative area for each sequence
        /// </summary>
        public void PrintCumulativeArea()
        {
            Console.Clear();

            // Scroll through struct
            foreach (var item in this.structList)
            {
                Console.WriteLine($"---------------------(\"{item.Sequence}\")---------------------");
                Console.WriteLine($"\n\tCumulative Area of Sequence: {item.SumOfArea}\n");
            }

            Console.Write("\nPress any key to go back to menu...");
            Console.ReadKey(true);
        }

        /// <summary>
        /// Allows the user to modify a sequence in history, the shapes need to be updated
        /// </summary>
        public void ModifyHistory()
        {
            Console.Clear();
            int i = 1;
            int pick = -1;
            int temp = -1;

            // Scroll through stack of structs
            foreach (var item in this.structList)
            {
                Console.WriteLine($"{i})\"{item.Sequence}\"");
                i++;
            }

            Console.Write("Enter digit that represents the sequence you wish to edit: ");

            // Ask for input until, they enter one that is part of the list
            while ((!int.TryParse(Console.ReadLine(), out pick)) || pick <= 0 || pick > this.structList.Count)
            {
                i = 1;
                Console.Clear();

                // Scroll through stack of structs
                foreach (var item in this.structList)
                {
                    Console.WriteLine($"{i})\"{item.Sequence}\"");
                    i++;
                }

                Console.Write("Try again (Digit must represent one of these sequences): ");
            }

            Console.Clear();
            Console.WriteLine($"Sequence: \"{this.structList.ElementAt(pick - 1).Sequence}\"");
            Console.Write("Enter 1 to edit Sequence, and 2 to Delete: ");

            // Ask for input until, they enter one that is part of the list
            while ((!int.TryParse(Console.ReadLine(), out temp)) || temp <= 0 || temp > 2)
            {
                Console.Clear();
                Console.WriteLine($"Sequence: \"{this.structList.ElementAt(pick - 1).Sequence}\"");
                Console.Write("Try again, must be an integer 1 or 2: ");
            }

            // Edit sequence if it's 1
            // Delete sequence other wise
            if (temp == 1)
            {
                Console.Clear();
                Console.Write($"Please enter a new sequence to replace the current \"{this.structList.ElementAt(pick - 1).Sequence}\":");
                string seq = Console.ReadLine();

                // Ask user for a sequence and pass to shape struct
                ShapeStructure editedSequence = new ShapeStructure(seq, this.shapeFact);
                this.structList[pick - 1] = editedSequence;
            }
            else
            {
                this.structList.RemoveAt(pick - 1);
            }
        }

        /// <summary>
        /// Change default size of a shape
        /// </summary>
        public void ChangeDefaultSize()
        {
            Console.Clear();
            string seq;

            // Error check for right shape character
            do
            {
                Console.Clear();
                Console.WriteLine("Which shape would you like to change size for? ('c','r','s'): ");
                seq = Console.ReadLine();
            }
            while (!string.Equals(seq, "c") && !string.Equals(seq, "r") && !string.Equals(seq, "s"));

            // If input is == c, get new default radius
            // else if input is == r, get new rectangle dimensions
            // else, get new side for square
            if (seq == "c")
            {
                Console.Clear();
                double radius;
                Console.WriteLine("Please enter new Circle Radius: ");

                // Ask for new dimensions until they enter an appropriate input
                while (!double.TryParse(Console.ReadLine(), out radius))
                {
                    Console.Clear();
                    Console.WriteLine("Try again (Must be positive double): ");
                }

                this.shapeFact.SetDefaultRadius(radius);
            }
            else if (seq == "r")
            {
                double length;
                double width;

                Console.Write("Please enter new Length for rectangle: ");

                // Ask for new dimensions until they enter an appropriate input
                while (!double.TryParse(Console.ReadLine(), out length))
                {
                    Console.Clear();
                    Console.WriteLine("Try again (Must be positive double): ");
                }

                Console.Write("Please enter new Width for rectangle: ");

                while (!double.TryParse(Console.ReadLine(), out width))
                {
                    Console.Clear();
                    Console.WriteLine("Try again (Must be positive double): ");
                }

                this.shapeFact.SetDefaultLength(length);
                this.shapeFact.SetDefaultWidth(width);
            }
            else
            {
                double sideLength;

                Console.Write("Please enter new side length for square: ");
                
                // Ask for new dimensions until they enter an appropriate input
                while (!double.TryParse(Console.ReadLine(), out sideLength))
                {
                    Console.Clear();
                    Console.WriteLine("Try again (Must be positive double): ");
                }

                this.shapeFact.SetDefaultSideLength(sideLength);
            }
        }

        /// <summary>
        /// List of all sequences
        /// </summary>
        public void SequenceHistory()
        {
            Console.Clear();
            Console.WriteLine("(From oldest to newest)");
            int i = 1;

            // Scroll through stack of structs
            foreach (var item in this.structList)
            {
                Console.WriteLine($"{i})\"{item.Sequence}\"");
                i++;
            }

            Console.Write("\nPress any key to go back to menu...");
            Console.ReadKey(true);
        }

        /// <summary>
        /// List of all sequences and their shapes info
        /// </summary>
        public void FullHistory()
        {
            Console.Clear();
            Console.WriteLine("(From oldest to newest)");
            
            // Scroll through stack of structs
            foreach (var item in this.structList)
            {
                Console.WriteLine("---------------------------------------------------------");
                item.PrintSequenceInfo();
                Console.WriteLine($"Cumulative Area of Sequence: {item.SumOfArea}");
            }

            Console.Write("\nPress any key to go back to menu...");
            Console.ReadKey(true);
        }

        /// <summary>
        /// Check user input for characters that are not allowed
        /// </summary>
        /// <param name="input"></param>
        /// <returns>true if there is a character not allowed in the input, else otherwise</returns>
        bool CheckInput(string input)
        {
            string allowableLetters = "csr ";

            // iterate input
            foreach (char c in input)
            {
                if (!allowableLetters.Contains(c.ToString()))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
