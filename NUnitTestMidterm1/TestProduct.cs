//-----------------------------------------------------------------------
// <copyright file="TestSaveSearch.cs" company="CompanyName">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace Midterm1App
{
    using NUnit.Framework;
    using System.Collections.Generic;

    /// <summary>
    /// Testing save search class
    /// </summary>
    public class TestProduct
    {
        /// <summary>
        /// Test if products can be generated
        /// </summary>
        [Test]
        public void TestProductCreation()
        {
            List<Product> productList = new List<Product>();
            productList.Add(new Product(1, "Playstation 5", 5, "The brand new console PS5, where you can play games"));
            productList.Add(new Product(2, "PlayBoy Magazine", 2, "Newest playboy magazine with Cardi B"));
            productList.Add(new Product(3, "Control", 2, "Play the Control on new generation of consoles"));

            Assert.IsTrue(productList.Count == 3);

        }

    }
}
