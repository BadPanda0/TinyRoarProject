using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CountdownUi : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _countdownText;

    public void UpdateText(float time)
    {
        _countdownText.text = Mathf.Ceil(time).ToString();
    }

    public void HideText()
    {
        gameObject.SetActive(false);
    }

    public void ShowText()
    {
        gameObject.SetActive(true);
    }
}
