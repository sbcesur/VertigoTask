using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace shooterGame.wheelGame
{
    public class Prize : ScriptableObject
    {
        [SerializeField] string prizeName;
        [SerializeField] protected prizeRarities prizeRarity;
        [SerializeField] private Texture2D icon;


        public void AddPrize()
        {

        }
    }
}