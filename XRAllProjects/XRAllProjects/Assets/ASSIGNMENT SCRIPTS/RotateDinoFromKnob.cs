using UnityEngine;

public class RotateDinoFromKnob : MonoBehaviour
{
    [Header("Assign in Inspector")]
    public Transform dinoPivot;

    [Header("Rotation")]
    public float maxYawDegrees = 360f;

    // Call this from the knob/lever "Value Changed" UnityEvent.
    // value is expected 0..1 (most knob implementations provide this).
    public void OnKnobValueChanged(float value)
    {
        if (!dinoPivot) return;
        float yaw = value * maxYawDegrees;
        dinoPivot.localRotation = Quaternion.Euler(0f, yaw, 0f);
    }
}
