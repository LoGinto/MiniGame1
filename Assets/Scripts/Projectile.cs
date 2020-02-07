using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    /// <summary>
    /// projectile 
    /// </summary>
    public float speed = 5f;
    public bool isHoming = false;
    public float lifeAfterImpacttime = 0.3f; 
    public Health target = null;//might remove "public" from here
    GameObject instigator = null;
    float damage = 1f;
    public float maximumLifeTime = 7f;
    [SerializeField] GameObject impactVFX = null;
    public GameObject[] destructionArray = null;
    public void SetTarget(Health target, GameObject instigator, float damage)
    {
        this.target = target;
        this.damage = damage;
        this.instigator = instigator;

        Destroy(gameObject, maximumLifeTime);
    }
    private Vector3 GetAim()
    {
        CapsuleCollider targetCapsule = target.GetComponent<CapsuleCollider>();
        targetCapsule = target.GetComponent<CapsuleCollider>();
        if (targetCapsule == null)
        {
            return target.transform.position;
        }
        return target.transform.position + Vector3.up * targetCapsule.height / 2;
    }
    // Start is called before the first frame update
    void Start()
    {
        transform.LookAt(GetAim());
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null) return;
        if (isHoming && !target.GetDeathState())
        {
            transform.LookAt(GetAim());
        }
        
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Health>() != target) return;
        if (target.GetDeathState()) return;
        target.TakeDamage(instigator, damage);
        if (impactVFX != null)
        {
            Instantiate(impactVFX,GetAim() ,transform.rotation);
        }
        else
        {
            Debug.LogWarning("NO VFX on projectile");
        }
        foreach (GameObject projectileToDestroy in destructionArray)
        {
            Destroy(projectileToDestroy);
        }

        Destroy(gameObject, lifeAfterImpacttime);
    }
}
