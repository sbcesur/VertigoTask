using System;
using UnityEngine;
using UnityEngine.EventSystems;


public class UIButton : MonoBehaviour, IPointerClickHandler
{
    public Action buttonAction;
    public void OnPointerClick(PointerEventData eventData)
    {
        buttonAction?.Invoke();
    }
}
