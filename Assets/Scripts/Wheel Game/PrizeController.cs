using shooterGame.wheelGame;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace shooterGame.wheelGame
{
    public class PrizeController : MonoBehaviour
    {
        //temp bool for testing
        public bool randomPrizeSelection = false;

        public WheelGameData wheelGameData;
        public PlayerInventory playerInventory;
        private Stack<Prize> _earnedPrizes = new Stack<Prize>();
        [Space]
        [Header("Scripts")]
        public PrizeInitializer prizeInitializer;
        public PrizeSelectionForWheel prizeSelectionForWheel;
        public BombSelector bombSelector;

        public Stack<Prize> earnedPrizes
        {
            get { return _earnedPrizes; }
        }
        public void PutPrizesOnWheel()
        {
            prizeSelectionForWheel.GetRandomPrizesForWheel(prizeInitializer.raritySortedPrizes);

            for (int i = 0; i < wheelGameData.currentWheel.slots.Count; i++)
            {
                PutPrizeOnWheelSlot(prizeSelectionForWheel.selectedPrizes[i], i);
            }
        }

        public void PutPrizeOnWheelSlot(Prize prize, int slotNo)
        {
            wheelGameData.currentWheel.slots[slotNo].prize = prize;
            wheelGameData.currentWheel.slots[slotNo].slotTransform.GetChild(0).GetComponent<UnityEngine.UI.Image>().sprite = prize.icon;
            wheelGameData.currentWheel.slots[slotNo].slotTransform.GetChild(0).GetComponent<UnityEngine.UI.Image>().preserveAspect = true;
        }

        public int SelectRandomPrizeFromWheel()
        {
            int chosenPrizeIndex = UnityEngine.Random.Range(0, wheelGameData.currentWheel.slots.Count);
            _earnedPrizes.Push(wheelGameData.currentWheel.slots[chosenPrizeIndex].prize);

            print("earned prize is " + _earnedPrizes.Peek().name);
            return chosenPrizeIndex;
        }

        public void AddEarnedPrizesToInventory()
        {
            if (_earnedPrizes.Count != 0)
            {


                Debug.Log("earned : " + _earnedPrizes.Pop().name);
                


                //below code is the logic to add items to player inventory
                //which requires creating scriptable item objects from assset menu
                /*Item earnedItem = _earnedPrizes.Pop().prizeItem;

                if (earnedItem != null)
                {
                    earnedItem.AddToInventory(playerInventory);
                }
                else
                {
                    //print error
                }
                */
            }
        }


    }
}
