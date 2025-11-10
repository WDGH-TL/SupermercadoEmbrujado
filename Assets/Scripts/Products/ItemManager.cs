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
        productName.text = item.itemTemplate[productIndex].productName;
        productValue.text = item.itemTemplate[productIndex].productValue;
    }

    public string GetProductName(Items item)
    {
        return item.itemTemplate[productIndex].productName;
    }
}
