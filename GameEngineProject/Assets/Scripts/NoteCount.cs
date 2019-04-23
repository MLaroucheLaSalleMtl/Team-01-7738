using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NoteCount : MonoBehaviour
{
    private NoteManager noteManager;

    void Start()
    {
        noteManager = GameObject.FindObjectOfType<NoteManager>();
    }

    void Update()
    {
        GetComponent<Text>().text = $" {noteManager.Notes.Count.ToString()}/5";
    }
}
