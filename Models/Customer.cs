using System;
using System.Collections.Generic;

namespace bikeShopApi.Models
{
    public class Customer
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string Zip { get; set; }

        public string Phone { get; set; }

        public DateTime LastLogin { get; set; }

        public int FailedLogins { get; set; }


        // 1 to N relationship to Shopping Carts
        public ICollection<ShoppingCart> ShoppingCarts { get; set; }

        // 1 to N relationship to Orders
        public ICollection<Order> Orders { get; set; }
    }
}
