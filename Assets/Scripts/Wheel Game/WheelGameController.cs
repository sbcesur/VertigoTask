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

        [Space]
        [Header("Scripts")]
        public WheelSpawner wheelSpawner;
        public PrizeController prizeController;


        private Dictionary<prizeRarities, List<Prize>> raritySortedPrizes = new Dictionary<prizeRarities, List<Prize>>();

        //wheel game entry point
        public void StartWheelGame(int startZone)
        {
            wheelGameData.currentZone = startZone;
            wheelSpawner.SpawnWheel();
            prizeController.PutPrizesOnWheel();
        }

        public void LoadNextZone()
        {
            wheelGameData.currentZone++;

        }

        public void SpinWheel()
        {

            if (!wheelIsSpinning)
            {
                wheelIsSpinning = true;

                float targetAngle = chosenPrizeIndex * (360.0f / (float)wheelGameData.currentWheel.slots.Count);
                int revolutionCount = 3;

                print("target angle = " + targetAngle);
                print("earned prize index = " + chosenPrizeIndex);

                print("spinning wheel");
                wheel.transform.GetChild(0).DORotate(new Vector3(0, 0, revolutionCount * 360.0f + targetAngle ), 3f, RotateMode.LocalAxisAdd)
                     .SetEase(Ease.OutCubic)
                     .OnComplete(WheelSpinEnded);
            }
        }

        void WheelSpinEnded()
        {

        }

        /*
        private void ShowResultUI()
        {
            if(!earnedPrizes.Peek().endsGame)
            {
                succes?.Invoke();
            }
            else
            {
                fail?.Invoke();
            }
        }
        */
    }
}
