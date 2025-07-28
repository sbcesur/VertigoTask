using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

namespace shooterGame.wheelGame
{
    public class BombSelector : MonoBehaviour
    {
        public PrizeController prizeController;
        [SerializeField] private WheelGameData wheelGameData;
        [SerializeField] private Bomb bomb;


        public void CondPutBombOnWheel()
        {
            if (wheelGameData.currentWheel != wheelGameData.goldWheelData && wheelGameData.currentWheel != wheelGameData.silverWheelData)
            {
                if (BombOnWheel())
                {
                    int bombSlotNo = ChooseSlotForBomb();
                    ReplacePrize(bomb, bombSlotNo);

                    print("putting bomb to slot " + bombSlotNo);
                }
            }
        }

        private bool BombOnWheel()
        {
            int rand = UnityEngine.Random.Range(0, wheelGameData.totalZoneCount);

            if(rand < wheelGameData.currentZone)
            {
                return true;
            }

            return false;
        }

        private int ChooseSlotForBomb()
        {
            int rand = UnityEngine.Random.Range(0, wheelGameData.currentWheel.slots.Count);
            return rand;
        }

        private void ReplacePrize(Prize bomb, int slotNo)
        {
            prizeController.PutPrizeOnWheelSlot(bomb, slotNo);
        }


    }
}
