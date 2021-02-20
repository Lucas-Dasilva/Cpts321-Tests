//-----------------------------------------------------------------------
// <copyright file="Restock.cs" company="CompanyName">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
using System.Collections.Generic;

namespace Midterm1App
{
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
        /// First, the list of products that match the search will be shown
        /// Then, the employee will be asked whether she/he would like to restock for all of them
        /// if the user does not which to restock, the employee is given the option of new N or to return to main menu
        /// </summary>
        /// <param name="pList">List of products Matching search</param>
        /// <param name="n">Quantity n</param>
        public List<Product> CheckStock(List<Product> pList, int n)
        {
            return pList;
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
            return lowInventoryItems;
        }
    }
}
