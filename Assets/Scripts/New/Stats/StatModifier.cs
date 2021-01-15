using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[System.Serializable]
public class StatModifier
{
	[SerializeField] private int _value;
	[SerializeField] private STATTYPE _type;

	public int value { get => _value; }
	public STATTYPE type { get => _type; }

    public StatModifier(int value, int type)
	{
		this._value = value;
		this._type = (STATTYPE)type;
	}
}
