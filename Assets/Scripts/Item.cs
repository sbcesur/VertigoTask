using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace shooterGame
{
    public abstract class Item : ScriptableObject
    {
        [SerializeField] protected string itemName;
        [SerializeField] private GameObject prefab;

        public abstract void AddToInventory();
    }
}