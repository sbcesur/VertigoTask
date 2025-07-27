using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

namespace shooterGame.wheelGame
{
    [CreateAssetMenu(menuName ="shooter game/wheel game/wheel")]
    public class WheelData : ScriptableObject
    {
        public List<WheelSlot> slots;
        [SerializeField] private GameObject _wheelPrefab;
        [SerializeField] private GameObject _wheelSlotsParent;

        public GameObject wheelPrefab
        {
            get { return _wheelPrefab; }
        }    

        public GameObject wheelSlotsParent
        {
            get { return _wheelSlotsParent; }
        }


        public int GetChildIndexToRotate()
        {
            for (int i = 0; i < _wheelPrefab.transform.childCount; i++)
            { 
                if(_wheelPrefab.transform.GetChild(i).name == _wheelSlotsParent.name)
                {
                    return i;
                }
            }

            return -1;
        }
    }
}
