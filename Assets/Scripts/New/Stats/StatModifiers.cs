using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum SOURCETYPE
{
	ITEM, SKILL,
}

[CreateAssetMenu(menuName ="Scriptables/StatModifiers")]
public class StatModifiers : ScriptableObject
{
	[SerializeField] List<StatModifier> _statModifiers = new List<StatModifier>();
	[SerializeField] SOURCETYPE type;
	int stateCount = (int)STATTYPE.NUM;

	public List<StatModifier> statModifiers { get => _statModifiers; }

	private void Awake()
	{
		_statModifiers = new List<StatModifier>(stateCount);
		for (int i = 0; i < stateCount; i++)
		{
			_statModifiers.Add(new StatModifier(0, i));
		}
	}

	public int GetStatValue(STATTYPE type)
	{
		return _statModifiers[(int)type].value;
	}
}
