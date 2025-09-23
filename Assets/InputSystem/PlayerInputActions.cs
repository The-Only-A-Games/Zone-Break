using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputActions : MonoBehaviour, InputSystem.IPlayerActions
{
    public InputSystem inputSystem { get; private set; }
    public Vector2 Move { get; private set; }
    public bool Jump { get; private set; }
    public bool Shoot { get; private set; }

    void OnEnable()
    {
        inputSystem = new InputSystem();
        inputSystem.Enable();

        inputSystem.Player.Enable();
        inputSystem.Player.SetCallbacks(this);
    }

    void OnDisable()
    {
        inputSystem.Player.Disable();
        inputSystem.Player.SetCallbacks(this);
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        Jump = context.ReadValueAsButton();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        Move = context.ReadValue<Vector2>();
    }

    public void OnShoot(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Shoot = context.ReadValueAsButton();
        }
        else
        {
            Shoot = false;
        }
    }
}
