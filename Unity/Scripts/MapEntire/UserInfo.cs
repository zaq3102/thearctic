using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;

public class UserInfo : MonoBehaviour
{
    public bool isRod = false;
    public int bearCount = 0;
    public bool isFish = false;
    public int fishFailCount = 0;

    public int saveStatus = 0;

    public AudioClip fallInWater;
    public AudioClip blizzardSound;
    AudioSource audioSource;
    bool fallInWaterSoundPlayed;

    [HideInInspector] public Vector3[] respawnPosA = {new Vector3(96.8315f, -8.5287f, -23.75552f),
                                                     new Vector3(-59.24031f, -9.172288f, 104.594f),
                                                     new Vector3(-69.16499f, -9.204637f, 158.5023f),
                                                     new Vector3(-55.53799f, -9.21084f, 206.5376f),
                                                     new Vector3(-93.27453f, -9.19831f, 218.609f),
                                                     new Vector3(-87.52583f, -9.3422f, 266.1652f),
                                                     new Vector3(-97.96579f, -9.677165f, 152.3597f),
                                                     new Vector3(-126.01001f,-10.6299992f,119.25f)};

    public bool mission2 = false;
    public bool mission2_carryBear = false;
   
    public ThirdPersonController controller;

    public GameObject starvingBearIcon;
    public GameObject mommyBearIcon;
    public GameObject babyBearIcon;
    public GameObject villainIcon;

    void Awake()
    {
        this.audioSource = GetComponent<AudioSource>();
    }

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        audioSource.clip = blizzardSound;
        audioSource.loop = true;
        audioSource.volume = 0.05f;
        audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < -20)
        {
            transform.position = Vector3.MoveTowards(transform.position, respawnPosA[saveStatus], 1000);
            controller.rb.velocity = Vector3.zero;
            controller.rb.angularVelocity = Vector3.zero;
            fallInWaterSoundPlayed = false;
            FallInWaterSoundPlay();
        }
    }

    public void FallInWaterSoundPlay() {
        if (!fallInWaterSoundPlayed) {
            audioSource.clip = fallInWater;
            audioSource.loop = false;
            audioSource.volume = 2f;
            audioSource.Play();
            fallInWaterSoundPlayed = true;
            StartCoroutine(WaitForBlizzard());
        }
    }

    public IEnumerator WaitForBlizzard()
    {
        yield return new WaitForSeconds(2.5f);
        audioSource.clip = blizzardSound;
        audioSource.loop = true;
        audioSource.volume = 0.05f;
        audioSource.Play();
    }
}
