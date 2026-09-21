using UnityEngine;

public class Item : MonoBehaviour
{
    private float randomiser;
    private void OnTriggerEnter2D(Collider2D autre)
    {
        if (!autre.CompareTag("Player"))
            return;

        if (gameObject.tag == "Box") 
        {
            randomiser = Random.Range(0f, 100f);
            if (randomiser >= 50f)
            {
                Player.Instance.PlayerHealth(-8f);
                Debug.Log("Player triggered an explosive box!");
            }
            return;
        }

        Player.Instance.PlayerHealth(10f);

        Destroy(gameObject);
    }
}
