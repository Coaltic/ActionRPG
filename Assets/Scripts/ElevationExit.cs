using UnityEngine;

public class ElevationExit : MonoBehaviour
{
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
                mountain.enabled = true;
            }

            foreach (Collider2D barrier in barrierColliders)
            {
                barrier.enabled = false;
            }

            foreach (Collider2D entry in entryColliders)
            {
                entry.enabled = true;
            }

            foreach (Collider2D exit in exitColliders)
            {
                exit.enabled = false;
            }

            //transform.GetChild(0).gameObject.SetActive(true);
        }


        collision.gameObject.GetComponent<SpriteRenderer>().sortingOrder -= 100;
    }

}
