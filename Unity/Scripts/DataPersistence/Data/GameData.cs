using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    [Header("UserInfo")]
    public string id;
    public bool isInit;
    public float time;

    public int saveStatus;
    public bool[] savePoints;
    public float audioVolume;
    public float memorizedVolume;
    public bool settingAudioImgActive;
    public bool settingAudioMuteImgActive;

    [Header("Map1 data")]
    public bool isRod;
    public int fishFailCount;
    public float rodHealth;
    public bool isFish;
    public int bearCount;
    public bool[] rodsActive;
    public bool fishBjtssActive;
    public bool humanBjtssActive;
    public bool starvingBearTriggerActive;
    public bool starvingBearGlowActive;
    public bool isStarvingBearFinished;
    public float[] starvingBearPos;
    public int garbageCount;
    public bool[] lakeGarbagesActive;
    public bool bridgeColliderActive;

    [Header("Map2 data")]
    public bool savePoint6Active;
    public bool isCarryingBear;
    public bool babyBearBjtssActive;
    public bool heartBjtssActive;
    public bool childBearLostActive;
    public bool childBearFindActive;
    public bool childBearIconActive;
    public bool isMommyBearFinished;
    public bool fogColliderActive;
    public bool fogActive;

    [Header("airplane")]
    public bool beforeVillanAirplane;
    public bool afterVillanAirplane;

    [Header("missionIcon")]
    public bool starvingBearIconActive;
    public bool mommyBearIconActive;
    public bool babyBearIconActive;
    public bool villainIconActive;

    //the values defined in this constructor will be the default values
    //the game starts with when there's no data to load
    public GameData(){
        this.isInit = true;
        this.time = 0;

        this.saveStatus = 0;
        this.savePoints = new bool[7];
        this.audioVolume = 0.5f;
        this.memorizedVolume = 0.5f;
        this.settingAudioImgActive = true;
        this.settingAudioMuteImgActive = false;

        this.isRod = false;
        this.fishFailCount = 0;
        this.rodHealth = 1;
        this.isFish = false;
        this.bearCount = 0;
        this.rodsActive = new bool[5];
        this.fishBjtssActive = false;
        this.humanBjtssActive = false;
        this.starvingBearTriggerActive = true;
        this.starvingBearGlowActive = true;
        this.isStarvingBearFinished = false;
        this.starvingBearPos = new float[3];
        this.garbageCount = 0;
        this.lakeGarbagesActive = new bool[9];
        this.bridgeColliderActive = true;

        this.savePoint6Active = false;
        this.isCarryingBear = false;
        this.babyBearBjtssActive = false;
        this.heartBjtssActive = false;
        this.childBearLostActive = true;
        this.childBearFindActive = false;
        this.childBearIconActive = false;
        this.isMommyBearFinished = false;
        this.fogColliderActive = true;
        this.fogActive = true;
       
        this.beforeVillanAirplane = true;
        this.afterVillanAirplane = false;

        this.starvingBearIconActive = true;
        this.mommyBearIconActive = false;
        this.babyBearIconActive = false;
        this.villainIconActive = false;
    }

    public static GameData Parse(string json)
    {
        return JsonUtility.FromJson<GameData>(json);
    }
}
