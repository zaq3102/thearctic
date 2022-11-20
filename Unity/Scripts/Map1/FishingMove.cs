using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FishingMove : MonoBehaviour
{
    float rightMax = 300.0f; 
    float leftMax = -300.0f;
    float currentPosition_x;
    float currentPosition_y;
    float currentPosition_z;
    Vector3 currentPosition;
    Vector2 startPosition;
    float direction = 1200.0f;

    public bool stopped = false;
    public bool restarted = false;

    public RectTransform rectTransform;

    public GameObject user;
    UserInfo userInfo;

    public GameObject rodHealth;
    RodHealth rodHealthScript;

    public GameObject getGarbage;
    public GameObject getFish;

    public GameObject fishingCenter;
    public GameObject fishingLeft;
    public GameObject fishingRight;
    public GameObject fishUI;
    public GameObject itemRod;

    public GameObject fishingRodGenerator;
    RegenFishingRod regenFishingRod;

    FishingSpotRange fishingSpotRange;
    public GameObject fishingSpot;

    public GameObject holdingFishingRod;

    // public Vector3 getPosition()
    //     {
    //         Camera cam = Camera.main;
    //         // GameObject canvasOverlayObject = GameObject.Find("CanvasOverlay");
    //         Canvas canvas = canvasOverlayObject.GetComponent<Canvas>();

    //         Vector3 rawPosition = Camera.main.ScreenToWorldPoint(gameObject.transform.position);

    //         return rawPosition;
    //     }

    private void Awake()
    {
        userInfo = user.GetComponent<UserInfo>();
        regenFishingRod = fishingRodGenerator.GetComponent<RegenFishingRod>();
        fishingSpotRange = fishingSpot.GetComponent<FishingSpotRange>();
        rodHealthScript = rodHealth.GetComponent<RodHealth>();
    }

    void Start()
    {
        rectTransform = this.GetComponent<RectTransform>();
        currentPosition = rectTransform.anchoredPosition;
        startPosition = rectTransform.anchoredPosition;
        currentPosition_x = currentPosition.x;
        currentPosition_y = currentPosition.y;
        currentPosition_z = currentPosition.z;
        rectTransform.anchoredPosition = startPosition;
    }

    void Update()
    {
        if (stopped)
        {
            if (rectTransform.anchoredPosition != startPosition && Input.GetKeyDown(KeyCode.Space))
            {
                fishingLeft.gameObject.SetActive(true);
                fishingRight.gameObject.SetActive(true);
                getGarbage.gameObject.SetActive(false);
                rectTransform.anchoredPosition = startPosition;
                transform.eulerAngles = new Vector3(0,0,0);
                fishUI.gameObject.SetActive(true);
            }
            else if (rectTransform.anchoredPosition == startPosition && Input.GetKeyDown(KeyCode.Space))
            {
                // user.GetComponent<Animator>().SetTrigger("isFishing");
                direction = 1200.0f;
                stopped = false;
            }
        }
        else
        {
            currentPosition_x = rectTransform.anchoredPosition.x;
            currentPosition_x += Time.deltaTime * direction;
            if (currentPosition_x >= rightMax)
            {
                direction *= -1;
                currentPosition_x = rightMax;
                transform.Rotate(0, 180, 0, Space.Self);
            }

            else if (currentPosition_x <= leftMax)
            {
                direction *= -1;
                currentPosition_x = leftMax;
                transform.Rotate(0, 180, 0, Space.Self);
            }

            rectTransform.anchoredPosition = new Vector3(currentPosition_x, currentPosition_y, currentPosition_z);

            if (Input.GetKeyDown(KeyCode.Space))
            {   
                direction = 0;
                stopped = true;
                if (rectTransform.anchoredPosition.x >= -90 && rectTransform.anchoredPosition.x <= 90)
                {
                    fishUI.gameObject.SetActive(false);
                    Debug.Log("fishing success");
                    user.GetComponent<Animator>().SetTrigger("isCatching");
                    int fishOrGarbage = Random.Range(1, 6);
                    int garbageCount = fishingSpotRange.garbageCount;
                    if (fishOrGarbage == 1 || garbageCount >= 9)
                    {
                        fishingSpotRange.EndGame();
                    } else
                    {
                        fishingSpotRange.PauseGame();
                    }
                }
                else
                {
                    Debug.Log("fishing failed");
                    if (userInfo.fishFailCount == 0)
                    {
                        userInfo.fishFailCount = 1;
                        rodHealthScript.HealthBarFiller(2/3f);
                    }
                    else if (userInfo.fishFailCount == 1)
                    {
                        userInfo.fishFailCount = 2;
                        rodHealthScript.HealthBarFiller(1/3f);
                    }
                    else if (userInfo.fishFailCount == 2)
                    {
                        fishingSpotRange.isFishingStarted = false;
                        userInfo.fishFailCount = 0;
                        rodHealthScript.HealthBarFiller(1f);
                        fishingCenter.gameObject.SetActive(false);
                        fishingLeft.gameObject.SetActive(false);
                        fishingRight.gameObject.SetActive(false);
                        fishUI.gameObject.SetActive(false);
                        getGarbage.gameObject.SetActive(false);
                        getFish.gameObject.SetActive(false);
                        itemRod.gameObject.SetActive(false);
                        holdingFishingRod.gameObject.SetActive(false);
                        userInfo.isRod = false;
                        regenFishingRod.Regen();
                        user.GetComponent<Animator>().Rebind();
                    }
                }
            }
        }
    }
}