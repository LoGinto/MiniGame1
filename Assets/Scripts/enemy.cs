using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class enemy : MonoBehaviour
{
    public float timeBetweenAttack = 1f;
    public WeaponScriptableObject weapon = null;
    public Transform rightHand = null;
    public Transform leftHand = null;
    //public float damage = 5f;
    public float moveSpeed = 4f;
    bool isEnemy = true;
    public Transform playerr;
    public float chaseDistance = 5f;
    public float attackDistance = 1f;
    public float shootDistance = 5f;//not applied for now 
    public bool hasShootingWeapon = false;
    private bool isChasing = false;
    NavMeshAgent agent;
    Animator animator;
    float timeSinceLastAttack = Mathf.Infinity;
    private void Start()
    {
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        weapon.SpawnWeapon(rightHand, leftHand, animator);
    }

    private void Update()
    {
        timeSinceLastAttack += Time.deltaTime;
            ChaseThePlayer();
            StopOnAttackDistance();
       
    }
   public bool HasShootingWeapon()
    {
        return hasShootingWeapon;
    }
   

    private void StopOnAttackDistance()
    {
        if (hasShootingWeapon == false)
        {
            if (OnAttackDistance())
            {
                StopEnemy();

            }
            else
            {
                ChaseThePlayer();
            }
        }
        else
        {
            if(Vector3.Distance(transform.position, playerr.position) <= shootDistance)
            {
                StopEnemy();
            }
            else
            {
                ChaseThePlayer();
            }
        }
    }

    public bool OnAttackDistance()
    {
        return Vector3.Distance(transform.position, playerr.position) <= attackDistance;
    }

    private void StopEnemy()
    {
        transform.LookAt(playerr);
        //agent.enabled = false;
        agent.isStopped = true;
        animator.SetBool("Is_Running", false);
        StartCoroutine("AttackingAnim"); 
        
    }

    void ChaseThePlayer()
    {
        if (Vector3.Distance(transform.position, playerr.position) <= chaseDistance)
        {
            transform.LookAt(playerr);
            //transform.position += transform.forward * moveSpeed * Time.deltaTime;
            agent.destination = playerr.position;
           
            animator.SetBool("Is_Running", true);
            isChasing = true;

        }
        else
        {
            return;
        }



    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, chaseDistance);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position,attackDistance);
       
    }
    IEnumerator AttackingAnim()
    {
        animator.SetTrigger("Attack");
        yield return new WaitForSeconds(timeBetweenAttack);
        animator.ResetTrigger("Attack");
    }
    public bool ISChasing()
    {
        return isChasing;
    }
    public bool ISEnemy()
    {
        return isEnemy;
    }

}
