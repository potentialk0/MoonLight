using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill
{
	GameObject playerModel;
	GameObject effect;

	Sprite icon;
	int id;
	string spellName;
	string description;

	Skill(Skill s)
	{
		icon = s.icon;
		id = s.id;
		spellName = s.spellName;
		description = s.description;
	}

	public virtual void UseSkill()
	{

	}
}
