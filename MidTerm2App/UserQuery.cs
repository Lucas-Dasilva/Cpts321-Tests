//-----------------------------------------------------------------------
// <copyright file="UserQuery.cs" company="Lucas Da Silva 11631988">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace MidTerm2App
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using System.Xml;

    /// <summary>
    /// This class is used to perform queries such as filter, search, delete
    /// </summary>
    public class UserQuery
    {
        /// <summary>
        /// A Stack, that holds the struct of shapes
        /// shapes created from the sequence.
        /// </summary>
        private List<ShapeStructure> structList;

        /// <summary>
        /// Load and save class
        /// </summary>
        private LoadSave ls;

        /// <summary>
        /// The shape factory, we only need one instance so we create it in this class
        /// </summary>
        private ShapeFactory shapeFact = new ShapeFactory();

        /// <summary>
        /// Initializes a new instance of the <see cref="UserQuery" /> class.
        /// </summary>
        public UserQuery()
        {
            this.structList = new List<ShapeStructure>();
            this.ls = new LoadSave();
            this.shapeFact = new ShapeFactory();
        }

        /// <summary>
        /// Check if user has created at least one sequence before accessing certain functions
        /// </summary>
        /// <returns>Returns true if they are not allowed and false otherwise</returns>
        public bool NotAllowedToEnter()
        {
            if (this.structList.Count == 0)
            {
                Console.Clear();
                Console.WriteLine("Make sure a sequence has been loaded or created first!!");
                Console.Write("\nPress any key to go back to menu...");
                Console.ReadKey(true);

                return true;
            }

            return false;
        }

        /// <summary>
        /// Ask the user to input sequence
        /// </summary>
        public void AskForSequence()
        {
            Console.Clear();
            string line;
            Console.WriteLine("Please enter a sequence of shapes ('c','r','s','t','p'): ");

            // Ask for input until, they enter one that is part of the list
            while (true)
            {
                // get the user input for every iteration, allowing to exit at will
                line = Console.ReadLine();
                if (this.CheckInput(line))
                {
                    break; 
                }

                Console.Clear();
                Console.Write("Please try again, only 'c', 's','t','p' and 'r' characters are allowed:");

                // this is what will happen in the loop body since we didn't exit
                // put whatever note stuff you want to execute again and again in here
            }

            // Ask user for a sequence and pass to shape struct
            ShapeStructure shapeStruct = new ShapeStructure(line, this.shapeFact);

            // Add the sequence and the shape structure into the stack
            this.structList.Add(shapeStruct);
        }

        /// <summary>
        /// Call load from xml method from LoadSave class and load the file into the struct list
        /// </summary>
        public void LoadFromXML()
        {
            Console.Clear();
            this.structList = this.ls.LoadFromXML(this.shapeFact);
            if (this.structList == null)
            {
                Console.WriteLine("Failed to load file..");
                Console.Write("\nPress any key to go back to menu...");
                Console.ReadKey(true);
            }
            else
            {
                Console.WriteLine("Sussfully loaded file!");
                Console.Write("\nPress any key to go back to menu...");
                Console.ReadKey(true);
            }
        }

        /// <summary>
        /// Save the struct list into an xml file
        /// </summary>
        public void SaveToXML()
        {
            if (this.NotAllowedToEnter())
            {
                return;
            }

            this.ls.SaveToXML(this.structList);
            Console.Clear();
            Console.WriteLine("Sussfully Saved file!");
            Console.Write("\nPress any key to go back to menu...");
            Console.ReadKey(true);
        }

        /// <summary>
        /// User wants to change border type of a given shape in a sequence
        /// </summary>
        public void ChangeShapeBorder()
        {
            if (this.NotAllowedToEnter())
            {
                return;
            }

            Console.Clear();
            int i = 1;
            int sequenceIndex;
            int shapeIndex = -1;
            int borderIndex;

            // If more than one sequence was created
            // Only one sequence was created
            if (this.structList.Count > 1)
            {
                // Print the sequence and corresponding number selection
                // Scroll through stack of structs
                foreach (var item in this.structList)
                {
                    Console.WriteLine($"{i})\"{item.Sequence}\"");
                    i++;
                }

                Console.Write("Enter digit that represents the sequence you wish to change Color of: ");

                // Ask for input until, they enter one that is part of the list
                while ((!int.TryParse(Console.ReadLine(), out sequenceIndex)) || sequenceIndex <= 0 || sequenceIndex > this.structList.Count)
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
            }
            else
            {
                sequenceIndex = 1;
            }

            // User has entered a valid input so now we ask for which shape and then which color
            int exitNum = this.structList.ElementAt(sequenceIndex - 1).Sequence.Length + 1;

            // We want to loop until user asks to exit
            while (shapeIndex != exitNum)
            {
                i = 1;
                Console.Clear();
                Console.WriteLine($"Sequence: \"{this.structList.ElementAt(sequenceIndex - 1).Sequence}\"");

                // Print character of each sequence
                foreach (char c in this.structList.ElementAt(sequenceIndex - 1).Sequence)
                {
                    Console.WriteLine($"{i})\"{c}\"");
                    i++;
                }

                Console.WriteLine("{0}) Done changing Borders...", exitNum);

                Console.Write("Enter digit that represents the character of the shape you wish to change the BORDER of: ");

                // Ask for input until, they enter one that is part of the list
                while ((!int.TryParse(Console.ReadLine(), out shapeIndex)) || shapeIndex <= 0 || shapeIndex > exitNum)
                {
                    i = 1;
                    Console.Clear();

                    // Print character of each sequence
                    foreach (char c in this.structList.ElementAt(sequenceIndex - 1).Sequence)
                    {
                        Console.WriteLine($"{i})\"{c}\"");
                        i++;
                    }

                    Console.WriteLine("{0}) Done changing border...", exitNum);
                    Console.Write("Try again (Digit must represent one of these sequences): ");
                }

                // If user wishes to exit early
                if (shapeIndex == exitNum)
                {
                    return;
                }

                // At this point, the user has selected a character representing a a character from the sequence, now he must select a color
                i = 1;

                Console.Clear();
                Console.WriteLine("1) Solid\n2) Dotted\n3) Dashed\n");
                Console.Write("Enter digit that represents the color you wish the shape to be: ");

                // Ask for color input until they enter one that is part of the list
                while ((!int.TryParse(Console.ReadLine(), out borderIndex)) || borderIndex <= 0 || borderIndex > 3)
                {
                    i = 1;
                    Console.Clear();
                    Console.WriteLine("1) Solid\n2) Dotted\n3) Dashed\n");
                    Console.Write("Try again (Digit must represent one of these sequences): ");
                }

                // Change border to solid
                // Change border to dotted
                // Change border to dashed
                if (borderIndex == 1)
                {
                    this.structList.ElementAt(sequenceIndex - 1).ChangeBorderOfShapeAt(shapeIndex, "Solid");
                }
                else if (borderIndex == 2)
                {
                    this.structList.ElementAt(sequenceIndex - 1).ChangeBorderOfShapeAt(shapeIndex, "Dotted");
                }
                else
                {
                    this.structList.ElementAt(sequenceIndex - 1).ChangeBorderOfShapeAt(shapeIndex, "Dashed");
                }
            }
        }

        /// <summary>
        /// User wants to change the color of a given shape in a sequence
        /// </summary>
        public void ChangeShapeColor()
        {
            if (this.NotAllowedToEnter())
            {
                return;
            }

            Console.Clear();
            int i = 1;
            int sequenceIndex;
            int shapeIndex = -1;
            int colorIndex;

            // If more than one sequence was created
            // Only one sequence was created
            if (this.structList.Count > 1)
            {
                // Print the sequence and corresponding number selection
                // Scroll through stack of structs
                foreach (var item in this.structList)
                {
                    Console.WriteLine($"{i})\"{item.Sequence}\"");
                    i++;
                }

                Console.Write("Enter digit that represents the sequence you wish to change Color of: ");

                // Ask for input until, they enter one that is part of the list
                while ((!int.TryParse(Console.ReadLine(), out sequenceIndex)) || sequenceIndex <= 0 || sequenceIndex > this.structList.Count)
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
            }
            else
            {
                sequenceIndex = 1;
            }

            // User has entered a valid input so now we ask for which shape and then which color
            int exitNum = this.structList.ElementAt(sequenceIndex - 1).Sequence.Length + 1;

            // We want to loop until user asks to exit
            while (shapeIndex != exitNum)
            {
                i = 1;
                Console.Clear();
                Console.WriteLine($"Sequence: \"{this.structList.ElementAt(sequenceIndex - 1).Sequence}\"");

                // Print character of each sequence
                foreach (char c in this.structList.ElementAt(sequenceIndex - 1).Sequence)
                {
                    Console.WriteLine($"{i})\"{c}\"");
                    i++;
                }

                Console.WriteLine("{0}) Done changing colors...", exitNum);

                Console.Write("Enter digit that represents the character of the shape you wish to change the color of: ");

                // Ask for input until, they enter one that is part of the list
                while ((!int.TryParse(Console.ReadLine(), out shapeIndex)) || shapeIndex <= 0 || shapeIndex > exitNum)
                {
                    i = 1;
                    Console.Clear();

                    // Print character of each sequence
                    foreach (char c in this.structList.ElementAt(sequenceIndex - 1).Sequence)
                    {
                        Console.WriteLine($"{i})\"{c}\"", c);
                        i++;
                    }

                    Console.WriteLine("{0}) Done changing colors...", exitNum);
                    Console.Write("Try again (Digit must represent one of these sequences): ");
                }

                // If user wishes to exit early
                if (shapeIndex == exitNum)
                {
                    return;
                }

                // At this point, the user has selected a character representing a a character from the sequence, now he must select a color
                i = 1;

                Console.Clear();
                Console.WriteLine("1) Red\n2) Green\n3) Blue\n");
                Console.Write("Enter digit that represents the color you wish the shape to be: ");

                // Ask for color input until they enter one that is part of the list
                while ((!int.TryParse(Console.ReadLine(), out colorIndex)) || colorIndex <= 0 || colorIndex > 3)
                {
                    i = 1;
                    Console.Clear();
                    Console.WriteLine("1) Red\n2) Green\n3) Blue\n");
                    Console.Write("Try again (Digit must represent one of these sequences): ");
                }

                // Change color to red
                // Change color to Green
                // Change color to Blue
                if (colorIndex == 1)
                {
                    this.structList.ElementAt(sequenceIndex - 1).ChangeColorOfShapeAt(shapeIndex, "Red");
                }
                else if (colorIndex == 2)
                {
                    this.structList.ElementAt(sequenceIndex - 1).ChangeColorOfShapeAt(shapeIndex, "Green");
                }
                else
                {
                    this.structList.ElementAt(sequenceIndex - 1).ChangeColorOfShapeAt(shapeIndex, "Blue");
                }
            }
        }

        /// <summary>
        /// Filters all the sequences, and displays only the shapes with the right criteria
        /// </summary>
        public void Filter()
        {
            if (this.NotAllowedToEnter())
            {
                return;
            }

            Console.Clear();
            int pick = -1;

            // Scroll through stack of structs
            Console.WriteLine("1) Filter by shape name\n2) Filter by area\n3) Filter by Color\n4) Filter by Border\n5) Back to menu");

            // Ask for input until, they enter one that is part of the list
            while ((!int.TryParse(Console.ReadLine(), out pick)) || pick <= 0 || pick > 5)
            {
                Console.Write("Try again (Digit must represent one of these sequences): ");
            }

            // If they want to filter by shape name
            // They want to filter by area
            // Filter by color
            // Filter by border
            // Return to menu
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
                    IEnumerable<Shape> shapes = l.ShapeList.Where(t => t.Area <= input);

                    foreach (var s in shapes)
                    {
                        s.Info();
                    }
                }

                Console.Write("\nPress any key to go back to menu...");
                Console.ReadKey(true);
            }
            else if (pick == 3)
            {
                Console.Clear();

                // Scroll through stack of structs
                Console.WriteLine("1) Red\n2) Green\n3) Blue\n");

                // Ask for input until, they enter one that is part of the list
                while ((!int.TryParse(Console.ReadLine(), out pick)) || pick <= 0 || pick > 3)
                {
                    Console.Write("Try again (Digit must represent one of these sequences): ");
                }

                Console.Clear();

                // If we want to display all shapes with color red
                // If we want to display all shapes with color blue
                // Else, we displaly green shapes
                if (pick == 1)
                {
                    // Scroll through stack of structs
                    foreach (var l in this.structList)
                    {
                        // Find shapes with area less than user input
                        IEnumerable<Shape> shapes = l.ShapeList.Where(t => t.Color == "Red");

                        if (shapes.Count() > 1)
                        {
                            foreach (var s in shapes)
                            {
                                s.Info();
                            }
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
                        IEnumerable<Shape> shapes = l.ShapeList.Where(t => t.Color == "Green");

                        if (shapes.Count() > 1)
                        {
                            foreach (var s in shapes)
                            {
                                s.Info();
                            }
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
                        IEnumerable<Shape> shapes = l.ShapeList.Where(t => t.Color == "Blue");

                        if (shapes.Count() > 1)
                        {
                            foreach (var s in shapes)
                            {
                                s.Info();
                            }
                        }
                    }

                    Console.Write("\nPress any key to go back to menu...");
                    Console.ReadKey(true);
                }
            }
            else if (pick == 4)
            {
                Console.Clear();

                // Scroll through stack of structs
                Console.WriteLine("1) Solid\n2) Dotted\n3) Dashed\n");

                // Ask for input until, they enter one that is part of the list
                while ((!int.TryParse(Console.ReadLine(), out pick)) || pick <= 0 || pick > 3)
                {
                    Console.Write("Try again (Digit must represent one of these sequences): ");
                }

                Console.Clear();

                // If we want to display all shapes with color red
                // If we want to display all shapes with color blue
                // Else, we displaly green shapes
                if (pick == 1)
                {
                    // Scroll through stack of structs
                    foreach (var l in this.structList)
                    {
                        // Find shapes with area less than user input
                        IEnumerable<Shape> shapes = l.ShapeList.Where(t => t.Border == "Solid");

                        if (shapes.Count() > 1)
                        {
                            foreach (var s in shapes)
                            {
                                s.Info();
                            }
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
                        IEnumerable<Shape> shapes = l.ShapeList.Where(t => t.Border == "Dotted");

                        if (shapes.Count() > 1)
                        {
                            foreach (var s in shapes)
                            {
                                s.Info();
                            }
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
                        IEnumerable<Shape> shapes = l.ShapeList.Where(t => t.Border == "Dashed");

                        if (shapes.Count() > 1)
                        {
                            foreach (var s in shapes)
                            {
                                s.Info();
                            }
                        }
                    }

                    Console.Write("\nPress any key to go back to menu...");
                    Console.ReadKey(true);
                }
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
            if (this.NotAllowedToEnter())
            {
                return;
            }

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
            if (this.NotAllowedToEnter())
            {
                return;
            }

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
                string seq;

                // Ask for input until, they enter one that is part of the list
                while (true)
                {
                    // get the user input for every iteration, allowing to exit at will
                    seq = Console.ReadLine();
                    if (this.CheckInput(seq))
                    {
                        break;
                    }

                    Console.Clear();
                    Console.Write("Please try again, only 'c', 's','t','p' and 'r' characters are allowed:");
                }

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
                Console.WriteLine("Which shape would you like to change size for? ('c','r','s','t','p'): ");
                seq = Console.ReadLine();
            }
            while (!string.Equals(seq, "c") && !string.Equals(seq, "r") && !string.Equals(seq, "s") && !string.Equals(seq, "t") && !string.Equals(seq, "p"));

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
            else if (seq == "t")
            {
                double topSide;
                double botSide;

                Console.Write("Please enter new top side length for Trapezium: ");

                // Ask for new dimensions until they enter an appropriate input
                while (!double.TryParse(Console.ReadLine(), out topSide))
                {
                    Console.Clear();
                    Console.WriteLine("Try again (Must be positive double): ");
                }

                Console.Write("Please enter new bottom side length for Trapezium: ");

                while (!double.TryParse(Console.ReadLine(), out botSide))
                {
                    Console.Clear();
                    Console.WriteLine("Try again (Must be positive double): ");
                }

                this.shapeFact.SetDefaultBotSide(botSide);
                this.shapeFact.SetDefaultTopSide(topSide);
            }
            else if (seq == "p")
            {
                double penSide;

                Console.Write("Please enter new Length for Pentagon: ");

                // Ask for new dimensions until they enter an appropriate input
                while (!double.TryParse(Console.ReadLine(), out penSide))
                {
                    Console.Clear();
                    Console.WriteLine("Try again (Must be positive double): ");
                }

                this.shapeFact.SetDefaultPentagonSide(penSide);
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
            if (this.NotAllowedToEnter())
            {
                return;
            }

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
            if (this.NotAllowedToEnter())
            {
                return;
            }

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
        /// <param name="input">input string</param>
        /// <returns>true if there is a character not allowed in the input, else otherwise</returns>
        public bool CheckInput(string input)
        {
            string allowableLetters = "csrtp ";

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
