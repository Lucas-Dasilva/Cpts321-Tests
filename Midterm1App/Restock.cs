//-----------------------------------------------------------------------
// <copyright file="Restock.cs" company="CompanyName">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
using System.Collections.Generic;

namespace Midterm1App
{
    using System;
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



        // Make a do while function that calls checkstock()
        //this.AskYesNo(); // Ask user if they wish to restock for all
        //if(this.AskYesNo())
        public List<Product> InquireUser(List<Product> pList)
        {
            // 1.Ask user if they wish to restock for all
            // 2.Yes then for each product user must enter how many additional items to be bought
            // 3.    then a confirmation must be sent that all products were purchased successfully 
            // 4. No then ask user to change n or return to main menu
            string prompt = "Choose a new 'N' or exit to Main Menu!";
            string[] options = { "Restock Again", "Exit" };
            Menu restockMenu = new Menu(prompt, options);
            List<Product> searchResults = new List<Product>(this.CheckStock(pList));

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
                            searchResults = this.CheckStock(pList);
                            choice = this.AskYesNo();
                            // We want to update the original products with the new quantities
                            if (choice == true)
                            {
                                searchResults = this.RestockProducts(searchResults);
                                return (this.UpdateProductList(pList, searchResults));
                            }
                            break;
                        case 1:
                            choice = true;
                            break;
                    }

                } while (choice == false);
            }
            else
            {
                searchResults = this.RestockProducts(searchResults);
                return (this.UpdateProductList(pList, searchResults));
            }
            
            return pList;
            
        }
        /// <summary>
        /// First, the list of products that match the search will be shown
        /// Then, the employee will be asked whether she/he would like to restock for all of them
        /// if the user does not which to restock, the employee is given the option of new N or to return to main menu
        /// </summary>
        /// <param name="pList">List of products Matching search</param>
        /// <param name="n">Quantity n</param>
        public List<Product> CheckStock(List<Product> pList)
        {
            List<Product> searchResults = new List<Product>();
            Console.Clear();
            Console.Write("Display all products with Quantity less than: ");
            int N = this.GetNumberFromUser();

            foreach (Product p in pList)
            {
                // add all results to list if greater than 0 and less than required quantity
                if (p.Quantity >= 0 && p.Quantity < N)
                {
                    searchResults.Add(p);
                }
            }
            this.PrintSimpleResults(searchResults); //Prints out results(simple list)

            return searchResults;
            // If they wish to restock for all
            // if theydon't want to restock for all

            
        }


        /// <summary>
        /// if yes then one by one, for products needed to restock, ask the the employee
        /// how many purchases of that product should be made.
        /// Confirmation must be shown that the purchase is successful, and the updated product information must be shown.
        /// </summary>
        /// <param name="lowInventoryItems"></param>
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

        private List<Product> UpdateProductList(List<Product> oldList, List<Product> newList)
        {
            return oldList;
        }

        /// <summary>
        /// Print full list details
        /// </summary>
        /// <param name="pList">the search result coming in</param>
        private void PrintSuccessfull(Product p)
        {
            Console.Clear();
            Console.WriteLine("Purchase of {0}s was Successfull!", p.Name);
            Console.WriteLine((String.Format("|Id: {0, 2}| |Name: {1, 15}||Quantity: {2, 4}| |Desc: {3, 20}.",
                                p.Id, p.Name, p.Quantity, p.Description)));
            Console.WriteLine("Press any key to move on...");
            Console.ReadKey(true);
        }

        /// <summary>
        /// Gets number from user based on input
        /// </summary>
        private int GetNumberFromUser()
        {
            string input = Console.ReadLine();

            // checks if input are only digits
            if (!IsDigitsOnly(input))
            {
                do
                {
                    Console.Clear();
                    Console.Write("Please only enter digits: ");
                    input = Console.ReadLine();

                } while (!IsDigitsOnly(input));
            }

            int N = Int16.Parse(input); //Convert digits to Int
            return N;
        }

        /// <summary>
        /// Print full list details
        /// </summary>
        /// <param name="pList">the search result coming in</param>
        private void PrintSingleProduct(Product p)
        {
            Console.Clear();
            Console.WriteLine((String.Format("|Id: {0, 2}| |Name: {1, 15}||Quantity: {2, 4}| |Desc: {3, 20}.",
                                p.Id, p.Name, p.Quantity, p.Description)));

        }

        /// <summary>
        /// printt basic list with name and description
        /// </summary>
        /// <param name="pList">the search result coming in</param>
        private void PrintSimpleResults(List<Product> pList)
        {
            Console.Clear();
            if (pList.Count == 0)
            {
                Console.WriteLine("No Results!\nPress any key to go back to Menu...");
                Console.ReadKey(true);
            }
            else
            {
                foreach (Product p in pList)
                {
                    Console.WriteLine("|Id: {0, 2}||Name: {1, 15}||Quantity: {2, 4}|", p.Id, p.Name, p.Quantity);
                }
            }


        }

        /// <summary>
        /// Helper function to ask user if it is an And or an Or search
        /// </summary>
        /// <returns>true if it's And, False otherwise</returns>
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
