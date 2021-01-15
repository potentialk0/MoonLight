using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Begin : State
{
    public Begin(StateSystem stateSystem) : base(stateSystem) { }

	public override IEnumerator Start()
	{ 
		yield return new WaitForSeconds(2f);
		stateSystem.SetState(new PlayerTurn(stateSystem));
		
	}
}
