using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Networking;
using Newtonsoft.Json;
using UnityEngine.UI;

public class GetRank : MonoBehaviour
{
    public TMP_Text[] rankNickNames;
    public TMP_Text[] rankTimes;

    private void Awake(){
        getRank();
    }

    public void getRank(){
        Debug.Log("랭킹 불러오기");
        GetData();
    }

    void GetData() => StartCoroutine(GetData_Coroutine());

    IEnumerator GetData_Coroutine()
    {
        string load_uri = DataPersistenceManager.uri + "/rank";
        using(UnityWebRequest request = UnityWebRequest.Get(load_uri))
        {
            yield return request.SendWebRequest();
            if (request.isNetworkError || request.isHttpError){
                Debug.Log(request.error);
            }
            else{
                RankInfoReq[] rankInfo = JsonConvert.DeserializeObject<RankInfoReq[]>(request.downloadHandler.text);
                for(int i=0; i<3; i++){
                    rankNickNames[i].text = rankInfo[i].nickName;
                    rankTimes[i].text = rankInfo[i].time;
                }
                Cursor.lockState = CursorLockMode.None;
            }
        }
    }
}
