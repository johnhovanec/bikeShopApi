using System;
using System.Collections.Generic;

namespace bikeShopApi.Models
{
    public class Order
    {
        public int ID { get; set; }

        public DateTime DateCreated { get; set; }

        public decimal Subtotal { get; set; }

        public decimal Tax { get; set; }

        public decimal Total { get; set; }

        public int CustomerID { get; set; }

        public int ShoppingCartID { get; set; }


        // 1 to 1 relationship to Shopping Cart
        public Customer Customer { get; set; }

        // 1 to 1 relationship to Shopping Cart
        public ShoppingCart ShoppingCart { get; set; }

        // 1 to N relationship to Products
        public ICollection<Product> Products { get; set; }
    }
}
