using UnityEngine;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    public int currentHealth;
    public int maxHealth;
    public Animator healthTextAnim;

    public TMP_Text healthText;

    private void Start()
    {
        healthText.color = new Color32(10, 200, 50, 255);
        // Debug.Log("Text Color: Green");
        healthText.text = "HP: " + currentHealth + " / " + maxHealth;
    }

    public void ChangeHealth(int amount)
    {
        currentHealth += amount;
        
        healthTextAnim.Play("TextUpdate");

        if (currentHealth < maxHealth && currentHealth > (float)(maxHealth / 2))
        {
            // Debug.Log("Max Health Half: " + (maxHealth / 2));
            healthText.color = new Color32(250, 225, 0, 255);
            //Debug.Log("Text Color: Yellow");
        }
        if (currentHealth < (maxHealth / 2))
        {
            // Debug.Log("Max Health Half: " + (float)(maxHealth / 2));
            healthText.color = new Color32(250, 150, 0, 255);
            //Debug.Log("Text Color: Orange");
        }

        healthText.text = "HP: " + currentHealth + " / " + maxHealth;

        if (currentHealth <= 0)
        {
            gameObject.SetActive(false);
            healthText.color = new Color32(250, 25, 0, 255);
            //Debug.Log("Text Color: Red");
        }
    }
}
