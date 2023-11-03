using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UiInteractableSelectorManager : MonoBehaviour
{
    public static UiInteractableSelectorManager Instance;

    public GameObject[] Interactables;

    public GameObject LastSelected;

    public int LastSelectedIndex;

    private void Awake()
    {
        Instance = this;
    }

    private void OnEnable()
    {
        StartCoroutine(SetSelectedAfterOneFrame());
    }

    private void Update()
    {
        if (Player.Instance.PlayerInput.NavigationInput.x > 0 )
        {
            HandleNextInteractableSelection(1);
        }

        if (Player.Instance.PlayerInput.NavigationInput.y > 0)
        {
            HandleNextInteractableSelection(-1);
        }
    }

    private IEnumerator SetSelectedAfterOneFrame() 
    {
        yield return null;
        EventSystem.current.SetSelectedGameObject(Interactables[0]);
    }

    private void HandleNextInteractableSelection(int addition)
    {
        if(EventSystem.current.currentSelectedGameObject == null && LastSelected != null)
        {
            int newIndex = LastSelectedIndex + addition;
            newIndex = Mathf.Clamp(newIndex, 0, Interactables.Length - 1);
            EventSystem.current.SetSelectedGameObject(Interactables[newIndex]);
        }
    }
}
