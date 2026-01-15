using UnityEngine;

public class KeyboardLightTest : MonoBehaviour
{
    public Light target;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            if (target != null)
                target.enabled = !target.enabled;

            Debug.Log("Pressed L. Light now = " + (target != null && target.enabled));
        }
    }
}




