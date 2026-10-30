using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; private set; }
    
    [SerializeField] private GameObject panelHUD;
    [SerializeField] private GameObject panelEnd;
    [SerializeField] private TextMeshProUGUI textScore;
    [SerializeField] private TextMeshProUGUI textTime;
    [SerializeField] private TextMeshProUGUI textFinalScore;

    public int score;

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
        textScore.text = "Score: " + score;
    }

    public void UpdateScore(int scoreChange)
    {
        score += scoreChange;

        if (score <= 0)
        {
            score = 0;
        }

        textScore.text = "Score: " + score;
    }

    public void UpdateTime()
    {
        textTime.text = GameManager.Instance.time.ToString();
    }


    public void ShowHUD()
    {
        panelHUD.SetActive(true);
        panelEnd.SetActive(false);
    }

    internal void ShowEnd()
    {
        panelHUD.SetActive(false);
        panelEnd.SetActive(true);
        textFinalScore.text = "Final Score: " + score;
    }
}
