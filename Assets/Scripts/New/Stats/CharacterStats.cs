using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptables/CharacterStats")]
public class CharacterStats : ScriptableObject
{

	[SerializeField] List<CharacterStat> _characterStats;
	int stateCount = (int)STATTYPE.NUM;

	public List<CharacterStat> characterStats { get => _characterStats; }

	private void Awake()
	{
		_characterStats = new List<CharacterStat>(stateCount);
		for (int i = 0; i < stateCount; i++)
		{
			_characterStats.Add(new CharacterStat(-1, i));
		}
	}

	public int GetBaseValue(STATTYPE type)
	{
		return _characterStats[(int)type].basevalue;
	}

	public int GetBaseValue(int type)
	{
		return _characterStats[type].basevalue;
	}

	public int GetValue(STATTYPE type)
	{
		return _characterStats[(int)type].value;
	}
}
