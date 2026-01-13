using UnityEngine;

public class SpinTest : MonoBehaviour
{
    void Update()
    {
        // rotates even if deltaTime is 0
        transform.Rotate(0f, 2f, 0f);
    }
}
