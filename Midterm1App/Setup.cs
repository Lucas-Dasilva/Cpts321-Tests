//-----------------------------------------------------------------------
// <copyright file="Menu.cs" company="CompanyName">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------

namespace Midterm1App
{
    using System.Collections.Generic;
    using System;

    class Setup
    {
        public void Start()
        {
            // Menu options
            string prompt = "(Use arrow keys to cycle through options and press enter to select it)";
            string[] options = { "Search", "Save Search", "Restock", "Exit" };

            // Initialize objects
            Menu mainMenu = new Menu(prompt, options);
            Search search = new Search();
            Restock restock = new Restock();
            List<Product> productList =  GenerateProducts(new List<Product>());            
            List<Product> searchResults =  GenerateProducts(new List<Product>());

            // save the search
            int selectedIndex = mainMenu.Run();

            do
            {
                switch (selectedIndex)
                {
                    case 0:
                        // Run first option
                        searchResults = search.MatchSearch(productList);
                        break;
                    case 1:
                        // Run second option
                        search.SaveSearch(searchResults);
                        break;
                    case 2:
                        // Run third option
                        restock.InquireUser(productList);
                        break;
                    case 3:
                        Environment.Exit(0); //Terminates Console
                        break;
                }
                selectedIndex = mainMenu.Run();

            } while (selectedIndex != 3);
        }
        private List<Product> GenerateProducts(List<Product> productList)
        {
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

            return productList;
        }


    }
}
