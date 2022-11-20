using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishingSpotRange : MonoBehaviour
{
    public GameObject pressE;
    public GameObject rodBjtss;
    public GameObject user;
    UserInfo userInfo;

    public GameObject rodHealth;
    RodHealth rodHealthScript;

    public GameObject fishingLeft;
    public GameObject fishingRight;
    public GameObject fishingCenter;
    public GameObject fishUI;
    public bool isFishingStarted;
    FishingMove fishingMove;
    public GameObject getGarbage;
    public GameObject getFish;
    public GameObject itemFish;
    public GameObject holdingFishingRod;
    
    public int garbageCount = 0;

    // public GameObject lakeGarbage1;
    // public GameObject lakeGarbage2;
    // public GameObject lakeGarbage3;
    // public GameObject lakeGarbage4;
    // public GameObject lakeGarbage5;
    // public GameObject lakeGarbage6;
    // public GameObject lakeGarbage7;
    // public GameObject lakeGarbage8;
    // public GameObject lakeGarbage9;

    public GameObject[] lakeGarbages;

    public GameObject gameSettings;

    public AudioClip throwing;
    public AudioClip catching;
    public AudioClip garbageCatch;
    public AudioClip fishCatch;
    AudioSource audioSource;
    bool throwSoundPlayed;
    bool catchSoundPlayed;
    bool garbageCatchSoundPlayed;
    bool fishCatchSoundPlayed;

    private void Awake()
    {
        userInfo = user.GetComponent<UserInfo>();
        fishingMove = fishingCenter.GetComponent<FishingMove>();
        rodHealthScript = rodHealth.GetComponent<RodHealth>();
        this.audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.name == "PlayerArmature" && !isFishingStarted && !itemFish.gameObject.activeSelf &&!gameSettings.gameObject.activeSelf)
        {
            pressE.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (userInfo.isRod)
                {
                    Debug.Log("fishing game started");
                    user.GetComponent<Animator>().SetTrigger("isFishing");
                    throwSoundPlayed = false;
                    ThrowSoundPlay();
                    isFishingStarted = true;
                    holdingFishingRod.SetActive(true);
                    pressE.SetActive(false);
                    fishingCenter.SetActive(true);
                    fishingLeft.SetActive(true);
                    fishingRight.SetActive(true);
                    fishUI.SetActive(true);
                    fishingMove.enabled = true;
                }
                else
                {
                    rodBjtss.SetActive(true);
                    StartCoroutine(WaitForBjtss());
                }
            }
        }

        if (other.name == "PlayerArmature" && isFishingStarted)
        {
            if (Input.GetKeyDown(KeyCode.Escape) && fishUI.activeSelf)
            {
                holdingFishingRod.SetActive(false);
                pressE.SetActive(true);
                fishingCenter.SetActive(false);
                fishingLeft.SetActive(false);
                fishingRight.SetActive(false);
                fishUI.SetActive(false);
                getGarbage.SetActive(false);
                getFish.SetActive(false);
                user.GetComponent<Animator>().Rebind();
                StartCoroutine(EndGameByEscape());
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.name == "PlayerArmature")
        {
            isFishingStarted = false;
            holdingFishingRod.SetActive(false);
            pressE.SetActive(false);
            fishingCenter.SetActive(false);
            fishingLeft.SetActive(false);
            fishingRight.SetActive(false);
            fishUI.SetActive(false);
            getGarbage.SetActive(false);
            getFish.SetActive(false);
            user.GetComponent<Animator>().Rebind();
        }
    }

    public void PauseGame() {
        fishingCenter.SetActive(false);
        fishingLeft.SetActive(false);
        fishingRight.SetActive(false);
        catchSoundPlayed = false;
        CatchSoundPlay();
        StartCoroutine(WaitForRestart());
    }

    public void EndGame() {
        fishingCenter.SetActive(false);
        fishingLeft.SetActive(false);
        fishingRight.SetActive(false);
        catchSoundPlayed = false;
        CatchSoundPlay();
        StartCoroutine(WaitForEnd());
    }

    public IEnumerator WaitForBjtss()
    {
        yield return new WaitForSeconds(1f);
        rodBjtss.SetActive(false);
    }

    public IEnumerator WaitForRestart()
    {
        yield return new WaitForSeconds(5f);
        fishingCenter.SetActive(true);
        getGarbage.SetActive(true);
        fishUI.SetActive(true);
        garbageCatchSoundPlayed = false;
        GarbageCatchSoundPlay();
        throwSoundPlayed = false;
        catchSoundPlayed = false;
        ShowLakeGarbage();
    }

    public void ShowLakeGarbage(){
        lakeGarbages[garbageCount].SetActive(true);
        garbageCount++;
    }

    public IEnumerator EndGameByEscape()
    {
        yield return new WaitForSeconds(0.0001f);
        isFishingStarted = false;
    }

    public IEnumerator WaitForEnd()
    {
        yield return new WaitForSeconds(5f);
        getFish.SetActive(true);
        itemFish.SetActive(true);
        fishCatchSoundPlayed = false;
        FishCatchSoundPlay();
        holdingFishingRod.SetActive(false);
        fishUI.SetActive(false);
        pressE.SetActive(false);
        userInfo.isFish = true;
        yield return new WaitForSeconds(2f);
        isFishingStarted = false;
        getFish.SetActive(false);
        user.GetComponent<Animator>().Rebind();
    }

    public void ThrowSoundPlay() {
        if (!throwSoundPlayed) {
            audioSource.clip = throwing;
            audioSource.loop = false;
            audioSource.Play();
            throwSoundPlayed = true;
        }
    }

    public void CatchSoundPlay() {
        if (!catchSoundPlayed) {
            audioSource.clip = catching;
            audioSource.loop = false;
            audioSource.Play();
            catchSoundPlayed = true;
        }
    }

    public void GarbageCatchSoundPlay() {
        if (!garbageCatchSoundPlayed) {
            audioSource.clip = garbageCatch;
            audioSource.loop = false;
            audioSource.Play();
            garbageCatchSoundPlayed = true;
        }
    }

    public void FishCatchSoundPlay() {
        if (!fishCatchSoundPlayed) {
            audioSource.clip = fishCatch;
            audioSource.loop = false;
            audioSource.Play();
            fishCatchSoundPlayed = true;
        }
    }
}
