using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlayerInputManager
{
    [SerializeField]
    private static bool InputEnabled = true;

    static public void SetEnabled(bool set)
    {
        InputEnabled = set;
    }

    static public bool GetEnabled()
    {
        return InputEnabled;
    }
}
