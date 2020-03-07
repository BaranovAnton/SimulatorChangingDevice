using UnityEngine;

public class RotateDragObject : DragObject
{
    private float factor = 15.0f;

    private float startRot;
    private float currRot;

    public override void Drag()
    {
        var delta = GetMouseAsWorldPoint() + offset;
        currRot = startRot - delta.x * factor + delta.y * factor + delta.z * factor;
        currRot = Mathf.Clamp(currRot, xConstraints.x, xConstraints.y);
        transform.parent.eulerAngles = new Vector3(0.0f, 0.0f, currRot);
    }
}