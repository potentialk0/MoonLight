using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SkillWindowSlot : Slot, IPointerClickHandler
{
    Image[] skillImage;

	public void OnPointerClick(PointerEventData eventData)
	{
        SkillManager.currentUISkill = icon.GetComponent<SkillIcon>();
        SkillWindow.SelectSkill(this);
	}

	private void Awake()
    {
        _iconType = ICONTYPE.SKILL;
        _slotType = SLOTTYPE.UI;
        skillImage = GetComponentsInChildren<Image>();
        skillImage[1].sprite = icon.GetComponent<SkillIcon>().skillData.iconImage;
        skillImage[1].gameObject.GetComponent<RectTransform>().localScale = new Vector3(0.8f, 0.8f, 0.8f);
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
