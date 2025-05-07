using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class GrabInteractableAudio : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;
    [SerializeField] XRGrabInteractable interactable;

    // Start is called before the first frame update
    void Start()
    {
        if (interactable != null)
        {
            interactable.selectEntered.AddListener(OnGrabbed);
            interactable.selectExited.AddListener(OnReleased);
        }
    }

    public void OnGrabbed(SelectEnterEventArgs arg0)
    {
        if (audioSource != null)
        {
            audioSource.Play();
        }
    }

    public void OnReleased(SelectExitEventArgs arg0)
    {
        if (audioSource != null)
        {
            audioSource.Stop();
        }
    }
}
