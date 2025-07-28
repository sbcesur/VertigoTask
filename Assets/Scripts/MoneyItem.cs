using shooterGame;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace shooterGame
{
    public class MoneyItem : Item
    {
        public int amount;

        public override void AddToInventory(Inventory inventory)
        {
            inventory.AddMoneyToInventory(amount);
        }
    }
}
