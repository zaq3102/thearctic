using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceScript : MonoBehaviour
{
    // Start is called before the first frame update
    bool isFalling = false;
    float downSpeed = 0;
    // Vector3 InitialPosition;
 
    private void OnTriggerEnter(Collider other)
    {
        // InitialPosition = gameObject.transform.position;
        if (other.tag == "Player")
        {
            isFalling = true;
            Destroy(gameObject, 5);
        }
    }

    private void Update()
    {
        if (isFalling)
        {
            downSpeed += Time.deltaTime / 8;
            transform.position = new Vector3(transform.position.x, transform.position.y - downSpeed, transform.position.z);
        }
    }
}
