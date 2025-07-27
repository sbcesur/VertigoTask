/*
 * This is a placeholder script to start the wheel game
 * for demo purposes game always starts from zone 1
 * game starts when screen is tapped
 */



using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace shooterGame
{
    public class GameManager : MonoBehaviour
    {
        public wheelGame.WheelGameController wheelGameController;
        private int wheelGamestartZone = 1;
        private bool wheelGameActive = false;

        public static GameManager Instance;
        // Start is called before the first frame update
        void Start()
        {
            GameManager.Instance = this;
        }

        // Update is called once per frame
 
        /*
        void Update()
        {
            if (!wheelGameActive)
            { 
                if (Input.GetMouseButtonDown(0) == true)
                {
                    wheelGameActive = true;
                    wheelGameController.enabled = true;
                    wheelGameController.StartWheelGame(wheelGamestartZone);
                }
            }
        }
        */
    }
}
