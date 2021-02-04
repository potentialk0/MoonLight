using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatContainer : MonoBehaviour
{
    CharacterItemSlot slot;
    [SerializeField] CharacterStats _statData;
    [SerializeField] int maxHP;
    [SerializeField] int currHP;
    [SerializeField] int maxMP;
    [SerializeField] int currMP;
    [SerializeField] int str;
    [SerializeField] int mag;
    [SerializeField] int def;
    [SerializeField] int res;
    [SerializeField] int speed;

    public CharacterStats statData { get => _statData; }
    
    void Awake()
	{
        if (_statData != null)
            ClearMods();
        maxHP = _statData.GetBaseValue(STATTYPE.MAXHP);
        maxMP = _statData.GetBaseValue(STATTYPE.MAXMP);
        str = _statData.GetBaseValue(STATTYPE.STR);
        mag = _statData.GetBaseValue(STATTYPE.MAG);
        def = _statData.GetBaseValue(STATTYPE.DEF);
        res = _statData.GetBaseValue(STATTYPE.RES);
        speed = _statData.GetBaseValue(STATTYPE.SPEED);

        currHP = maxHP;
        currMP = maxMP;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void RefreshStats()
	{
        float hpRatio = (float)currHP / maxHP;
        float mpRatio = (float)currMP / maxMP;
        maxHP  = _statData.GetValue(STATTYPE.MAXHP);
        maxMP  = _statData.GetValue(STATTYPE.MAXMP);
        str     = _statData.GetValue(STATTYPE.STR);
        mag     = _statData.GetValue(STATTYPE.MAG);
        def     = _statData.GetValue(STATTYPE.DEF);
        res     = _statData.GetValue(STATTYPE.RES);
        speed   = _statData.GetValue(STATTYPE.SPEED);

        currHP = (int)(maxHP * hpRatio);
        currMP = (int)(maxMP * mpRatio);
    }

    public void TakeDamage(int value)
	{
        currHP -= value;
	}

    public void Equip(Item item)
	{
        for(int i = 0; i < (int)STATTYPE.NUM; i++)
		{
            _statData.characterStats[i].AddModifier(item.statMod.statModifiers[i]);
		}
        RefreshStats();
	}

    public void UnEquip(Item item)
    {
        for (int i = 0; i < (int)STATTYPE.NUM; i++)
        {
            _statData.characterStats[i].RemoveModifier(item.statMod.statModifiers[i]);
        }
        RefreshStats();
    }

    void ClearMods()
	{
        for(int i = 0; i < (int)STATTYPE.NUM; i++)
		{
            _statData.characterStats[i].statModifiers.Clear();
		}
	}
}
