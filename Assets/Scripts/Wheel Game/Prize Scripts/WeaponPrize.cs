using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace shooterGame.wheelGame
{
    [CreateAssetMenu(menuName = "shooter game/wheel game/prizes/weapon")]
    public class WeaponPrize : Prize
    {
        public Weapon prizeWeapon;

        public void AddPrizeToInventory()
        {
            prizeWeapon.AddToInventory();
        }
    }
}
