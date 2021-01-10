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
    Slot[] skillSlots;
    [SerializeField]
    GameObject[] skills;
    
    public GameObject effect;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
		for (int i = 0; i < skillSlots.Length; i++)
		{
            //skillSlots[i].GetComponent<Button>().onClick.AddListener(delegate { player.GetComponent<PlayerController>().ChangeState(STATE.ATTACK); });
        }
        
	}

    // Update is called once per frame
    void Update()
    {
        
    }

    void ShowInt(int a)
	{
        Debug.Log(a);
	}

    void UseSkill()
	{
        Debug.Log("Skill Used!!");
        GameObject obj = effect;
        Instantiate(obj, player.transform.position, player.transform.rotation);
	}

    void UseSkill(int a)
	{
        Instantiate(skills[a]);
	}
}
