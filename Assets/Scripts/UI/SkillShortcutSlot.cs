using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

// image type == filled, fill origin == top, Clockwise X
public class SkillShortcutSlot : MonoBehaviour, IPointerClickHandler
{
    [SerializeField]
    SkillData _currentSkill;
    public SkillData currentSkill { get => _currentSkill; }
    [SerializeField]
    Image currentImage;
    [SerializeField]
    Sprite idleImage;

    bool isCoolDown = false;

    // Start is called before the first frame update
    void Start()
    {
        currentImage = GetComponent<Image>();
        DisplayUI();
    }

    // Update is called once per frame
    void Update()
    {
        if(_currentSkill != null)
            CoolDown();
    }

    public void SetSkill(SkillData skill)
    {
        _currentSkill = skill;
    }

    public void DisplayUI()
    {
        if (_currentSkill != null)
        {
            currentImage.sprite = _currentSkill.iconImage;
        }
        else
        {
            currentImage.sprite = idleImage;
        }
    }

	public void OnPointerClick(PointerEventData eventData)
	{
        if (isCoolDown == false)
        {
            isCoolDown = true;
            currentImage.fillAmount = 1;
            UseSkill();
        }
    }

    void CoolDown()
    {
        if (isCoolDown == true)
        {
            currentImage.fillAmount -= 1 / _currentSkill.baseCooldown * Time.deltaTime;

            if (currentImage.fillAmount <= 0)
            {
                currentImage.fillAmount = 1;
                isCoolDown = false;
            }
        }
    }

    void UseSkill()
	{
        if(_currentSkill != null)
		{
            GameObject obj = _currentSkill.skillObject;
            Instantiate(obj);
        }
	}
}
