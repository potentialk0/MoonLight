using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SkillObject : MonoBehaviour
{
    public SkillData skillData;

    void Awake()
	{
        Debug.Log(skillData.value);
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
