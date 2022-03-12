using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone
{
    class Gum : Item
    {
        public Gum(string name, decimal price, int quantityToStock = -1) 
            : base(name, price, quantityToStock) { }
       
        public override string VendItem()
        {
            QuantityAvailable -= 1;
            return "Chomp Chomp";
        }
    }
}
