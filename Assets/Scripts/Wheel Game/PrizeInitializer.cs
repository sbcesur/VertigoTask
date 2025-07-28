using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace shooterGame.wheelGame
{
    public class PrizeInitializer : MonoBehaviour 
    {
        private Prize[] _allPrizes;
        [SerializeField] private WheelGameData _wheelGameData;
        private Dictionary<prizeRarities, List<Prize>> _raritySortedPrizes = new Dictionary<prizeRarities, List<Prize>>();
        private bool Initialized;

        private void Start()
        {
            Initialized = false;
        }

        public Dictionary<prizeRarities, List<Prize>> raritySortedPrizes
        {
            get { return _raritySortedPrizes; }
        }

        public void InitializePrizes()
        {

            if (!Initialized)
            {
                Initialized = true;

                print("initializing przes");
                //initialize prize data
                _allPrizes = _wheelGameData.allPrizes;

                prizeRarities[] rarityTypes = (prizeRarities[])System.Enum.GetValues(typeof(prizeRarities));

                for (int i = 0; i < rarityTypes.Length; i++)
                {
                    _raritySortedPrizes.Add(rarityTypes[i], new List<Prize>());
                }

                for (int i = 0; i < _allPrizes.Length; i++)
                {
                    //put prizes to dictionary accoring to their rarities
                    Prize prize = _allPrizes[i];

                    if (_raritySortedPrizes.ContainsKey(prize.prizeRarity))
                    {
                        _raritySortedPrizes[prize.prizeRarity].Add(prize);
                    }
                    else
                    {
                        Debug.Log("Error " + prize.prizeRarity + " not found in the dictionary");
                    }
                }
            }
        }
    }
}
