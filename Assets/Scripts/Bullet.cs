using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody2D corps;
    private float speed = 5f;

    private void Awake()
    {
        corps = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        corps.MovePosition(corps.position + new Vector2(1, 0).normalized * speed * Time.fixedDeltaTime);
    }

    private void OnTriggerEnter2D(Collider2D autre)
    {
        if (!autre.CompareTag("Ennemy") && !autre.CompareTag("Wall"))
            return;

        if (autre.CompareTag("Wall")) 
        {
            Destroy(gameObject);
            return;
        }

        GameManager.Instance.ScoreManager(10);
        Destroy(autre.gameObject);
        Destroy(gameObject);
    }
}
