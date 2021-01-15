using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateSystem : StateMachine
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnAttackButton()
	{
        StartCoroutine(state.Attack());
	}

    public void OnHealButton()
	{
        StartCoroutine(state.Heal());
	}
}
