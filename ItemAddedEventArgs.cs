using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dashboard
{
    public class ItemAddedEventArgs : EventArgs
    {
        public string ProductID { get; }
        public string ItemName { get; }
        public string Description { get; }
        public decimal Price { get; }
        public int Quantity { get; }
        public decimal Subtotal { get; }

        public ItemAddedEventArgs(string productID, string itemName, string description, decimal price, int quantity, decimal subtotal)
        {
            ProductID = productID;
            ItemName = itemName;
            Description = description;
            Price = price;
            Quantity = quantity;
            Subtotal = subtotal;
        }
    }
}
