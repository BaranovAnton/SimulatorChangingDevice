﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockView : MonoBehaviour
{
    private Material material;
    private Color defaultColor;

    private void Start()
    {
        material = GetComponent<MeshRenderer>().sharedMaterial;
        defaultColor = material.color;
    }

    public void SetColor(Color color)
    {
        material.color = color;
    }

    public void SetDefaultColor()
    {
        material.color = defaultColor;
    }
}
