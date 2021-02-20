//-----------------------------------------------------------------------
// <copyright file="Program.cs" company="CompanyName">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace Midterm1App
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Opening Class of midterm project, where we initialize all objects
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Start of project
        /// </summary>
        /// <param name="args">arguments passed if any</param>
        public static void Main(string[] args)
        {
            Search search = new Search();
            Restock restock = new Restock();
            List<Product> productList = new List<Product>();
            productList.Add(new Product(1, "Playstation 5", 0, "The brand new console PS5, where you can play games"));
            productList.Add(new Product(2, "PlayBoy Mag", 2, "Newest playboy magazine with Cardi B"));
            productList.Add(new Product(3, "Control", 10, "Play the Control on new generation of consoles"));
            productList.Add(new Product(4, "Door Mirror", 2, "A mirror designed to be hangned on your wall"));
            productList.Add(new Product(5, "$50 PSN Card", -1, "Giftcard for for PSN store"));
            productList.Add(new Product(6, "Skii Boots", 5, "Control your lines with extreme precision with these highgrade boots used for skiing, for adults"));
            productList.Add(new Product(7, "Windows 10", -1, "The #1 OS that everyone uses, and is also way better than Linux"));
            productList.Add(new Product(8, "Pen", 1232, "The best pens in the world, jk they're cheap, that's why we have so many of them"));
            productList.Add(new Product(9, "Iphone 10", 4, "The best phone you can get right now, play games and movies in stunning 360P quality"));
            productList.Add(new Product(10, "PS3 Controller", 3, "A controller used to control games on the playstation 3"));



            Console.Write("Enter Search Input: ");
            string input = Console.ReadLine();
            List<Product> searchResult = new List<Product>(search.MatchSearch(productList, input));
            search.PrintSimpleResults(searchResult);


            Console.WriteLine("(1)Search\n(2)Save Search\n(3)Restock");
            string choice = Console.ReadLine();
            switch (choice)
            {
                    case "1": // correction 1
                    Console.Clear();
                    break;

                case "2": // correction 2
                    break;                
                case "3": // correction 2
                    break;

                default:
                    Console.WriteLine(" You did not type a or b");
                    Console.WriteLine();
                    Console.ReadLine();
                    break;
            }
            string date = 

           
            // search result
            
            // print search result
            search.PrintFullResults(searchResult);
            string line1 = "Search Results for: " + input + " using  '"+ method +"'";
            string output = JsonConvert.SerializeObject(productList, Formatting.Indented);
            // save the search
            search.SaveSearch(line1, output, date.ToString());






        }
    }
}
