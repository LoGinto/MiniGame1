using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Weapon", menuName = "Weapons/Make New Weapon", order = 0)]
public class WeaponScriptableObject :ScriptableObject
{
    public float damage = 4f;
    public string description = null;
    public GameObject prefabofWeapon = null;
    public AnimatorOverrideController animatorOverride = null;
    public bool isRightHanded = true;
    const string weaponName = "Weapon";
    public Projectile projectile = null;
    

    public void LaunchProjectile(Vector3 origin,Health target,GameObject instigator,float calcDamage)
    {
        Projectile projectileInstance = Instantiate(projectile, origin, Quaternion.identity);
        projectileInstance.SetTarget(target, instigator,damage);
    }
    public bool hasProjectile()
    {
        return projectile != null;
    }

     

    public void SpawnWeapon(Transform rightHand,Transform leftHand,Animator animator)
    {
        DestroyOldWeapon(rightHand, leftHand);
        if(prefabofWeapon == null)
        {
            Debug.LogWarning("No prefab found");
        }
        else
        {
            Transform handTransform = GetTransform(rightHand, leftHand);
            GameObject weapon = Instantiate(prefabofWeapon, handTransform);
            weapon.name = weaponName;
        }

        var overrideController = animator.runtimeAnimatorController as AnimatorOverrideController;
        if (animatorOverride != null)
        {
            animator.runtimeAnimatorController = animatorOverride;
        }
        else if (overrideController != null)
        {
            animator.runtimeAnimatorController = overrideController.runtimeAnimatorController;
        }
    }

    public void DestroyOldWeapon(Transform rightHand,Transform leftHand)
    {
        Transform oldWeapon = rightHand.Find(weaponName);
        if (oldWeapon == null)
        {
            oldWeapon = leftHand.Find(weaponName);
        }
        if (oldWeapon == null) return;

        oldWeapon.name = "DESTROYING";
        Destroy(oldWeapon.gameObject);
    }

    private Transform GetTransform(Transform rightHand, Transform leftHand)
    {
        Transform handTransform;
        if (isRightHanded) handTransform = rightHand;
        else handTransform = leftHand;
        return handTransform;
    }

    public float GetDamage()
    {
        return damage;
    }
    public string getDescription()
    {
        return description;
    }
    public GameObject GetPrefab()
    {
        return prefabofWeapon;
    }
    public AnimatorOverrideController GetAnimatorOverride()
    {
        return animatorOverride;
    }
}
