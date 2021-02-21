//-----------------------------------------------------------------------
// <copyright file="Menu.cs" company="CompanyName">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace Midterm1App
{
    using System;

    /// <summary>
    /// A custom console menu made by Lucas Da Silva
    /// Go Cougs!
    /// </summary>
    public class Menu
    {
        /// <summary>
        /// Points to current option
        /// </summary>
        private int selectedIndex;

        /// <summary>
        /// Array of menu options
        /// </summary>
        private string[] options;

        /// <summary>
        /// Start up message 
        /// </summary>
        private string prompt;

        /// <summary>
        /// Initializes a new instance of the <see cref="Menu"/> class.
        /// </summary>
        /// <param name="prompt">Main menu message</param>
        /// <param name="options">Array of menu options</param>
        public Menu(string prompt, string[] options)
        {
            this.prompt = prompt;
            this.options = options;
            this.selectedIndex = 0;
        }

        /// <summary>
        /// This will handle all the arrow key inputs
        /// </summary>
        /// <returns>Get back selected index</returns>
        public int Run()
        {
            ConsoleKey keyPressed;
            do
            {
                // Set standard background because string.format bug
                Console.ForegroundColor = System.ConsoleColor.White;
                Console.BackgroundColor = System.ConsoleColor.Black;
                Console.Clear(); // Clear console
                this.DisplayOptions(); // Redraw new Options

                ConsoleKeyInfo keyInfo = Console.ReadKey(true); // Get key pressed
                keyPressed = keyInfo.Key;

                // if keypressed is up arrow lower index
                // if key is down arrow increase index
                if (keyPressed == ConsoleKey.UpArrow)
                {
                    this.selectedIndex--;

                    // if index is at the top edge, change index to lowest option
                    if (this.selectedIndex == -1)
                    {
                        this.selectedIndex = this.options.Length - 1;
                    }
                }

                if (keyPressed == ConsoleKey.DownArrow)
                {
                    this.selectedIndex++;

                    // if index is at lowest edge, change index to highest option
                    if (this.selectedIndex == this.options.Length)
                    {
                        this.selectedIndex = 0;
                    }
                }
            } while (keyPressed != ConsoleKey.Enter);

            return this.selectedIndex;
        }

        /// <summary>
        /// Run option 1
        /// </summary>
        public void FirstOption()
        {
            // Set standard background because string.format bug
            Console.ForegroundColor = System.ConsoleColor.White;
            Console.BackgroundColor = System.ConsoleColor.Black;
            Console.Clear();
            Console.WriteLine("Option 1");
            Console.WriteLine("\nPress any key to go back to menu...");
            Console.ReadKey(true);
        }

        /// <summary>
        /// Run option 2
        /// </summary>
        public void SecondOption()
        {
            // Set standard background because string.format bug
            Console.ForegroundColor = System.ConsoleColor.White;
            Console.BackgroundColor = System.ConsoleColor.Black;
            Console.Clear();
            Console.WriteLine("Option 2");
            Console.WriteLine("\nPress any key to go back to menu...");
            Console.ReadKey(true);
        }

        /// <summary>
        /// Display the options to console window
        /// </summary>
        private void DisplayOptions()
        {
            // Main menu message
            Console.WriteLine(this.prompt);

            // List out options
            for (int i = 0; i < this.options.Length; i++)
            {
                string currentOption = this.options[i];
                string prefix; // Points to the option selected

                // if selected index points to the option, then highlight it
                // else don't highlight it 
                if (i == this.selectedIndex)
                {
                    prefix = ">>";
                    Console.ForegroundColor = System.ConsoleColor.White;
                    Console.BackgroundColor = System.ConsoleColor.DarkRed;
                }
                else
                {
                    prefix = "  ";
                    Console.ForegroundColor = System.ConsoleColor.White;
                    Console.BackgroundColor = System.ConsoleColor.Black;
                }

                // Format option and write to console
                string menuStr = string.Format("{0,-2} {1,-12}", prefix, currentOption);
                Console.WriteLine(menuStr);
            }
        }
    }
}
