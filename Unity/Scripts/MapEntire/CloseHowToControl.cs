using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseHowToControl : MonoBehaviour
{
    public GameObject gameSettings;
    public GameObject howToControl;
    
    // Start is called before the first frame update
    public void Close()
    {   
        gameSettings.SetActive(true);
        howToControl.SetActive(false);
    }
}
