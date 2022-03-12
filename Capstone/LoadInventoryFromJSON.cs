using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.IO;//different dependencies for this class

namespace Capstone
{



    class LoadInventoryFromJSON : ILoadInventory
    {

        private readonly string DEAFULT_LOCATION = Environment.CurrentDirectory;
        private const string DEAFAULT_FILENAME = "vendingmachine.json";
        private string fullyQualifiedPathToFile = "";
        private IWrite writer;
        public bool Error { get; private set; } = false;

        public LoadInventoryFromJSON(IWrite writer)
        {
            fullyQualifiedPathToFile = Path.Combine(DEAFULT_LOCATION, DEAFAULT_FILENAME);
            this.writer = writer;
        }

        public Dictionary<string, Item> Load()
        {
           Dictionary<string, Item> output = new Dictionary<string, Item>();

            try
            {
                string vendingJSON =  File.ReadAllText(fullyQualifiedPathToFile);
                List<ItemModel> inventory = JsonConvert.DeserializeObject<List<ItemModel>>(vendingJSON);

                foreach (ItemModel line in inventory)
                {
                    output[line.slot] = new Gum(line.name, line.price, line.quantity); 
                }
            }
            catch (Exception)
            {
                Error = true;
                writer.Print("Error reading json file");
            }
            return output;
        }
    }
}
