using UnityEngine;

public class LeverLeafConnector : MonoBehaviour
{
    public Transform leafToRotate;
    public float rotationMultiplier = 1f;

    private float startAngle;

    void Start()
    {
        startAngle = transform.localEulerAngles.x;
    }

    void Update()
    {
        float currentAngle = transform.localEulerAngles.x;
        float delta = Mathf.DeltaAngle(startAngle, currentAngle);

        if (leafToRotate != null)
        {
            // Apply Y-axis rotation to the leaf
            leafToRotate.localRotation = Quaternion.Euler(0f, delta * rotationMultiplier, 0f);
        }
        else
        {
            Debug.LogWarning("Leaf to rotate not assigned!");
        }
    }
}
