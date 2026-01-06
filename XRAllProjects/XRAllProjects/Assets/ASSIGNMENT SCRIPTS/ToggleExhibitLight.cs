using UnityEngine;
using UnityEngine.Events;


public class ToggleExhibitLight : MonoBehaviour
{
    [Header("Target")]
    [SerializeField] private Light targetLight;          // assign the Spot Light component
    [SerializeField] private GameObject targetLightGO;   // optional if you want to toggle the whole object

    [Header("Optional feedback")]
    [SerializeField] private AudioSource clickSound;
    [SerializeField] private Material onMaterial;
    [SerializeField] private Material offMaterial;
    [SerializeField] private Renderer buttonRenderer;

    private bool isOn;

    private void Reset()
    {
        // Auto-grab an interactable if present (nice for setup)
        if (!TryGetComponent<UnityEngine.XR.Interaction.Toolkit.Interactables.XRSimpleInteractable>(out _))
            gameObject.AddComponent<UnityEngine.XR.Interaction.Toolkit.Interactables.XRSimpleInteractable>();
    }

    public void Toggle()
    {
        isOn = !isOn;

        if (targetLight != null) targetLight.enabled = isOn;
        if (targetLightGO != null) targetLightGO.SetActive(isOn);

        if (clickSound != null) clickSound.Play();

        if (buttonRenderer != null)
        {
            if (isOn && onMaterial != null) buttonRenderer.material = onMaterial;
            if (!isOn && offMaterial != null) buttonRenderer.material = offMaterial;
        }
    }
}
