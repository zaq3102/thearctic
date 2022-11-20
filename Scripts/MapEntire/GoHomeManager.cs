using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoHomeManager : MonoBehaviour
{
    public GameObject gameSettings;
    public GameObject alert;

    public void YesBtn()
    {
        SceneManager.LoadScene("MainUI");
    }

    public void NoBtn()
    {   
        gameSettings.SetActive(true);
        alert.SetActive(false);
    }
}
