using UnityEngine;

[ExecuteAlways] // Works in both Edit and Play mode
public class UpdateWheelInEditMode : MonoBehaviour
{
    void Update()
    {
        // This will run every frame in editor
        Debug.Log("Running in Edit Mode");
    }
}