using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RodTrigger : MonoBehaviour
{
    public GameObject rod;
    public GameObject user;
    public GameObject itemRod;
    UserInfo userInfo;
    // public GameObject rodOnHand;

    private void Awake() {
        userInfo = user.GetComponent<UserInfo>();
    }

    private void OnTriggerStay(Collider other) {
        if(other.tag == "Player"){
            userInfo.isRod = true;
            itemRod.SetActive(true);
            rod.SetActive(false);
        //    rodOnHand.SetActive(true);
        }
    }
}