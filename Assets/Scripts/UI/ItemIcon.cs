using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ItemIcon : Icon, IBeginDragHandler, IPointerUpHandler
{
    [SerializeField] Item _item;
    public Item item { get => _item; }

    // Start is called before the first frame update
    void Start()
    {
        iconType = ICONTYPE.ITEM;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    new public void OnBeginDrag(PointerEventData eventData)
	{
        base.OnBeginDrag(eventData);
		if (UI.GetCurrentSlot().GetType() == typeof(CharacterItemSlot))
		{
			UI.GetCurrentSlot().GetComponent<CharacterItemSlot>().playerStats.UnEquip(item);
		}
	}

    new public void OnPointerUp(PointerEventData eventData)
	{
        base.OnPointerUp(eventData);
        if(UI.GetCurrentSlot() == null)
		{
            previousSlot.GetComponent<CharacterItemSlot>().playerStats.Equip(item);
        }
	}
}
