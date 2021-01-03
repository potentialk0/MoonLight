using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class InventorySlot
{
    public ItemType[] allowedItems = new ItemType[0];

    //[NonSerialized]
    //public InventoryObject parent; // 초기화되기 때문에 json으로 연동하지 않기 위해 nonserialized
    [NonSerialized]
    public GameObject slotUI;

    // 갱신될 때 변경할 수 있게
    [NonSerialized]
    public Action<InventorySlot> OnPreUpdate;
    [NonSerialized]
    public Action<InventorySlot> OnPostUpdate;

    public Item item;
    public int amount; // stackable한 아이템을 위한 변수

    /*
    public ItemObject ItemObject
	{
		get
		{
            return item.id >= 0 ? parent.database.itemObject[item.id] : null;
		}
	}*/

    public InventorySlot() => UpdateSlot(new Item(), 0);
    public InventorySlot(Item item, int amount) => UpdateSlot(item, amount);

    public void RemoveItem() => UpdateSlot(new Item(), 0);

    public void AddAmount(int value) => UpdateSlot(item, amount += value);

    // slot 갱신
    public void UpdateSlot(Item item, int amount)
	{
        OnPreUpdate?.Invoke(this);

        this.item = item;
        this.amount = amount;

        OnPostUpdate?.Invoke(this);
	}

    public bool CanPlaceInSlot(ItemObject itemObject)
    {
        // 비어있으면 true
        if (allowedItems.Length <= 0 || itemObject == null || itemObject.data.id < 0)
		{
            return true;
		}

        // 허용된 type이면 true
        foreach(ItemType type in allowedItems)
		{
            if (itemObject.type == type) return true;
		}

        return false;
	}
}
