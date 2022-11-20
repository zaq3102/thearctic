using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavePointTrigger : MonoBehaviour
{
    public int saveStatus;
    public GameObject savePoint;
    public GameObject savePointGlow;
    public GameObject savePointSparkle;
    public GameObject savedUI;
    public GameObject user;
    UserInfo userInfo;

    public bool isSaved;

    private void Awake()
    {
        userInfo = user.GetComponent<UserInfo>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.name == "PlayerArmature" && !isSaved)
        {
            isSaved = true;
            changeColor();
            userInfo.saveStatus = saveStatus;
            DataPersistenceManager.instance.SaveGame();
            StartCoroutine(WaitForSave());
        }
    }

    public IEnumerator WaitForSave()
    {
        savedUI.gameObject.SetActive(true);
        yield return new WaitForSeconds(2f);
        savedUI.gameObject.SetActive(false);
    }
    // private void OnTriggerExit(Collider other)
    // {
    //     if (other.name == "PlayerArmature")
    //     {
    //         // pressE.gameObject.SetActive(false);
    //         isSaved = false;
    //     }
    // }

    public void changeColor(){
        savePoint.GetComponent<ParticleSystem>().startColor = new Color(255, 0, 0);
        savePointGlow.GetComponent<ParticleSystem>().startColor = new Color(255, 0, 0);
        savePointSparkle.GetComponent<ParticleSystem>().startColor = new Color(255, 0, 0);
    }
}
