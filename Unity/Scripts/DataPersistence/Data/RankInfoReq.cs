using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class RankInfoReq
{
    public string nickName;
    public string time;

    public RankInfoReq(string nickName, string time){
        this.nickName = nickName;
        this.time = time;
    }
}
