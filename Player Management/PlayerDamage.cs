using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class PlayerDamage : MonoBehaviour
{
    [SerializeField] Healthbar healthbar;
    public int currentHealth;
    public int maxHealth;
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        maxHealth = 100;
        currentHealth = maxHealth;
        animator = GetComponent<Animator>();
        healthbar = GetComponentInChildren<Healthbar>();
        healthbar.UpdateHealthBar(maxHealth, currentHealth);

    }
    public void TakeDamage(int damage)
    {
        healthbar.UpdateHealthBar(maxHealth, currentHealth);
        currentHealth -= damage;


        if (currentHealth < 0)
        {
            currentHealth = 0;
        }


        if (currentHealth == 0)
        {
            Die();
        }
        else
        {
            animator.SetTrigger("damage");
            healthbar.UpdateHealthBar(maxHealth, currentHealth);
        }


        void Die()
        {

            animator.SetTrigger("dying");


        }



    }
}

