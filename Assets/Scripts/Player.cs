using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{

    public static Player Instance { get; set; }


    [SerializeField] public float speed = 5f;
    [SerializeField] private Animator anim;
    [SerializeField] public float maxHealth = 100f;
    [SerializeField] public float health = 100f;

    private Rigidbody2D corps;
    private Vector2 direction;
    public int coins = 0;

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

        Anims();

        GameManager.Instance.UpdateDisplay(health, maxHealth, speed);
    }

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            Shoot();
        }
        corps.MovePosition(corps.position + direction * speed * Time.fixedDeltaTime);
    }

    private void Shoot()
    {
        Debug.Log("Player shot!");
    }

    public void PlayerHealth(float value) 
    {
        health += value;
        if (health < 0)
            DeathAnim();
        else if (health > 100)
            health = 100;
        Debug.Log("Player health: " + health);
    }

    private void Anims() 
    {
        if (direction != Vector2.zero)
            anim.SetBool("isMoving", true);
        else
            anim.SetBool("isMoving", false);
    }

    private void DeathAnim() 
    {
        anim.SetBool("isDead", true);
        //gameObject.setActive(false) // after 5sec
    }
}
