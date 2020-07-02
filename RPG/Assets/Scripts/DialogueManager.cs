using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{

    public Text dialogueText;
    public Text nameText;
    public GameObject dialoguePanel;
    public GameObject namePanel;

    public string[] dialogueLines;

    public int currentLine;
    private bool justStarted;

    public static DialogueManager instnace;

    void Start()
    {
        instnace = this;

        //dialogueText.text = dialogueLines[currentLine]; //This was used for testing purposes
    }


    void Update()
    {
        if (dialoguePanel.activeInHierarchy)//if dialoguePanel is active in the scene at the moment
        {
            if (Input.GetButtonUp("Fire1"))//When Fire1 button is released
            {
                if (!justStarted)//If have not tasted yet
                {
                    currentLine += 1;

                    if (currentLine >= dialogueLines.Length)
                    {
                        dialoguePanel.SetActive(false);

                        GameManager.instance.dialogActive = false;
                    }
                    else
                    {
                        CheckIfName();

                        dialogueText.text = dialogueLines[currentLine];
                    }
                }
                else//started is true
                {
                    justStarted = false;//Overal this fixes the skip line problem
                }
            }
        }
    }


    public void ShowDialogue(string[] newLines, bool isPerson)//Takes in an array of strings and names array newLines, this also says if object is a person
    {
        dialogueLines = newLines;//Whatever the array that was passed in contains... its then set to newLines array

        currentLine = 0;//Resets curentLine back to 0

        CheckIfName();

        dialogueText.text = dialogueLines[currentLine];//Makes sure the 1st line thats going to appear before Dialogue pannel appears is correct

        dialoguePanel.SetActive(true);

        justStarted = true;

        namePanel.SetActive(isPerson);//If this is a person then name Panel will show

        GameManager.instance.dialogActive = true;
    }

    public void CheckIfName()
    {
        if (dialogueLines[currentLine].StartsWith("n-"))
        {
            nameText.text = dialogueLines[currentLine].Replace("n-", "");
            currentLine++;
        }
    }
}