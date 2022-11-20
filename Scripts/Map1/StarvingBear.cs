using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class StarvingBear : MonoBehaviour
{
    public bool isGoing;
    public GameObject bearDestination;
    public GameObject bearDestination2;
    public GameObject floorFish;
    public GameObject floorFish2;

    public GameObject fishBjtss;
    public GameObject humanBjtss;

    public GameObject bridgeCollider;

    public float bearRunSpeed = 5f;

    public AudioClip eatFish;
    AudioSource audioSource;
    bool eatFishSoundPlayed;

    Animator anim;
    NavMeshAgent nav;

    void Awake() {
        this.audioSource = GetComponent<AudioSource>();
    }

    void Start()
    {
        isGoing = false;
        anim = GetComponent<Animator>();
        nav = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if (isGoing == true)
        {
            moveToFish();
            anim.SetBool("isRun", true);
        }

        if (Vector3.Distance(transform.position, bearDestination.transform.position) <= 1f)
        {
            isGoing = false;
            if (Vector3.Distance(transform.position, bearDestination2.transform.position) <= 3f)
            {   
                bridgeCollider.gameObject.SetActive(false);
                StartCoroutine(WaitForEat());
            }
            fishBjtss.gameObject.SetActive(false);
            humanBjtss.gameObject.SetActive(false);
            nav.ResetPath();
            nav.isStopped = true;
        }
    }

    public void moveToFish(){
        nav.SetDestination(bearDestination.transform.position);
        nav.speed = bearRunSpeed;
    }

    public IEnumerator WaitForEat()
    {
        anim.SetBool("isEat", true);
        EatFishSoundPlay();
        yield return new WaitForSeconds(4.3f);
        floorFish.gameObject.SetActive(false);
        floorFish2.gameObject.SetActive(true);
        eatFishSoundPlayed = false;
        anim.SetBool("isEat", false);
        anim.SetBool("isRun", false);
    }

    public void EatFishSoundPlay() {
        if (!eatFishSoundPlayed) {
            audioSource.clip = eatFish;
            audioSource.loop = false;
            audioSource.Play();
            eatFishSoundPlayed = true;
        }
    }
}
