using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public static Player Instance;

    public PlayerInput PlayerInput;
    public PlayerInteract PlayerInteract;
    public PlayerMovement PlayerMovement;

    private void Awake()
    {

        Instance = this;

        PlayerInput = GetComponent<PlayerInput>();
        PlayerInteract = GetComponent<PlayerInteract>();
        PlayerMovement = GetComponent<PlayerMovement>();
    }

}
