using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float healthPoints = 20f;
    float maxHealth;
    bool isDead = false;
    Animator animator;
    public AudioClip deathSFX;
    AudioSource audioSource;
    
    private void Start()
    {
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        maxHealth = healthPoints;
    }

    public void TakeDamage(GameObject instigator,float damage)
    {
        Debug.Log(gameObject.name + "took " + damage + " Damage");
        healthPoints = Mathf.Max(healthPoints - damage, 0);
        
        if(healthPoints <= 0)
        {
            Die();
        }
    }
    private void Die()
    {
        audioSource.PlayOneShot(deathSFX, 0.5f);
        if(gameObject.tag == "Enemy")
        {
            gameObject.GetComponent<enemy>().enabled = false;
            gameObject.GetComponent<EnemyPatrol>().enabled = false;
            gameObject.GetComponent<DamageDealer>().enabled = false;
        }
        else if(gameObject.tag == "Player")
        {
            gameObject.GetComponent<player>().enabled = false;
            gameObject.GetComponent<PlayerAttackScript>().enabled = false;
            //TO DO: ADD death picture. 
            //TO DO: Make a menu(for death as well) 

        }


        animator.SetTrigger("Die");
        isDead = true; 
       
    }
    public float ReturnMaxHealth()
    {
        return maxHealth;
    }    
    public bool GetDeathState()
    {
        return isDead;
    }
    public float GetHealthPoints()
    {
        return healthPoints; 
    }
}
