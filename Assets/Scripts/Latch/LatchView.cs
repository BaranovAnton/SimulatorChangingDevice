using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LatchView : MonoBehaviour
{
    private Material material;

    private void Start()
    {
        material = GetComponent<MeshRenderer>().sharedMaterial;
    }

    public void SetMaterial(Material material)
    {
        this.material = material;
    }
}