namespace IUP.Toolkits.InventorySystem
{
    public class IntProperty : Property
    {
        public int value { get; private set; }
        public IntProperty(string name, int value) : base(name, typeof(IntProperty))
        {
            this.value = value;
        }

        public override bool TrySet(IProperty value)
        {
            if (
    value.propertyType == typeof(StringProperty)
    && value.name == name)
            {
                IntProperty referenseStr = (IntProperty)value;
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
