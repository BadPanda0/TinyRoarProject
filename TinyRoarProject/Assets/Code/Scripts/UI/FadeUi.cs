using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeUi : MonoBehaviour
{
    public static FadeUi instance;

    private Animator _animator;
    private SceneLoader.Scene _sceneToLoad;

    private void Awake()
    {
        instance = this;

        _animator = GetComponent<Animator>();
    }

    public void FadeToLevel(SceneLoader.Scene scene)
    {
        _sceneToLoad = scene;

        _animator.SetTrigger("FadeOut");
    }

    public void OnFadeComplete()
    {
        SceneLoader.Load(_sceneToLoad);
    }
}
