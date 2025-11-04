using UnityEngine;

public class NPCDialogue : MonoBehaviour
{
    public Dialogue NpcDialogo;
   public void StartConversation()
    {
        DialogueManager.Instance.Talk(NpcDialogo);
    }
}
