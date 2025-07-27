using UnityEngine;
using UnityEngine.EventSystems;

namespace shooterGame.wheelGame
{
    public class UIController : MonoBehaviour
    {
        [SerializeField] private WheelGameController gameController;
        [Space]
        [Header("Buttons")]
        [SerializeField] private UIButton nextZoneButton;
        [SerializeField] private UIButton exitGameButton;
        [SerializeField] private UIButton spinWheelButton;

        private void Start()
        {

            nextZoneButton.buttonAction = OnPlayClicked;
            exitGameButton.buttonAction = OnQuitClicked;
            spinWheelButton.buttonAction = onSpinClicked;
        }

        private void OnPlayClicked()
        {
            Debug.Log("Play Game");
        }

        private void OnQuitClicked()
        {
            Debug.Log("Quit Game");

        }

        private void onSpinClicked()
        {

            gameController.SpinWheel();

        }
    }
}