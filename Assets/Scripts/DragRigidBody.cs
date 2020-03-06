using UnityEngine;

public class DragRigidBody : MonoBehaviour
{
    float factor = 15.0f;
    float minRot = 0.0f;
    float maxRot = 90.0f;

    private float startRot;
    private float currRot;

    private Vector3 offset;
    private float zPosition;

    void OnMouseDown()
    {
        zPosition = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
        offset = gameObject.transform.position - GetMouseAsWorldPoint();
    }

    void OnMouseDrag()
    {
        var delta = GetMouseAsWorldPoint() + offset;
        currRot = startRot - delta.x * factor + delta.y * factor + delta.z * factor;
        currRot = Mathf.Clamp(currRot, minRot, maxRot);
        transform.parent.eulerAngles = new Vector3(0.0f, 0.0f, currRot);
    }

    private Vector3 GetMouseAsWorldPoint()
    {
        Vector3 mousePoint = Input.mousePosition;
        mousePoint.z = zPosition;

        return Camera.main.ScreenToWorldPoint(mousePoint);
    }
}