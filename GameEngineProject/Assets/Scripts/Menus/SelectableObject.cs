using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SelectableObject : MonoBehaviour, IPointerEnterHandler, IDeselectHandler, ISelectHandler
{
    private bool isSelected;

    [SerializeField] private AudioSource selectedSound;

    public bool IsSelected { get => isSelected; set => isSelected = value; }

    public void OnPointerEnter(PointerEventData eventData)
    {
        GetComponent<Selectable>().Select();
    }

    public void OnDeselect(BaseEventData eventData)
    {
        GetComponent<Selectable>().OnPointerExit(null);
        isSelected = false;
    }

    public void OnSelect(BaseEventData eventData)
    {
        isSelected = true;
        //selectedSound.Play();
    }
}
