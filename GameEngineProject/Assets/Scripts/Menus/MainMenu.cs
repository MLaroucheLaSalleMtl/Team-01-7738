using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject[] panels;
    [SerializeField] private Selectable[] defaultOptions;

    private void Start()
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
