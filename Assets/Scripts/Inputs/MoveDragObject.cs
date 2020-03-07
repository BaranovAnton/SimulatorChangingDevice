using UnityEngine;

public class MoveDragObject : DragObject 
{
    public override void Drag()
    {
        transform.position = GetMouseAsWorldPoint() + offset;
        CheckConstraints();
    }

    private void CheckConstraints()
    {
        Vector3 newPosition = transform.localPosition;
        newPosition = new Vector3(
            Mathf.Clamp(newPosition.x, xConstraints.x, xConstraints.y),
            Mathf.Clamp(newPosition.y, yConstraints.x, yConstraints.y),
            Mathf.Clamp(newPosition.z, zConstraints.x, zConstraints.y));
        transform.localPosition = newPosition;
    }
}