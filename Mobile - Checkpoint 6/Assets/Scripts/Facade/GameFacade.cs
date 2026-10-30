using UnityEngine;

public class GameFacade : MonoBehaviour
{
    public static GameFacade Instance;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(this.gameObject);
            return;
        }

        Instance = this;
    }

    public void StartGame()
    {
        UIManager.Instance.ShowHUD();
    }

    public void EndGame()
    {
        UIManager.Instance.ShowEnd();
    }


}
