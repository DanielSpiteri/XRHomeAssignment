using UnityEngine;

public class XRJoystickLeafRotator : MonoBehaviour
{
    public XRJoystickDrive joystick;
    public Transform leafPivot;
    public float rotationSpeed = 60f;
    public float returnSpeed = 90f; // degrees per second for snap-back

    private Quaternion originalRotation;
    private Vector3 lockedPosition;

    void Start()
    {
        if (!leafPivot) return;

        // Save the original rotation and position of the pivot
        originalRotation = leafPivot.rotation;
        lockedPosition = leafPivot.position;
    }

    void Update()
    {
        if (!joystick || !leafPivot) return;

        // Lock position to prevent drifting
        leafPivot.position = lockedPosition;

        // Is the joystick being grabbed?
        bool isHeld = joystick.grabHandle.interactorsSelecting.Count > 0;

        if (isHeld)
        {
            // Actively rotate based on joystick input
            float inputX = joystick.value.x;
            float rotationAmount = inputX * rotationSpeed * Time.deltaTime;

            leafPivot.Rotate(Vector3.up, rotationAmount, Space.Self);
        }
        else
        {
            // Return to original rotation smoothly when joystick is released
            leafPivot.rotation = Quaternion.RotateTowards(
                leafPivot.rotation,
                originalRotation,
                returnSpeed * Time.deltaTime
            );
        }
    }
}
