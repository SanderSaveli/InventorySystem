using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using UnityEngine;

namespace IUP.Toolkits.InventorySystem
{
    [Serializable]
    public class Item : IItem
    {
        [field: SerializeField] public string ID { get; private set; }

        public IReadOnlyCollection<IProperty> staticProperties =>
            new ReadOnlyCollection<IProperty>(_staticProperties.Values.ToList());
        public IReadOnlyCollection<IProperty> dynamicProperties =>
            new ReadOnlyCollection<IProperty>(_dynamicProperties.Values.ToList());

        [SerializeField] private readonly Dictionary<string, IProperty> _staticProperties;
        [SerializeField] private Dictionary<string, IProperty> _dynamicProperties = new();

        public Item(
            string ID,
            ItemAtlas itemAtlas,
            Dictionary<string, IProperty> dynamicProperties = default)
        {
            if(ID == null) 
                throw new ArgumentNullException("ID cannot be null");
            this.ID = ID;
            dynamicProperties ??= new();
            _staticProperties = itemAtlas.GetItem(ID).staticProperties;
            _dynamicProperties = dynamicProperties;
        }

        public bool AddProperty<T>(string propertyName, T propertyValue)
        {
            if (_dynamicProperties.ContainsKey(propertyName) || _staticProperties.ContainsKey(propertyName))
            {
                throw new NotImplementedException($"Item {this} alredy has property {propertyName}"); //TODO
            }
            _dynamicProperties.Add(propertyName, CreateProperty(propertyName, propertyValue));
            return true;
        }

        public bool SetProperty<T>(string propertyName, T propertyValue)
        {
            if (_dynamicProperties.ContainsKey(propertyName)) 
            {
                _dynamicProperties[propertyName] = CreateProperty(propertyName, propertyValue);
                return true;
            }
            return false;
        }

        public bool TryGetProperty<T>(string propertyName, out T propertyValue)
        {
            IProperty value;
            if (_dynamicProperties.TryGetValue(propertyName, out value) || 
                _staticProperties.TryGetValue(propertyName,out value))
            {
                Type valueType = typeof(T);
                if (valueType == typeof(string)) 
                {
                    propertyValue = value.GetValue<T>();
                    return true;
                }
                if (valueType == typeof(int)) 
                {
                    propertyValue = value.GetValue<T>();
                    return true;
                }
            }
            propertyValue = default;
            return false;
        }

        private IProperty CreateProperty<T>(string name, T value)
        {
            Type valueType = value.GetType();
            if (valueType == typeof(string))
                return new StringProperty(name, value as string);
            if (valueType == typeof(int))
                return new IntProperty(name, Convert.ToInt32(value));
            throw new NotImplementedException("Value type is not one of the allowed types for properties.");
        }
    }
}

