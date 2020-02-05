using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestPickup : MonoBehaviour
{
    [SerializeField] GameObject droppedVFX = null;
    bool isPickedUp = false;
    [SerializeField] GameObject UI = null;
    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Player")
        {
            UI.SetActive(true);
        }
        if(other.tag == "Player" && Input.GetKeyDown(KeyCode.F))
        {
            isPickedUp = true;
            UI.SetActive(false);
            Destroy(gameObject, 1f);

        }
    }
    public bool PickedUP()
    {
        return isPickedUp;
    }
}
