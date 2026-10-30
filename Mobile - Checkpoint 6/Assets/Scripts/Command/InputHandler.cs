using UnityEngine;
using UnityEngine.InputSystem;

public class InputHandler : MonoBehaviour
{
    [SerializeField] private Player playerScript;

    [SerializeField] private InputActionReference jumpAction;
    [SerializeField] private InputActionReference pauseToggle;

    ICommand jumpCommand;
    ICommand pauseCommand;

    void OnEnable()
    {
        jumpAction.action.Enable();
        pauseToggle.action.Enable();
    }

    void OnDisable()
    {
        jumpAction.action.Disable();
        pauseToggle.action.Disable();
    }

    void Start()
    {
        jumpCommand = new JumpCommand(playerScript);
        pauseCommand = new PauseCommand(playerScript);
    }

    void Update()
    {
        ReadInput();
    }

    void ReadInput()
    {
        if (jumpAction.action.WasPressedThisFrame())
        {
            jumpCommand.Execute();
        }

        if (pauseToggle.action.WasPressedThisFrame())
        {
            pauseCommand.Execute();
        }
    }
}
