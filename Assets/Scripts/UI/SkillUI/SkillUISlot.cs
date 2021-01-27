using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SkillUISlot : Slot, IPointerClickHandler
{
    Image[] skillImage;

	public void OnPointerClick(PointerEventData eventData)
	{
        SkillManager.currentUISkill = icon.GetComponent<SkillIcon>();
	}

	private void Awake()
    {
        _iconType = ICONTYPE.SKILL;
        _slotType = SLOTTYPE.UI;
        skillImage = GetComponentsInChildren<Image>();
        skillImage[1].sprite = icon.GetComponent<SkillIcon>().skillData.iconImage;
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
