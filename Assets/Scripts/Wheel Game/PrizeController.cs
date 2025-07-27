using shooterGame.wheelGame;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrizeController : MonoBehaviour
{
    //temp bool for testing
    public bool test = false;

    public WheelGameData wheelGameData;
    private Prize[] allPrizes;
    private Stack<Prize> earnedPrizes;
    private Dictionary<prizeRarities, List<Prize>> raritySortedPrizes = new Dictionary<prizeRarities, List<Prize>>();

    private void Start()
    {
        //initialize prize data
        allPrizes = wheelGameData.allPrizes;
        earnedPrizes = new Stack<Prize>();

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

    public void PutPrizesOnWheel()
    {
        GetRandomPrizesForWheel();
    }

    public Prize SelectRandomPrizeFromWheel()
    {
        int chosenPrizeIndex = UnityEngine.Random.Range(0, wheelGameData.currentWheel.slots.Count);
        earnedPrizes.Push(wheelGameData.currentWheel.slots[chosenPrizeIndex].prize);

        print("earned prize is " + earnedPrizes.Peek().name);
        return earnedPrizes.Peek();
    }

    private void GetRandomPrizesForWheel()
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


    //helper script
    float GetGaussian(float mean, float stdDev)
    {
        float u1 = UnityEngine.Random.value;
        float u2 = UnityEngine.Random.value;

        float randStdNormal = Mathf.Sqrt(-2.0f * Mathf.Log(u1)) *
                              Mathf.Sin(2.0f * Mathf.PI * u2);

        return mean + stdDev * randStdNormal;
    }

    private void Update()
    {
        if(test)
        {
            
        }
    }
}
