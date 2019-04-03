using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    [SerializeField] private bool[] isOccupied;
    [SerializeField] private GameObject[] items;
    [SerializeField] private GameObject[] panels;
    [SerializeField] private Selectable[] defaultOptions;

    public bool[] IsOccupied { get => isOccupied; set => isOccupied = value; }
    public GameObject[] Items { get => items; set => items = value; }

    void Start()
    {
        PanelToggle(0);  
    }

    public void PanelToggle(int position)
    {
        Input.ResetInputAxes();

        for (int i = 0; i < panels.Length; i++)
        {
            panels[i].SetActive(position == i);

            if (position == i)
                defaultOptions[i].Select();
        }
    }
}
