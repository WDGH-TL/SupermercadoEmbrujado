using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public Dialogue initialDialogue;
    public TextMeshProUGUI dialogueText, nameText;
    public Image spriteImage;

    public bool isTalking;
    public int phraseIndex;
    public bool isTypeWriterEnded;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.F))
        {
            Talk();
        }
    }

    private void Talk()
    {
        if (isTalking)
        {
            if (phraseIndex < initialDialogue.dialoguetext.Length - 1)
            {
                if (isTypeWriterEnded)
                {
                    phraseIndex++;
                    RefreshPhrase();
                }
                else
                {
                    StopCoroutine("TypeWriterDialogue");
                    dialogueText.text = initialDialogue.dialoguetext[phraseIndex].phrase;
                    isTypeWriterEnded = true;
                }
            }
            else
            {
                if (isTypeWriterEnded)
                {
                    nameText.text = string.Empty;
                    dialogueText.text = string.Empty;
                    spriteImage.sprite = null;
                    phraseIndex = 0;
                    isTalking = false;
                }
                else
                {
                    StopCoroutine("TypeWriterDialogue");
                    dialogueText.text = initialDialogue.dialoguetext[phraseIndex].phrase;
                    isTypeWriterEnded = true;
                }
            }
        }
        else
        {
            RefreshPhrase();
            isTalking = true;
        }
    }

    private void RefreshPhrase()
    {
        nameText.text = initialDialogue.dialoguetext[phraseIndex].characterName;
        spriteImage.sprite = initialDialogue.dialoguetext[phraseIndex].characterSprite;

        StartCoroutine("TypeWriterDialogue");
    }

    private IEnumerator TypeWriterDialogue()
    {
        isTypeWriterEnded = false;
        dialogueText.text = string.Empty;
        foreach (char character in initialDialogue.dialoguetext[phraseIndex].phrase)
        {
            dialogueText.text += character;
            yield return new WaitForSeconds(0.1f);
        }
        isTypeWriterEnded = true;
    }
}
