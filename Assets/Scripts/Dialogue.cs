using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/// <summary>
/// Simple dialogue system. No choices. 
/// </summary>
public class Dialogue : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI theText;
    [SerializeField] string[] sentences;
    [SerializeField] float typeSpeed = 0.02f;
    [SerializeField] GameObject continueButton;
    [SerializeField] GameObject pressEbuttonUI;
    int index;

    private void Start()
    {
        continueButton.SetActive(false);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            pressEbuttonUI.SetActive(true);
           
        }
        
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player" && Input.GetKeyDown(KeyCode.E))
        {
            
            StartCoroutine(StartDialogue());
            continueButton.SetActive(true);
        }
        else
        {
            return;
        }
        
    }
   

    private void OnTriggerExit(Collider other)
    {
       
        if (other.tag == "Player")
        {
            pressEbuttonUI.SetActive(false);
            //continueButton.SetActive(false);
            
        }
    }
    public void NextSentence()//button func 
    {
        continueButton.SetActive(false);
        if (index < sentences.Length - 1)
        {
            index++;
            theText.text = "";
           
            StartCoroutine(StartDialogue());
           
        }
        else
        {
            theText.text = "";
            continueButton.SetActive(false);
        }
    }
    IEnumerator StartDialogue()
    {
        foreach (char letter in sentences[index].ToCharArray())
        {
            theText.text += letter;
            if (theText.text == sentences[index])
            {
                continueButton.SetActive(true);
            }
            yield return new WaitForSeconds(typeSpeed);
        }
    }
}