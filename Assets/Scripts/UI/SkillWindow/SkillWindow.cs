using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillWindow : MonoBehaviour
{
    private static SkillWindow instance = null;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }

    public static SkillWindow Instance
    {
        get
        {
            if (instance == null)
            {
                return null;
            }
            return instance;
        }
    }
    private static SkillWindowSlot selectedSkillSlot = null;

    [SerializeField]
    public List<SkillWindowShortcutSlot> _skillWindowShortcuts = new List<SkillWindowShortcutSlot>();
    private static List<SkillWindowShortcutSlot> skillWindowShortcuts = new List<SkillWindowShortcutSlot>();

    [SerializeField]
    public List<SkillShortcutSlot> _skillShortcuts = new List<SkillShortcutSlot>();
    private static List<SkillShortcutSlot> skillShortcuts = new List<SkillShortcutSlot>();

    RectTransform rect;

    // Start is called before the first frame update
    void Start()
    {
        rect = GetComponent<RectTransform>();
        skillWindowShortcuts = _skillWindowShortcuts;
        skillShortcuts = _skillShortcuts;
        SyncSkillShortcuts();
        Debug.Log(rect.anchoredPosition.x);
        Debug.Log(rect.anchoredPosition.y);
        StartCoroutine(Show());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void SelectSkillSlot(SkillWindowSlot selectedSlot)
    {
        selectedSkillSlot = selectedSlot;
    }

    public static SkillWindowSlot GetSelectedSkillSlot()
    {
        return selectedSkillSlot;
    }

    public static void StartShortcutAnim()
    {
        for(int i = 0; i < skillWindowShortcuts.Count; i++)
        {
            skillWindowShortcuts[i].StartScaleEffect();
        }
    }

    public static void CheckForSameSkill()
    {
        if (selectedSkillSlot == null) return;
        for (int i = 0; i < skillWindowShortcuts.Count; i++)
        {
            if (skillWindowShortcuts[i].currentSkill == selectedSkillSlot.skillData)
            {
                skillWindowShortcuts[i].SetSkill(null);
                return;
            }
        }
    }

    public static void StopShortcutAnim()
	{
        for(int i = 0; i < skillWindowShortcuts.Count; i++)
		{
            skillWindowShortcuts[i].StopScaleEffect();
            skillWindowShortcuts[i].DisplayUI();
		}
    }

    public static void SyncSkillShortcuts()
	{
        for(int i = 0; i < skillWindowShortcuts.Count; i++)
		{
            skillShortcuts[i].SetSkill(skillWindowShortcuts[i].currentSkill);
            skillShortcuts[i].DisplayUI();
		}
	}

    IEnumerator Show()
	{
        while(rect.anchoredPosition.x > -300)
		{
            transform.position -= transform.right * 1000 * Time.deltaTime;
            if (rect.anchoredPosition.x <= -300)
                rect.anchoredPosition = new Vector2(-300, -540);
            yield return null;
		}
	}
}
