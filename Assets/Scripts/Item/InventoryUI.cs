using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public Inventory inventory;
    public Transform content;
    public ItemUI itemObjectUIPrefab;

    // Start is called before the first frame update
    void Start()
    {
        if (inventory) Display(inventory);
    }

    public virtual void Display(Inventory i)
	{
        this.inventory = i;
        Refresh();
	}

    public virtual void Refresh()
    {
        foreach(Transform t in content)
		{
            Destroy(t.gameObject);
		}

        foreach(ItemObject i in inventory.itemObjects)
		{
            ItemUI ui = ItemUI.Instantiate(itemObjectUIPrefab, content);
            ui.Display(i);
		}
    }
}
