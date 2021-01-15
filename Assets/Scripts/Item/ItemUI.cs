using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemUI : MonoBehaviour
{
    public ItemObject itemObject;
    public Text itemName;

    // Start is called before the first frame update
    void Start()
    {
        if (itemObject) Display(itemObject);
    }


    public virtual void Display(ItemObject item)
	{
        this.itemObject = item;
        itemName.text = item.name;
	}
}
