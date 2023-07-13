using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace IUP.Toolkits.InventorySystem
{
    public class ItemTester : MonoBehaviour
    {
        private IItem _testedItem;
        void Start()
        {
            StringProperty tag = new StringProperty("tag", "Gun");
            IntProperty damage = new IntProperty("damage", 20);
            List<Property> staticProp = new();
            List<Property> dynamicProp = new();
            staticProp.Add(tag);
            dynamicProp.Add(damage);
            _testedItem = new LogItem("007", staticProp, dynamicProp);
            StartCoroutine(Test());
        }

        IEnumerator Test()
        {
            yield return new WaitForSeconds(2);
            IntProperty ammo = new IntProperty("ammo", 100);
            _testedItem.AddProperty(ammo);
            IntProperty bonusAmmo = new IntProperty("ammo", 120);
            _testedItem.SetProperty(bonusAmmo);
            List<Property> staticProp = new();
            List<Property> dynamicProp = new();
            _testedItem.GetProperties(out staticProp, out dynamicProp);

            StringProperty tag;
            _testedItem.TryGetProperty("tag", out tag);
            _testedItem.AddProperty(ammo);
        }

    }

}
