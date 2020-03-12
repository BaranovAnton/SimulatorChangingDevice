using UnityEngine;

/// <summary>
/// Class for Button view
/// </summary>
public class ButtonView : MonoBehaviour
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