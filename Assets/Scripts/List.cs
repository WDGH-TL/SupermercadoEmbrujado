using System.Collections.Generic;
using TMPro;
using UnityEngine;
using System;

public class List : MonoBehaviour
{
    public TextMeshProUGUI groceryList;
    public TextMeshProUGUI productList;
    public int maxItemAmount;

    public string[] availableProducts;
    public int requestedProducts;
    public string selectedProduct;
    private List<string> selectedProductsList = new List<string>();
    private void Awake()
    {
        GroceryListItemAmount();
        GroceryListItems();
    }
    void Start()
    {
        groceryList.text = ("I want " + maxItemAmount + " things");
    }

    void GroceryListItemAmount()
    {
        if (availableProducts == null || availableProducts.Length == 0)
        {
            maxItemAmount = 0;
            return;
        }

        int maxPossible = Math.Min(6, availableProducts.Length);
        maxItemAmount = UnityEngine.Random.Range(1, maxPossible + 1);
    }

    void GroceryListItems()
    {
        if (maxItemAmount == 0)
        {
            productList.text = "No items requested.";
            return;
        }
        List<string> tempProducts = new List<string>(availableProducts);
        selectedProductsList.Clear();

        for (int i = 0; i < maxItemAmount; i++)
        {
            if (tempProducts.Count == 0) break;
            int randomIndex = UnityEngine.Random.Range(0, tempProducts.Count);
            selectedProductsList.Add(tempProducts[randomIndex]);
            tempProducts.RemoveAt(randomIndex);
        }
        DisplayFinalList();
    }
    void DisplayFinalList()
    {
        string finalDisplay = "";

        foreach (string product in selectedProductsList)
        {
            int productQuantity = UnityEngine.Random.Range(1, 4);

            finalDisplay += $"- {productQuantity} x {product}\n";
        }

        productList.text = finalDisplay;
    }
}
