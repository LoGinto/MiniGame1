using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    public Health target;
    float damage;
    public WeaponScriptableObject weaponScriptableObject;
    public Transform origin = null;
    // Start is called before the first frame update
    void Start()
    {
        damage = weaponScriptableObject.GetDamage();
    }
    void Hit()
    {
        if (target == null) { return; }
        Debug.Log("Animation event is working");
        if (weaponScriptableObject.hasProjectile())
        {
            weaponScriptableObject.LaunchProjectile(origin.transform.position, target, gameObject,damage);
        }
        else
        {
            target.TakeDamage(gameObject, damage);
        }
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    public Health GetTarget()
    {
        return target;
    }
    void Shoot()
    {
        Hit();
    }
}
