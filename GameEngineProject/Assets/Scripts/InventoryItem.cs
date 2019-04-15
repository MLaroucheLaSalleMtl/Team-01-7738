using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InventoryItem : MonoBehaviour, ISelectHandler, IDeselectHandler
{
    private Inventory inventory;
    private PickupItem item;
    private Text descriptionText;
    private GameObject deleteButton;
    private Transform deleteButtonPosition;
    private int index;

    [SerializeField] private string itemDescription;

    //public int Index { get => index; set => index = value; }

    public InventoryItem(int index)
    {
        this.index = index;
    }

    void Start()
    {
        inventory = GameObject.FindObjectOfType<Inventory>();
        descriptionText = GameObject.FindGameObjectWithTag("ItemDescriptionTag").GetComponent<Text>();
        deleteButtonPosition = GameObject.FindGameObjectWithTag("DeleteButton").transform;
        deleteButton = transform.GetChild(0).gameObject;

        deleteButton.transform.position = new Vector2(deleteButtonPosition.position.x, deleteButtonPosition.position.y);
        deleteButton.SetActive(false);

        Debug.Log(index);
    }

    public void Examine()
    {
        descriptionText.text = itemDescription;
    }

    public void Discard()
    {
        //inventory.IsOccupied[index] = false;
        Destroy(gameObject);
    }

    public void OnSelect(BaseEventData eventData)
    {
        deleteButton.SetActive(true);
    }

    public void OnDeselect(BaseEventData eventData)
    {
        deleteButton.SetActive(false);
    }

}
