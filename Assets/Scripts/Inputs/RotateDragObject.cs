using UnityEngine;

/// <summary>
/// Class for objects which are rotating when draggable
/// </summary>
public class RotateDragObject : DragObject
{
    private const float factor = 15.0f; // rotation sensetivity (TODO: need to setting)
    private float currRot;

    public override void Drag()
    {
        var delta = GetMouseAsWorldPoint() + offset;
        currRot = - delta.x * factor + delta.y * factor + delta.z * factor;
        currRot = Mathf.Clamp(currRot, (zConstraints.x < zConstraints.y)? zConstraints.x : zConstraints.y, 
                                       (zConstraints.x > zConstraints.y)? zConstraints.x : zConstraints.y);
        transform.parent.eulerAngles = new Vector3(transform.parent.eulerAngles.x, transform.parent.eulerAngles.y, currRot);
    }
}