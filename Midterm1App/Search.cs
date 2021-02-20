﻿//-----------------------------------------------------------------------
// <copyright file="Search.cs" company="CompanyName">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
using System.Collections.Generic;

namespace Midterm1App
{
    /// <summary>
    /// An employee can search for a product in the store database
    /// search should be performed on all possible fields
    /// search by code or by keywords, this must be handled implicitly
    /// sequence of characters contains one or more spaces, it would need to be split into tokens 
    /// employee should be asked whether this is an AND search (all tokens must be present in each product) or and OR search
    /// If the user enters an empty sequence of characters, i.e., 
    /// she/he simply hits enter or space(s), then the result should be all products in the store.
    /// </summary>
    public class Search
    {
        public List<Product> MatchSearch(List<Product> pList, string input)
        {
            //if input is empty sequence of characters return List
            return pList;
        }

        /// <summary>
        /// The last search performed will be saved to a file in a subdirectory of the project
        /// called "searches"
        /// if the search was performed at 8:34:30pm on February 4, 2021 the filename would be “2021-02-04-20h34m30s.txt”
        /// The first line of the file should contain the sequences of characters that the employee used for
        /// the search and whether it was an AND or OR search if applicable
        /// The rest of the file, i.e., starting from line 2, must contain the result of the search as it was shown to the employee. 
        /// </summary>
        public bool SaveSearch(string searchDate)
        {
            return false;
        }
    }
}
