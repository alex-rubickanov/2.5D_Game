using System;
using UnityEditor.Networking.PlayerConnection;
using UnityEngine;

public class GameInput : MonoBehaviour
{
    private PlayerInputActions playerInputActions;

    public event EventHandler OnLeftShootAction;
    public event EventHandler OnRightShootAction;
    public event EventHandler OnReloadAction;

    private void Awake()
    {
        playerInputActions =  new PlayerInputActions();
        playerInputActions.Player.Enable();

        playerInputActions.Player.LeftShoot.performed += LeftShoot_performed;
        playerInputActions.Player.RightShoot.performed += RightShoot_performed;
        playerInputActions.Player.Reload.performed += Reload_performed;
    }

    private void Reload_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        OnReloadAction?.Invoke(this, EventArgs.Empty);
    }

    private void RightShoot_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        OnRightShootAction?.Invoke(this, EventArgs.Empty);
    }

    private void LeftShoot_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        OnLeftShootAction?.Invoke(this, EventArgs.Empty);
    }

    public Vector2 GetMovementVectorNormalized()
    {
        Vector2 inputVector = playerInputActions.Player.Move.ReadValue<Vector2>();

        inputVector = inputVector.normalized;

        return inputVector;
    }
}
