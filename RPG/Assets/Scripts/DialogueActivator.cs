using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueActivator : MonoBehaviour
{

    public string[] lines;

    private bool canActivate;

    public bool isPerson = true;

    void Start()
    {
        
    }

    
    void Update()
    {
        if (canActivate && Input.GetButtonDown("Fire1") && !DialogueManager.instnace.dialoguePanel.activeInHierarchy)//if canActivate is true, and you clicked mouse button down, and dialoguePannel is not active in hierachy
        {
            DialogueManager.instnace.ShowDialogue(lines, isPerson);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)//When player is inside area canActivate is set to true
    {
        if(collision.tag == "Player")
        {
            canActivate = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)//when player is outside of area canActivate is set to false
    {
        if (collision.tag == "Player")
        {
            canActivate = false;
        }
    }
}
