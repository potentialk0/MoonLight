using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State
{
    protected StateSystem stateSystem;

    public State(StateSystem stateSystem)
	{
        this.stateSystem = stateSystem;
	}

    public virtual IEnumerator Start() { yield break; }
    public virtual IEnumerator Attack() { yield break; }
    public virtual IEnumerator Heal() { yield break; }
}
