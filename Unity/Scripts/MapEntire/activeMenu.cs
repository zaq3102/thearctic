using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class activeMenu : MonoBehaviour
{
    public GameObject gameSettings;
    public GameObject minimap;
    public GameObject fishingSpot;
    public GameObject rankAlert;

    FishingSpotRange fishingSpotRange;
    
    private bool gameSettingsOn;
    private bool minimapOn;

    public GameObject howToControl;
    public GameObject alert;

    public AudioClip minimapSound;
    AudioSource audioSource;
    bool minimapSoundPlayed;

    [HideInInspector] public bool gameFinished;

    private void Awake()
    {
        fishingSpotRange = fishingSpot.GetComponent<FishingSpotRange>();
        this.audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(minimap.activeSelf || gameSettings.activeSelf || alert.activeSelf || rankAlert.activeSelf || howToControl.activeSelf){
            Cursor.lockState = CursorLockMode.None;
        } else{
            Cursor.lockState = CursorLockMode.Locked;
        }

        // if(!gameFinished){
            if (!minimapOn && !gameSettingsOn) {
                if (Input.GetKeyDown(KeyCode.M) && !gameFinished) {
                    minimap.gameObject.SetActive(true);
                    minimapOn = true;
                    minimapSoundPlayed = false;
                    MinimapSoundPlay();
                }
                else if (Input.GetKeyDown(KeyCode.Escape) && !fishingSpotRange.isFishingStarted && !howToControl.gameObject.activeSelf && !alert.gameObject.activeSelf && !gameFinished) {
                    Time.timeScale = 0;
                    // Cursor.lockState = CursorLockMode.None;
                    gameSettings.gameObject.SetActive(true);
                    gameSettingsOn = true;
                }
            }
            else if (minimapOn) {
                if (Input.GetKeyDown(KeyCode.M)) {
                    minimap.gameObject.SetActive(false);
                    minimapOn = false;
                    minimapSoundPlayed = false;
                    MinimapSoundPlay();
                }
            }
            else if (gameSettingsOn) {
                if (Input.GetKeyDown(KeyCode.Escape) && !howToControl.gameObject.activeSelf && !alert.gameObject.activeSelf) {
                    Time.timeScale = 1;
                    // Cursor.lockState = CursorLockMode.Locked;
                    gameSettings.gameObject.SetActive(false);
                    gameSettingsOn = false;
                }
            }
        // }
    }

    public void MinimapSoundPlay() {
        if (!minimapSoundPlayed) {
            audioSource.clip = minimapSound;
            audioSource.loop = false;
            audioSource.Play();
            minimapSoundPlayed = true;
        }
    }
}
