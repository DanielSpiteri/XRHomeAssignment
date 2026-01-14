using UnityEngine;

public class XRJoystickLeafController : MonoBehaviour
{
    [Header("Input")]
    public XRJoystickDrive joystick;

    [Header("Tuning")]
    [Tooltip("Max degrees per second the leaf can rotate at full stick.")]
    public float rotateSpeed = 120f;

    [Tooltip("If true, only rotate while joystick is being grabbed.")]
    public bool onlyRotateWhileGrabbed = true;

    void Update()
    {
        if (!joystick) return;

        if (onlyRotateWhileGrabbed && joystick.grabHandle != null &&
            joystick.grabHandle.interactorsSelecting.Count == 0)
            return;

        // Read joystick x (-1..1)
        float turn = joystick.value.x * rotateSpeed * Time.deltaTime;

        // Rotate the leaf pivot around Y axis
        transform.Rotate(0f, turn, 0f, Space.Self);
    }
}
