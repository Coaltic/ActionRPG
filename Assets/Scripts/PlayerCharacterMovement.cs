using UnityEngine;

public class PlayerCharacterMovement : MonoBehaviour
{
    public float speed = 5;
    public float runSpeed = 7.5f;
    public int facingDirection = 1;
    public Rigidbody2D rb;
    public Animator anim;


    // Update is called once per frame
    void FixedUpdate()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        if (horizontal > 0 && transform.localScale.x < 0 || 
            horizontal < 0 && transform.localScale.x > 0)
        {
            Flip();
        }

        anim.SetFloat("horizontal", Mathf.Abs(horizontal));
        anim.SetFloat("vertical", Mathf.Abs(vertical));

        if (Input.GetKey(KeyCode.LeftShift))
        {
            rb.linearVelocity = new Vector2(horizontal, vertical) * runSpeed;
        }
        else
        {
            rb.linearVelocity = new Vector2(horizontal, vertical) * speed;
        }

    }

    void Flip()
    {
        facingDirection *= -1;
        transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
    }
}
