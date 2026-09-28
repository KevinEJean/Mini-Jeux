using UnityEngine;

public class Coin : MonoBehaviour
{
    private void OnTriggerExit2D(Collider2D autre)
    {
        if (!autre.CompareTag("Player"))
            return;

        GameManager.Instance.ScoreManager(1);
        Debug.Log("Player collected a coin. (coins count: " + Player.Instance.coins + ")");
        AudioManager.Instance.AudioPlayer("coin");

        Destroy(gameObject);
    }
}
