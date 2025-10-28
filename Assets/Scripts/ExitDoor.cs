using UnityEngine;

public class ExitDoor : MonoBehaviour
{
    public GameObject Clue;

    public void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            Clue.SetActive(false);
            Invoke("ClueHide", 2f);
        }
    }

    void ClueHide()
    {
        if (Clue != null)
        {
            Clue.SetActive(false);
        }
    }
}
