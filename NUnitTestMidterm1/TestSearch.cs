//-----------------------------------------------------------------------
// <copyright file="TestSearch.cs" company="CompanyName">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace Midterm1App
{
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
            List<Product> productList = new List<Product>();
            productList.Add(new Product(1, "Playstation 5", 5, "The brand new console PS5, where you can play games"));
            productList.Add(new Product(2, "PlayBoy Magazine", 2, "Newest playboy magazine with Cardi B"));
            productList.Add(new Product(3, "Control", 0, "Play the Control on new generation of consoles"));
            productList.Add(new Product(4, "Door Mirror", 2, "A mirror designed to be hangned on your wall"));
            productList.Add(new Product(5, "$50 PSN Gift Card", -1, "Giftcard for for PSN store"));

            string input = "play";
            Search search = new Search();
            List<Product> searchResult = new List<Product>(search.MatchSearch(productList, input));
            productList.RemoveAt(4);
            productList.RemoveAt(3);

            Assert.AreEqual(searchResult, productList);
        }

    }
}
