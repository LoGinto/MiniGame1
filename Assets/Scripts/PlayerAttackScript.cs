using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackScript : MonoBehaviour
{
    public float attackSpeed = 2f;
    public WeaponScriptableObject weapon = null;
    public bool hasShootingWeapon = false;
    Animator animator;
    float damage;
    public float timeBetweenAttack = 1f;
    Health enemyHealth;
    public GameObject launchOrigin = null;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        if (weapon != null)
        {
            damage = weapon.GetDamage();
        }
        else
        {
            damage = 5f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Attackin();
    }
    private void Attackin()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            StartCoroutine("playerAttackAnim");

        }
    }
    void Hit()//animation event
    {
        
        Debug.Log("Player attack is working");
        if (enemyHealth == null) { Debug.Log("No Enemy Detected"); return; }
        //it is working
        enemyHealth.TakeDamage(gameObject, damage);//not working, but working against player
    }
    IEnumerator playerAttackAnim()
    {
        animator.SetTrigger("Attack");
        yield return new WaitForSeconds(timeBetweenAttack);
        animator.ResetTrigger("Attack");
    }
}
