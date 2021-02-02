using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SkillIcon : Icon
{
	[SerializeField] public SkillData skillData;
    bool isCoolDown = false;
    Image image;

	// Start is called before the first frame update
	void Start()
    {
        iconType = ICONTYPE.SKILL;
        image = GetComponent<Image>();
        image.sprite = skillData.iconImage;
    }

    // Update is called once per frame
    void Update()
    {
        CoolDown();
    }

	public override void OnBeginDrag(PointerEventData eventData)
	{
		base.OnBeginDrag(eventData);
        if(UI.GetCurrentSlot() != null && UI.GetCurrentSlot().slotType == SLOTTYPE.SHORTCUT)
		{
            SkillManager.currentSkillIconList.Remove(this);
		}
	}

	public override void OnPointerDown(PointerEventData eventData)
	{
        canvasGroup.alpha = 0.8f;
        if (eventData != null)
        {
            previousSlot = UI.GetCurrentSlot();
            transform.SetAsLastSibling();
        }

        if (isCoolDown == false)// && UI.GetCurrentSlot().slotType == SLOTTYPE.SHORTCUT)
        {
            isCoolDown = true;
            image.fillAmount = 1;
            SkillManager.currentSkillIcon = this;
            SkillManager.UseSkill();
        }
	}

    public override void OnEndDrag(PointerEventData eventData)
	{
        base.OnEndDrag(eventData);
        // 드래그가 끝난 위치가 슬롯이 아니고 숏컷 슬롯에서 드래그가 시작되었다면
        if(UI.GetCurrentSlot() == null && previousSlot.slotType == SLOTTYPE.SHORTCUT)
		{
            // 다시 스킬리스트에 추가
            SkillManager.currentSkillIconList.Add(this);
        }
        else if(UI.GetCurrentSlot() != null)
		{
            SkillManager.currentSkillIconList.Add(this);
		}
	}

    void CoolDown()
	{
        if (isCoolDown == true)
		{
            image.fillAmount -= 1 / skillData.baseCooldown * Time.deltaTime;

            if(image.fillAmount <= 0)
			{
                image.fillAmount = 1;
                isCoolDown = false;
			}
		}
	}

    public SkillData GetSkillData()
	{
        return skillData;
	}
}
