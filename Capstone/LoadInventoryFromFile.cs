using System;
using System.Collections.Generic;
using System.IO;
namespace Capstone
{
    class LoadInventoryFromFile : ILoadInventory
    {

        private readonly string DEFAULT_LOCATION = Environment.CurrentDirectory;
        private const string DEFAULT_FILENAME = "vendingmachine.csv";
        private string fullyQualifiedPathToFile = "";
        private IWrite writer;
        public bool Error { get; private set; } = true;

        public LoadInventoryFromFile(IWrite writer)
        {
            fullyQualifiedPathToFile = Path.Combine(DEFAULT_LOCATION, DEFAULT_FILENAME);
            this.writer = writer;
        }

        public LoadInventoryFromFile(string pathToFile, IWrite writer)
        {
            fullyQualifiedPathToFile = pathToFile;
            this.writer = writer;
        }

        public Dictionary<string, Item> Load()
        {
            Dictionary<string, Item> output = new Dictionary<string, Item>();

            try
            {
                using (StreamReader sr = new StreamReader(fullyQualifiedPathToFile))
                {
                    while (!sr.EndOfStream)
                    {
                        string line = sr.ReadLine();
                        Item itemToAdd = ParseItem(line);
                        if (itemToAdd != null)
                        {
                            output[ParseId(line)] = itemToAdd;
                        }
                    }
                }
            }
            catch (Exception ex)//why does it keep going after
            {
                writer.Print("--------------------------------------------------");
                writer.Print($"Could not load inventory. Error was: {ex.Message}");
                writer.Print("--------------------------------------------------");
                return output;
            }

            Error = false;
            return output;
        }

        private Item ParseItem(string line, string delimiter = "|")
        {
            Item item = null;

            try
            {     
                string[] parts = line.Split(delimiter);
                string itemType = parts[3].ToLower();
                if (itemType == "gum")
                {
                    item = new Gum(parts[1], decimal.Parse(parts[2]));
                } else
                {
                    writer.Print($"Type {itemType} not found, ignoring line");
                }
            }
            catch (Exception)
            {
                writer.Print($"Could not parse <{line}>, ignoring line");
            }

            return item;
        }

        private string ParseId(string line)
        {
            return line.Substring(0, 2);
        }
    }
}
