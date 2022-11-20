using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegenFishingRod : MonoBehaviour
{
    public GameObject[] rods;

    public void Regen(){
        int randomRod = Random.Range(0,4);
        rods[randomRod].SetActive(true);
    }
}