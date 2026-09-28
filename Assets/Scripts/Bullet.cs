using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float speed = 10f;
    private Rigidbody2D corps;

    private Vector2 direction = Player.Instance.direction;

    private void Awake()
    {
        corps = GetComponent<Rigidbody2D>();
        if (direction.x == 0)
        {
            direction = new Vector2(1, 0);
        }
        AudioManager.Instance.AudioPlayer("playerShoot");
    }

    void FixedUpdate()
    {
        corps.MovePosition(corps.position + direction * speed * Time.fixedDeltaTime);
    }

    private void OnTriggerEnter2D(Collider2D autre)
    {
        if (!autre.CompareTag("Ennemy") && !autre.CompareTag("Wall"))
            return;

        Destroy(gameObject);
    }
}
