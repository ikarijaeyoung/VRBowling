using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinHitSound : MonoBehaviour
{
    [SerializeField] AudioSource _audioSource;
    [SerializeField] AudioClip _pinHitSound;
    ResetPin resetPin;
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        resetPin = GetComponentInChildren<ResetPin>();
    }
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Pin")
        || collision.gameObject.CompareTag("Ball"))
        {
            _audioSource.PlayOneShot(_pinHitSound);
            resetPin.HidePin();
        }
    }
}
