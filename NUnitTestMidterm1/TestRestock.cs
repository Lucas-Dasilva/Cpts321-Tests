//-----------------------------------------------------------------------
// <copyright file="TestRestock.cs" company="CompanyName">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace Midterm1App
{
    using System.Collections.Generic;
    using NUnit.Framework;

    /// <summary>
    /// Testing restock class
    /// </summary>
    public class TestRestock
    {
        /// <summary>
        /// Test if FilterList() returns hash set with only distinct integers
        /// Do not alter the list in any way 
        /// Determine time complexity
        /// Use MSDN to help with this
        /// </summary>
        public void TestCheckStock()
        {
            string input = "control";
            List<Product> productList = new List<Product>();
            productList.Add(new Product(1, "Playstation 5", 0, "The brand new console PS5, where you can play games"));
            productList.Add(new Product(2, "PlayBoy Magazine", 2, "Newest playboy magazine with Cardi B"));
            productList.Add(new Product(3, "Control", 10, "Play the Control on new generation of consoles"));
            productList.Add(new Product(4, "Door Mirror", 2, "A mirror designed to be hangned on your wall"));
            productList.Add(new Product(5, "$50 PSN Gift Card", -1, "Giftcard for for PSN store"));
            productList.Add(new Product(6, "Skii Boots", 5, "Control your lines with extreme precision with these highgrade boots used for skiing, for adults"));
            productList.Add(new Product(7, "Windows 10", -1, "The #1 OS that everyone uses, and is also way better than Linux"));
            productList.Add(new Product(8, "Pen", 1232, "The best pens in the world, jk they're cheap, that's why we have so many of them"));
            productList.Add(new Product(9, "Iphone 10", 4, "The best phone you can get right now, play games and movies in stunning 360P quality"));
            productList.Add(new Product(10, "PS3 Controller", 3, "A controller used to control games on the playstation 3"));

            Search search = new Search();
            List<Product> searchResult = new List<Product>(search.MatchSearch(productList, input));

            Restock restock = new Restock();

            List<Product> expectedValue = new List<Product>
            {
                new Product(10, "PS3 Controller", 3, "A controller used to control games on the playstation 3")
            };
            Assert.AreEqual(restock.CheckStock(searchResult, 5), expectedValue); 
        }

        /// <summary>
        /// Test restock function
        /// </summary>
        [Test]
        public void TestRestockProducts()
        {
            List<Product> productList = new List<Product>();
            productList.Add(new Product(1, "Playstation 5", 0, "The brand new console PS5, where you can play games"));
            productList.Add(new Product(2, "PlayBoy Magazine", 2, "Newest playboy magazine with Cardi B"));

            Restock restock = new Restock();

            restock.RestockProducts(productList);
            List<Product> expectedValue = new List<Product>
            {
                new Product(1, "Playstation 5", 10, "The brand new console PS5, where you can play games"),
                new Product(2, "PlayBoy Magazine", 10,  "Newest playboy magazine with Cardi B")
            };
            Assert.AreEqual(productList, expectedValue);
        }
    }
}
