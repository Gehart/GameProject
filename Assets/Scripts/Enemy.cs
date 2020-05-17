using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float health;
    float currentHealth;

    public Transform attackPoint;
    public float attackRange;
    public LayerMask playerLayer;
    public int attackDamage;
    private Animator animator;
    private void attack()
    {
        Collider[] hitPlayers = Physics.OverlapSphere(attackPoint.position, attackRange, playerLayer);

        foreach (Collider player in hitPlayers)
        {
            Debug.Log("we hit " + player.name);
            player.GetComponent<PlayerScript>().TakeDamage(attackDamage);
        }
    }

    public void takeDamage(int damage)
    {
        currentHealth -= damage;
        animator.SetTrigger("GetDamage");
        if (currentHealth <= 0)
        {
            die();
        }
    }

    void die()
    {
        Debug.Log("Emeny die");
        animator.SetBool("Dead", true);
    }


    void Start()
    {
        currentHealth = health;
        animator = this.GetComponent<Animator>();
    }
}