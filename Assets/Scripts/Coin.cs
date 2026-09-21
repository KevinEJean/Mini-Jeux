using UnityEngine;

public class Coin : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D autre)
    {
        if (!autre.CompareTag("Player"))
            return;

        Player.Instance.coins += 1;
        Debug.Log("Player collected a coin. (coins count: " + Player.Instance.coins + ")");

        Destroy(gameObject);
    }
}
