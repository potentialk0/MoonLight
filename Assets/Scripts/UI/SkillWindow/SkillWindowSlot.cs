using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class SkillWindowSlot : MonoBehaviour, IPointerClickHandler
{
    [SerializeField]
    SkillData _skillData;
    public SkillData skillData { get => _skillData; }
    Image[] skillImage;

	public void OnPointerClick(PointerEventData eventData)
	{
        SkillWindow.SelectSkillSlot(this);
        SkillWindow.StartShortcutAnim();
	}

	private void Awake()
    {
        skillImage = GetComponentsInChildren<Image>();
        skillImage[1].sprite = _skillData.iconImage;
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
