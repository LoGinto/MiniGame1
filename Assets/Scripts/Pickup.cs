using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    public Transform rightHandTransform = null;
    public Transform leftHandTransform = null;
    public WeaponScriptableObject weaponToPickup = null;
    public GameObject pressButtonToEquipText = null; 
    
    private void OnTriggerStay(Collider other)
    {
        pressButtonToEquipText.SetActive(true);
        
        if (other.tag == "Player")
        {
            
            if (Input.GetKeyDown(KeyCode.E))
            {
                weaponToPickup.SpawnWeapon(rightHandTransform, leftHandTransform, other.GetComponent<Animator>());
                Destroy(gameObject);
                pressButtonToEquipText.SetActive(false);
                other.GetComponent<PlayerAttackScript>().weapon = weaponToPickup;
            }
            if (rightHandTransform == null || leftHandTransform == null)
            {
                Debug.LogError("RightHandTransform or LeftHandTransform are not assigned");
            }
           // Destroy(gameObject);
        }
    }

    //private void OnTriggerExit(Collider other)
    //{
    //    pressButtonToEquipText.SetActive(false);
    //}


}
