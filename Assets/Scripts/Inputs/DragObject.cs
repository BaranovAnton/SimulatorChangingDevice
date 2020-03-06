using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragObject : MonoBehaviour 
{
    private Vector3 offset;
    private float zPosition;
    private PositionConstraints posConstraints;

    public void SetConstraints(float x1, float x2, float y1, float y2, float z1, float z2)
    {
        posConstraints.x = new Vector2(x1, x2);
        posConstraints.y = new Vector2(y1, y2);
        posConstraints.z = new Vector2(z1, z2);
    }

    public void StartDrag()
    {
        zPosition = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
        offset = gameObject.transform.position - GetMouseAsWorldPoint();
    }

    public void Drag()
    {
        transform.position = GetMouseAsWorldPoint() + offset;
        CheckConstraints();
    }

    private Vector3 GetMouseAsWorldPoint()
    {
        Vector3 mousePoint = Input.mousePosition;
        mousePoint.z = zPosition;

        return Camera.main.ScreenToWorldPoint(mousePoint);
    }

    private void CheckConstraints()
    {
        Vector3 newPosition = transform.localPosition;
        newPosition = new Vector3(
            Mathf.Clamp(newPosition.x, posConstraints.x.Value.x, posConstraints.x.Value.y),
            Mathf.Clamp(newPosition.y, posConstraints.y.Value.x, posConstraints.y.Value.y),
            Mathf.Clamp(newPosition.z, posConstraints.z.Value.x, posConstraints.z.Value.y));
        transform.localPosition = newPosition;

        /*Vector3 newPosition = transform.localPosition;
        newPosition = new Vector3(0.5f, Mathf.Clamp(newPosition.y, -1.5f, 0f), Mathf.Clamp(newPosition.z, 0f, 0f));
        transform.localPosition = newPosition;*/
    }
}

public struct PositionConstraints
{
    public Vector2? x;
    public Vector2? y;
    public Vector2? z;
}

public struct RotationConstraints
{
    Vector2 x;
    Vector2 y;
    Vector2 z;
}