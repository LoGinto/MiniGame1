using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Slot : MonoBehaviour
{
    public GameObject item;
    public string type;
    public string description;
    public int ID;
    public bool isEmpty;
    public Sprite icon;
    public Transform slotIconGameObject; 
    // Start is called before the first frame update
    void Start()
    {
        slotIconGameObject = transform.GetChild(1);
    }
    public void SlotUpdate()
    {
        slotIconGameObject.GetComponent<Image>().sprite = icon;
    }
   
}
