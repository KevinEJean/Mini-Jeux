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

    private Rigidbody2D corps;
    private Vector2 direction;
    public int coins = 0;
    private bool isShooting = false;


    private void Awake()
    {
        Instance = this;
        corps = GetComponent<Rigidbody2D>();

    }

    private void Update()
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

    private void FixedUpdate()
    {
        corps.MovePosition(corps.position + direction * speed * Time.fixedDeltaTime);
    }

    public void PlayerHealth(float value) 
    {
        health += value;
        if (health < 0)
        {
            health = 0;
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
            Vector3 curRotation = transform.eulerAngles;
            transform.eulerAngles = new Vector3(curRotation.x, -200f, curRotation.z);
        }
        else
        {
            Vector3 curRotation = transform.eulerAngles;
            transform.eulerAngles = new Vector3(curRotation.x, 0, curRotation.z);
        }
    }

    private void Anims() 
    {
        if (direction != Vector2.zero)
            anim.SetBool("isMoving", true);
        else
            anim.SetBool("isMoving", false);
    }

    private IEnumerator DeathAnim() 
    {
        anim.SetBool("isDead", true);
        gameObject.SetActive(false);
        yield return new WaitForSeconds(1);
        GameManager.Instance.GameOver();
    }
}
