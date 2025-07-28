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
        [SerializeField] private GameObject resultCard;
        [SerializeField] private GameObject resultCardParent;

        private void Start()
        {
            gameController.wheelSpawner.enableSpin = EnableSpinButton;
            gameController.succes = ShowSuccesUI;
            gameController.fail = showFailUI;

            //buttons
            nextZoneButton.buttonAction = moveToNextZone;
            reviveButton.buttonAction = moveToNextZone;

            exitGameButton.buttonAction = OnQuitClicked;
            exitGameOnFailButton.buttonAction = OnQuitClickedOnFail;

            spinWheelButton.buttonAction = onSpinClicked;
        }

        private void ShowSuccesUI()
        {
            resultCardParent.SetActive(true);
            resultCard.GetComponent<UnityEngine.UI.Image>().sprite = gameController.prizeController.earnedPrizes.Peek().icon;
            succesUI.SetActive(true);
        }

        private void showFailUI()
        {
            resultCardParent.SetActive(true);
            resultCard.GetComponent<UnityEngine.UI.Image>().sprite = gameController.prizeController.earnedPrizes.Peek().icon;
            failUI.SetActive(true);
        }

        private void EnableSpinButton()
        {
            spinWheelButton.gameObject.SetActive(true);
        }

        //buttons
        private void moveToNextZone()
        {
            print("moving to next zone");
            gameController.LoadNextZone();

            DisableUIElements();
        }

        private void OnQuitClicked()
        {
            gameController.ExitWheelGame();
            DisableUIElements();
        }

        private void OnQuitClickedOnFail()
        {
            gameController.DropPrizes();
        }

        private void onSpinClicked()
        {
            spinWheelButton.gameObject.SetActive(false);
            gameController.SpinWheel();
        }


        //helper functions
        private void DisableUIElements()
        {
            succesUI.SetActive(false);
            failUI.SetActive(false);
            resultCardParent.SetActive(false);
        }
    }
}