using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainHospitalDoor : Doors
{
    private NoteManager noteManager;
    private AsyncOperation async;

    // Start is called before the first frame update
    void Start()
    {
        noteManager = FindObjectOfType<NoteManager>();
    }


    protected override void Interact()
    {
        if (noteManager.HasFiveNote)
        {
            StartCoroutine(DisplayText(interactedText));
            Invoke("SecondInteract", 3f);

        }
        else
            StartCoroutine(DisplayText("..."));
    }

    protected override void SecondInteract()
    {
        OpenMainDoor();
    }

    void OpenMainDoor()
    {
        animator.SetBool("FadeIn/Out", true);
        Scene currentScene = SceneManager.GetActiveScene();
        async = SceneManager.LoadSceneAsync(0);
        async.allowSceneActivation = true;
    }

    protected override IEnumerator OpenDoor()
    {
        yield return new WaitForSeconds(0);
    }
}
