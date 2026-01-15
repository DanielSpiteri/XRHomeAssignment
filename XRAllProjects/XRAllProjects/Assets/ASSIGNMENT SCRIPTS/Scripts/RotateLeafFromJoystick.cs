using UnityEngine;

public class RotateLeafFromJoystick : MonoBehaviour
{
    public XRJoystickDrive joystickDrive;
    public Transform leafPivot;
    public float maxYawDegrees = 90f;

    void Update()
    {
        if (joystickDrive == null || leafPivot == null) return;

        float x = joystickDrive.value.x;   //  lowercase
        float yaw = x * maxYawDegrees;

        leafPivot.localRotation = Quaternion.Euler(0f, yaw, 0f);
    }
}
