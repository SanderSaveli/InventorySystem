using System.Collections.Generic;

namespace IUP.Toolkits.InventorySystem
{
    public interface IItem
    {
        public string ID { get; }

        public IReadOnlyCollection<IProperty> staticProperties { get; }

        public IReadOnlyCollection<IProperty> dynamicProperties { get; }

        public bool AddProperty<T>(string propertyName, T propertyValue);

        public bool SetProperty<T>(string propertyName, T propertyValue);

        public bool TryGetProperty<T>(string propertyName, out T propertyValue);
    }
}

