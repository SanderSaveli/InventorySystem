using System;
using System.Collections.Generic;
using UnityEngine;

namespace IUP.Toolkits.InventorySystem
{
    [Serializable]
    public class Item : IItem
    {
        [SerializeField] public string id { get; private set; }
        [SerializeField] private List<Property> _staticProperties = new();
        [SerializeField] private List<Property> _dynamicProperties = new();

        public Item(
            string id,
            List<Property> staticProperties = null,
            List<Property> dynamicProperties = null)
        {
            this.id = id;
            if (staticProperties != null) this._staticProperties = staticProperties;
            if (dynamicProperties != null) this._dynamicProperties = dynamicProperties;
        }

        public bool AddProperty<T>(T propertyValue) where T : Property
        {
            if (TryGetProperty(propertyValue.name, out T value))
            {
                //throw new NotImplementedException($"Item {this} alredy has property {value}"); //TODO
                return false;
            }
            _dynamicProperties.Add(propertyValue);
            return true;
        }

        public bool SetProperty<T>(T propertyValue) where T : Property
        {
            if (TryGetProperty(propertyValue.name, out T value))
            {
                value.TrySet(propertyValue);
                return true;
            }
            return false;
        }

        public bool TryGetProperty<T>(string propertyName, out T propertyValue) where T : Property
        {
            List<Property> allProperties = new();
            allProperties.AddRange(_dynamicProperties);
            allProperties.AddRange(_staticProperties);

            if (TryFindProperty(allProperties, propertyName, out propertyValue))
            {
                return true;
            }
            return false;
        }

        public void GetProperties(
    out List<Property> staticProperties,
    out List<Property> dynamicProperties)
        {
            staticProperties = this._staticProperties;
            dynamicProperties = this._dynamicProperties;
        }

        private bool TryFindProperty<T>(
            List<Property> properties,
            string propertyName,
            out T propertyValue) where T : Property
        {
            foreach (var property in properties)
            {
                Type propertyType = property.GetType();
                if (propertyType == typeof(T) && property.name == propertyName)
                {
                    propertyValue = (T)property;
                    return true;
                }
            }
            propertyValue = null;
            return false;
        }
    }
}

