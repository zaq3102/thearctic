using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VillanTrigger : MonoBehaviour
{
    public UserInfo userInfo;
    public GameObject pressE;
    public Animator anim;
    public SceneController sceneController;
    public activeMenu activeMenuscript;
    
    public RankTimer timer;

    bool isFinished = false;

    private void OnTriggerEnter(Collider other) {
        if (other.name == "PlayerArmature" && !isFinished){
            pressE.SetActive(true);
        }
    }

    private void OnTriggerStay(Collider other) {
        if (other.tag == "Player" && !isFinished) {
            if(Input.GetKeyDown(KeyCode.E)){
                activeMenuscript.gameFinished = true;
                timer.SetTimerOff();
                pressE.SetActive(false);
                userInfo.villainIcon.SetActive(false);
                isFinished = true;
                if(DataPersistenceManager.instance.GetGameData.isInit){
                    Time.timeScale = 0;
                    timer.getRank();
                } else{
                    startEndingCinematic();
                }
            }
        }      
    }

    private void OnTriggerExit(Collider other) {
        if(other.tag == "Player"){
            pressE.SetActive(false);
        }
    }

    private void startEndingCinematic(){
        sceneController.SaveAndFadeToLevel("Ending");
    }
}
