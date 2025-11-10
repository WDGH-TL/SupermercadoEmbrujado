using UnityEngine;
using TMPro;

public class Voucher : MonoBehaviour
{

    public GameObject voucher;
    public TextMeshProUGUI inventoryDisplay;
    public TextMeshProUGUI total;

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {

            if (voucher != null)
            {
                voucher.SetActive(true);
                string displayText = "\n";
                float totalValue = 0f;


                for (int i = 0; i < Inventory.Instance.itemInventory.Length; i++)
                {
                    Items item = Inventory.Instance.itemInventory[i];

                    if (item != null)
                    {
                        int productIndex = Inventory.Instance.itemIndex[i];

                        if (productIndex >= 0 && productIndex < item.itemTemplate.Length)
                        {
                            PRODUCTS productData = item.itemTemplate[productIndex];
                            float itemValue;
                            string rawValue = productData.productValue.Replace("$", "").Trim();

                            if (float.TryParse(rawValue, out itemValue))
                            {
                                totalValue += itemValue;
                                displayText += $"{i + 1}. {productData.productName} ${rawValue}\n";
                            }

                        }

                    }

                }

                inventoryDisplay.text = displayText;
                if (total != null)
                {

                    total.text = $"Total Value: ${totalValue:F2}";
                }
            }

        }
    }
    private void OnTriggerExit(Collider other)
    {

        if (other.CompareTag("Player"))
        {
            voucher.SetActive(false);
        }
    }
}