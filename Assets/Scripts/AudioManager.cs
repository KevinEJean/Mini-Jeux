using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    [SerializeField] private AudioSource coinAudio;
    [SerializeField] private AudioSource flyingEyeAudio;
    [SerializeField] private AudioSource itemAudio;
    [SerializeField] private AudioSource gameOverAudio;
    [SerializeField] private AudioSource playerDmgAudio;
    [SerializeField] private AudioSource playerMoveAudio;
    [SerializeField] private AudioSource playerShootAudio;
    [SerializeField] private AudioSource teleportAudio;
    [SerializeField] private AudioSource themeAudio;
    [SerializeField] private AudioSource victoryAudio;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        if (!themeAudio.isPlaying)
            themeAudio.Play();

        if (!flyingEyeAudio.isPlaying)
            flyingEyeAudio.Play();
    }

    public void AudioPlayer(string name)
    {
        switch (name) 
        {
            case "coin":
                if (!coinAudio.isPlaying)
                    coinAudio.Play();
                break;

            case "victory":
                if (!victoryAudio.isPlaying)
                {
                    coinAudio.Stop();
                    flyingEyeAudio.Stop();
                    itemAudio.Stop();
                    gameOverAudio.Stop();
                    playerDmgAudio.Stop();
                    playerMoveAudio.Stop();
                    playerShootAudio.Stop();
                    teleportAudio.Stop();
                    themeAudio.Stop();
                    victoryAudio.Play();
                }
                break;

            case "teleport":
                if (!teleportAudio.isPlaying)
                    teleportAudio.Play();
                break;

            case "gameOver":
                if (!gameOverAudio.isPlaying)
                    gameOverAudio.Play();
                break;

            case "item":
                if (!itemAudio.isPlaying)
                    itemAudio.Play();
                break;

            case "playerDmg":
                if (!playerDmgAudio.isPlaying)
                    playerDmgAudio.Play();
                break;

            case "playerMove":
                if (!playerMoveAudio.isPlaying)
                    playerMoveAudio.Play();
                break;

            default:
                Debug.Log(name + " does not match any audio file.");
                break;
        }
    }

    public void StopAudioPlayer(string name)
    {
        switch (name)
        {
            case "coin":
                if (coinAudio.isPlaying)
                    coinAudio.Stop();
                break;

            case "victory":
                if (victoryAudio.isPlaying)
                    victoryAudio.Stop();
                break;

            case "teleport":
                if (teleportAudio.isPlaying)
                    teleportAudio.Stop();
                break;

            case "gameOver":
                if (gameOverAudio.isPlaying)
                    gameOverAudio.Stop();
                break;

            case "item":
                if (itemAudio.isPlaying)
                    itemAudio.Stop();
                break;

            case "playerDmg":
                if (playerDmgAudio.isPlaying)
                    playerDmgAudio.Stop();
                break;

            case "playerShoot":
                if (playerShootAudio.isPlaying)
                    playerShootAudio.Stop();
                break;

            case "playerMove":
                if (playerMoveAudio.isPlaying)
                    playerMoveAudio.Stop();
                break;

            default:
                Debug.Log(name + " does not match any audio file.");
                break;
        }
    }
}
