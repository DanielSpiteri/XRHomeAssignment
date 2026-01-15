using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class SpotlightToggle : MonoBehaviour
{
    [Header("Spotlight")]
    [Tooltip("Spotlight that will be toggled on button press.")]
    public Light targetSpotlight;

    [Header("Visual Feedback")]
    [Tooltip("Material when not hovered.")]
    public Material defaultMaterial;

    [Tooltip("Material when hovered.")]
    public Material hoveredMaterial;

    [Tooltip("Renderer of the button mesh.")]
    public Renderer switchRenderer;

    // Called when the XR button is pressed
    public void ToggleSpotlight(SelectEnterEventArgs args)
    {
        if (targetSpotlight != null)
        {
            targetSpotlight.enabled = !targetSpotlight.enabled;
        }
    }

    // Hover enter  change material
    public void OnHoverEntered(HoverEnterEventArgs args)
    {
        if (switchRenderer != null && hoveredMaterial != null)
        {
            switchRenderer.material = hoveredMaterial;
        }
    }

    // Hover exit  revert material
    public void OnHoverExited(HoverExitEventArgs args)
    {
        if (switchRenderer != null && defaultMaterial != null)
        {
            switchRenderer.material = defaultMaterial;
        }
    }
}
