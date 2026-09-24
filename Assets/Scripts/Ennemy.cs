using UnityEngine;

public class Ennemy : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private float minRange;
    [SerializeField] private float maxRange;

    private Rigidbody2D corps;
    private bool movingRight = true;
    Vector2 moveRight = new Vector2(1, 0).normalized;
    Vector2 moveLeft = new Vector2(-1, 0).normalized;

    private void Awake()
    {
        corps = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        Movement();
    }

    private void Movement()
    {
        Vector2 direction = movingRight ? moveRight : moveLeft;

        corps.MovePosition(corps.position + direction * speed * Time.fixedDeltaTime);

        if (movingRight && corps.position.x >= maxRange)
            movingRight = false;

        else if (!movingRight && corps.position.x <= minRange)
            movingRight = true;
    }

    private void OnTriggerEnter2D(Collider2D autre)
    {
        if (!autre.CompareTag("Player"))
            return;

        Player.Instance.PlayerHealth(-15f);
    }
}
