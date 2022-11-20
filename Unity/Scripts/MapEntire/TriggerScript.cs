using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TriggerScript : MonoBehaviour
{
    public PlayerInput playerInput;
    public Animator anim;
    public Bear bear;
    public GameObject panel;

    private void OnTriggerEnter(Collider other) {
        if(other.tag == "Player"){
            playerInput.enabled = false;
            if(bear.nav.isStopped) StartCoroutine(Blink());
        }
    }

    public IEnumerator Blink(){
        int cnt = 0;
        while(cnt<3){
            if(cnt == 0) yield return new WaitForSeconds(.8f);
            panel.SetActive(true);
            yield return new WaitForSeconds(.15f);
            panel.SetActive(false);
            yield return new WaitForSeconds(.15f);
            cnt++;
        }
    }
}
