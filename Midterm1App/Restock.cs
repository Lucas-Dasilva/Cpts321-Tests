//-----------------------------------------------------------------------
// <copyright file="Restock.cs" company="CompanyName">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------

namespace Midterm1App
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// all physical products with less than N items will be restocked, where N is provided by the employee
    /// First, the list of products that match the search will be shown
    /// Then, the employee will be asked whether she/he would like to restock for all of them
    /// if yes then one by one, for products needed to restock, ask the the employee
    /// how many purchases of that product should be made.
    /// After that, a confirmation must be shown that the purchase is successful, and the updated product information must be shown.
    /// if the user does not which to restock, the employee is given the option of new N or to return to main menu
    /// </summary>
    public class Restock
    {
        /// <summary>
        /// This runs the menu for user if they wish to not restock for all products
        /// </summary>
        /// <param name="prodList">Original product list</param>
        /// <returns>A new List of products, if you do a search after restocking, the list will be updated</returns>
        public List<Product> InquireUser(List<Product> prodList)
        {
            // Create new menu for restocking
            string prompt = "Choose a new 'N' or exit to Main Menu!";
            string[] options = { "Restock Again", "Exit" };
            Menu restockMenu = new Menu(prompt, options);
            List<Product> searchResults = new List<Product>(this.CheckStock(prodList));

            bool choice = this.AskYesNo();
            if (choice == false)
            {
                // Run restock menu until user wants to exit
                do
                {
                    int selection = restockMenu.Run();
                    switch (selection)
                    {
                        case 0:
                            searchResults = this.CheckStock(prodList);
                            choice = this.AskYesNo();

                            // We want to update the original products with the new quantities
                            if (choice == true)
                            {
                                searchResults = this.RestockProducts(searchResults);
                                return this.UpdateProductList(prodList, searchResults);
                            }

                            break;
                        case 1:
                            choice = true;
                            break;
                    }
                } 
                while (choice == false);
            }
            else
            {
                searchResults = this.RestockProducts(searchResults);
                return this.UpdateProductList(prodList, searchResults);
            }
            return prodList;
        }

        /// <summary>
        /// First, the list of products that match the search will be shown
        /// Then, the employee will be asked whether she/he would like to restock for all of them
        /// if the user does not which to restock, the employee is given the option of new N or to return to main menu
        /// </summary>
        /// <param name="prodList">List of products Matching search</param>
        /// <returns>Product list that matched the search</returns>

        public List<Product> CheckStock(List<Product> prodList)
        {
            List<Product> searchResults = new List<Product>();
            Console.Clear();
            Console.Write("Display all products with Quantity less than: ");
            int n = this.GetNumberFromUser();

            foreach (Product p in prodList)
            {
                // add all results to list if greater than 0 and less than required quantity
                if (p.Quantity >= 0 && p.Quantity < n)
                {
                    searchResults.Add(p);
                }
            }
            this.PrintSimpleResults(searchResults); // Prints out results(simple list)
            return searchResults;
        }

        /// <summary>
        /// if yes then one by one, for products needed to restock, ask the the employee
        /// how many purchases of that product should be made.
        /// Confirmation must be shown that the purchase is successful, and the updated product information must be shown.
        /// </summary>
        /// <param name="lowInventoryItems"> the search results for low inventory</param>
        /// <returns>Updated product list after purchasing items</returns>
        public List<Product> RestockProducts(List<Product> lowInventoryItems)
        {
            Console.WriteLine("Restocking For all items!\n");
            int n;
            foreach (Product p in lowInventoryItems)
            {
                this.PrintSingleProduct(p);
                Console.Write("Enter how much inventory should be purchased: ");
                n = this.GetNumberFromUser();
                p.Quantity += n; // Sets new number in inventory
                this.PrintSuccessfull(p);
            }
            return lowInventoryItems;
        }

        /// <summary>
        /// Updates the original list with new stock
        /// </summary>
        /// <param name="oldList">old product list</param>
        /// <param name="newList">new stocked up list</param>
        /// <returns>Updated product list</returns>
        private List<Product> UpdateProductList(List<Product> oldList, List<Product> newList)
        {
            return oldList;
        }

        /// <summary>
        /// Print full list details
        /// </summary>
        /// <param name="p">the search result coming in</param>
        private void PrintSuccessfull(Product p)
        {
            Console.Clear();
            Console.WriteLine("Purchase of {0}s was Successfull!", p.Name);
            Console.WriteLine(string.Format("|Id: {0, 2}| |Name: {1, 15}||Quantity: {2, 4}| |Desc: {3, 20}.",
                                                p.Id, p.Name, p.Quantity, p.Description));
            Console.Write("Press any key to move on...");
            Console.ReadKey(true);
        }

        /// <summary>
        /// Gets number from user based on input
        /// </summary>
        /// <returns>The integer from the readline statement</returns>
        private int GetNumberFromUser()
        {
            string input = Console.ReadLine();

            // checks if input are only digits
            if (!this.IsDigitsOnly(input))
            {
                do
                {
                    Console.Clear();
                    Console.Write("Please only enter digits: ");
                    input = Console.ReadLine();
                } 
                while (!this.IsDigitsOnly(input));
            }
            int n = short.Parse(input); // Convert digits to Int
            return n;
        }

        /// <summary>
        /// Print full list details
        /// </summary>
        /// <param name="p">the search result coming in</param>
        private void PrintSingleProduct(Product p)
        {
            Console.Clear();
            Console.WriteLine(string.Format("|Id: {0, 2}| |Name: {1, 15}||Quantity: {2, 4}| |Desc: {3, 20}.",
                                            p.Id, p.Name, p.Quantity, p.Description));
        }

        /// <summary>
        /// print basic list with name and description
        /// </summary>
        /// <param name="prodList">the search result coming in</param>
        private void PrintSimpleResults(List<Product> prodList)
        {
            Console.Clear();
            if (prodList.Count == 0)
            {
                Console.Write("No Results!\nPress any key to go back to Menu...");
                Console.ReadKey(true);
            }
            else
            {
                foreach (Product p in prodList)
                {
                    Console.WriteLine("|Id: {0, 2}||Name: {1, 15}||Quantity: {2, 4}|", p.Id, p.Name, p.Quantity);
                }
            }
        }

        /// <summary>
        /// Helper function ask user for input
        /// </summary>
        /// <returns>true if user answered yes, false otherwise</returns>
        private bool AskYesNo()
        {
            Console.WriteLine("Would you like to restock for all?(Y/N): ");
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
        /// <param name="str">A string that should be a digit</param>
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
