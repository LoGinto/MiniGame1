using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackScript : MonoBehaviour
{
   
    public float attackSpeed = 2f;
    public WeaponScriptableObject weapon = null;
    
    //public bool hasShootingWeapon = false;
    Animator animator;
    float damage;
    public float timeBetweenAttack = 1f;
    Health enemyHealth;
    public Transform attackPoint = null;
    public float attackRange = 0.5f;
    public LayerMask enemyLayer;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        damage = 5f;
    }

    // Update is called once per frame
    void Update()
    {
        Attackin();
        if(weapon != null)
        {
            damage = weapon.GetDamage();
        }
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
        
            //it is working
            Collider[] hitEnemies = Physics.OverlapSphere(attackPoint.position, attackRange, enemyLayer);
            foreach (Collider enemy in hitEnemies)
            {

                Debug.Log("I hit enemy ");
                enemy.GetComponent<Health>().TakeDamage(gameObject, damage);
            }
        
        
       
    }
    IEnumerator playerAttackAnim()
    {
        animator.SetTrigger("Attack");
        yield return new WaitForSeconds(timeBetweenAttack);
        animator.ResetTrigger("Attack");
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
