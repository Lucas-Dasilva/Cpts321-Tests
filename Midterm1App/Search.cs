//-----------------------------------------------------------------------
// <copyright file="Search.cs" company="CompanyName">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------

namespace Midterm1App
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

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
            List<Product> searchResults = new List<Product>();
            // if input is empty sequence of characters return List
            // if input is only digits (User using id of product to check inventory)
            // else input is sequence of strings
            if (string.IsNullOrWhiteSpace(input))
            {
                return pList;
            }
            if (this.IsDigitsOnly(input))
            {
                foreach (Product p in pList)
                {
                    // add product to search result if the id matches
                    if (p.Id.ToString() == input)
                    {
                        searchResults.Add(p);
                    }
                }
            }
            else
            {
                input = input.ToUpper();
      
                if (input.Contains(" "))
                {
                    // And (all tokens must be present in each product)
                    // Or (at least one of the tokens must be present in each product)
                    string[] tokenList = input.Split(' ');

                    // if it's an 'Or' Search
                    // else Do an 'And' search
                    if (!this.CheckAndOr())
                    {
                        foreach (Product p in pList)
                        {
                            // if any string in token list is inside either Name or description
                            if (tokenList.Any(p.Name.ToUpper().Contains) || tokenList.Any(p.Description.ToUpper().Contains))
                            {
                                searchResults.Add(p);
                            }
                        }
                    }
                    else
                    {
                        foreach (Product p in pList)
                        {
                            // if the string input is inside either Name or description
                            if (tokenList.All(p.Name.ToUpper().Contains) || tokenList.All(p.Description.ToUpper().Contains))
                            {
                                searchResults.Add(p);
                            }
                        }
                    }
                }
                else
                {
                    foreach (Product p in pList)
                    {
                        // if the string input is inside either Name or description
                        if (p.Name.ToUpper().Contains(input) || p.Description.ToUpper().Contains(input))
                        {
                            searchResults.Add(p);
                        }
                    }
                }
            }
            return searchResults;
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
        /// <summary>
        /// Helper function to ask user if it is an And or an Or search
        /// </summary>
        /// <returns>true if it's And, False otherwise</returns>
        private bool CheckAndOr()
        {
           Console.Write("Is this an 'And' search? (Y/N): ");
            string searchType = Console.ReadLine();
            //Check if input is not valid

            // If an And search return true
            // else return false
            if (searchType == "y" || searchType == "Y")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// Checks if input is only digits
        /// </summary>
        /// <param name="str"></param>
        /// <returns>true if only digits</returns>
        private bool IsDigitsOnly(string str)
        {
            // scroll through string, look for non digits
            foreach (char c in str)
            {
                if (c < '0' || c > '9')
                {
                    return false;
                }
            }
            return true;
        }


    }
}
