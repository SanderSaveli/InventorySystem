using System;

namespace IUP.Toolkits.InventorySystem
{
    [Serializable]
    public class StringProperty : Property
    {
        public string value { get; private set; }

        public StringProperty(string name, string str) : base(name, typeof(StringProperty))
        {
            this.value = str; 
        }

        public override bool TrySet(IProperty value)
        {
            if(
                value.propertyType == typeof(StringProperty) 
                && value.name == name) 
            {
                StringProperty referenseStr = (StringProperty)value;
                this.value = referenseStr.value;
                return true;
            }
            return false;
        }

        public override T GetValue<T>()
        {
            return (T)(object)value;
        }
    }
}


