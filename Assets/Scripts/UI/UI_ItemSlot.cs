using UnityEngine.UI;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

// 物品槽
public class UI_ItemSlot : MonoBehaviour , IPointerDownHandler
{
    [SerializeField] private Image itemImage;
    [SerializeField] private TextMeshProUGUI itemText;


    public InventoryItem item;


    public void UpdateSlot(InventoryItem _newitem)
    {
        item = _newitem;

        itemImage.color = Color.white;
        
        if (item != null)
        {
            itemImage.sprite = item.data.icon;
            if (item.stackSize > 1)
            {
                itemText.text = item.stackSize.ToString();
            }
            else
            {
                itemText.text = "";
            }
        }
    }

    public void CleanUpSlot()
    {
        item = null;

        itemImage.sprite = null;
        itemImage.color = Color.clear;
        itemText.text = "";
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (item.data.itemTpye == ItemTpye.Equipment)
            Inventory.instance.EquipItem(item.data);
    }
}
