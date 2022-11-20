using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;

public class RigidBodyCustom : MonoBehaviour
{
   Rigidbody rb;
   public ThirdPersonController _controller;

   private void Start() {
    rb = GetComponent<Rigidbody>();
   }

   private void Update() {
    rb.AddForce(_controller.targetDirection.normalized * (_controller._speed) +
                             new Vector3(0.0f, _controller._verticalVelocity, 0.0f));
   }
    

}
