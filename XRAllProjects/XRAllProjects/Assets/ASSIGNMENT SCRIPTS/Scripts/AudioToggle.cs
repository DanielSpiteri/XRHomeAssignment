using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class AudioToggle : MonoBehaviour
{
    private AudioSource audioSource;
    private XRSimpleInteractable interactable;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        interactable = GetComponent<XRSimpleInteractable>();
    }

    void OnEnable()
    {
        interactable.selectEntered.AddListener(PlayAudio);
    }

    void OnDisable()
    {
        interactable.selectEntered.RemoveListener(PlayAudio);
    }

    private void PlayAudio(SelectEnterEventArgs args)
    {
        if (!audioSource.isPlaying)
        {
            audioSource.Play();
        }
    }
}