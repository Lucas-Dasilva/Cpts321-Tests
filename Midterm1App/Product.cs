//-----------------------------------------------------------------------
// <copyright file="Product.cs" company="CompanyName">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace Midterm1App
{
    public class Product
    {
        private int Id { get; set; }

        private int Quantity { get; set; }
        private string Name { get; set; }
        private string Description { get; set; }

        public Product(int id, string name, int quantity, string description)
        {
            this.Id = id;
            this.Quantity = quantity;
            this.Name = name;
            this.Description = description;
        }
        
    }
}
