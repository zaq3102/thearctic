using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSettingManager : MonoBehaviour
{
    public GameObject gameSettings;
    public GameObject howToControl;
    public GameObject alert;

    public void OpenHowToControl()
    {
        howToControl.SetActive(true);
        gameSettings.SetActive(false);
    }

    public void OpenGoHome()
    {
        alert.SetActive(true);
        gameSettings.SetActive(false);
    }

    public void Close()
    {   
        gameSettings.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
    }
}
