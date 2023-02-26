using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameInput : MonoBehaviour
{
    private const string PLAYER_PREFS_BINDINGS = "InputBindings";

    public static GameInput Instance { get; private set; }  

    public event EventHandler OnInteractAction;
    public event EventHandler OnInteractAlternateAction;
    public event EventHandler OnPauseAction;

    public enum Binding
    {
        Move_Up, 
        Move_Down, 
        Move_Left, 
        Move_Right, 
        Interact, 
        InteractAlternate, 
        Pause,
        GamePad_Interact,
        GamePad_InteractAlternate,
        GamePad_Pause,
    }

    private PlayerInputActions playerInputAcions;

    private void Awake()
    {
        Instance = this;

        playerInputAcions = new PlayerInputActions();

        if (PlayerPrefs.HasKey(PLAYER_PREFS_BINDINGS))
        {
            playerInputAcions.LoadBindingOverridesFromJson(PlayerPrefs.GetString(PLAYER_PREFS_BINDINGS));
        }

        playerInputAcions.Player.Enable();

        playerInputAcions.Player.Interact.performed += Interact_performed; // E KEY
        playerInputAcions.Player.InteractAlternate.performed += InteractAlternate_Performed; // F KEY
        playerInputAcions.Player.Pause.performed += Pause_performed; // ESC KEY
    }

    private void OnDestroy()
    {
        playerInputAcions.Player.Interact.performed -= Interact_performed;
        playerInputAcions.Player.InteractAlternate.performed -= InteractAlternate_Performed;
        playerInputAcions.Player.Pause.performed -= Pause_performed;

        playerInputAcions.Dispose();
    }

    private void Pause_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        OnPauseAction?.Invoke(this, EventArgs.Empty);
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

    public string GetBindingText(Binding binding)
    {
        switch (binding) 
        {
            default:

            case Binding.Move_Up:
                return playerInputAcions.Player.Move.bindings[1].ToDisplayString();

            case Binding.Move_Down:
                return playerInputAcions.Player.Move.bindings[2].ToDisplayString();

            case Binding.Move_Left:
                return playerInputAcions.Player.Move.bindings[3].ToDisplayString();

            case Binding.Move_Right:
                return playerInputAcions.Player.Move.bindings[4].ToDisplayString();

            case Binding.Interact:
                return playerInputAcions.Player.Interact.bindings[0].ToDisplayString();

            case Binding.InteractAlternate:
                return playerInputAcions.Player.InteractAlternate.bindings[0].ToDisplayString();

            case Binding.Pause:
                return playerInputAcions.Player.Pause.bindings[0].ToDisplayString();

            case Binding.GamePad_Interact:
                return playerInputAcions.Player.Interact.bindings[1].ToDisplayString();

            case Binding.GamePad_InteractAlternate:
                return playerInputAcions.Player.InteractAlternate.bindings[1].ToDisplayString();

            case Binding.GamePad_Pause:
                return playerInputAcions.Player.Pause.bindings[1].ToDisplayString();

        }
    }

    public void RebindBinding(Binding binding, Action onActionRebound)
    {
        playerInputAcions.Player.Disable();

        InputAction inputAction;
        int bindingIndex;

        switch (binding)
        {
            default:

            case Binding.Move_Up:
                inputAction = playerInputAcions.Player.Move;
                bindingIndex = 1;
                break;

            case Binding.Move_Down:
                inputAction = playerInputAcions.Player.Move;
                bindingIndex = 2;
                break;

            case Binding.Move_Left:
                inputAction = playerInputAcions.Player.Move;
                bindingIndex = 3;
                break;

            case Binding.Move_Right:
                inputAction = playerInputAcions.Player.Move;
                bindingIndex = 4;
                break;

            case Binding.Interact:
                inputAction = playerInputAcions.Player.Interact;
                bindingIndex = 0;
                break;

            case Binding.InteractAlternate:
                inputAction = playerInputAcions.Player.InteractAlternate;
                bindingIndex = 0;
                break;

            case Binding.Pause:
                inputAction = playerInputAcions.Player.Pause;
                bindingIndex = 0;
                break;

            case Binding.GamePad_Interact:
                inputAction = playerInputAcions.Player.Interact;
                bindingIndex = 1;
                break;

            case Binding.GamePad_InteractAlternate:
                inputAction = playerInputAcions.Player.InteractAlternate;
                bindingIndex = 1;
                break;

            case Binding.GamePad_Pause:
                inputAction = playerInputAcions.Player.Pause;
                bindingIndex = 1;
                break;
        }

        inputAction.PerformInteractiveRebinding(bindingIndex)
            .OnComplete(callback =>
            {
                callback.Dispose();
                playerInputAcions.Player.Enable();
                onActionRebound();

                PlayerPrefs.SetString(PLAYER_PREFS_BINDINGS, playerInputAcions.SaveBindingOverridesAsJson());
                PlayerPrefs.Save();
            })
            .Start();
    }
}
