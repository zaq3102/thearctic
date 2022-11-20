using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public PlayerInput playerInput;
    public Bear bear;

    private void OnControllerColliderHit(ControllerColliderHit hit) {
        // if(hit.gameObject.tag == "Bear"){
            Debug.Log("멈추잉");
            playerInput.enabled = false;
        // }
    }
}
