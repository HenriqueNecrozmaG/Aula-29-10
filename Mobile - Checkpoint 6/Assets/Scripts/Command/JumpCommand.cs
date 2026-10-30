using UnityEngine;

public class JumpCommand : ICommand
{
    private Player playerScript;

    public JumpCommand(Player playerScript)
    {
        this.playerScript = playerScript;
    }

    public void Execute()
    {
        playerScript.jumpQueued = true;
    }
}
