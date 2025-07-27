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
        [SerializeField] private string _slotParentTag;

        public GameObject wheelPrefab
        {
            get { return _wheelPrefab; }
        }

        public string slotParentTag
        {
            get { return _slotParentTag; }  
        }

        public Transform FindChildWithTag(Transform parent, string tag)
        {
            if (parent.CompareTag(tag))
                return parent;

            foreach (Transform child in parent)
            {
                Transform result = FindChildWithTag(child, tag);
                if (result != null)
                    return result;
            }

            return null;
        }
    }
}
