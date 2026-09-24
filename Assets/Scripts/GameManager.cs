using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] private GameObject door;
    [SerializeField] private GameObject victoryUI;
    [SerializeField] private GameObject gameOverUI;
    [SerializeField] private TextMeshProUGUI healthText;
    [SerializeField] private TextMeshProUGUI speedText;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private float score = 0f;
    [SerializeField] private float scoreObjectif = 30f;

    private void Awake()
    {
        Instance = this;
        door.SetActive(false);
        gameOverUI.SetActive(false);
        victoryUI.SetActive(false);
    }

    public void UpdateDisplay(float health, float maxHealth, float speed)
    {
        if (speed < 0)
        {
            speed = 0;
        }

        healthText.text = health + " / " + maxHealth;
        speedText.text = speed.ToString();
        scoreText.text = score + " / " + scoreObjectif;
    }

    public void ScoreManager(int points) 
    {
        score += points;
        if (score >= scoreObjectif) 
        {
            score = scoreObjectif;
            if (SceneManager.GetActiveScene().name == "Level2") 
            {
                Victory();
                return;
            }
            OpenDoor();
        }
    }

    public void Victory() 
    {
        victoryUI.SetActive(true);
    }

    public void GameOver()
    {
        gameOverUI.SetActive(true);
    }

    public void OpenDoor()
    {
        door.SetActive(true);
    }

    public void LoadGambleRoomScene()
    {
        SceneManager.LoadScene("GambleRoom");
    }

    public void LoadScene(string scene) 
    {
        SceneManager.LoadScene(scene);
    }
    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
