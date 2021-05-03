//-----------------------------------------------------------------------
// <copyright file="Setup.cs" company="CompanyName">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------

namespace MidTerm2App
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Windows.Forms;

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
            string[] options = { "Add a Sequence", "Change Default Shape Size", "Change Border Style", "Change Shape Color", "List Created Shapes", "View Sequence History", "Modifiy A Sequence (Edit or Delete)", "Print Cumulative Area of Sequences", "Filter Shapes Based on Criteria", "Save to XML File", "Load from XML File", "Exit" };

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
                        // ask for a new sequence
                        user.AskForSequence();
                        break;
                    case 1:
                        // Change default values of shapes
                        user.ChangeDefaultSize();
                        break;
                    case 2:
                        // Change a certain shaper border
                        user.ChangeShapeBorder();
                        break;
                    case 3:
                        // Change a certain shapes color
                        user.ChangeShapeColor();
                        break;
                    case 4:
                        // List All Shapes Created and their info and cumulative area
                        user.FullHistory();
                        break;
                    case 5:
                        // List only the sequence history, no info, just a string
                        user.SequenceHistory();
                        break;
                    case 6:
                        // edit or delete a sequence
                        user.ModifyHistory();
                        break;
                    case 7:
                        // print the culmulative area for each sequence
                        user.PrintCumulativeArea();
                        break;
                    case 8:
                        // Filter based on certain criterias
                        user.Filter();
                        break;                    
                    case 9:
                        // Save to file
                        user.SaveToXML();
                        break;                   
                    case 10:
                        // Load file
                        user.LoadFromXML();
                        break;              
                    case 11:
                        // Exit
                        Environment.Exit(0); 
                        break;
                }

                selectedIndex = mainMenu.Run();
            }
            while (selectedIndex != 11);
        }
    }
}
