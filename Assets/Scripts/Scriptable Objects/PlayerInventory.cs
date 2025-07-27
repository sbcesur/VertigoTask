using shooterGame;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

namespace shooterGame
{
    [CreateAssetMenu(menuName = "shooter game/player inventory")]
    public class PlayerInventory : Inventory
    {
        //player exclusive data
        public override void AddWeaponToInventory(WeaponItem weapon)
        {
            weapons.Add(weapon);
        }

        public void AddCoinToInventory(int addedAmount)
        {
            coins.amount += addedAmount;
        }

        public void ShowInventory()
        {
            for (int i = 0; i < weapons.Count; i++)
            {
                Debug.Log(i + " : " + weapons[i].itemName);
            }
            Debug.Log("coin = ", coins);
        }
    }
}
