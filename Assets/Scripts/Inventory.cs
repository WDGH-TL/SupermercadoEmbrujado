using Unity.VisualScripting;
using UnityEngine;

public class Inventory : MonoBehaviour
{

    public static Inventory Instance;
    public Items[] itemInventory;
    public int[] itemIndex;


    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        itemInventory = new Items[36];
        itemIndex = new int[36];
    }


    public void AddItemToInventory(RaycastHit hit)
    {
        ItemTemplate itemToAdd = hit.transform.GetComponent<ItemTemplate>();
        int addedToIndex = ItemManager.Instance.productIndex;

        for (int i = 0; i < itemInventory.Length; i++)
        {
            if (itemInventory[i] == null)
            {
                itemInventory[i] = itemToAdd.itemText;
                itemIndex[i] = addedToIndex;
                Destroy(itemToAdd.gameObject);
                break;
            }
        }
    }
}
