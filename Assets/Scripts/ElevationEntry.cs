using UnityEngine;

public class ElevationEntry : MonoBehaviour
{
    public int currentPlayerRenderLevel;
    public int previousPlayerRenderLevel;
    public Collider2D[] mountainColliders;
    public Collider2D[] barrierColliders;
    public Collider2D[] entryColliders;
    public Collider2D[] exitColliders;

    private void OnTriggerEnter2D(Collider2D collision)
    {


        if (collision.gameObject.tag == "Player")
        {
            foreach (Collider2D mountain in mountainColliders)
            {
                mountain.enabled = false;
            }

            foreach (Collider2D barrier in barrierColliders)
            {
                barrier.enabled = true;
            }

            foreach (Collider2D entry in entryColliders)
            {
                entry.enabled = false;
            }

            foreach (Collider2D exit in exitColliders)
            {
                exit.enabled = true;
            }

            //transform.GetChild(0).gameObject.SetActive(true);
            //gameObject.GetComponent<BoxCollider2D>().enabled = false;
            // transform.GetComponentInParent<BoxCollider2D>().gameObject.SetActive(true);
            // previousPlayerRenderLevel = collision.gameObject.GetComponent<SpriteRenderer>().sortingOrder;
        }
        

        collision.gameObject.GetComponent<SpriteRenderer>().sortingOrder += 100;
    }
}
