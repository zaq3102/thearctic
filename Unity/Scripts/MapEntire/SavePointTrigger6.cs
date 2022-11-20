using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavePointTrigger6 : MonoBehaviour
{
    public GameObject savePoint;
    public GameObject pressE;
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
            pressE.gameObject.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E))
            {
                isSaved = true;
                pressE.gameObject.SetActive(false);
                savePoint.GetComponent<Renderer>().material.color = new Color(255, 0, 0);
                userInfo.saveStatus = 6;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.name == "PlayerArmature")
        {
            pressE.gameObject.SetActive(false);
            isSaved = false;
        }
    }
}
