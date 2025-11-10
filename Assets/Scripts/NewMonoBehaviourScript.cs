using UnityEngine;

[CreateAssetMenu(fileName = "NewItem", menuName = "ScriptableObjects/Item")] //PERMITE CREAR UN ARCHIVO EN LA RUTA CREATE --> ScriptableObjects --> Item
public class MA3_ItemScriptable : ScriptableObject //EN VEZ DE MONOBEHAVIOUR, LO CAMBIAMOS POR ScriptableObject
{
    public string itemName;
    public string itemDescription;
    public int itemPrice;
}