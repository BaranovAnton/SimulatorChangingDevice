/// <summary>
/// Класс описывающий состояние разблокировано/заблокировано
/// он же может использоваться для создания ограничений перемещения/поворота объекта
/// задаётся ось и два значения для неё
/// </summary>
public class LockConstraints
{
    public enum LockAxis { x, y, z };
    public LockAxis axis;

    public float lockedValue; // для простых ограничений, это значение используется как minValue
    public float unlockedValue; // для простых ограничений, это значение используется как maxValue

    public LockConstraints(LockAxis axis, float lockedValue, float unlockedValue)
    {
        this.axis = axis;
        this.lockedValue = lockedValue;
        this.unlockedValue = unlockedValue;
    }
}