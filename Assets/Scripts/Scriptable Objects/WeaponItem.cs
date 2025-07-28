using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace shooterGame
{
    [CreateAssetMenu(menuName = "shooter game/item/weapon")]
    public class WeaponItem : Item
    {
        [SerializeField] private float damage;

        public override void AddToInventory(Inventory inventory)
        {
            inventory.AddWeaponToInventory(this);
        }
    }
}
