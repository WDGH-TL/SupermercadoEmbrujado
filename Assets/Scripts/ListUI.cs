using UnityEngine;
using System.Collections.Generic;
using TMPro;

public class ListUI : MonoBehaviour
{
    public TextMeshProUGUI displayUI;
    private List<string> loadedGroceryList = new List<string>();

    void Start()
    {
        LoadGroceryList();
        Dictionary<string, int> loadedList = LoadingGroceryList();
        DisplayLoadedList(loadedList);
    }

    void LoadGroceryList()
    {
        if(PlayerPrefs.HasKey("GroceryList"))
        {
            string serializedList = PlayerPrefs.GetString("GroceryList");
            string[] productArray = serializedList.Split(',');
            loadedGroceryList = new List<string>(productArray);
        }
    }
    void DisplayLoadedList(Dictionary<string, int> list)
    {
        string display = "Shopping List:\n";

        if (list.Count == 0)
        {
            displayUI.text = "No hay productos en la lista.";
            return;
        }

        foreach (KeyValuePair<string, int> item in list)
        {
            display += $"- {item.Value} x {item.Key}\n";
        }

        displayUI.text = display;
    }
    Dictionary<string, int> LoadingGroceryList()
    {
        Dictionary<string, int> loadedList = new Dictionary<string, int>();

        if (PlayerPrefs.HasKey("GroceryListWithQuantity"))
        {
            string serializedList = PlayerPrefs.GetString("GroceryListWithQuantity");

            string[] productEntries = serializedList.Split('#');

            foreach (string entry in productEntries)
            {
                string[] parts = entry.Split(':');

                if (parts.Length == 2 && int.TryParse(parts[1], out int quantity))
                {
                    string productName = parts[0];
                    loadedList.Add(productName, quantity);
                }
            }
        }
        return loadedList;
    }
}
