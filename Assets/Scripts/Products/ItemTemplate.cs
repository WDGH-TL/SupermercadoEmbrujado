using UnityEngine;

public class ItemTemplate : MonoBehaviour
{
    public Items itemText;

    public void displayItemText()
    {
        ItemManager.Instance.Display(itemText);
    }
}
