using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using MongoDB.Driver;
using UnityEngine.Networking;

public class DataPersistenceManager : MonoBehaviour
{
    // [Header("File Storage Config")]
    // [SerializeField] private string fileName;
    
    // private const string MONGO_URI = "mongodb://thearctic:qnrrmrrhaaldksgo@thearctic.site:8088/?authMechanism=SCRAM-SHA-256";
    // private const string DATABASE_NAME = "theArctic";
    // private MongoClient client;
    // private IMongoDatabase db;

    public bool initialStart;

    public GameObject waitForLoadCanvas;
    public GameObject sceneChanger;
    public GameObject timer;

    private GameData gameData;
    public GameData GetGameData{
        get{
            return this.gameData;
        }
    }
    private List<IDataPersistence> dataPersistenceObjects;
    // private FileDataHandler dataHandler;

    public static DataPersistenceManager instance{get; private set;}
    // IMongoCollection<GameData> gameDataCollection;

    public static string uri = "https://thearctic.site:8081";

    private void Awake(){
        if(instance != null){
            Debug.LogError("Found more than one Data Persistence Manager in the scene.");
        }
        instance = this;

        /************** start by file **************/
        // this.dataHandler = new FileDataHandler(Application.persistentDataPath, fileName);
        // this.dataPersistenceObjects = FindAllDataPersistenceObjects();
        /*******************************************/

        /************** start by mongoDB **************/
        // this.dataPersistenceObjects = FindAllDataPersistenceObjects();
        // client = new MongoClient(MONGO_URI);
        // db = client.GetDatabase(DATABASE_NAME);
        // gameDataCollection = db.GetCollection<GameData>("GameData");
        // StartCoroutine(GetIp());
        /*******************************************/

        /************** start by backend **************/
        this.dataPersistenceObjects = FindAllDataPersistenceObjects();
        if(initialStart){
            NewGame();
            LoadGame();
            SaveGame();
            timer.SetActive(true);
        } else{
            GetData();
        }
        /*******************************************/

    }

    private void Start(){
        
        
    }

    public void NewGame(){
        this.gameData = new GameData();
    }

    public void LoadGame(){
        /************** load by file **************/
        // // Load any saved datat from a file using the data handler
        // this.gameData = dataHandler.Load();
        
        // //if no data can be loaded, initialize to a new game
        // if(this.gameData == null){
        //     Debug.Log("No data was found. Initializing data to defaults");
        //     NewGame();
        // }

        // // push the loaded data to all other scripts that need it
        // foreach(IDataPersistence dataPersistenceObj in dataPersistenceObjects){
        //     dataPersistenceObj.LoadData(gameData);
        // }
        /*****************************************/

        /************** load by mongoDB **************/
        // this.gameData = gameDataCollection.Find(data => data.id.Equals(myIp)).SingleOrDefault();
        // if(this.gameData == null){
        //     NewGame();
        // }

        // foreach(IDataPersistence dataPersistenceObj in dataPersistenceObjects){
        //     dataPersistenceObj.LoadData(gameData);
        // }
        /*****************************************/

        /************** load by backend **************/
        // this.gameData = gameDataCollection.Find(data => data.id.Equals(myIp)).SingleOrDefault();
        // if(this.gameData == null){
        //     Debug.Log("없는데??");
        //     NewGame();
        // }

        // Debug.Log("데이터 출력: " + this.gameData.id);
        if(this.gameData == null){
            NewGame();
        }
        foreach(IDataPersistence dataPersistenceObj in dataPersistenceObjects){
            dataPersistenceObj.LoadData(gameData);
        }

        sceneChanger.SetActive(true);
        waitForLoadCanvas.SetActive(false);

        if(gameData.isInit){
            Debug.Log("처음부터 했음!!");
            timer.SetActive(true);
        } else{
            Debug.Log("이어했음");
            timer.SetActive(false);
        }
        /*****************************************/
    }

    public void SaveGame(){
        /************** save by file **************/
        // // pass the data to other scripts so they can update it
        // foreach(IDataPersistence dataPersistenceObj in dataPersistenceObjects){
        //     dataPersistenceObj.SaveData(ref gameData);
        // }

        // // save that data to a file using the data handler
        // dataHandler.Save(gameData);
        /*****************************************/

        /************** save by mongoDB **************/
        // foreach(IDataPersistence dataPersistenceObj in dataPersistenceObjects){
        //     dataPersistenceObj.SaveData(ref gameData);
        // }
        // if(gameDataCollection.Find(data => data.id.Equals(myIp)).SingleOrDefault() == null){
        //     gameDataCollection.InsertOne(this.gameData);
        // } else{
        //     gameDataCollection.FindOneAndReplace(data => data.id == myIp, this.gameData);
        // }
        /*****************************************/

         /************** save by mongoDB **************/
        foreach(IDataPersistence dataPersistenceObj in dataPersistenceObjects){
            dataPersistenceObj.SaveData(ref gameData);
        }
        PostData();
        /*****************************************/
    }

    // private void OnApplicationQuit(){
    //     SaveGame();
    // }

    private List<IDataPersistence> FindAllDataPersistenceObjects(){
        IEnumerable<IDataPersistence> dataPersistenceObjects = FindObjectsOfType<MonoBehaviour>().OfType<IDataPersistence>();

        return new List<IDataPersistence>(dataPersistenceObjects);
    }

    void PostData() => StartCoroutine(PostData_Coroutine());
    void GetData() => StartCoroutine(GetData_Coroutine());

    IEnumerator PostData_Coroutine()
    {
        string json = JsonUtility.ToJson(gameData);
        string save_uri = uri + "/gamedata/save";
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
        string load_uri = uri + "/gamedata/load";
        using(UnityWebRequest request = UnityWebRequest.Get(load_uri))
        {
            yield return request.SendWebRequest();
            if (request.isNetworkError || request.isHttpError){
                Debug.Log(request.error);
            }
            else{
                this.gameData = GameData.Parse(request.downloadHandler.text);
                LoadGame();
            }
        }
    }
}
