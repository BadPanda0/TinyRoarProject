using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UiInteractableHandler : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, ISelectHandler, IDeselectHandler
{

    [SerializeField] public UiInteractableSelectorManager UiInteractableSelectorManager;

    public void OnPointerEnter(PointerEventData eventData)
    {
        eventData.selectedObject = gameObject;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        eventData.selectedObject = null;
    }

    public void OnSelect(BaseEventData eventData)
    {
        UiInteractableSelectorManager.LastSelected = gameObject;

        for(int i = 0; i < UiInteractableSelectorManager.Interactables.Length; i++) 
        {
            if (UiInteractableSelectorManager.Interactables[i] == gameObject)
            {
                UiInteractableSelectorManager.LastSelectedIndex = i;
                return;
            }
        }
    }

    public void OnDeselect(BaseEventData eventData)
    {

    }
}
