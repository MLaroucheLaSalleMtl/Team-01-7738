using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slot : MonoBehaviour
{
    [SerializeField] private bool isEmpty;

    public bool IsEmpty { get => isEmpty; set => isEmpty = value; }
}

