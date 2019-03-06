using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventSystem : MonoBehaviour
{
    private bool hasMainKey = false;
    private bool beenToMainDoorOnce = false;

    public bool HasMainKey { get => hasMainKey; set => hasMainKey = value; }
    public bool BeenToMainDoorOnce { get => beenToMainDoorOnce; set => beenToMainDoorOnce = value; }
}
