using UnityEngine;

public class Enemy_Combat : MonoBehaviour
{

    public int health;
    public int damage;
    public Transform attackPoint;
    public float weaponRange;
    public LayerMask playerLayer;

    public void Start()
    {
        health = 5;
        damage = 1;

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // if (collision.gameObject.tag == "Player") collision.gameObject.GetComponent<PlayerHealth>().ChangeHealth(-damage);
            
    }

    public void Attack()
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(attackPoint.position, weaponRange, playerLayer);

        if (hits.Length > 0)
        {
            hits[0].GetComponent<PlayerHealth>().ChangeHealth(-damage);
        }
    }
}
