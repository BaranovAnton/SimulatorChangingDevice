using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragObject : MonoBehaviour 
{
    private Vector3 offset;
    private float zPosition;
    private Vector2 xConstraints, yConstraints, zConstraints;

    public void SetConstraints(Vector2 x, Vector2 y, Vector2 z)
    {
        xConstraints = x;
        yConstraints = y;
        zConstraints = z;
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
            Mathf.Clamp(newPosition.x, xConstraints.x, xConstraints.y),
            Mathf.Clamp(newPosition.y, yConstraints.x, yConstraints.y),
            Mathf.Clamp(newPosition.z, zConstraints.x, zConstraints.y));
        transform.localPosition = newPosition;
    }
}