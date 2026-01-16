using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ToggleInfoPanelXR : MonoBehaviour
{
    [Header("Panel to Toggle")]
    public GameObject infoPanel;

    private bool isVisible = false;

    // Called when the XR button is pressed
    public void TogglePanel(SelectEnterEventArgs args)
    {
        if (infoPanel == null) return;

        isVisible = !isVisible;
        infoPanel.SetActive(isVisible);
    }
}
