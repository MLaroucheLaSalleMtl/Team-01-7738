using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventSystem : MonoBehaviour
{
    private static bool[] keys;
    private static bool hasMainKey = false;
    private static bool hasCloseKey = false;
    private static bool beenToMainDoorOnce = false;

    public static bool HasMainKey { get => hasMainKey; set => hasMainKey = value; }
    public static bool BeenToMainDoorOnce { get => beenToMainDoorOnce; set => beenToMainDoorOnce = value; }
    public static bool HasCloseKey { get => hasCloseKey; set => hasCloseKey = value; }
    public static bool[] Keys { get => keys; set => keys = value; }

    private void Start()
    {
        Keys = new bool[] {hasCloseKey, hasMainKey};
        beenToMainDoorOnce = false;
    }
}
