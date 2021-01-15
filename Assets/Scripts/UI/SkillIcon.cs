using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SkillIcon : Icon
{
	[SerializeField] Skill skill;

	// Start is called before the first frame update
	void Start()
    {
        iconType = ICONTYPE.SKILL;
        GetComponent<Image>().sprite = skill.iconImage;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            skill.Use();
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
        skill.Use();
	}

}
