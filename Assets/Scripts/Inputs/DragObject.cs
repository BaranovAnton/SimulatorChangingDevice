using UnityEngine;

/// <summary>
/// Base class for draggable objects
/// </summary>
public abstract class DragObject : MonoBehaviour
{
    // offset mouse start position and object pivot
    protected Vector3 offset;
    protected float zPosition;
    // moving constraints
    protected Vector2 xConstraints, yConstraints, zConstraints;

    private bool useConstraints = true;
    public bool UseConstraints { get => useConstraints; set => useConstraints = value; }

    public void SetConstraints(Vector2 x, Vector2 y, Vector2 z)
    {
        xConstraints = x;
        yConstraints = y;
        zConstraints = z;
    }

    // when drag starting
    public virtual void StartDrag()
    {
        zPosition = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
        offset = gameObject.transform.position - GetMouseAsWorldPoint();
    }

    // drag in process
    public virtual void Drag() { }

    // convert screen mouse coordinates to world
    protected Vector3 GetMouseAsWorldPoint()
    {
        Vector3 mousePoint = Input.mousePosition;
        mousePoint.z = zPosition;

        return Camera.main.ScreenToWorldPoint(mousePoint);
    }
}