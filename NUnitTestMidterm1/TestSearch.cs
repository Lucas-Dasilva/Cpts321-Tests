//-----------------------------------------------------------------------
// <copyright file="TestSearch.cs" company="CompanyName">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace Midterm1App
{
    using System;
    using NUnit.Framework;
    using System.Collections.Generic;

    /// <summary>
    /// Testing search class
    /// </summary>
    public class TestSearch
    {
        /// <summary>
        /// Test if FilterList() returns hash set with only distinct integers
        /// Do not alter the list in any way 
        /// Determine time complexity
        /// Use MSDN to help with this
        /// </summary>
        [Test]
        public void TestMatchSearch()
        {
            Console.WriteLine("jsif");
            List<Product> productList = new List<Product>();
            productList.Add(new Product(1, "Playstation 5", 5, "The brand new console PS5, where you can play games"));
            productList.Add(new Product(2, "PlayBoy Magazine", 2, "Newest playboy magazine with Cardi B"));
            productList.Add(new Product(3, "Control", 0, "Play the Control on new generation of consoles"));
            productList.Add(new Product(4, "Door Mirror", 2, "A mirror designed to be hangned on your wall"));
            productList.Add(new Product(5, "$50 PSN Gift Card", -1, "Giftcard for for PSN store"));

            string input = "play control";
            Search search = new Search();
            List<Product> searchResult = new List<Product>(search.MatchSearch(productList, input));
            productList.RemoveAt(4);
            productList.RemoveAt(3);

            Assert.AreEqual(searchResult, productList);
        }
        /// <summary>
        /// Test save search if it returns tru as in the file was created succesffuly
        /// </summary>
        [Test]
        public void TestSaveSearch()
        {
            Search search = new Search();
            string filename = "2021-02-04-20h34m30s";
        }

    }
}
