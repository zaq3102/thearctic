using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public Animator animator;
    private string levelToLoad;
    public AudioClip mainUISound;
    AudioSource audioSource;
    public bool isMainUI;
    public bool isUseLoaingScene;

    void Awake()
    {
        this.audioSource = GetComponent<AudioSource>();
    }

    void Start()
    {
        if(isMainUI){
            audioSource.clip = mainUISound;
            audioSource.loop = true;
            audioSource.volume = 0.1f;
            audioSource.Play();
        }
    }

    public void SaveAndFadeToLevel(string sceneName){
        DataPersistenceManager.instance.SaveGame();
        FadeToLevel(sceneName);
    }

    public void FadeToLevel(string sceneName){
        levelToLoad = sceneName;
        animator.SetTrigger("FadeOut");
    }

    public void OnFadeComplete(){
        if(isUseLoaingScene){
            LoadingSceneController.LoadScene(levelToLoad);

        } else{
            SceneManager.LoadScene(levelToLoad);
        }
    }
}
