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
        [SerializeField] private UIButton exitGameOnFailButton;
        [SerializeField] private UIButton reviveButton;
        [SerializeField] private UIButton watchAddButton;
        [Space]
        [Header("UI")]
        [SerializeField] private GameObject succesUI;
        [SerializeField] private GameObject failUI;

        private void Start()
        {
            gameController.spinEnded = EnableSpinButton;
            gameController.succes = ShowSuccesUI;
            gameController.fail = showFailUI;

            //buttons
            nextZoneButton.buttonAction = moveToNextZone;
            reviveButton.buttonAction = moveToNextZone;

            exitGameButton.buttonAction = OnQuitClicked;
            exitGameOnFailButton.buttonAction = OnQuitClicked;

            spinWheelButton.buttonAction = onSpinClicked;
        }

        private void ShowSuccesUI()
        {
            succesUI.SetActive(true);
        }

        private void showFailUI()
        {
            failUI.SetActive(true);
        }

        private void EnableSpinButton()
        {
            spinWheelButton.gameObject.SetActive(true);
        }

        //buttons
        private void moveToNextZone()
        {
            gameController.LoadNextZone();
            succesUI.SetActive(false);
            failUI.SetActive(false);
        }

        private void OnQuitClicked()
        {
            Debug.Log("Quit Game");
            succesUI.SetActive(false);
            failUI.SetActive(false);
        }

        private void onSpinClicked()
        {
            spinWheelButton.gameObject.SetActive(false);
            gameController.SpinWheel();
        }
    }
}