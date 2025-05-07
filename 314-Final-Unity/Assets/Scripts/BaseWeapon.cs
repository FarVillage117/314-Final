using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.XR.Interaction.Toolkit;

public class BaseWeapon : MonoBehaviour
{
    NotifManager notifManager;
    [SerializeField] XRGrabInteractable interactable;

    // Start is called before the first frame update
    void Start()
    {
        notifManager = FindObjectOfType<NotifManager>();
        if (interactable != null)
        {
            interactable.selectEntered.AddListener(OnGrabbed);
            interactable.selectExited.AddListener(OnReleased);
        }
        else
        {
            Debug.LogError("XRGrabInteractable not assigned on " + gameObject.name);
        }
    }

    public void OnGrabbed(SelectEnterEventArgs arg0)
    {
        notifManager.InteractedWithWeapon(0);
    }

    public void OnReleased(SelectExitEventArgs arg0)
    {
        notifManager.InteractedWithWeapon(1);
    }
}
