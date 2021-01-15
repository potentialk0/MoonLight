using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum ITEMTYPE
{ 
    HELMET, ARMOR, WEAPON, POTION,
    NUM,
}

[CreateAssetMenu(menuName = "Scriptables/Item")]
public class Item : ScriptableObject
{
    [Header("◎ Description")]
    [Space(10f)]
    [SerializeField] string _itemName = "New Item";
    [SerializeField] ITEMTYPE _itemType;
    [SerializeField] [TextArea(3, 10)] string _description;

    [Header("◎ Effects")]
    [Space(10f)]
    [SerializeField] GameObject _itemObject;
    [SerializeField] Sprite _iconImage;
    [SerializeField] AudioClip _sound;

    [Space(10f)]
    [SerializeField] StatModifiers _statMod;

    #region Getters
    public string itemName { get => _itemName; }
    public ITEMTYPE itemType { get => _itemType; }
    public string description { get => _description; }

    public GameObject itemObject { get => _itemObject; }
    public Sprite iconImage { get => _iconImage; }
    public AudioClip sound { get => _sound; }

    public StatModifiers statMod { get => _statMod; }

    #endregion

    public void UseSkill()
    {
        //GameObject obj = skillObject;
        //obj.GetComponent<SkillObject>().skillData = this.skillData;
        //Instantiate(obj);
    }
}
