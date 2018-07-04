using System;
using System.Collections.Generic;

namespace bikeShopApi.Models
{
    public class ShoppingCart
    {
        public int ID { get; set; }

        public DateTime Date { get; set; }

        public int CustomerID { get; set; }


        // 1 to 1 relationship to Customers
        public Customer Customer { get; set; }

        // 1 to N relationship to Products
        public ICollection<Product> Products { get; set; }
    }
}
