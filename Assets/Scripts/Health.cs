using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float healthPoints = 20f;
    bool isDead = false;
    Animator animator;
    
    private void Start()
    {
        animator = GetComponent<Animator>();
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
        animator.SetTrigger("Die");
        isDead = true; 
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
