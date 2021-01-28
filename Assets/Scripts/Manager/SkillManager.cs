using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillManager : MonoBehaviour
{
    private static SkillManager instance;

    public static SkillManager Instance
    {
        get
        {
            if (null == instance)
            {
                instance = new SkillManager();
            }
            return instance;
        }
    }

    PlayerController player;
    bool isGlobalCooldown = false;
    float globalCooldown = 1.0f;

    public static bool isAutoAttacking = false;

    public List<SkillIcon> allSkills = new List<SkillIcon>();
    public static SkillIcon currentSkillIcon;
    public static List<SkillIcon> currentSkillIconList = new List<SkillIcon>();
    public static Queue<SkillIcon> skillIconQueue = new Queue<SkillIcon>();

    public static SkillIcon currentUISkill;

    private void Awake()
    {
        player = GameObject.Find("PlayerObject").GetComponent<PlayerController>();
    }

	private void Update()
	{
		if(player.currentState == STATE.ATTACK)
		{
            AutoSkill();
		}
        if(Input.GetKeyDown(KeyCode.Space))
		{
            Debug.Log("---------- Skills are ----------");
            ShowSkill();
		}
	}

    // skillData를 가지고 있는 게 아니라 skillIcon을 가지고 있어야 한다~
    void AutoSkill()
	{
        if(isGlobalCooldown == true)
		{

		}
	}

	public static void ShowSkill()
	{
        for(int i = 0; i < currentSkillIconList.Count; i++)
		{
            Debug.Log(currentSkillIconList[i].skillData.name);
		}
	}

    public static void UseSkill()
    {
        GameObject obj = currentSkillIcon.skillData.skillObject;
        Instantiate(obj);
    }
}
