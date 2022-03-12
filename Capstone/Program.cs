using System;
using System.Collections.Generic;

namespace Capstone
{
    class Program
    {
        static void Main(string[] args)
        {
            /*what does vm need?
              a way to load inventory
              ui
              vend
              money manager
              logging
            */
            IWrite writer = new ConsoleIO();
            // ILoadInventory loader = new LoadInventoryFromJSON(writer);
            ILoadInventory loader = new LoadInventoryFromFile(writer);

            Dictionary<string, Item> inventory = loader.Load();
            
            if (!loader.Error)
            {
                new VendingMachine(inventory, writer).RunApp();
            } else
            {
                writer.Print("Check log files, Error loading inventory");
            }
        }
    }
}
