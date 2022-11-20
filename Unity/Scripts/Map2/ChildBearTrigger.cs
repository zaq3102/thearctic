using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildBearTrigger : MonoBehaviour
{
    public UserInfo userInfo;
    public GameObject ChildBear;
    public GameObject ChildBearIcon;
    private bool carryBear;
    public GameObject ICELAND;
    // public Mission gameController;
    public GameObject savePoint6;
    public GameObject pressE;

    private void OnTriggerEnter(Collider other) {
        if(other.tag == "Player"){
            pressE.SetActive(true);
        }
    }

    private void OnTriggerStay(Collider other) {
        if (userInfo) {
            if (other != null) {
                bool carryBear = userInfo.mission2_carryBear;
                if(other.tag == "Player"){
                    if (carryBear) {
                        ChildBear.SetActive(false);
                        userInfo.babyBearIcon.SetActive(false);
                    }
                    else {
                        if (Input.GetKeyDown(KeyCode.E)) {
                            userInfo.mission2_carryBear = true;
                            userInfo.saveStatus = 6;
                            ChildBear.SetActive(false);
                            ChildBearIcon.SetActive(true);
                            ICELAND.GetComponent<Animator>().SetBool("isComplete", true);
                            savePoint6.SetActive(true);
                            userInfo.saveStatus = 6;
                            pressE.SetActive(false);
                        }
                    }
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player") {
            pressE.SetActive(false);
        }
    }
   
}