using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName = "New Inventory Item", menuName = "Inventory System/Items")]
public class InventoryItem : ScriptableObject
{
    public string itemName;
    public Sprite itemIcon;
    public bool isUnique;
}
