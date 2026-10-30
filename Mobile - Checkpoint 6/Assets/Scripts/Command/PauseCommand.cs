using UnityEngine;

public class PauseCommand : ICommand
{
    private Player playerScript;

    public PauseCommand(Player playerScript)
    {
        this.playerScript = playerScript;
    }

    public void Execute()
    {
        playerScript.pauseQueued = true;
    }
}
