using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ballStatus
{
    public static bool IsTwoPoint = false;
    public static bool IsFreeThrow = false;
    public static void statusReset()
    {
        IsTwoPoint = false;
        IsFreeThrow = false;
    }
}
