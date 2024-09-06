using System;


[Serializable]
// 物品包装类，包含一个物品和数量，相当于同一个物品可以叠加，而不是每个物品占一格
public class InventoryItem 
{
    public ItemData data;
    public int stackSize;

    public InventoryItem(ItemData _newItemData)
    {
        data = _newItemData;
        AddStack();
    }

    public void AddStack() => stackSize++;

    public void RemoveStack() => stackSize--;

}
