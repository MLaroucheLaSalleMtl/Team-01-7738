using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainHouseDoor : Doors
{
    private AsyncOperation async;

    protected override void Interact()
    {
        if (key.KeyPickedUp)
            OpenMainDoor();
        else
            StartCoroutine(DisplayText("You neEd to fiNd the KEy"));
    }

    void OpenMainDoor()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        async = SceneManager.LoadSceneAsync(currentScene.buildIndex + 1);
        async.allowSceneActivation = true;
    }

    protected override IEnumerator OpenDoor()
    {
        yield return new WaitForSeconds(0);
    }
}
