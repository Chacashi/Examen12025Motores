using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputReaderGame : MonoBehaviour
{
    public static event Action<Vector2> OnPlayerMovement;
    public static event Action<bool> OnPressK;
    public static event Action<bool> OnPressJ;
    public static event Action<bool> OnPressSpace;
    private bool aux;

    public void Movement(InputAction.CallbackContext context)
    {

        OnPlayerMovement?.Invoke( context.ReadValue<Vector2>());

    }


    public void PressK(InputAction.CallbackContext context)
    {
        if(context.phase == InputActionPhase.Started)
        {
            aux = true;
           OnPressK?.Invoke(aux );
        }
    }

    public void PressJ(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started)
        {
            aux = true;
            OnPressJ?.Invoke(aux);
        }
    }

    public void Jump(InputAction.CallbackContext context)
    {
        if(context.phase != InputActionPhase.Performed)
        {
            return;
        }
        aux = true;
        OnPressSpace?.Invoke(aux);

    }

}
