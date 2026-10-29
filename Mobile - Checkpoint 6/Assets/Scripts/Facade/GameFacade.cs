using UnityEngine;

public class GameFacade : MonoBehaviour
{
    [SerializeField] UIManager uiManager;

    public void StartMatch()
    {
        uiManager.ShowHUD();
    }
}
