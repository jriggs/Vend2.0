using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone
{
    class VendingMachine
    {
        public Dictionary<string, Item> inventory { get; }
        private IWrite io;
        public decimal Balance { get; private set; }
        public VendingMachine(Dictionary<string, Item> initInventory, IWrite write)
        {
            io = write;
            inventory = initInventory;
            //RunApp();
        }

        public void RunApp()
        {

            int userInput = 0;
            while (userInput != 3)
            {
                io.Welcome();
                userInput =  io.GetNumber();

                if (userInput == 1)
                {
                    DisplayInventory();
                }
                else if (userInput == 2)
                {
                    PurchaseMenu();
                }
            }
        }

        private void PurchaseMenu()
        {
            
            int userInput = 0;
            while (userInput !=-1)
            {
                io.Print($"Currrent Balance: { Balance }");
                
                userInput = io.GetNumber(new int[] { 1, 2, 5, 10 });

                if (userInput > 0)
                {
                    Balance += userInput;
                }
            }
        }

        private void DisplayInventory()
        {
            foreach (KeyValuePair<string, Item> item in inventory)
            {
                //Item rowItem = item.Value;
                string output = $"{item.Key} {item.Value}";
                io.Print(output);
            }
        }
    }
}
