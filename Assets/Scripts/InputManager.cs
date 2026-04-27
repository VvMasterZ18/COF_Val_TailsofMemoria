using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    public ProtagonistMovement pm;
    public void OnDash()
    {
        pm.Dash();
    }
    public void OnUpgradedJump()
    {

    }
}
