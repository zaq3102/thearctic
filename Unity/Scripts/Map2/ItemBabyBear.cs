using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBabyBear : MonoBehaviour
{
    public AudioClip getBabyBear;
    AudioSource audioSource;

    private void Awake() {
        this.audioSource = GetComponent<AudioSource>();
    }
    
    void Start() {
        audioSource.clip = getBabyBear;
        audioSource.loop = false;
        audioSource.Play();
    }
}