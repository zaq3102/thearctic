using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MommyBearTrigger : MonoBehaviour
{
    public UserInfo userInfo;
    public GameObject BeforeMission;
    public GameObject AfterMission;
    public GameObject ChildBear;
    public GameObject ChildBearIcon;

    public Animator anim;

    public SceneController sceneController;

    public GameObject[] airplanes;

    public AudioClip mamaHowl;
    public AudioClip babyHowl;
    AudioSource audioSource;
    bool mamaHowlSoundPlayed;
    bool babyHowlSoundPlayed;

    public GameObject pressE5;

    public GameObject fog;
    public GameObject fogCollider;

    public RankTimer timer;

    private void Awake()
    {
        this.audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerStay(Collider other) {
        if (userInfo) {
            // mission2 = userInfo.mission2;
            // carryBear = userInfo.mission2_carryBear;
            if (other.tag == "Player") {
                if (!BeforeMission.activeSelf && !userInfo.mission2_carryBear && !userInfo.mission2) {
                    pressE5.SetActive(true);
                    if (Input.GetKeyDown(KeyCode.E)) {
                        BeforeMission.SetActive(true);
                        pressE5.SetActive(false);
                    }
                }


                if (userInfo.mission2_carryBear) {
                    if (userInfo.mission2) {
                        if(Input.GetKeyDown(KeyCode.E)){
                            // airplanes[0].SetActive(false);
                            // airplanes[1].SetActive(true);
                            // userInfo.saveStatus = 7;
                            // fog.SetActive(false);
                            // fogCollider.SetActive(false);
                            startMidCinematic();
                        }
                    }
                    else {
                        pressE5.SetActive(true);
                        if (Input.GetKeyDown(KeyCode.E)) {
                            pressE5.SetActive(false);
                            anim.SetBool("isMission", true);
                            BeforeMission.SetActive(false);
                            ChildBearIcon.SetActive(false);
                            AfterMission.SetActive(true);
                            userInfo.mission2 = true;
                            ChildBear.SetActive(true);
                            userInfo.saveStatus = 7;
                            userInfo.mommyBearIcon.SetActive(false);
                            userInfo.villainIcon.SetActive(true);
                            airplanes[0].SetActive(false);
                            airplanes[1].SetActive(true);
                            userInfo.saveStatus = 7;
                            // fog.SetActive(false);
                            fogCollider.SetActive(false);
                            timer.SetTimerOff();
                            StartCoroutine(WaitForChangeScene());
                            // startMidCinematic();
                        }
                    }
                }
                else {
                    // BeforeMission.SetActive(true);
                    // if (Input.GetKeyDown(KeyCode.E)) {
                    //     animator.SetTrigger("Buff");
                    // }
                }
            }
        }        
    }

    private void OnTriggerExit(Collider other) {
        if(other.tag == "Player"){
            pressE5.SetActive(false);
        }
    }

    private void startMidCinematic(){
        sceneController.SaveAndFadeToLevel("Cinema");
    }

    public void MamaHowlSoundPlay() {
        if (!mamaHowlSoundPlayed) {
            audioSource.clip = mamaHowl;
            audioSource.loop = false;
            audioSource.Play();
            mamaHowlSoundPlayed = true;
        }
    }

    public void BabyHowlSoundPlay() {
        if (!babyHowlSoundPlayed) {
            audioSource.clip = babyHowl;
            audioSource.loop = false;
            audioSource.Play();
            babyHowlSoundPlayed = true;
        }
    }

    public IEnumerator WaitForChangeScene()
    {
        MamaHowlSoundPlay();
        yield return new WaitForSeconds(2f);
        BabyHowlSoundPlay();
        yield return new WaitForSeconds(1f);
        startMidCinematic();
    }
}