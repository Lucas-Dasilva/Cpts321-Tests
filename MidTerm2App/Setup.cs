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
            string[] options = { "Add New Sequence", "Change Default Size", "Filter", "Modifiy A Sequence", "List Sequence History", "List Shapes Created", "Print Cumulative Area", "Exit" };

            // Initialize objects
            Menu mainMenu = new Menu(prompt, options);
            UserQuery user = new UserQuery();

            // save the search
            int selectedIndex = mainMenu.Run();
            do
            {
                switch (selectedIndex)
                {
                    case 0:
                        // Add new sequence
                        user.AskForSequence();
                        break;
                    case 1:
                        // Change default size
                        user.ChangeDefaultSize();
                        break;                    
                    case 2:
                        // Filter
                        user.Filter();
                        break;                    
                    case 3:
                        // Modify sequence
                        user.ModifyHistory();
                        break;                   
                    case 4:
                        // List Sequence History
                        user.SequenceHistory();
                        break;              
                    case 5:
                        // List All Shapes Created and their info and cumulative area
                        user.FullHistory();
                        break;
                    case 6:
                        // Print out the sequence name and it's cumulative area only
                        user.PrintCumulativeArea();
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
