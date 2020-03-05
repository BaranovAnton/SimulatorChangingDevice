using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LatchView : MonoBehaviour
{
    private Material material;
    private Animator animator;

    private void Start()
    {
        material = GetComponent<MeshRenderer>().sharedMaterial;
        animator = GetComponent<Animator>();
    }

    public void SetColor(Color color)
    {
        material.color = color;
    }

    public void PlayAnimation(string triggerName)
    {
        animator.SetTrigger(triggerName);
    }
}
