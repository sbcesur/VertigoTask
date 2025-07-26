using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace shooterGame.wheelGame.ui
{
    public class SpinWheelButton : MonoBehaviour, IPointerClickHandler
    {
        public WheelGameController wheelGameControllerScript;
        public void OnPointerClick(PointerEventData eventData)
        {
            Debug.Log("clicked");
            wheelGameControllerScript.SpinWheel();
        }
    }
}
