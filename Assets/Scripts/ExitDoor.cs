using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitDoor : MonoBehaviour
{
    public GameObject Clue;

    public void backToDaBoss()
    {
        SceneManager.LoadScene("BossApartment");
    }

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
