using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemTpye
{
    Material,
    Equipment
}

[CreateAssetMenu(fileName = "New Item Data", menuName = "Data/Item")]
// 物品容器
public class ItemData : ScriptableObject
{
    public ItemTpye itemTpye;
    public string itemName;
    public Sprite icon;
}
