using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerScript : BaseCharacter
{
    //public int maxHealth = 100;
    //public int currentHealth;

    //public Transform attackPoint;
    //public float attackRange;
    //private Animator animator;
    //public int attackDamage = 25;

    public LayerMask enemyLayers;
    public HealthBar healthBar;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "DangerousObject")
        {
            takeDamage(25);
        }
    }

    public override void takeDamage(int damage)
    {
        currentHealth -= damage;
        animator.SetTrigger("GetDamage");

        healthBar.SetHealth(currentHealth);
        if (currentHealth <= 0)
        {
            die();
        }
    }

    protected override void die()
    {
        animator.SetBool("Dead", true);
        Destroy(GetComponent<UnityStandardAssets.Characters.ThirdPerson.ThirdPersonUserControl>());
    }


    public override void Attack()
    {
        // атакует всех, оказавшихся в радиусе круга с радиусом attackRange
        Collider[] hitEnemies = Physics.OverlapSphere(attackPoint.position, attackRange, enemyLayers);

        foreach (Collider enemy in hitEnemies)
        {
            enemy.GetComponent<Enemy>().takeDamage(attackDamage);
        }
    }

    void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
        {
            return;
        }
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            animator.SetTrigger("Punching");
            Attack();
        }
    }
}
