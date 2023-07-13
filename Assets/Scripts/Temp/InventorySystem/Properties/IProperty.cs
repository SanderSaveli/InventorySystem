using System;

namespace IUP.Toolkits.InventorySystem 
{
    public interface IProperty
    {
        public string name { get; }

        public Type propertyType { get; }

        public bool TrySet(IProperty value);
    }
}
