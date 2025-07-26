using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


namespace shooterGame.wheelGame
{
    public class WheelGameController : MonoBehaviour
    {
        public WheelGameData wheelGameData;
        public Transform Canvas;

        private Prize[] allPrizes;
        private GameObject wheel;
        private Stack<Prize> earnedPrizes;

        bool wheelIsSpinning = false;

        private bool isSuperZone() => wheelGameData.currentZone % wheelGameData.superZone == 0;
        private bool isSafeZone() => wheelGameData.currentZone % wheelGameData.safeZone == 0;

        private Dictionary<prizeRarities, List<Prize>> raritySortedPrizes = new Dictionary<prizeRarities, List<Prize>>();

        // Start is called before the first frame update
        void Start()
        {
            allPrizes = wheelGameData.allPrizes;
            prizeRarities[] rarityTypes = (prizeRarities[])System.Enum.GetValues(typeof(prizeRarities));

            for (int i = 0; i < rarityTypes.Length; i++)
            {
                raritySortedPrizes.Add(rarityTypes[i], new List<Prize>());
            }

            for (int i = 0; i < allPrizes.Length; i++)
            {
                //put prizes to dictionary accoring to their rarities
                Prize prize = allPrizes[i];

                if (raritySortedPrizes.ContainsKey(prize.prizeRarity))
                {
                    raritySortedPrizes[prize.prizeRarity].Add(prize);
                }
                else
                {
                    Debug.Log("Error " + prize.prizeRarity + " not found in the dictionary");
                }
            }
        }



        //wheel game entry point
        public void StartWheelGame(int startZone)
        {
            wheelGameData.currentZone = startZone;
            GetWheelDataForZone();
            InstantiateCurrentWheel();
            GetWheelSlots();
            GetRandomPrizesForWheel();

            //LoadNextZone();
        }

        private void LoadNextZone()
        {

        }

        private void GetWheelDataForZone()
        {
            if (isSuperZone())
            {
                wheelGameData.currentWheel =  wheelGameData.goldWheelData;
                return;
            }

            if (isSafeZone())
            {
                wheelGameData.currentWheel =  wheelGameData.silverWheelData;
                return;
            }

            wheelGameData.currentWheel = wheelGameData.bronzeWheelData;
            return;
        }

        private void InstantiateCurrentWheel()
        {
            if (wheel != null)
            {
                Destroy(wheel);
            }
            
            //instantiate current wheel
            wheel = Instantiate(wheelGameData.currentWheel.wheelPrefab, Canvas);
            print("current zone no = " + wheelGameData.currentZone);
        }

        private void GetWheelSlots()
        {
            for (int i = 0; i < wheelGameData.currentWheel.slots.Count; i++)
            {
                wheelGameData.currentWheel.slots[i].slotTransform = wheel.transform.GetChild(0).GetChild(i);
            }

            /*
            for (int i = 0; i < wheelGameData.currentWheel.slots.Count; i++)
            {
                print(wheelGameData.currentWheel.slots[i].slot.name);
            }
            */
        }
        private void GetRandomPrizesForWheel()
        {
            for (int i = 0; i < wheelGameData.currentWheel.slots.Count; i++)
            {
                prizeRarities rarity = GetPrizeRarityFromZoneNo();
                List<Prize> prizesToSelectFrom =  raritySortedPrizes[rarity];
                int prizeIndex = UnityEngine.Random.Range(0, prizesToSelectFrom.Count);
                Prize selectedPrize = prizesToSelectFrom[prizeIndex];
                wheelGameData.currentWheel.slots[i].prize = selectedPrize;
                wheelGameData.currentWheel.slots[i].slotTransform.GetChild(0).GetComponent<UnityEngine.UI.Image>().sprite = selectedPrize.icon;
                print("i = " + i);
            }
        }

        private prizeRarities GetPrizeRarityFromZoneNo()
        {
            float normalizedZoneNo = (float)wheelGameData.currentZone / (float)wheelGameData.totalZoneCount;
            prizeRarities[] rarities = (prizeRarities[])System.Enum.GetValues(typeof(prizeRarities));
            int rarityTypeNo = rarities.Length - 1;
            float standartDeviation = 0.75f;
            float mean = normalizedZoneNo * (float)rarityTypeNo;

            float rawIndex = GetGaussian(mean, standartDeviation);
            int rarityIndex = Mathf.Clamp(Mathf.RoundToInt(rawIndex), 0, rarityTypeNo);

            //print(normalizedZoneNo);

            return rarities[rarityIndex];
        }

        private void SetPrizeIconsOnWheel()
        {

        }

        private void ShowSpinButton()
        {

        }


        public void SpinWheel()
        {
            if (!wheelIsSpinning)
            {
                wheelIsSpinning = true;
                print("spinning wheel");
                wheel.transform.DORotate(new Vector3(0, 0, -1080), 3f, RotateMode.FastBeyond360)
                     .SetEase(Ease.OutCubic)
                     .OnComplete(WheelSpinEnded);
            }
        }

        private void WheelSpinEnded()
        {
            wheelIsSpinning = false;
            ChooseRandomPrizeFromWheel();
            ShowChosenPrize();

            if(earnedPrizes.Peek().endsGame)
            {
                //bomb exploded
            }
            else
            {
                //next level or leave game
            }
        }

        private void ChooseRandomPrizeFromWheel()
        {
            int chossenPrizeIndex = Random.Range(0, wheelGameData.currentWheel.slots.Count);
            earnedPrizes.Push(wheelGameData.currentWheel.slots[chossenPrizeIndex].prize);
        }

        private void ShowChosenPrize()
        {

        }



        bool testStarted = false;

        
        /*
        void Update()
        {
            if (!testStarted && Input.GetMouseButtonDown(0) == true)
            {
                print("test started");
                //testStarted = true;
                //testGetRandomPrizeFromZoneNo();
                
            }
        }
        */
       
        void testGetRandomPrizeFromZoneNo()
        {
            while (wheelGameData.currentZone < wheelGameData.totalZoneCount)
            {
                prizeRarities result = GetPrizeRarityFromZoneNo();
                print("zone: " + wheelGameData.currentZone + "\trarity: " + result);
                wheelGameData.currentZone++;
            }
        }

        float GetGaussian(float mean, float stdDev)
        {
            float u1 = UnityEngine.Random.value;
            float u2 = UnityEngine.Random.value;

            float randStdNormal = Mathf.Sqrt(-2.0f * Mathf.Log(u1)) *
                                  Mathf.Sin(2.0f * Mathf.PI * u2);

            return mean + stdDev * randStdNormal;
        }

    }
}
