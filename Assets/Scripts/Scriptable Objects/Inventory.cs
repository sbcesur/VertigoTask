using shooterGame;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace shooterGame
{
    public abstract class Inventory : ScriptableObject
    {
        [SerializeField] protected int WeaponItemSlots;

        [SerializeField] protected List<WeaponItem> weapons;
        protected CoinItem coins;
        protected MoneyItem money;

        public abstract void AddWeaponToInventory(WeaponItem weapon);
        public abstract void AddCoinToInventory(int amount);
        public abstract void AddMoneyToInventory(int amount);

    }
}
