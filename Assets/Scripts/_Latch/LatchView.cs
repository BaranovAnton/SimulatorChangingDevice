using UnityEngine;

/// <summary>
/// Class for Latch view
/// </summary>
public class LatchView : MonoBehaviour
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