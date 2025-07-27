using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace shooterGame.wheelGame
{
    public class Prize : ScriptableObject
    {
        [SerializeField] string prizeName;
        [SerializeField] private prizeRarities _prizeRarity;
        [SerializeField] private Sprite _icon;
        [SerializeField] private bool _endsGame = false;
        public int occupiedSlotIndex;

        public prizeRarities prizeRarity
        {
            get { return _prizeRarity; }
        }

        public bool endsGame
        {
            get { return _endsGame; }
        }

        public Sprite icon
        {
            get { return _icon; }
        }

        public void AddPrize()
        {

        }
    }
}