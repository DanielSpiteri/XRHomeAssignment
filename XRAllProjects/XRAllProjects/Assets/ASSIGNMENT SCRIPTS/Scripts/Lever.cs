using UnityEngine;

public class Lever : MonoBehaviour
{
    HingeJoint hinge;

    [Header("Lever Settings")]
    public float leverOutput;
    public float minValue, maxValue;
    public int triggerGrow = 70;
    public int triggerShrink = -70;
    public bool isActivated = false;
    //public float startingValue;

    [Header("Growth Settings")]
    public Transform targetObject;
    public Vector3 grownScale = new Vector3(2f, 2f, 2f);
    public float growSpeed = 2f;

    private Vector3 originalScale;




    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        hinge = GetComponent<HingeJoint>();

        /*if (startingValue >= minValue && startingValue <= maxValue)
        {
            float rangeFraction = (startingValue - minValue) / (maxValue - minValue);
            float degreeRotation = hinge.limits.min + (hinge.limits.max - hinge.limits.min) * rangeFraction;
            Vector3 worldSpaceHingeAxis = transform.TransformDirection(hinge.axis);
            transform.rotation = Quaternion.AngleAxis(degreeRotation, worldSpaceHingeAxis) * transform.rotation;
        }*/

        if (targetObject != null)
        {
            originalScale = targetObject.localScale;
        }

    }

    // Update is called once per frame
    void Update()
    {
        float betweenZeroAndOne = (hinge.angle - hinge.limits.min) / (hinge.limits.max - hinge.limits.min);
        leverOutput = minValue + (maxValue - minValue) * betweenZeroAndOne;
        
        if (leverOutput > triggerGrow)
        {
            isActivated = true;
        }

        if (leverOutput < triggerShrink)
        {
            isActivated = false;
        }

        if (targetObject != null)
        {
            if (isActivated)
            {
                targetObject.localScale = Vector3.Lerp(targetObject.localScale, grownScale, Time.deltaTime * growSpeed);
            }
            else
            {
                targetObject.localScale = Vector3.Lerp(targetObject.localScale, originalScale, Time.deltaTime * growSpeed);
            }
        }

    }
}
