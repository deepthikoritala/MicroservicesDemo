﻿namespace Orders.Models
{
    public class Order
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public double Total { get; set; }

        public int NoOfItems { get; set; }
    }
}
