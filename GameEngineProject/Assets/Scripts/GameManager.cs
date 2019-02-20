using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private bool isGamePaused;
    private bool isInventory;

    [SerializeField] private GameObject[] panels;
    [SerializeField] private Selectable[] defaultOptions;

    void Start()
    {
        PanelToggle(0);
    }

    void Update()
    {
        if (Input.GetButton("Cancel"))
        {
            isGamePaused = !isGamePaused;
            Pause(isGamePaused);
        }

        if (Input.GetButton("Inventory"))
        {
            isInventory = !isInventory;

            if (isInventory)
            {
                PanelToggle(2);
            }
            else
            {
                PanelToggle(0);
            }
        }
    }

    #region PauseMenu

    void Pause(bool isGamePaused)
    {
        if (isGamePaused)
        {
            Time.timeScale = 0f;
            PanelToggle(1);
        }
        else
        {
            Time.timeScale = 1f;
            PanelToggle(0);
        }
    }

    public void ResumeButton()
    {
        isGamePaused = false;
        Pause(isGamePaused);
    }

    public void QuitButton()
    {
        Application.Quit();
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }

    #endregion

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
