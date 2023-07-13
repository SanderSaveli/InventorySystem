using System;

namespace IUP.Toolkits.InventorySystem
{
    [Serializable]
    public abstract class Property : IProperty
    {
        public string name { get; private set; }

        public Type propertyType { get; protected set; }

        public abstract bool TrySet(IProperty value);

        public Property(string name, Type propertyType)   
        {
            this.name = name;
            this.propertyType = propertyType;
        }
    }
}

