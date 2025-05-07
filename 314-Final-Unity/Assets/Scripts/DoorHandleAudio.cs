using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class DoorHandleAudio : MonoBehaviour
{
    [SerializeField] AudioSource handleAudio;
    [SerializeField] AudioSource doorAudio;

    [SerializeField] XRGrabInteractable interactable;

    // Start is called before the first frame update
    void Start()
    {
        handleAudio = GetComponent<AudioSource>();
        interactable = GetComponent<XRGrabInteractable>();

        if (interactable != null)
        {
            interactable.selectEntered.AddListener(OnGrabbed);
            interactable.selectExited.AddListener(OnReleased);
        }
    }

    public void OnGrabbed(SelectEnterEventArgs arg0)
    {
        handleAudio.Stop();
        doorAudio.Stop();

        handleAudio.Play();
        doorAudio.Play();
    }

    public void OnReleased(SelectExitEventArgs arg0)
    {
        handleAudio.Stop();
    }
}
