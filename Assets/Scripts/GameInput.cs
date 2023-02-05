using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInput : MonoBehaviour
{
    private PlayerInputActions playerInputAcions;

    private void Awake()
    {
        playerInputAcions = new PlayerInputActions();
        playerInputAcions.Player.Enable();
    }

    public Vector2 GetMovementVectorNormalized()
    {
        Vector2 inputVector = playerInputAcions.Player.Move.ReadValue<Vector2>();

        inputVector = inputVector.normalized;

        return inputVector; 
    }
}
