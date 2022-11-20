using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoxTrigger : MonoBehaviour
{
    public GameObject[] foxes = new GameObject[2];

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "Player"){
            foxes[0].GetComponent<Animator>().SetBool("isIdle", true);
            StartCoroutine(waitToWakeup(foxes[1].GetComponent<Animator>()));
        }
    }

    private void OnTriggerExit(Collider other) {
        if(other.gameObject.tag == "Player"){
            foxes[1].GetComponent<Animator>().SetBool("isIdle", false);
            StartCoroutine(waitToSleep(foxes[0].GetComponent<Animator>()));
        }
    }

    IEnumerator waitToWakeup(Animator anim){
        yield return new WaitForSeconds(1f);
        anim.SetBool("isIdle", true);
    }

    IEnumerator waitToSleep(Animator anim){
        yield return new WaitForSeconds(1.3f);
        anim.SetBool("isIdle", false);
    }
}
