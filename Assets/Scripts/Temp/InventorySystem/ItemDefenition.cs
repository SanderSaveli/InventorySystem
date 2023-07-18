using IUP.Toolkits.InventorySystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace IUP.Toolkits.InventorySystem 
{
    public class ItemDefenition
    {
        public Dictionary<string, IProperty> staticProperties { get; private set; }

        public ItemDefenition(Dictionary<string, IProperty> staticProperties)
        {
            this.staticProperties = staticProperties;
        }
    }
}

