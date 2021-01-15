using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;




public class CharacterItemSlot : Slot, IDropHandler
{
    StatContainer _playerStats;
    Item item;

    public StatContainer playerStats { get => _playerStats; }

    private void Awake()
	{
        _playerStats = GameObject.Find("PlayerObject").GetComponent<StatContainer>();
        iconType = ICONTYPE.ITEM;
        slotType = SLOTTYPE.UI;
	}

	// Start is called before the first frame update
	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    new public void OnDrop(PointerEventData eventData)
	{
        ItemIcon dragIcon = eventData.pointerDrag.GetComponent<ItemIcon>();
        if (dragIcon != null)
        {
            dragIcon.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
            item = dragIcon.item;

            _playerStats.Equip(item);
        }
	}
}
