using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace shooterGame
{
    [CreateAssetMenu(menuName = "shooter game/item/weapon")]
    public class Weapon : Item
    {
        [SerializeField] private float damage;

        public override void AddToInventory()
        {
            Debug.Log("Added " + this.itemName + "to inventory.");
        }

        public void DropWeapon()
        {

        }
    }
}
