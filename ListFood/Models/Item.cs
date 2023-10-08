﻿
namespace ListFood.Models
{
    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public int Quantity { get; set; }
        public bool Available { get; set; }
        public decimal Price { get; set; }
    }
}
