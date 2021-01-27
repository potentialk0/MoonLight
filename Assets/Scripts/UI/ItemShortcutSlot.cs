using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemShortcutSlot : Slot
{
	private void Awake()
	{
        _iconType = ICONTYPE.ITEM;
        _slotType = SLOTTYPE.SHORTCUT;
	}

	// Start is called before the first frame update
	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
