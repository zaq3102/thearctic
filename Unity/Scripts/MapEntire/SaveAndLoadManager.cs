using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveAndLoadManager : MonoBehaviour, IDataPersistence
{
    public UserInfo userInfo;
    public GameObject itemRod;
    public RodHealth rodHealth;
    public GameObject itemFish;
    public RegenFishingRod regenFishingRod;
    public StarvingBearRange starvingBearRange;
    public StarvingBear starvingBear;
    public FishingSpotRange fishingSpotRange;
    public SavePointTrigger[] savePointTriggers;
    public MommyBearTrigger mommyBearTrigger;
    public ChildBearTrigger ChildBearTrigger;
    public GameObject savePoint6;
    public Transform childBearIsland;
    public Transform endChildBearIslandPos;
    public SettingMenu settingMenu;

    public void LoadData(GameData data){
        userInfo.saveStatus = data.saveStatus;
        userInfo.transform.position = userInfo.respawnPosA[userInfo.saveStatus];
        savePoint6.SetActive(data.savePoint6Active);
        settingMenu.slider.value = data.audioVolume;
        settingMenu.memorizedVolume = data.memorizedVolume;
        settingMenu.volume.SetActive(data.settingAudioImgActive);
        settingMenu.volume.SetActive(data.settingAudioMuteImgActive);

        for(int i=0; i<savePointTriggers.Length; i++){
            savePointTriggers[i].isSaved = data.savePoints[i];
            if(savePointTriggers[i].isSaved){
                savePointTriggers[i].changeColor();
            }
        }

        /*---------------- map1 load data start ----------------*/
        userInfo.isRod = data.isRod;
        userInfo.isFish = data.isFish;
        userInfo.bearCount = data.bearCount;
        starvingBearRange.isFinished = data.isStarvingBearFinished;
        starvingBearRange.bearGlow.SetActive(data.starvingBearGlowActive);

        if(userInfo.isRod){
            itemRod.SetActive(true);
            userInfo.fishFailCount = data.fishFailCount;
            rodHealth.targetHealth = data.rodHealth;
            rodHealth.healthBar.fillAmount = rodHealth.targetHealth;
        } else{
            itemRod.SetActive(false);
        }

        if(userInfo.isFish){
            itemFish.SetActive(true);
        } else{
            itemFish.SetActive(false);
        }

        for(int i=0; i<regenFishingRod.rods.Length; i++){
           regenFishingRod.rods[i].SetActive(data.rodsActive[i]);
        }

        starvingBearRange.gameObject.SetActive(data.starvingBearTriggerActive);

        if(data.fishBjtssActive){
            starvingBearRange.fishBjtss.SetActive(true);
        } else{
            starvingBearRange.fishBjtss.SetActive(false);
        }

        if(data.humanBjtssActive){
            starvingBearRange.humanBjtss.SetActive(true);
        } else{
            starvingBearRange.humanBjtss.SetActive(false);
        }

        if(data.isStarvingBearFinished){
            float[] position = data.starvingBearPos;
            starvingBear.transform.position = new Vector3(position[0], position[1], position[2]);
            starvingBear.floorFish2.SetActive(true);
        }

        fishingSpotRange.garbageCount = data.garbageCount;
        for(int i=0; i<fishingSpotRange.lakeGarbages.Length; i++){
            fishingSpotRange.lakeGarbages[i].SetActive(data.lakeGarbagesActive[i]);
        }

        starvingBear.bridgeCollider.SetActive(data.bridgeColliderActive);
        /*---------------- map1 load data end ----------------*/

        /*---------------- map2 load data start ----------------*/
        userInfo.mission2_carryBear = data.isCarryingBear;
        if(userInfo.mission2_carryBear){
            childBearIsland.gameObject.GetComponent<Animator>().enabled = false;
            childBearIsland.position = endChildBearIslandPos.position;
        }
        mommyBearTrigger.BeforeMission.SetActive(data.babyBearBjtssActive);
        mommyBearTrigger.AfterMission.SetActive(data.heartBjtssActive);
        ChildBearTrigger.ChildBear.SetActive(data.childBearLostActive);
        mommyBearTrigger.ChildBear.SetActive(data.childBearFindActive);
        mommyBearTrigger.ChildBearIcon.SetActive(data.childBearIconActive);
        userInfo.mission2 = data.isMommyBearFinished;

        mommyBearTrigger.fogCollider.SetActive(data.fogColliderActive);
        if(userInfo.saveStatus == 7)
            mommyBearTrigger.fog.SetActive(false);
        else
            mommyBearTrigger.fog.SetActive(true);
        /*---------------- map2 load data end ----------------*/

        /*---------------- airplane load data start ----------------*/
        mommyBearTrigger.airplanes[0].SetActive(data.beforeVillanAirplane);
        mommyBearTrigger.airplanes[1].SetActive(data.afterVillanAirplane);
        /*---------------- airplane load data end ----------------*/

        /*---------------- minimap icon load data start ----------------*/
        userInfo.starvingBearIcon.SetActive(data.starvingBearIconActive);
        userInfo.mommyBearIcon.SetActive(data.mommyBearIconActive);
        userInfo.babyBearIcon.SetActive(data.babyBearIconActive);
        userInfo.villainIcon.SetActive(data.villainIconActive);
        /*---------------- minimap icon load data end ----------------*/

    }

    public void SaveData(ref GameData data){
        data.saveStatus = userInfo.saveStatus;
        data.savePoint6Active = savePoint6.activeSelf;
        data.audioVolume = settingMenu.slider.value;
        data.memorizedVolume = settingMenu.memorizedVolume;
        data.settingAudioImgActive = settingMenu.volume.activeSelf;
        data.settingAudioMuteImgActive = settingMenu.volume.activeSelf;

        for(int i=0; i<savePointTriggers.Length; i++){
            data.savePoints[i] = savePointTriggers[i].isSaved;
        }

        /*---------------- map1 save data start ----------------*/
        data.isRod = userInfo.isRod;
        data.fishFailCount = userInfo.fishFailCount;
        data.isFish = userInfo.isFish;
        data.rodHealth = rodHealth.targetHealth;
        data.bearCount = userInfo.bearCount;
        data.isStarvingBearFinished = starvingBearRange.isFinished;
        data.starvingBearGlowActive = starvingBearRange.bearGlow.activeSelf;

        for(int i=0; i<regenFishingRod.rods.Length; i++){
            data.rodsActive[i] = regenFishingRod.rods[i].activeSelf;
        }

        data.starvingBearTriggerActive = starvingBearRange.gameObject.activeSelf;

        data.fishBjtssActive = starvingBear.fishBjtss.activeSelf;
        data.humanBjtssActive = starvingBear.humanBjtss.activeSelf;

        if(starvingBearRange.isFinished){
            Vector3 position = starvingBear.transform.position;
            data.starvingBearPos[0] = position.x;
            data.starvingBearPos[1] = position.y;
            data.starvingBearPos[2] = position.z;
        }

        data.garbageCount = fishingSpotRange.garbageCount;
        for(int i=0; i<fishingSpotRange.lakeGarbages.Length; i++){
            data.lakeGarbagesActive[i] = fishingSpotRange.lakeGarbages[i].activeSelf;
        }

        data.bridgeColliderActive = starvingBear.bridgeCollider.activeSelf;
        /*---------------- map1 save data end ----------------*/

        /*---------------- map2 save data start ----------------*/
        data.isCarryingBear = userInfo.mission2_carryBear;
        data.babyBearBjtssActive = mommyBearTrigger.BeforeMission.activeSelf;
        data.heartBjtssActive = mommyBearTrigger.AfterMission.activeSelf;
        data.childBearLostActive = ChildBearTrigger.ChildBear.activeSelf;
        data.childBearFindActive = mommyBearTrigger.ChildBear.activeSelf;
        data.childBearIconActive = mommyBearTrigger.ChildBearIcon.activeSelf;
        data.isMommyBearFinished = userInfo.mission2;

        data.fogColliderActive = mommyBearTrigger.fogCollider.activeSelf;
        data.fogActive = mommyBearTrigger.fog.activeSelf;
        /*---------------- map2 save data end ----------------*/

        /*---------------- airplane save data start ----------------*/
        data.beforeVillanAirplane = mommyBearTrigger.airplanes[0].activeSelf;
        data.afterVillanAirplane = mommyBearTrigger.airplanes[1].activeSelf;
        /*---------------- airplane save data end ----------------*/

        /*---------------- minimap icon save data start ----------------*/
        data.starvingBearIconActive = userInfo.starvingBearIcon.activeSelf;
        data.mommyBearIconActive = userInfo.mommyBearIcon.activeSelf;
        data.babyBearIconActive = userInfo.babyBearIcon.activeSelf;
        data.villainIconActive = userInfo.villainIcon.activeSelf;
        /*---------------- minimap icon save data end ----------------*/
    }
}
