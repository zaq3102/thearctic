using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MeshToCollider : MonoBehaviour
{
    SkinnedMeshRenderer meshRenderer;
    MeshCollider collider;
    Mesh bakedMesh;
   

    void Start()
    {
        meshRenderer = transform.GetComponent<SkinnedMeshRenderer>();
        collider = transform.GetComponent<MeshCollider>();
        bakedMesh = new Mesh();
        collider.sharedMesh = bakedMesh;
    }

    // Update is called once per frame
    void Update()
    {
        meshRenderer.BakeMesh(bakedMesh);
        collider.sharedMesh = bakedMesh;
    }
}
