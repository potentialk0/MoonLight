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
    public static SkillIcon currentUISkill;
    private static SkillWindowSlot selectedSkillSlot = null;
    public List<SkillWindowShortcutSlot> UIshortcut = new List<SkillWindowShortcutSlot>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void SelectSkill(SkillWindowSlot selectedSlot)
    {
        selectedSkillSlot = selectedSlot;
    }

    public static SkillWindowSlot GetSelectedSkill()
    {
        return selectedSkillSlot;
    }

    public void OnClicked()
    {
        for(int i = 0; i < UIshortcut.Count; i++)
        {
            UIshortcut[i].OnSelected();
        }
    }
}
