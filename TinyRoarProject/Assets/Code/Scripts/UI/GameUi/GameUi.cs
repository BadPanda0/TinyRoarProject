using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameUi : MonoBehaviour
{
    public void Show()
    {
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }
}
