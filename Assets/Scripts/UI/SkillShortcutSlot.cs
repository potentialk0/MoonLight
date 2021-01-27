using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillShortcutSlot : Slot
{
    private void Awake()
    {
        _iconType = ICONTYPE.SKILL;
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

    public void SetSkill()
	{
        _icon.GetComponent<SkillIcon>().GetSkillData();
    }
}
