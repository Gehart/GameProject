    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public GameObject Player;

    public int maxHealth = 100;
    public int currentHealth;

    public HealthBar healthBar;
    public Transform attackPoint;
    public float attackRange;
    public LayerMask enemyLayers;
    public int attackDamage;

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

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        healthBar.SetHealth(currentHealth);
    }

    void Attack()
    {
        // атакует всех, оказавшихся в радиусе круга с радиусом attackRange
        Collider[] hitEnemies = Physics.OverlapSphere(attackPoint.position, attackRange, enemyLayers);

        foreach(Collider enemy in hitEnemies)
        {
            Debug.Log("we hit " + enemy.name);
            enemy.GetComponent<Enemy>().takeDamage(attackDamage);
        }
    }

    void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
        {
            Debug.Log("Haha!");
            return;
        }
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
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
            Attack();
        }
        if( currentHealth <= 0)
        {
            Player.GetComponent<Animator>().SetBool("Dead", true);
        }
    }
}
