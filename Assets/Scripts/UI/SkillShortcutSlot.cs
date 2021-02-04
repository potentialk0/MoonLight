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

    bool _isCoolDown = false;
    public bool isCoolDown { get => _isCoolDown; }

    // Start is called before the first frame update
    void Start()
    {
        
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
        else if(_currentSkill == null)
        {
            currentImage.sprite = idleImage;
        }
    }

	public void OnPointerClick(PointerEventData eventData)
	{
        UseSkill();
    }

    void CoolDown()
    {
        if (_isCoolDown == true)
        {
            currentImage.fillAmount -= 1 / _currentSkill.baseCooldown * Time.deltaTime;

            if (currentImage.fillAmount <= 0)
            {
                currentImage.fillAmount = 1;
                _isCoolDown = false;
            }
        }
    }

    public void UseSkill()
    {
        if (_isCoolDown == false)
        {
            _isCoolDown = true;
            currentImage.fillAmount = 1;
            if (_currentSkill != null)
            {
                GameObject obj = _currentSkill.skillObject;
                Instantiate(obj);
            }
        }
    }
}
