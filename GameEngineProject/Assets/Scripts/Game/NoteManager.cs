using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteManager : MonoBehaviour
{
    private List<GameObject> notes;

    private bool hasFiveNote = false;

    public List<GameObject> Notes { get => notes; set => notes = value; }
    public bool HasFiveNote { get => hasFiveNote; set => hasFiveNote = value; }

    void Start()
    {
        notes = new List<GameObject>();
    }

    void Update()
    {
        if (notes.Count == 5)
        {
            hasFiveNote = true;
        }    
    }
}
