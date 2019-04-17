using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    [SerializeField] private Slot[] slots;
    [SerializeField] private GameObject[] items;
    [SerializeField] private GameObject[] panels;
    [SerializeField] private Selectable[] defaultOptions;

    public Slot[] Slots { get => slots; set => slots = value; }

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
