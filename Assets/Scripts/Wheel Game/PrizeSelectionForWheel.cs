using shooterGame.wheelGame;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace shooterGame.wheelGame
{
    public class PrizeSelectionForWheel : MonoBehaviour
    {
        [SerializeField] private WheelGameData wheelGameData;
        public void GetRandomPrizesForWheel(Dictionary<prizeRarities, List<Prize>> raritySortedPrizes)
        {
            for (int i = 0; i < wheelGameData.currentWheel.slots.Count; i++)
            {
                prizeRarities rarity = GetPrizeRarityFromZoneNo();
                List<Prize> prizesToSelectFrom = raritySortedPrizes[rarity];
                int prizeIndex = UnityEngine.Random.Range(0, prizesToSelectFrom.Count);
                Prize selectedPrize = prizesToSelectFrom[prizeIndex];
                wheelGameData.currentWheel.slots[i].prize = selectedPrize;
                wheelGameData.currentWheel.slots[i].slotTransform.GetChild(0).GetComponent<UnityEngine.UI.Image>().sprite = selectedPrize.icon;
                wheelGameData.currentWheel.slots[i].slotTransform.GetChild(0).GetComponent<UnityEngine.UI.Image>().preserveAspect = true;
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