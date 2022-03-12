using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone
{
    public abstract class Item
    {

        public string Name { get; }
        public decimal Price { get; }
        public int QuantityAvailable { get; protected set; }
        private const int DEFAULT_QUANTITY = 5;

        public Item(string name, decimal price, int quantityToStock = DEFAULT_QUANTITY)
        {
            Name = name;
            Price = price;
            QuantityAvailable = quantityToStock;
        }

        private string QuanityAvailableMessage
        {
            get
            {
                if (QuantityAvailable > 0)
                {
                    return QuantityAvailable.ToString();
                }
                else
                {
                    return "Sold Out";
                }
            }
        }

        public abstract string VendItem();
        public override string ToString()
        {
            return $"{Name} {Price} {QuanityAvailableMessage} ";
        }
    }
}
