using UnityEngine;

public class LeverToRotation : MonoBehaviour
{
    public Transform leafToRotate;
    public float rotationMultiplier = 1f;

    private float initialLeverAngle;

    void Start()
    {
        initialLeverAngle = transform.localEulerAngles.x;
    }

    void Update()
    {
        float leverAngle = transform.localEulerAngles.x;
        float angleDifference = Mathf.DeltaAngle(initialLeverAngle, leverAngle);

        if (leafToRotate != null)
        {
            leafToRotate.localRotation = Quaternion.Euler(0f, angleDifference * rotationMultiplier, 0f);
        }
    }
}
