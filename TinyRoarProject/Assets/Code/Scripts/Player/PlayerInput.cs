using Cinemachine;
using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    public float Horizontal { get; private set; }
    public float Vertical { get; private set; }
    public bool Interact { get; private set; }
    public Vector2 NavigationInput { get; set; }

    public event Action OnInteract = delegate { };

    public Controls _controls;

    private void Awake()
    {
        _controls = new Controls();
    }

    private void OnDestroy()
    {
        _controls.Player.Interact.performed -= OnInteractPeformed;
        _controls.Player.Movement.performed -= OnMovementPeformed;
        _controls.Player.Movement.canceled -= OnMovementCanceled;
        _controls.Player.Pause.performed -= OnPausePeformed;
        _controls.UI.Navigate.performed -= NavigatePerformed;

        _controls.Dispose();
    }

    public void EnableInput()
    {
        _controls.Enable();
        SetCameraMovement(true);
        _controls.Player.Interact.performed += OnInteractPeformed;
        _controls.Player.Movement.performed += OnMovementPeformed;
        _controls.Player.Movement.canceled += OnMovementCanceled;
        _controls.Player.Pause.performed += OnPausePeformed;
        _controls.UI.Navigate.performed += NavigatePerformed;
    }

    public void DisableMovement()
    {
        SetCameraMovement(false);
        _controls.Player.Interact.performed -= OnInteractPeformed;
        _controls.Player.Movement.performed -= OnMovementPeformed;
    }
    
    private void OnMovementPeformed(InputAction.CallbackContext value)
    {
        Horizontal = value.ReadValue<Vector2>().x;
        Vertical = value.ReadValue<Vector2>().y;
    }

    private void OnMovementCanceled(InputAction.CallbackContext value)
    {
        Horizontal = 0;
        Vertical = 0;
    }

    private void OnInteractPeformed(InputAction.CallbackContext value)
    {
        OnInteract();
    }

    private void OnPausePeformed(InputAction.CallbackContext value)
    {
        GameManager.instance.GamePaused = !GameManager.instance.GamePaused;
    }

    private void NavigatePerformed(InputAction.CallbackContext value)
    {
        NavigationInput = value.ReadValue<Vector2>();
    }

    private void SetCameraMovement(bool isEnabled)
    {
        Camera.main.GetComponent<CinemachineBrain>().enabled = isEnabled;
    }
}