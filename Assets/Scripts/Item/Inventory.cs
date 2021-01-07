using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Inventory
{
    public InventorySlot[] slots = new InventorySlot[24];

    public void Clear()
	{
		foreach(InventorySlot slot in slots)
		{
			//slot.UpdateSlot(new Item(), 0); 아랫줄과 동일
			slot.RemoveItem();
		}
	}

	/*
	// 인벤토리에 해당 아이템이 포함되어있느냐 판단
	public bool IsContained(ItemObject itemObject)
	{
		return IsContained(itemObject.data.id);
		//return Array.Find(slots, i => i.item.id == itemObject.data.id) != null;
	}

	public bool IsContained(int id)
	{
		return slots.FirstOrDefault(i => i.item.id == id) != null;
	}*/
}
