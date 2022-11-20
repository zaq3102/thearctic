using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeController : MonoBehaviour
{
    public GameObject mute;
    public GameObject volume;
    public GameObject volumeSlider;
    SettingMenu settingMenu;

    public Slider slider;

    // Start is called before the first frame update
    private void Awake()
    {
        settingMenu = volumeSlider.GetComponent<SettingMenu>();
    }

    public void Mute(){

        mute.gameObject.SetActive(true);
        settingMenu.memorizedVolume = slider.value;
        settingMenu.SetVolume(0f);
        slider.value = 0f;
        gameObject.SetActive(false);
    }

    public void Sound(){
        volume.gameObject.SetActive(true);
        settingMenu.SetVolume(settingMenu.memorizedVolume);
        slider.value = settingMenu.memorizedVolume;
        gameObject.SetActive(false);
    }
}
