using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//generalUI manager of the game
namespace shooterGame
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField] private GameObject TapToStart;

        public static UIManager Instance;

        private void Start()
        {
            Instance = this;
        }

        public void DisableTapToStartText()
        {
            TapToStart.SetActive(false);
        }

        public void EnableTapToStartText()
        {
            TapToStart.SetActive(true);
        }
    }
}
