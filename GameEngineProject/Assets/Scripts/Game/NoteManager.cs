using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteManager : MonoBehaviour
{
    private List<GameObject> notes;

    public List<GameObject> Notes { get => notes; set => notes = value; }

    void Start()
    {
        notes = new List<GameObject>();
    }
}
