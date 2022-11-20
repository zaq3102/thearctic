package com.ssafy.thearctic.db.entity;

import lombok.Getter;
import lombok.Setter;
import nonapi.io.github.classgraph.json.Id;
import org.springframework.data.annotation.TypeAlias;

@Getter
@Setter
@TypeAlias("data")
public class GameData {
    @Id
    public String id;
    public boolean isInit;
    public float time;

    public int saveStatus;
    public boolean[] savePoints;
    public float audioVolume;
    public float memorizedVolume;
    public boolean settingAudioImgActive;
    public boolean settingAudioMuteImgActive;

    public boolean isRod;
    public int fishFailCount;
    public float rodHealth;
    public boolean isFish;
    public int bearCount;
    public boolean[] rodsActive;
    public boolean fishBjtssActive;
    public boolean humanBjtssActive;
    public boolean starvingBearTriggerActive;
    public boolean starvingBearGlowActive;
    public boolean isStarvingBearFinished;
    public float[] starvingBearPos;
    public int garbageCount;
    public boolean[] lakeGarbagesActive;
    public boolean bridgeColliderActive;

    public boolean savePoint6Active;
    public boolean isCarryingBear;
    public boolean babyBearBjtssActive;
    public boolean heartBjtssActive;
    public boolean childBearLostActive;
    public boolean childBearFindActive;
    public boolean childBearIconActive;
    public boolean isMommyBearFinished;
    public boolean fogColliderActive;
    public boolean fogActive;

    public boolean beforeVillanAirplane;
    public boolean afterVillanAirplane;

    public boolean starvingBearIconActive;
    public boolean mommyBearIconActive;
    public boolean babyBearIconActive;
    public boolean villainIconActive;
}
