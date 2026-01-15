using UnityEngine;

public class Lever : MonoBehaviour
{
    HingeJoint hinge;
    public float leverOutput;
    public float minValue, maxValue;
    public bool isActivated = false;
    public int triggeredAngle = 70;

    public float startingValue;




    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        hinge = GetComponent<HingeJoint>();
    
        if (startingValue >= minValue && startingValue <= maxValue)
        {
            float rangeFraction = (startingValue - minValue) / (maxValue - minValue);
            float degreeRotation = hinge.limits.min + (hinge.limits.max - hinge.limits.min) * rangeFraction;
            Vector3 worldSpaceHingeAxis = transform.TransformDirection(hinge.axis);
            transform.rotation = Quaternion.AngleAxis(degreeRotation, worldSpaceHingeAxis) * transform.rotation;
        }
    
    }

    // Update is called once per frame
    void Update()
    {
        float betweenZeroAndOne = (hinge.angle - hinge.limits.min) / (hinge.limits.max - hinge.limits.min);
        leverOutput = minValue + (maxValue - minValue) * betweenZeroAndOne;
        
        if (leverOutput > triggeredAngle)
        {
            isActivated = true;
        }

    }
}
