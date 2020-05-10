using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public GameObject Player;

    public int maxHealth = 100;
    public int currentHealth;

    public HealthBar healthBar;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "DangerousObject")
        {
            currentHealth -= 25;
        }
    }

    /*private void OnTriggerStay(Collider other)
    {
        if (other.tag == "DangerousObject")
        {
            currentHealth -= 1;
        }
    }*/

    void TakeDamage(int damage)
    {
        currentHealth -= damage;

        healthBar.SetHealth(currentHealth);
    }
    
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Player.GetComponent<Animator>().SetTrigger("Punching");
        }
        if( currentHealth <= 0)
        {
            Player.GetComponent<Animator>().SetBool("Dead", true);
        }
    }
}
