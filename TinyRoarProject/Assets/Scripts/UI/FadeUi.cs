using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeUi : MonoBehaviour
{
    [SerializeField] private CanvasGroup _canvasGroup;

    private bool _fadeIn;
    private bool _fadeOut;

    private void Awake()
    {
        if(gameObject.activeSelf)
            _canvasGroup.alpha = 1.0f;
        else
            _canvasGroup.alpha = 0.0f;
    }
    public void Show()
    {
        gameObject.SetActive(true);
        _canvasGroup.alpha = 0;
        _fadeIn = true;
    }

    public void Hide()
    {
        gameObject.SetActive(true);
        _canvasGroup.alpha = 1;
        _fadeOut = true;
    }

    private void Update()
    {
        if (_fadeIn)
        {
            _canvasGroup.alpha += Time.deltaTime;
            if (_canvasGroup.alpha >= 1)
            {
                _fadeIn = false;
            }
        }
        if (_fadeOut)
        {
            _canvasGroup.alpha -= Time.deltaTime;
            if (_canvasGroup.alpha <= 0)
            {
                _fadeOut = false;
            }
        }
    }
}
