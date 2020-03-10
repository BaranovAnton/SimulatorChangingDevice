using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuseView : MonoBehaviour
{
    private MeshRenderer meshRenderer;

    private void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    public void SetMaterial(Material material)
    {
        meshRenderer.sharedMaterial = material;
    }
}