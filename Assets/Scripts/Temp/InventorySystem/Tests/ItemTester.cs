using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine;

namespace IUP.Toolkits.InventorySystem
{
    public class ItemTester : MonoBehaviour
    {
        private IItem _testedItem;
        private ItemAtlas _itemAtlas;
        void Start()
        {
            _itemAtlas = CreateItemAtlas();
            IntProperty damage = new IntProperty("damage", 20);
            Dictionary<string, IProperty> dynamicProp = new();
            dynamicProp.Add("damage", damage);
            _testedItem = new LogItem("1", _itemAtlas, dynamicProp);
            StartCoroutine(Test());
        }

        IEnumerator Test()
        {
            yield return new WaitForSeconds(2);
            _testedItem.AddProperty("ammo", 100);
            _testedItem.SetProperty("ammo", 120);
            ReadOnlyCollection<IProperty> properties = (ReadOnlyCollection<IProperty>)_testedItem.dynamicProperties;
            properties = (ReadOnlyCollection<IProperty>)_testedItem.staticProperties;
            _testedItem.TryGetProperty("tag", out string tag);
            try 
            {
                _testedItem.AddProperty("ammo", 200);
            }
            catch (NotImplementedException exc) 
            {
                Debug.Log(exc.Message);
            }
            Debug.Log("Test completed");
        }

        private ItemAtlas CreateItemAtlas() 
        {
            Dictionary<string, ItemDefenition> pairs = new();
            pairs.Add("1", CreateRifleItemDefenition());
            pairs.Add("2", CreateShotgunItemDefenition());
            return new ItemAtlas(pairs);
        }

        private ItemDefenition CreateRifleItemDefenition() 
        {
            Dictionary<string, IProperty> itemProperties = new();
            itemProperties.Add("name", new StringProperty("name", "rifle"));
            itemProperties.Add("tag", new StringProperty("tag", "gun"));
            return new ItemDefenition(itemProperties);
        }

        private ItemDefenition CreateShotgunItemDefenition()
        {
            Dictionary<string, IProperty> itemProperties = new();
            itemProperties.Add("Name", new StringProperty("Name", "shotgun"));
            itemProperties.Add("Tag", new StringProperty("Tag", "gun"));
            return new ItemDefenition(itemProperties);
        }
    }

}
