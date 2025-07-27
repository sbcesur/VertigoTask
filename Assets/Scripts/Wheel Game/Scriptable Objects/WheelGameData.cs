using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace shooterGame.wheelGame
{
    [CreateAssetMenu(menuName = "shooter game/wheel game/game data")]
    public class WheelGameData : ScriptableObject
    {
        [SerializeField] private Prize[] _allPrizes;
        [SerializeField] private WheelData _bronzeWheel;
        [SerializeField] private WheelData _goldWheel;
        [SerializeField] private WheelData _silverWheel;
        [SerializeField] private int _safeZone = 5;
        [SerializeField] private int _superZone = 30;
        [SerializeField] private int _totalZoneCount = 120; 

        public int currentZone = 0;
        [HideInInspector] public WheelData currentWheel;
       

        public Prize[] allPrizes
        {
            get { return _allPrizes; }
        }

        public int safeZone
        {
            get { return _safeZone; }  
        }

        public int superZone
        {
            get { return _superZone; }
        }

        public WheelData bronzeWheelData
        {
            get { return _bronzeWheel; }
        }

        public WheelData silverWheelData
        {
            get { return _silverWheel; }
        }
        public WheelData goldWheelData
        {
            get { return _goldWheel; }
        }

        public int totalZoneCount
        {
            get { return _totalZoneCount; }
        }

    }
}