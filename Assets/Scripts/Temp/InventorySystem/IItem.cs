using System.Collections.Generic;

namespace IUP.Toolkits.InventorySystem
{
    public interface IItem
    {
        public string id { get; }

        public bool AddProperty<T>(T propertyValue) where T : Property;

        public bool SetProperty<T>(T propertyValue) where T : Property;

        public bool TryGetProperty<T>(string propertyName, out T propertyValue) where T : Property;

        public void GetProperties(out List<Property> staticProperties, out List<Property> dynamicProperties);
    }
}

