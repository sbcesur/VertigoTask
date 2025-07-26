using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace shooterGame.wheelGame
{
    [CreateAssetMenu(menuName ="shooter game/wheel game/wheel")]
    public class WheelData : ScriptableObject
    {
        public List<WheelSlot> slots;
        [SerializeField] private GameObject _wheelPrefab;

        public GameObject wheelPrefab
        {
            get { return _wheelPrefab; }
        }    

    }
}
