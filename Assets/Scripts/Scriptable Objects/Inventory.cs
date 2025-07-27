using shooterGame;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace shooterGame
{
    public class Inventory : ScriptableObject
    {
        [SerializeField] protected int WeaponItemSlots;

        [SerializeField] protected List<WeaponItem> weapons;
        protected Currency coins;
        protected Currency money;

        public virtual void AddWeaponToInventory(WeaponItem weapon)
        {

        }
    }
}
