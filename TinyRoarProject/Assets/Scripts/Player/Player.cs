using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public static Player Instance;

    [NonSerialized] public PlayerInput PlayerInput;
    [NonSerialized] public PlayerInteract PlayerInteract;
    [NonSerialized] public PlayerMovement PlayerMovement;

    private void Awake()
    {

        Instance = this;

        PlayerInput = GetComponent<PlayerInput>();
        PlayerInteract = GetComponent<PlayerInteract>();
        PlayerMovement = GetComponent<PlayerMovement>();
    }

}
