using shooterGame;
using shooterGame.wheelGame;
using UnityEngine;
using UnityEngine.Events;



public class WheelSpawner : MonoBehaviour
{
    //temp bool for test 
    public bool testCode = false;

    public WheelGameData wheelGameData;
    private GameObject wheel;

    public UnityAction enableSpin;

    private bool isSuperZone() => wheelGameData.currentZone % wheelGameData.superZone == 0;
    private bool isSafeZone() => wheelGameData.currentZone % wheelGameData.safeZone == 0;


    public GameObject SpawnWheel()
    {
        GetWheelDataForZone();
        InstantiateCurrentWheel();
        GetWheelSlots();

        enableSpin?.Invoke();

        return wheel;
    }

    private void GetWheelDataForZone()
    {
        if (isSuperZone())
        {
            wheelGameData.currentWheel = wheelGameData.goldWheelData;
            return;
        }

        if (isSafeZone())
        {
            wheelGameData.currentWheel = wheelGameData.silverWheelData;
            return;
        }

        wheelGameData.currentWheel = wheelGameData.bronzeWheelData;
        return;
    }

    private void InstantiateCurrentWheel()
    {
        if (wheel != null)
        {
            Destroy(wheel);
        }

        //instantiate current wheel
        wheel = Instantiate(wheelGameData.currentWheel.wheelPrefab, GameManager.Instance.canvas);
        print("current zone no = " + wheelGameData.currentZone);
        enableSpin?.Invoke();
    }


    //put the instantiated objects slots into scriptble object
    private void GetWheelSlots()
    {
        Transform wheelSlotParent = wheelGameData.currentWheel.FindChildWithTag(wheel.transform, "wheelSlotParent");
        if (wheelSlotParent != null)
        {
            for (int i = 0; i < wheelGameData.currentWheel.slots.Count; i++)
            {
                wheelGameData.currentWheel.slots[i].slotTransform = wheelSlotParent.GetChild(i);
                //print(wheelGameData.currentWheel.slots[i].slotTransform.name);
            }
        }
        else
        {
            Debug.LogError("Error! Check wheel prefab");
        }
    }
}
