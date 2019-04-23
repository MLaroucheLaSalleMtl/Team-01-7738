using UnityEngine;

public class Notes : PickupItem
{
    private NoteManager noteManager;

    void Awake()
    {
        noteManager = GameObject.FindObjectOfType<NoteManager>();
        inventoryScript = GameObject.FindObjectOfType<Inventory>();
    }

    protected override void Interact()
    {
        for (int i = 0; i < inventoryScript.Slots.Length; i++)
        {
            if (inventoryScript.Slots[i].transform.Find("Notes(Clone)"))
            {
                SecondInteract();
                break;
            }
            else
            {
                if (inventoryScript.Slots[i].IsEmpty == true)
                {
                    AddItemToInventory(i);
                    SecondInteract();
                    break;
                }
                else
                {
                    StartCoroutine(DisplayText("InveNtory FuLl"));
                }
            }
        }
    }

    protected override void SecondInteract()
    {
        StartCoroutine(DisplayText(interactedText));
        noteManager.Notes.Add(gameObject);
        GetComponent<MeshRenderer>().enabled = false;
        transform.position = new Vector3(0, 0, 0);
        Invoke("DestroyObject", 1f);
    }

    void DestroyObject()
    {
        interactText.text = string.Empty;
    }
}
