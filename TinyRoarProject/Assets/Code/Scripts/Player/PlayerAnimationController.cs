using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{

    private Animator _animator;

    public enum Parameter
    {
        SpeedF,
        IsCarryingB,
        StunnedT,
        GameOverT
    }

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void SetFloat(Parameter parameter, float value)
    {
        _animator.SetFloat(parameter.ToString(), value);
    }

    public void SetInteger(Parameter parameter, int value)
    {
        _animator.SetInteger(parameter.ToString(), value);
    }

    public void SetBool(Parameter parameter, bool isTrue)
    {
        _animator.SetBool(parameter.ToString(), isTrue);
    }

    public void SetTrigger(Parameter parameter)
    {
        _animator.SetTrigger(parameter.ToString());
    }
}
