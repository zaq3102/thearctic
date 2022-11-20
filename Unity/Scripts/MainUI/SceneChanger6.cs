using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger6 : MonoBehaviour
{
    // void OnEnable(){
    //     Debug.Log("씬 바꿔라");
    // }

    void Update(){
        if(this.gameObject.activeSelf){
            // SceneManager.LoadScene("FlyingAirplane");
            SceneManager.LoadScene("Cookie");
        }
    }
}
