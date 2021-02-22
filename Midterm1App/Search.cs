//-----------------------------------------------------------------------
// <copyright file="Search.cs" company="CompanyName">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------

namespace Midterm1App
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;

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
        public Queue<string> lastSearch = new Queue<string>();
        public Queue<string> lastDate = new Queue<string>();

        /// <summary>
        /// Look for matches inside a list of products
        /// </summary>
        /// <param name="pList"></param>
        /// <returns></returns>
        public List<Product> MatchSearch(List<Product> pList)
        {
            Console.Clear();
            Console.Write("Enter a search query: ");
            string input = Console.ReadLine();
            // save search into queue
            
            this.lastDate.Enqueue(DateTime.Now.ToString("yyyy-MM-dd-HH'h'mm'm'ss's'"));

            List<Product> searchResults = new List<Product>();
            // if input is empty sequence of characters return List
            // if input is only digits (User using id of product to check inventory)
            // else input is sequence of strings
            if (string.IsNullOrWhiteSpace(input))
            {
                this.PrintFullResults(pList);
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
                string originalInput = input;
                input = input.ToUpper(); //Set all characters to upper so, there's no case match
                
                // If the search contains multiple words
                // else, search does not contain multiple words
                if (input.Contains(" "))
                {
                    // And (all tokens must be present in each product)
                    // Or (at least one of the tokens must be present in each product)
                    string[] tokenList = input.Split(' ');

                    // if it's an 'Or' Search
                    // else Do an 'And' search
                    if (!this.CheckAndOr())
                    {
                        // Add message for when we write to file
                        this.lastSearch.Enqueue("Your Last Search Input: '" + originalInput + "' using 'OR'" + "\n");
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
                        // Add message for when we write to file
                        this.lastSearch.Enqueue("Your Last Search Input: '" + originalInput + "' using 'AND'" + "\n");
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
                    // Add message for when we write to file
                    this.lastSearch.Enqueue("Your Last Search Input: '" + originalInput + "'\n");
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
            //print results
            this.PrintFullResults(searchResults);
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
        public void SaveSearch(List<Product> pList)
        {
            // If you have not searched before
            // Else, save search to file
            if (this.lastSearch.Count == 0)
            {
                Console.Clear();
                Console.WriteLine("You have no search history, start with a search query first!");
                Console.WriteLine("Press any key to go back to Menu...");
                Console.ReadKey(true);
            }
            else
            { 
                string path = @"..\..\..\..\Midterm1App\searches\" + this.lastDate.Last() + ".txt";

                try
                {
                    // Create the file, or overwrite if the file exists.
                    using (FileStream fs = File.Create(path))
                    {
                        string[] searchResults = this.ParseObject(pList); // The search results as string
                        byte[] info1 = new UTF8Encoding(true).GetBytes(this.lastSearch.Last());
                        fs.Write(info1, 0, info1.Length);

                        for (int i = 0; i < searchResults.Length; i++)
                        {
                            byte[] info2 = new UTF8Encoding(true).GetBytes(searchResults[i]);
                            // Add some information to the file.
                            fs.Write(info2, 0, info2.Length);
                        }
                    }
                }

                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    Console.ReadKey(true);
                }
            }
        }

        /// <summary>
        /// printt basic list with name and description
        /// </summary>
        /// <param name="pList">the search result coming in</param>
        private string[] ParseObject(List<Product> pList)
        {
            string[] strList = new string[pList.Count];
            Product p = new Product();
            for (int i = 0; i < pList.Count; i ++) 
            {
                p = pList.ElementAt(i);
                strList[i] = (String.Format("|Id: {0, 2}| |Name: {1, 15}||Quantity: {2, 4}| |Desc: {3, 20}.\n", 
                    p.Id, p.Name, p.Quantity, p.Description));
            }
            return strList;
        }



        /// <summary>
        /// Print full list details
        /// </summary>
        /// <param name="pList">the search result coming in</param>
        private void PrintFullResults(List<Product> pList)
        {
            Console.Clear();
            if (pList.Count == 0)
            {
                Console.WriteLine("No Results!\nPress any key to go back to Menu...");
                Console.ReadKey(true);
            }
            else
            {

                Console.WriteLine("{0} Results from search!", pList.Count);
                foreach (Product p in pList)
                {
                    Console.WriteLine((String.Format("|Id: {0, 2}| |Name: {1, 15}||Quantity: {2, 4}| |Desc: {3, 20}.",
                                        p.Id, p.Name, p.Quantity, p.Description)));
                }
                Console.WriteLine("Press any key to go back to Menu...");
                Console.ReadKey(true);
            }

        }

        /// <summary>
        /// Helper function to ask user if it is an And or an Or search
        /// </summary>
        /// <returns>true if it's And, False otherwise</returns>
        private bool CheckAndOr()
        {
            Console.Write("Is this an 'And' search? (Y/N): ");
            string searchType = Console.ReadLine();
            Console.Clear();

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
