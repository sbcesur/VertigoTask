using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;


namespace shooterGame.wheelGame
{
    public class WheelGameController : MonoBehaviour
    {
        public WheelGameData wheelGameData;
        

        private GameObject wheel;
        private int chosenPrizeIndex;

        private bool wheelIsSpinning = false;

        public Action succes;
        public Action fail;
        public Action spinEnded;
        public Action updateZoneNoText;

        [Space]
        [Header("Scripts")]
        public WheelSpawner wheelSpawner;
        public PrizeController prizeController;


        private Dictionary<prizeRarities, List<Prize>> raritySortedPrizes = new Dictionary<prizeRarities, List<Prize>>();

        //wheel game entry point
        public void StartWheelGame(int startZone)
        {
            prizeController.prizeInitializer.InitializePrizes();
            wheelGameData.currentZone = startZone;
            wheel = wheelSpawner.SpawnWheel();
            prizeController.PutPrizesOnWheel();
            updateZoneNoText?.Invoke();
        }

        public void LoadNextZone()
        {
            wheelGameData.currentZone++;
            wheel = wheelSpawner.SpawnWheel();
            prizeController.PutPrizesOnWheel();
            prizeController.bombSelector.CondPutBombOnWheel();
            updateZoneNoText?.Invoke();
        }

        public void SpinWheel()
        {
            int chosenPrizeIndex = prizeController.SelectRandomPrizeFromWheel();

            if (!wheelIsSpinning)
            {
                wheelIsSpinning = true;

                float targetAngle = chosenPrizeIndex * (360.0f / (float)wheelGameData.currentWheel.slots.Count);
                int revolutionCount = 3;

                print("earned prize index = " + chosenPrizeIndex);

                Transform objectToRotate = wheelGameData.currentWheel.FindChildWithTag(wheel.transform, wheelGameData.currentWheel.slotParentTag);
                objectToRotate.DORotate(new Vector3(0, 0, revolutionCount * 360.0f + targetAngle ), 3f, RotateMode.LocalAxisAdd)
                     .SetEase(Ease.OutCubic)
                     .OnComplete(WheelSpinEnded);
            }
        }

        void WheelSpinEnded()
        {
            wheel.SetActive(false);
            wheelIsSpinning = false;

            if (!prizeController.earnedPrizes.Peek().endsGame)
            {
                succes?.Invoke();
            }
            else
            {
                fail?.Invoke();
            }
        }

        public void DropPrizes()
        {
            prizeController.earnedPrizes.Clear();
            print(prizeController.earnedPrizes.Count);
        }

        public void ExitWheelGame()
        {
            prizeController.AddEarnedPrizesToInventory();
            GameManager.Instance.ExitWheelGame();
        }
    }
}
