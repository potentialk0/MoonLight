using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTurn : State
{
    public PlayerTurn(StateSystem stateSystem) : base(stateSystem)
	{

	}

	public override IEnumerator Start()
	{
		return base.Start();
	}

	public override IEnumerator Attack()
	{
		return base.Attack();
	}

	public void Won()
	{

	}
}
