using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SkillWindowShortcutSlot : Slot, IPointerClickHandler
{
    [SerializeField]
    SkillData _currentSkill;
    public SkillData currentSkill { get => _currentSkill;}
    [SerializeField]
    Image currentImage;
    [SerializeField]
    Sprite idleImage;

    float scaleRange = 0.05f;
    float scaleSpeed = 15.0f;
    float t = 0;

    bool isSkillClicked = false;

    // Start is called before the first frame update
    void Start()
    {
        currentImage = GetComponent<Image>();
        DisplayUI();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        SkillWindow.CheckForSameSkill();
        SetSkillIcon();
        SkillWindow.StopShortcutAnim();
        SkillWindow.SyncSkillShortcuts();
    }

    public void StartScaleEffect()
    {
        if (isSkillClicked == false)
        {
            StartCoroutine(ChangeScale());
            isSkillClicked = true;
        }
    }

    public void StopScaleEffect()
    {
        isSkillClicked = false;
        StopAllCoroutines();
        transform.localScale = new Vector3(1, 1, 1);
    }

    void SetSkillIcon()
	{
        if (SkillWindow.GetSelectedSkillSlot() != null)
        {
            _currentSkill = SkillWindow.GetSelectedSkillSlot().skillData;
            SkillWindow.SelectSkillSlot(null);
        }
    }

    public void DisplayUI()
	{
        if(_currentSkill != null)
		{
            currentImage.sprite = _currentSkill.iconImage;
		}
        else
		{
            currentImage.sprite = idleImage;
        }
	}

    public void SetSkill(SkillData skill)
	{
        _currentSkill = skill;
	}

    IEnumerator ChangeScale()
    {
        while (true)
        {
            t += Time.deltaTime;
            float offset = Mathf.Sin(t * scaleSpeed) * scaleRange;
            transform.localScale = new Vector3(1 + offset, 1 + offset, 1 + offset);
            yield return null;
        }
    }
}
