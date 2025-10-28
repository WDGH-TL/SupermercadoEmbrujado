using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    #region references
    public static DialogueManager Instance;
    #endregion
    public Dialogue initialDialogue;
    public TextMeshProUGUI dialogueText, nameText;
    public Image spriteImage;

    public bool isTalking;
    public int phraseIndex;
    public bool isTypeWriterEnded;
    private void Awake()
    {
     Instance = this;      
    }
    private void Update()
    {
       
    }

    public void Talk(Dialogue dialogo)
    {
        if (isTalking)
        {
            if (phraseIndex < initialDialogue.dialoguetext.Length - 1)
            {
                if (isTypeWriterEnded)
                {
                    phraseIndex++;
                    RefreshPhrase(dialogo);
                }
                else
                {
                    StopCoroutine("TypeWriterDialogue");
                    dialogueText.text = dialogo.dialoguetext[phraseIndex].phrase;
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
                    dialogueText.text = dialogo.dialoguetext[phraseIndex].phrase;
                    isTypeWriterEnded = true;
                }
            }
        }
        else
        {
            RefreshPhrase(dialogo);
            isTalking = true;
        }
    }

    private void RefreshPhrase(Dialogue dialogo)
    {
        nameText.text = dialogo.dialoguetext[phraseIndex].characterName;
        spriteImage.sprite = dialogo.dialoguetext[phraseIndex].characterSprite;

        StartCoroutine(TypeWriterDialogue(dialogo));
    }

    private IEnumerator TypeWriterDialogue(Dialogue dialogo)
    {
        isTypeWriterEnded = false;
        dialogueText.text = string.Empty;
        foreach (char character in dialogo.dialoguetext[phraseIndex].phrase)
        {
            dialogueText.text += character;
            yield return new WaitForSeconds(0.1f);
        }
        isTypeWriterEnded = true;
    }
}
