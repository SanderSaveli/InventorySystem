using System;
using System.Collections.Generic;

namespace IUP.Toolkits.InventorySystem
{
    public class ItemAtlas
    {
        private Dictionary<string, ItemDefenition> _items;

        public ItemAtlas(Dictionary<string, ItemDefenition> items)
        {
            _items = items;
        }

        public ItemDefenition GetItem(string ID)
        {
            if (_items.TryGetValue(ID, out ItemDefenition defenition))
            {
                return defenition;
            }
            throw new NotImplementedException($"By ID {ID} does not contain an item");
        }
    }

}
