﻿/// <summary>
/// Device available or not for interaction
/// </summary>
public class LockAvailable
{
    public enum LockAvailableEnum { enamble, disable };
}

/// <summary>
/// Latch (or similar device) locked or unlocked
/// </summary>
public class LockStates
{
    public enum LockStateEnum { locked, unlocked };
}

/// <summary>
/// Cover (or similar device) opened or closed
/// </summary>
public class OpenStates
{
    public enum OpenStateEnum { opened, closed };
}

/// <summary>
/// Button (or similar device) released or pressed
/// </summary>
public class ButtonStates
{
    public enum ButtonStateEnum { released, pressed };
}