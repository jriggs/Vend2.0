using System.Collections.Generic;

namespace Capstone
{
    interface ILoadInventory
    {
        Dictionary<string, Item> Load();
        bool Error { get; }
    }
}