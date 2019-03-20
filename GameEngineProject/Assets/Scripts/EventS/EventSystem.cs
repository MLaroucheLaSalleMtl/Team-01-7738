using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventSystem : MonoBehaviour
{
    bool event1 = false;
    bool event2 = false;

    [SerializeField] private Keys[] keys;

    public bool Event1 { get => event1; set => event1 = value; }
    public bool Event2 { get => event2; set => event2 = value; }

    void Update()
    {
        if (keys[0].KeyPickedUp)
        {
            event1 = true;
        }

        if (keys[1].KeyPickedUp)
        {
            event2 = true;
        }
    }
}
