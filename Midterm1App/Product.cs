//-----------------------------------------------------------------------
// <copyright file="Product.cs" company="CompanyName">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
using System;

namespace Midterm1App
{
    public class Product
    {
        public int Id { get; set; }

        public int Quantity { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public Product(int id, string name, int quantity, string description)
        {
            this.Id = id;
            this.Quantity = quantity;
            this.Name = name;
            this.Description = description;
        }
        public Product()
        {
            this.Id = 0;
            this.Quantity = 0;
            this.Name = "";
            this.Description = "";
        }


    }
}
