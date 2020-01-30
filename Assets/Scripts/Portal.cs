using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
/// <summary>
/// Portal, a bit simplified
/// </summary>
/// 

public class Portal : MonoBehaviour
{
    public GameObject uiStuff;
    [SerializeField] int scenetoLoad = -1;
    private void Start()
    {
        uiStuff.SetActive(false);
    }
    private void OnTriggerStay(Collider doorscollision)
    {
        Debug.Log("Door is triggered like an angry feminist");
        if(doorscollision.tag == "Player")
        {
            uiStuff.SetActive(true);
        }
        if(doorscollision.tag == "Player"&& Input.GetKeyDown(KeyCode.F))
        {
            OpenTheDoor();

        }
    }
    private void OnTriggerExit(Collider other)
    {
        uiStuff.SetActive(false);
    }
    private void OpenTheDoor()
    {
        if (scenetoLoad < 0)
        {
            Debug.LogError("No scene to load");
            //return;
        }
        else if(scenetoLoad <= 0)
        {
            SceneManager.LoadScene(scenetoLoad);
        }
    }
}
