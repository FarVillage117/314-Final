using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShatterWhenThrown : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;
    [SerializeField] Rigidbody rb;
    [SerializeField] MeshRenderer mr;
    [SerializeField] ParticleSystem ps;

    float oldVelMag;
    [SerializeField] float breakforce;

    // Update is called once per frame
    void Update()
    {
        if (oldVelMag - rb.velocity.magnitude > breakforce)
        {
            Debug.Log($"{gameObject.name} is broken with a threshold value of {oldVelMag - rb.velocity.magnitude}");
            mr.enabled = false;
            ps.Play();
            audioSource.Play();
        }
        oldVelMag = rb.velocity.magnitude;
    }
}
