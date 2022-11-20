using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class StarvingBearRange : MonoBehaviour
{
    public GameObject pressE;
    public GameObject user;
    UserInfo userInfo;
    public GameObject firstFishingRod;
    public GameObject fishBjtss;
    public GameObject humanBjtss;
    public GameObject floorFish;
    public GameObject bear;
    StarvingBear starvingBear;
    
    public GameObject itemRod;
    public GameObject itemFish;
    public GameObject bearGlow;
    public GameObject gameGuide;

    public bool isFinished;

    public PlayerInput playerInput;
    public Animator bearAnimator;
    public Animator playerAnimator;

    public AudioClip throwFish;
    public AudioClip attackPlayer;
    public AudioClip playerHitted;
    public AudioClip bearStarving;
    AudioSource audioSource;
    bool throwFishSoundPlayed;
    bool attackPlayerSoundPlayed;
    bool playerHittedSoundPlayed;
    bool bearStarvingSoundPlayed;

    private void Awake()
    {
        userInfo = user.GetComponent<UserInfo>();
        starvingBear = bear.GetComponent<StarvingBear>();
        this.audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other) {
        if (other.name == "PlayerArmature" && !isFinished){
            pressE.SetActive(true);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.name == "PlayerArmature" && !isFinished)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (userInfo.isFish)
                {
                    Debug.Log("give fish to bear");
                    throwFishSoundPlayed = false;
                    ThrowFishSoundPlay();
                    floorFish.SetActive(true);
                    itemFish.SetActive(false);
                    itemRod.SetActive(false);
                    fishBjtss.SetActive(false);
                    humanBjtss.SetActive(false);
                    userInfo.isRod = false;
                    userInfo.isFish = false;
                    isFinished = true;
                    pressE.SetActive(false);
                    userInfo.starvingBearIcon.SetActive(false);
                    userInfo.mommyBearIcon.SetActive(true);
                    userInfo.babyBearIcon.SetActive(true);
                    StartCoroutine(Wait());
                } else
                {
                    if (pressE.activeSelf) {
                        switch (userInfo.bearCount)
                        {
                            case 0:
                                Debug.Log("fish bjtss");
                                bearStarvingSoundPlayed = false;
                                BearStarvingSoundPlay();
                                firstFishingRod.SetActive(true);
                                gameGuide.SetActive(true);
                                userInfo.bearCount += 1;
                                fishBjtss.SetActive(true);
                                bearGlow.SetActive(false);
                                pressE.SetActive(false);
                                break;
                            case 1:
                                Debug.Log("hujman bjtss");
                                bearStarvingSoundPlayed = false;
                                BearStarvingSoundPlay();
                                gameGuide.SetActive(true);
                                userInfo.bearCount += 1;
                                fishBjtss.SetActive(false);
                                humanBjtss.SetActive(true);
                                pressE.SetActive(false);
                                break;
                            case 2:
                                Debug.Log("bear will eat you");
                                humanBjtss.SetActive(false);
                                humanBjtss.gameObject.SetActive(false);
                                bearAnimator.SetBool("isAttack", true);
                                attackPlayerSoundPlayed = false;
                                AttackPlayerSoundPlay();
                                playerInput.enabled = false;
                                StartCoroutine(WaitForEndGame());
                                break;
                        }
                    }
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.name == "PlayerArmature")
        {
            pressE.SetActive(false);
            gameGuide.SetActive(false);
        }
    }

    public IEnumerator Wait()
    {
        yield return new WaitForSeconds(1f);
        starvingBear.isGoing = true;
        pressE.SetActive(false);
        this.gameObject.SetActive(false);
    }

    public IEnumerator WaitForEndGame()
    {
        yield return new WaitForSeconds(1f);
        PlayerHittedSoundPlay();
        playerAnimator.SetBool("isDying2", true);
        yield return new WaitForSeconds(3f);
        Debug.Log("Game Over");
        SceneManager.LoadScene("GameOver");
    }

    public void ThrowFishSoundPlay() {
        if (!throwFishSoundPlayed) {
            audioSource.clip = throwFish;
            audioSource.loop = false;
            audioSource.Play();
            throwFishSoundPlayed = true;
        }
    }

    public void AttackPlayerSoundPlay() {
        if (!attackPlayerSoundPlayed) {
            audioSource.clip = attackPlayer;
            audioSource.loop = false;
            audioSource.Play();
            attackPlayerSoundPlayed = true;
        }
    }

    public void PlayerHittedSoundPlay() {
        if (!playerHittedSoundPlayed) {
            audioSource.clip = playerHitted;
            audioSource.loop = false;
            audioSource.Play();
            playerHittedSoundPlayed = true;
        }
    }

    public void BearStarvingSoundPlay() {
        if (!bearStarvingSoundPlayed) {
            audioSource.clip = bearStarving;
            audioSource.loop = false;
            audioSource.Play();
            bearStarvingSoundPlayed = true;
        }
    }
}
