using UnityEngine;

public class Item : MonoBehaviour
{
    private float randomiser;
    private void OnTriggerEnter2D(Collider2D autre)
    {
        if (!autre.CompareTag("Player"))
            return;

        Player.Instance.PlayerHealth(10f);

        Destroy(gameObject);
    }
}
