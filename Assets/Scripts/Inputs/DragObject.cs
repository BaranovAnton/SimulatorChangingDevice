using UnityEngine;

public abstract class DragObject : MonoBehaviour
{
    protected Vector3 offset;
    protected float zPosition;
    protected Vector2 xConstraints, yConstraints, zConstraints;

    private bool useConstraints = true;
    public bool UseConstraints { get => useConstraints; set => useConstraints = value; }

    public void SetConstraints(Vector2 x, Vector2 y, Vector2 z)
    {
        xConstraints = x;
        yConstraints = y;
        zConstraints = z;
    }

    public virtual void StartDrag()
    {
        zPosition = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
        offset = gameObject.transform.position - GetMouseAsWorldPoint();
    }

    public virtual void Drag() { }

    protected Vector3 GetMouseAsWorldPoint()
    {
        Vector3 mousePoint = Input.mousePosition;
        mousePoint.z = zPosition;

        return Camera.main.ScreenToWorldPoint(mousePoint);
    }
}