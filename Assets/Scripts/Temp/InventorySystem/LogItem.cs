using System.Collections.Generic;
using UnityEngine;
namespace IUP.Toolkits.InventorySystem
{
    public class LogItem : IItem
    {
        private Item item;

        public LogItem(string ID,
            ItemAtlas itemAtlas,
            Dictionary<string, IProperty> dynamicProperties = null)
        {
            item = new Item(ID, itemAtlas, dynamicProperties);
            Debug.Log($"Item {this} Ini, Property on ini: ");
        }
        public string ID => item.ID;

        public IReadOnlyCollection<IProperty> staticProperties { get
            {
                Debug.Log("Static properties: ");
                return LogProperty(item.staticProperties);
            } } 

        public IReadOnlyCollection<IProperty> dynamicProperties
        {
            get
            {
                Debug.Log("Dynamic properties: ");
                return LogProperty(item.dynamicProperties);
            }
        }


        public bool AddProperty<T>(string propertyName, T propertyValue)
        {
            if (item.AddProperty(propertyName, propertyValue))
            {
                Debug.Log($"Property {propertyName} added");
                return true;
            }
            Debug.LogWarning($"Property {propertyName} not added");
            return false;
        }

        public bool SetProperty<T>(string propertyName, T propertyValue)
        {
            if (item.SetProperty(propertyName, propertyValue))
            {
                Debug.Log($"Property {propertyName} setted");
                return true;
            }
            Debug.LogWarning($"Property {propertyName} not settes");
            return false;
        }

        public bool TryGetProperty<T>(string propertyName, out T propertyValue)
        {
            if(item.TryGetProperty(propertyName, out propertyValue)) 
            {
                Debug.Log($"Property {propertyName} is on Item");
                return true;
            }
            Debug.LogWarning($"Property {propertyName} is not on Item");
            return false;
        }

        private IReadOnlyCollection<IProperty> LogProperty(IReadOnlyCollection<IProperty> properties) 
        {
            string prop = "";
            foreach (Property property in properties)
            {
                prop += property.name + ", ";
            }
            Debug.Log(prop);
            return properties;
        }
    }
}

