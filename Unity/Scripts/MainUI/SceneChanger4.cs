using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneChanger4 : MonoBehaviour
{
    public SceneController sceneController;
    public string sceneName;

    void Update(){
        if(this.gameObject.activeSelf){
            sceneController.FadeToLevel(sceneName);
        }
    }
}
