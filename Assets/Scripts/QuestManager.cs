using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestManager : MonoBehaviour
{
    //probably will put it on trigger or player, let's see
    public GameObject[] enemiesToKill = null;
    public GameObject[] thingsToTake = null;
    public string description_of_Guest = null;
    public string title_of_Guest = null; 
    public GameObject questPanel = null;
    public Text ui_text = null;
    public Text ui_title = null;
    public Text accept_button = null;
    bool isAccepted = false;
    bool allEnemiesKilled = false;
    bool allThingsAreTaken = false;
    bool questFinished = false;
    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Player" && Input.GetKeyDown(KeyCode.Q))
        {
            Debug.Log("Trigger worked for player");
            ShowQuestUI();
        }
        //Debug.Log("Collision occurs");
    }

    private void ShowQuestUI()
    {
        ui_title.text = title_of_Guest.ToString();
        ui_text.text = description_of_Guest.ToString();
        questPanel.SetActive(true);
    }

    public void CloseButton()
    {
        questPanel.SetActive(false);
    }
    public void Accept()
    {
        Debug.Log("Quest accepted" +
            "Let's roll");
        Destroy(accept_button,1f);
        isAccepted = true;
    }
    private void Update()
    {
        if (isAccepted)
        {
            DoTheQuest();
            if (Input.GetKeyDown(KeyCode.Q))
            {
                ShowQuestUI();
            }
        }

    }
    void DoTheQuest()
    {
        if (enemiesToKill.Length != 0)
        {

            try
            {
                int deadEnemyCount = 0;
                foreach (GameObject enemy in enemiesToKill)
                {
                    if (enemy.GetComponent<Health>().GetHealthPoints() <= 0)
                    {
                        deadEnemyCount++;
                    }
                    if (deadEnemyCount == enemiesToKill.Length)
                    {
                        Debug.Log("You killed all enemies");
                        break;
                    }
                }
               
            }
            catch
            {
                Debug.LogError("Wrong objects with no Health");
            }
        }
        else
        {
            allEnemiesKilled = true;
        }
        if(thingsToTake.Length != 0)
        {
            int takeCount = 0;
            foreach(GameObject pickup in thingsToTake)
            {
                if (pickup.GetComponent<QuestPickup>().PickedUP())
                {
                    takeCount++;
                }
                if(takeCount == thingsToTake.Length)
                {
                    Debug.Log("You took everything");
                    break;
                }
            }
        }
        else
        {
            allThingsAreTaken = true;
        }
        if (allEnemiesKilled && allThingsAreTaken)
        {
            questFinished = true;
            Debug.Log("Finished Quest");
            //Reward System to do
        }
    }
    public bool QuestIsFinished()
    {
        return questFinished;
    }
}
