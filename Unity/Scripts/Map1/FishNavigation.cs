using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FishNavigation : MonoBehaviour
{
    // public GameObject Destination;
    NavMeshAgent nav;

    private void Awake()
    {
        nav = GetComponent<NavMeshAgent>();
        nav.enabled = false;
    }

    void Start()
    {
        // transform.position= Destination.transform.position;
        // nav.enabled = true;
    }
}
