using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public void Jugar()
    {
        SceneManager.LoadScene("BossApartment");
    }

    public void DeCompras()
    {
        SceneManager.LoadScene("GroceryStore");
    }

    public void Comprar()
    {
        SceneManager.LoadScene("BossJudgement");
    }

    public void Salir()
    {
        Application.Quit();
    }    

}
