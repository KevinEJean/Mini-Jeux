using TMPro;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] private TextMeshProUGUI healthText;
    [SerializeField] private TextMeshProUGUI speedText;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private float score = 0f;
    [SerializeField] private float scoreObjectif = 1000f;

    private void Awake()
    {
        Instance = this;
    }

    public void UpdateDisplay(float health, float maxHealth, float speed) 
    {
        healthText.text = health + " / " + maxHealth;
        speedText.text = speed.ToString();
        scoreText.text = score + " / " + scoreObjectif;
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
