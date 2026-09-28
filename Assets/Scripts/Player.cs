using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{

    public static Player Instance { get; set; }


    [SerializeField] public float speed = 5f;
    [SerializeField] private Animator anim;
    [SerializeField] private GameObject bullet;
    [SerializeField] public float maxHealth = 100f;
    [SerializeField] public float health = 100f;
    [SerializeField] public SpriteRenderer spriteRenderer;

    private Rigidbody2D corps;
    public Vector2 direction;
    public int coins = 0;
    private bool isShooting = false;


    private void Awake()
    {
        Instance = this;
        corps = GetComponent<Rigidbody2D>();

    }

    private void Update()
    {
        if (!GameManager.Instance.levelCompleted && !GameManager.Instance.gameOver)
        {
            float horizontal = Input.GetAxisRaw("Horizontal");
            float vertical = Input.GetAxisRaw("Vertical");

            direction = new Vector2(horizontal, vertical).normalized;

            Direction(horizontal);

            Anims();

            if (Input.GetKey(KeyCode.Space) && !isShooting)
                StartCoroutine(Shoot());

            GameManager.Instance.UpdateDisplay(health, maxHealth, speed);
        }
        else 
        {
            gameObject.SetActive(false);
        }
    }

    private void FixedUpdate()
    {
        corps.MovePosition(corps.position + direction * speed * Time.fixedDeltaTime);
    }

    public void PlayerHealth(float value) 
    {
        if (value < 0) 
        {
            AudioManager.Instance.AudioPlayer("playerDmg");
        }
        health += value;
        if (health <= 0)
        {
            health = 0;
            anim.SetBool("isDead", true);
            StartCoroutine(DeathAnim());
        }
        else if (health > 100)
        {
            health = 100;
        }
        Debug.Log("Player health: " + health);
    }

    private IEnumerator Shoot() 
    {
        //AudioManager.Instance.AudioPlayer("playerShoot");
        isShooting = true;
        bullet.transform.position = corps.transform.position;
        Instantiate(bullet);
        yield return new WaitForSeconds(0.5f);
        isShooting = false;
    }

    private void Direction(float horizontal) 
    {
        if (horizontal < 0)
        {
            spriteRenderer.flipX = true;
        }
        else if (horizontal > 0)
        {
            spriteRenderer.flipX = false;
        }
    }

    private void Anims() 
    {
        if (direction != Vector2.zero)
        {
            AudioManager.Instance.AudioPlayer("playerMove");
            anim.SetBool("isMoving", true);
        }
        else
        {
            AudioManager.Instance.StopAudioPlayer("playerMove");
            anim.SetBool("isMoving", false);
        }
    }

    private IEnumerator DeathAnim() 
    {
        yield return new WaitForSeconds(0.5f);
        GameManager.Instance.GameOver();
    }
}
