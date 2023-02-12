using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInput : MonoBehaviour
{
    public event EventHandler OnInteractAction;
    public event EventHandler OnInteractAlternateAction;

    private PlayerInputActions playerInputAcions;

    private void Awake()
    {
        playerInputAcions = new PlayerInputActions();
        playerInputAcions.Player.Enable();

        // press 'E' this will be invoked
        playerInputAcions.Player.Interact.performed += Interact_performed;
        playerInputAcions.Player.InteractAlternate.performed += InteractAlternate_Performed;
    }

    private void Interact_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        OnInteractAction?.Invoke(this, EventArgs.Empty);
    }

    private void InteractAlternate_Performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        OnInteractAlternateAction?.Invoke(this, EventArgs.Empty);   
    }

    public Vector2 GetMovementVectorNormalized()
    {
        Vector2 inputVector = playerInputAcions.Player.Move.ReadValue<Vector2>();

        inputVector = inputVector.normalized;

        return inputVector; 
    }
}
