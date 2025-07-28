using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace shooterGame
{
    public abstract class Item : ScriptableObject
    {
        [SerializeField] protected string _itemName;
        [SerializeField] private GameObject prefab;

        public string itemName
        {
            get { return _itemName; }
        }

        public abstract void AddToInventory(Inventory inventory);
            
    }
}