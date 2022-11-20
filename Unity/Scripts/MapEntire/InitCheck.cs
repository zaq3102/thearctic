using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class InitCheck : MonoBehaviour
{
    GameData gameData;

    public void IsInitFalse(){
        GetData();
    }

    void PostData() => StartCoroutine(PostData_Coroutine());
    void GetData() => StartCoroutine(GetData_Coroutine());

    IEnumerator PostData_Coroutine()
    {
        string json = JsonUtility.ToJson(gameData);
        string save_uri = "https://thearctic.site:8081/gamedata/save";
        using(UnityWebRequest request = UnityWebRequest.Post(save_uri, json))
        {
            byte[] jsonToSend = new System.Text.UTF8Encoding().GetBytes(json);
            request.uploadHandler = new UploadHandlerRaw(jsonToSend);
            request.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
            request.SetRequestHeader("Content-Type", "application/json");
            yield return request.SendWebRequest();
            if (request.isNetworkError || request.isHttpError){
                Debug.Log(request.error);
            }
            else{
                // outputArea.text = request.downloadHandler.text;
                Debug.Log(request.downloadHandler.text);
            }
        }
    }

    IEnumerator GetData_Coroutine()
    {
        string load_uri = "https://thearctic.site:8081/gamedata/load";
        using(UnityWebRequest request = UnityWebRequest.Get(load_uri))
        {
            yield return request.SendWebRequest();
            if (request.isNetworkError || request.isHttpError){
                Debug.Log(request.error);
            }
            else{
                this.gameData = GameData.Parse(request.downloadHandler.text);
                if(gameData == null){
                    this.gameData = new GameData();
                }

                gameData.isInit = false;
                PostData();
            }
        }
    }
}
