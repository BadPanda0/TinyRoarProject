using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public float Horizontal { get; private set; }
    public float Vertical { get; private set; }
    public bool Interact { get; private set; }

    public event Action OnInteract = delegate { };

    private void Update()
    {
        Horizontal = Input.GetAxisRaw("Horizontal");
        Vertical = Input.GetAxisRaw("Vertical");
        Interact = Input.GetButtonDown("Interact");
        if (Interact)
            OnInteract();
    }
}
