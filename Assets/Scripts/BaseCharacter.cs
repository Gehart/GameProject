using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// base class for player character and enemy character
abstract public class BaseCharacter : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    public Transform attackPoint;
    public float attackRange;
    public Animator animator;
    public int attackDamage = 25;

    //public abstract void attack();


    public virtual void takeDamage(int damage)
    {
        currentHealth -= damage;
        if (animator)
        {
            animator.SetTrigger("GetDamage");
        }

        if (currentHealth <= 0)
        {
            die();
        }
    }
    protected virtual void die()
    {
        if (animator)
        {
            animator.SetBool("Dead", true);
        }
    }
    public abstract void Attack();

}