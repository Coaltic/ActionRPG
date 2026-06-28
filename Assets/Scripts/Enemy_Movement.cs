using UnityEngine;

public class Enemy_Movement : MonoBehaviour
{
    public float speed;
    public float attackRange = 1;

    public EnemyState enemyState;
    private int facingDirection = 1;
    public float attackCooldown = 2;

    private float attackCooldownTimer;
    private Rigidbody2D rb;
    private Transform player;
    private Animator anim;


    void Start()
    {
        speed = 4;
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        ChangeState(EnemyState.Idle);

    }

    // Update is called once per frame
    void Update()
    {
        if (attackCooldownTimer > 0)
        {
            attackCooldownTimer -= Time.deltaTime;
        }

        if (enemyState == EnemyState.Chasing)
        {
            Chase();
        }
        else if (enemyState == EnemyState.Attacking)
        {
            rb.linearVelocity = Vector2.zero;
        }
    }

    void Chase()
    {
        if (Vector2.Distance(transform.position, player.transform.position) <= attackRange && attackCooldownTimer <= 0)
        {
            Debug.Log(Vector2.Distance(transform.position, player.transform.position));
            ChangeState(EnemyState.Attacking);
        }

        else if (player.position.x > transform.position.x && facingDirection == -1 ||
                player.position.x < transform.position.x && facingDirection == 1)
        {
            Flip();
        }

        // Debug.Log("moving");
        // Debug.Log(enemyState);
        //if (enemyState == EnemyState.Chasing)
        {
            Vector2 direction = (player.position - transform.position).normalized;
            rb.linearVelocity = direction * speed;
        }
        
    }
    void Flip()
    {
        facingDirection *= -1;
        transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
    }

    /*private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (player == null)
            {
                player = collision.transform;
            }

            ChangeState(EnemyState.Chasing);
        }
    }*/

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (player == null)
            {
                player = collision.transform;
            }

            ChangeState(EnemyState.Chasing);
            //Debug.Log("ontrigger stay");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            rb.linearVelocity = Vector2.zero;
            ChangeState(EnemyState.Idle);
        }

    }

    void ChangeState(EnemyState newState)
    {
        // exit current animation
        if (enemyState == EnemyState.Idle)
            anim.SetBool("isIdle", false);
        else if (enemyState == EnemyState.Chasing)
            anim.SetBool("isChasing", false);
        else if (enemyState == EnemyState.Attacking)
            anim.SetBool("isAttacking", false);

        // update state
        enemyState = newState;

        // update new animation
        if (enemyState == EnemyState.Idle)
            anim.SetBool("isIdle", true);
        else if (enemyState == EnemyState.Chasing)
            anim.SetBool("isChasing", true);
        else if (enemyState == EnemyState.Attacking)
            anim.SetBool("isAttacking", true);
    }
}

public enum EnemyState
{
    Idle,
    Chasing,
    Attacking,
}