//-----------------------------------------------------------------------
// <copyright file="Setup.cs" company="CompanyName">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------

namespace MidTerm2App
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Sets up the menu and the project
    /// </summary>
    public class Setup
    {
        /// <summary>
        /// Starts the menu
        /// </summary>
        public void Start()
        {
            // Menu options
            string prompt = "(Use arrow keys to cycle through options and press enter to select it)";
            string[] options = { "Add New Sequence", "Compute Area of Sequence", "Change Default Size", "Filter", "Modifiy A Sequence", "List Shapes Created", "List Sequence History", "Exit" };

            // Initialize objects
            Menu mainMenu = new Menu(prompt, options);

            // save the search
            int selectedIndex = mainMenu.Run();
            do
            {
                switch (selectedIndex)
                {
                    case 0:
                        // Add new sequence
                        break;
                    case 1:
                        // compute area of sequence
                        break;
                    case 2:
                        // Change default size
                        break;                    
                    case 3:
                        // Filter
                        break;                    
                    case 4:
                        // Modify sequence
                        break;                   
                    case 5:
                        // List Shapes Created
                        break;              
                    case 6:
                        // List Sequence History
                        break;
                    case 7:
                        // Exit
                        Environment.Exit(0); // Terminates Console
                        break;
                }

                selectedIndex = mainMenu.Run();
            }
            while (selectedIndex != 7);
        }
    }
}
