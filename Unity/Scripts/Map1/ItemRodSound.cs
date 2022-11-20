using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemRodSound : MonoBehaviour
{
    public AudioClip getRod;
    AudioSource audioSource;

    private void Awake() {
        this.audioSource = GetComponent<AudioSource>();
    }
    
    void Start() {
        audioSource.clip = getRod;
        audioSource.loop = false;
        audioSource.Play();
    }
}
