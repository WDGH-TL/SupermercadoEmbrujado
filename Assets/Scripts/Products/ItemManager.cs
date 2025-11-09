using TMPro;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    public static ItemManager Instance;
    public TextMeshProUGUI productName, productValue;

    public int productIndex;
    public GameObject ItemUI;

    private void Awake()
    {
        Instance = this;
    }

    public void Display(Items item)
    {
        Debug.Log("Is Calling");
        Debug.Log(item.itemTemplate[productIndex].productName);
        Debug.Log(item.itemTemplate[productIndex].productValue);
        productName.text = item.itemTemplate[productIndex].productName;
        productValue.text = item.itemTemplate[productIndex].productValue;
       
    }
}
