using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InventoryItem : MonoBehaviour, IDeselectHandler
{

    private bool isUsed = false;
    private Inventory inventory;
    private PickupItem item;
    private Text descriptionText;
    private GameObject deleteButton;
    private Transform deleteButtonPosition;

    [SerializeField] private string itemDescription;

    public bool IsUsed { get => isUsed; set => isUsed = value; }

    void Start()
    {
        inventory = GameObject.FindObjectOfType<Inventory>();
        descriptionText = GameObject.FindGameObjectWithTag("ItemDescriptionTag").GetComponent<Text>();
        deleteButtonPosition = GameObject.FindGameObjectWithTag("DeleteButtonPosition").transform;
        deleteButton = transform.parent.GetChild(1).gameObject;

        deleteButton.transform.position = new Vector2(deleteButtonPosition.position.x, deleteButtonPosition.position.y);
        deleteButton.SetActive(false);
    }

    public void Examine()
    {
        descriptionText.text = itemDescription;
        this.deleteButton.SetActive(true);

        GameObject[] deleteButtons;
        deleteButtons = GameObject.FindGameObjectsWithTag("DeleteButton");

        for (int i = 0; i < deleteButtons.Length; i++)
        {
            if (deleteButtons[i] == this.deleteButton)
            {
                if (isUsed)
                {
                    Debug.Log("is Used");
                    this.deleteButton.SetActive(true);
                }
                else
                {
                    deleteButtons[i].SetActive(false);
                }
            }
            else
            {
                deleteButtons[i].SetActive(false);
                Debug.Log("Set active false");
            }
        }
    }

    public void Discard()
    {
        descriptionText.text = string.Empty;
        transform.parent.transform.parent.GetComponent<Slot>().IsEmpty = true;
        Destroy(transform.parent.gameObject);
    }

    public void OnDeselect(BaseEventData eventData)
    {
        descriptionText.text = string.Empty;
    }
}
