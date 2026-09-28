using System.Collections;
using UnityEngine;

public class Ennemy : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private float minRange;
    [SerializeField] private float maxRange;
    [SerializeField] private Animator anim;

    private Rigidbody2D corps;
    private bool movingRight = true;
    private bool isDead = false;
    Vector2 moveRight = new Vector2(1, 0).normalized;
    Vector2 moveLeft = new Vector2(-1, 0).normalized;
    Vector3 curRotation;

    private void Awake()
    {
        corps = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (!GameManager.Instance.levelCompleted && !GameManager.Instance.gameOver)
        {
            if (!isDead)
                Movement();
        }
        else
        {
            gameObject.SetActive(false);
        }
    }

    private void Movement()
    {
        Vector2 direction = movingRight ? moveRight : moveLeft;
        Vector2 horizontal = movingRight ? new Vector2(1, 0) : new Vector2(-1, 0);
        curRotation = transform.eulerAngles;

        corps.MovePosition(corps.position + direction * speed * Time.fixedDeltaTime);

        if (movingRight && corps.position.x >= maxRange)
        {
            movingRight = false;
            transform.eulerAngles = new Vector3(curRotation.x, -200f, curRotation.z);
        }
        else if (!movingRight && corps.position.x <= minRange)
        {
            movingRight = true;
            transform.eulerAngles = new Vector3(curRotation.x, 0, curRotation.z);
        }
    }

    private IEnumerator Die() 
    {
        isDead = true;
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D autre)
    {
        if (!autre.CompareTag("Player") && !autre.CompareTag("Bullet"))
            return;

        if (autre.CompareTag("Bullet"))
        {
            anim.SetBool("isDead", true);
            StartCoroutine(Die());
        }

        Player.Instance.PlayerHealth(-15f);
    }
}
