using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Networking;
using Newtonsoft.Json;
using UnityEngine.UI;
using System.Text.RegularExpressions;


public class RankTimer : MonoBehaviour
{
    bool timer_active; //버튼이 활성화 상태인지 검사.
    TMP_Text text_time; // 시간을 표시할 text
    int minutes;
    int seconds;
    
    public GameObject rankAlert;
    public TMP_InputField input;
    public TMP_Text[] rankNickNames;
    public TMP_Text[] rankTimes;

    private void Start()
    {
        text_time = GetComponent<TMP_Text>();
        SetTimerOn();
    }
    
    public void SetTimerOn() { // 버튼 활성화 메소드
        timer_active = true; 
    }

    public void SetTimerOff() { // 버튼 비활성화 메소드
        timer_active = false;
    }

    private void Update() // 바뀌는 시간을 text에 반영 해 줄 update 생명주기
    {
        if (timer_active) {
            DataPersistenceManager.instance.GetGameData.time += Time.deltaTime;
            minutes = (int)DataPersistenceManager.instance.GetGameData.time / 60;
            seconds = (int)DataPersistenceManager.instance.GetGameData.time % 60;
            text_time.text = string.Format("{0:00}:{1:00}", minutes, seconds);
            // text_time.text = time.ToString();
        }

        // if(Input.GetKeyDown(KeyCode.Alpha0)){
        //     addRank();
        // } else if(Input.GetKeyDown(KeyCode.Alpha9)){
        //     getRank();
        // }

        input.characterLimit = 10;
        input.onValueChanged.AddListener(
            (word) => input.text = Regex.Replace(word, @"[^0-9a-zA-Z가-힣]", "")
        );
    }

    public void addRank(){
        Time.timeScale = 1;
        Debug.Log("시간 저장");
        PostData();
    }

    public void getRank(){
        Debug.Log("랭킹 불러오기");
        GetData();
    }

    void PostData() => StartCoroutine(PostData_Coroutine());
    void GetData() => StartCoroutine(GetData_Coroutine());

    IEnumerator PostData_Coroutine()
    {
        RankInfoReq rankInfo = new RankInfoReq(input.text, DataPersistenceManager.instance.GetGameData.time.ToString());
        string json = JsonUtility.ToJson(rankInfo);
        string save_uri = DataPersistenceManager.uri + "/rank/add";
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
                Debug.Log(request.downloadHandler.text);
            }
        }
    }

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
                Debug.Log(request.downloadHandler.text);
                RankInfoReq[] rankInfo = JsonConvert.DeserializeObject<RankInfoReq[]>(request.downloadHandler.text);
                foreach(RankInfoReq rank in rankInfo)
                {
                    Debug.Log("결과: " + rank.time);
                }
                for(int i=0; i<3; i++){
                    rankNickNames[i].text = rankInfo[i].nickName;
                    rankTimes[i].text = rankInfo[i].time;
                }
                rankAlert.SetActive(true);
                Cursor.lockState = CursorLockMode.None;
            }
        }
    }
}
