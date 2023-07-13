using System.Collections.Generic;
using UnityEngine;
namespace IUP.Toolkits.InventorySystem
{
    public class LogItem : IItem
    {
        private Item item;

        public LogItem(string id,
            List<Property> staticProperties = null,
            List<Property> dynamicProperties = null)
        {
            item = new Item(id, staticProperties, dynamicProperties);
            Debug.Log($"Item {this} Ini, Property on ini: ");
            GetProperties(out staticProperties, out dynamicProperties);
        }
        public string id => throw new System.NotImplementedException();

        public bool AddProperty<T>(T propertyValue) where T : Property
        {
            if (item.AddProperty(propertyValue)) 
            {
                Debug.Log($"Property {propertyValue.name} added");
                return true;
            }
            Debug.LogWarning($"Property {propertyValue.name} not added");
            return false;
        }

        public void GetProperties(out List<Property> staticProperties, out List<Property> dynamicProperties)
        {
            item.GetProperties(out staticProperties, out dynamicProperties);
            string statProp = "";
            foreach(Property property in staticProperties) 
            {
                statProp += property.name + ", ";
            }
            Debug.Log("Static properties: "+ statProp);
            string DynProp = "";
            foreach (Property property in dynamicProperties)
            {
                DynProp += property.name + ", ";
            }
            Debug.Log("Dynamic properties: " + DynProp);
        }

        public bool SetProperty<T>(T propertyValue) where T : Property
        {
            if (item.SetProperty(propertyValue))
            {
                Debug.Log($"Property {propertyValue.name} setted");
                return true;
            }
            Debug.LogWarning($"Property {propertyValue.name} not settes");
            return false;
        }

        public bool TryGetProperty<T>(string propertyName, out T propertyValue) where T : Property
        {
            if(item.TryGetProperty(propertyName, out propertyValue)) 
            {
                Debug.Log($"Property {propertyValue.name} is on Item");
                return true;
            }
            Debug.LogWarning($"Property {propertyValue.name} is not on Item");
            return false;
        }
    }
}

