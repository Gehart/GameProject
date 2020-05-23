using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : BaseCharacter
{
    /*
    public int maxHealth = 100;
    float currentHealth;

    public Transform attackPoint;
    public float attackRange;
    private Animator animator;
    public int attackDamage;
    */
    public LayerMask playerLayer;
    public float attackSpeed = 1f;
    public float attackCooldown = 0f;

    public override void Attack()
    {
        if(attackCooldown <= 0f)
        {
            attackCooldown = 1f / attackSpeed;

            Collider[] hitPlayers = Physics.OverlapSphere(attackPoint.position, attackRange, playerLayer);

            foreach (Collider player in hitPlayers)
            {
                player.GetComponent<PlayerScript>().takeDamage(attackDamage);
            }
        }
    }

    public override void takeDamage(int damage)
    {
        currentHealth -= damage;
        animator.SetTrigger("GetDamage");

        if (currentHealth <= 0)
        {
            die();
        }
    }

    protected override void die()
    {
        Destroy(GetComponent<UnityStandardAssets.Characters.ThirdPerson.EnemyAI>());
        animator.SetBool("Dead", true);
    }


    void Start()
    {
        currentHealth = maxHealth;
        animator = this.GetComponent<Animator>();

    }

    void Update()
    {
        attackCooldown -= Time.deltaTime;
    }
}