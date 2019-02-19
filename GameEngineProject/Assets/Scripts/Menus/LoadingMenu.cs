using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class LoadingMenu : MonoBehaviour
{
    private bool ready = false;

    private AsyncOperation async;

    [SerializeField] private bool waitForInput = false;
    [SerializeField] private float delay = 0.0f;
    [SerializeField] private int sceneToLoad = -1;

    [SerializeField] private Image progressBar;
    //[SerializeField] private Text interacText;

    // Use this for initialization
    void Start()
    {
        Time.timeScale = 1f; //Reset the timescale
        Input.ResetInputAxes(); //Reset the intput
        System.GC.Collect(); //Clean the gargabe
        Scene currentScene = SceneManager.GetActiveScene();

        if (sceneToLoad == -1)
            async = SceneManager.LoadSceneAsync(currentScene.buildIndex + 1); //Load the following scene
        else
            async = SceneManager.LoadSceneAsync(sceneToLoad); //Load the following scene

        async.allowSceneActivation = false; // Wait before moving to next scene

        //interacText.enabled = false;

        if (!waitForInput)
            Invoke("Activate", delay);
    }

    // Update is called once per frame
    void Update()
    {
        /*if (async.progress >= 0.89)
            interacText.enabled = true;*/

        if (waitForInput && Input.anyKey)
            if (async.progress >= 0.89 && SplashScreen.isFinished)
            {
                ready = true;
            }

        if (progressBar)
            progressBar.fillAmount = async.progress + 0.1f;

        if (async.progress >= 0.89 && SplashScreen.isFinished && ready) //Check id loading is done
            async.allowSceneActivation = true; //Move to the next Scene            
    }

    void Activate()
    {
        ready = true;
    }
}
