using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum GameState
{
    Playing,
    Paused,
    Finished
}

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    GameState state;

    public int time;
    public bool isPaused;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        Instance = this;
    }

    void Start()
    {
        IsPlaying();
        time = 100;
        isPaused = false;

        UIManager.Instance.UpdateTime();

        StartCoroutine(PassTime());
    }

    public void IsPlaying()
    {
        state = GameState.Playing;
        GameFacade.Instance.StartGame();
    }

    public void IsFinished()
    {
        state = GameState.Finished;
        GameFacade.Instance.EndGame();
    }

    public void PauseGame()
    {
        if (state == GameState.Finished) return;

        if (state == GameState.Playing)
        {
            state = GameState.Paused;
            Time.timeScale = 0;
        }
        else if (state == GameState.Paused)
        {
            state = GameState.Playing;
            Time.timeScale = 1;
        }
    }

    public void ReturnToStartScreen()
    {
        SceneManager.LoadScene("StartScreen");
    }

    IEnumerator PassTime()
    {
        yield return new WaitForSeconds(1);
        time--;
        UIManager.Instance.UpdateTime();
        
        if (time <= 0)
        {
            state = GameState.Finished;
            time = 0;
            GameFacade.Instance.EndGame();
            Time.timeScale = 0;
        }
        else
        {
            StartCoroutine(PassTime());
        }
    }
}
