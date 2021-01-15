using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public enum STATTYPE
{
	MAXHP, MAXMP, STR, MAG, DEF, RES, SPEED,
	NUM,
}

[System.Serializable]
public class CharacterStat
{
	[SerializeField] private int _baseValue;
	[SerializeField] private STATTYPE _type;
	[SerializeField] private List<StatModifier> _statModifiers = new List<StatModifier>();

	public int basevalue { get => _baseValue; }
	public STATTYPE type { get => _type; }
	public List<StatModifier> statModifiers { get => _statModifiers; }

	public int value
	{
		get
		{
			if (isChanged)
			{
				_value = CalcFinalValue();
				isChanged = false;
			}
			return _value;
		}
	}

	private int _value;
	private bool isChanged = true;

	public CharacterStat(int baseValue, int type)
	{
        this._baseValue = baseValue;
		this._type = (STATTYPE)type;
        _statModifiers = new List<StatModifier>();
	}

	public CharacterStat(int baseValue, STATTYPE type)
	{
		this._baseValue = baseValue;
		this._type = type;
		_statModifiers = new List<StatModifier>();
	}

	public void AddModifier(StatModifier mod)
	{
		isChanged = true;
        statModifiers.Add(mod);
	}

    public void RemoveModifier(StatModifier mod)
	{
		isChanged = true;
		statModifiers.Remove(mod);
	}

    private int CalcFinalValue()
	{
		int finalValue = _baseValue;
        foreach(StatModifier mod in statModifiers)
		{
            finalValue += mod.value;
		}

		return finalValue;
	}
}
