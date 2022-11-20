using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cylinderTrigger : MonoBehaviour
{
    public Transform respawnPoint;
    public Transform respawnPoint1;
    public Transform respawnPoint2;
    public Transform respawnPoint3;
    public bool check1 = false;
    public bool check2 = false;
    public bool check3 = false;


    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            
            player.SetActive(false);
            if (check3)
            {
                player.transform.position = respawnPoint3.position;
                player.SetActive(true);
                return;

            }
            if (check2)
            {
                player.transform.position = respawnPoint2.position;
                player.SetActive(true);
                return;
            }else if (check1)
            {
                player.transform.position = respawnPoint1.position;
                player.SetActive(true);
                return;
            }
            else
            {
                player.transform.position = respawnPoint.position;
                player.SetActive(true);
                return;

            }
          

        }
    }
    public void save1()
    {
        check1 = true;
    }

    public void save2()
    {
        check2 = true;
    }

    public void save3()
    {
        check3 = true;
    }

    public void reset()
    {
        check1 = false;
        check2 = false;
        check3 = false;
    }
}
