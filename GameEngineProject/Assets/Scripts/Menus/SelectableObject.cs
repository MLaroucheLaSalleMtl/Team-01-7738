using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SelectableObject : MonoBehaviour, IPointerEnterHandler, IDeselectHandler, ISelectHandler
{
    private AudioSource selectedSound;

    public void OnPointerEnter(PointerEventData eventData)
    {
        GetComponent<Selectable>().Select();
    }

    public void OnDeselect(BaseEventData eventData)
    {
        GetComponent<Selectable>().OnPointerExit(null);
    }

    public void OnSelect(BaseEventData eventData)
    {
        //selectedSound.Play();
    }
}
