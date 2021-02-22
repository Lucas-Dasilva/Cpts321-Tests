//-----------------------------------------------------------------------
// <copyright file="Product.cs" company="CompanyName">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------

namespace Midterm1App
{
    using System;

    /// <summary>
    /// Generates product list
    /// </summary>
    public class Product
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Product"/> class>
        /// </summary>
        /// <param name="id">id of product</param>
        /// <param name="name">product name</param>
        /// <param name="quantity">amount of stock</param>
        /// <param name="description">product description</param>
        public Product(int id, string name, int quantity, string description)
        {
            this.Id = id;
            this.Quantity = quantity;
            this.Name = name;
            this.Description = description;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Product"/> class>
        /// </summary>
        public Product()
        {
            this.Id = 0;
            this.Quantity = 0;
            this.Name = string.Empty;
            this.Description = string.Empty;
        }

        /// <summary>
        /// Gets or sets int id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets or sets Product stock
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// Gets or sets Product name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets Description of the product
        /// </summary>
        public string Description { get; set; }
    }
}
