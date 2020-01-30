using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public bool inventoryEnabled;
    public GameObject inventoryCanvas;
    int slotAmount;
    int availableSlots;
    GameObject[] slot;
    [SerializeField] GameObject itemHolder;

    private void Start()
    {
        inventoryEnabled = false;
        LoopedSlots();

    }

    private void Update()
    {
        EnableInventorySystem();
    }
    void EnableInventorySystem()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            inventoryEnabled = !inventoryEnabled;
        }
        if (inventoryEnabled)
        {
            inventoryCanvas.SetActive(true);

        }
        else
        {
            inventoryCanvas.SetActive(false);
        }
    }
    void LoopedSlots()
    {
        slotAmount = 14;
        slot = new GameObject[availableSlots];
        for(int i = 0; i < slotAmount; i++)
        {
            slot[i] = itemHolder.transform.GetChild(i).gameObject;
            if (slot[i].GetComponent<Slot>().item = null)
            {
                slot[i].GetComponent<Slot>().isEmpty = true;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Item")
        {
           
            GameObject pickedUpItem = other.gameObject;
            Item item = pickedUpItem.GetComponent<Item>();
            AddItem(pickedUpItem, item.ID,item.type,item.description, item.icon);
        }
    }
   private void AddItem(GameObject itemObject, int itemID,string itemType,string itemDescription,Sprite itemIcon)
    {
        for(int i = 0;i < slotAmount; i++)
        {
            if (slot[i].GetComponent<Slot>().isEmpty)
            {
                itemObject.GetComponent<Item>().pickedUp = true;
                slot[i].GetComponent<Slot>().item = itemObject;
               slot[i].GetComponent<Slot>().icon = itemIcon;
                slot[i].GetComponent<Slot>().type = itemType;
                slot[i].GetComponent<Slot>().ID = itemID;
                slot[i].GetComponent<Slot>().description = itemDescription;
                itemObject.transform.parent = slot[i].transform;
                itemObject.SetActive(false);
                    slot[i].GetComponent<Slot>().SlotUpdate();
                    slot[i].GetComponent<Slot>().isEmpty = false;
                return;
            }
            
        }
    }
}
