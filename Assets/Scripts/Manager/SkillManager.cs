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

    [SerializeField]
    SkillButton[] skillButtons;
    [SerializeField]
    Skill[] s;
    public GameObject effect;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Skill Manager Executed");
		for (int i = 0; i < skillButtons.Length; i++)
		{
			//skillButtons[i].GetComponent<Button>().onClick.AddListener(delegate { UseSkill(i); });
            skillButtons[i].GetComponent<Button>().onClick.AddListener(UseSkill);
        }
	}

    // Update is called once per frame
    void Update()
    {
        
    }
    void UseSkill()
	{
        Debug.Log("Skill Used!!");
        GameObject obj = effect;
        Instantiate(obj, player.transform.position, player.transform.rotation);
	}

    void UseSkill(int a)
	{

	}
}
