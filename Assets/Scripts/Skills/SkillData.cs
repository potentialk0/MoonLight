using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum SKILLTYPE
{
    PROJECTILE, AOE, BUFF,
    NUM,
}

[CreateAssetMenu(menuName = "Scriptables/SkillData")]
public class SkillData : ScriptableObject
{
    [Header("◎ Description")]
    [Space(10f)]
    [SerializeField] string _skillName = "New Skill";
    [SerializeField] SKILLTYPE _skillType;
    [SerializeField] [TextArea(3, 10)] string _description;
    
    [Header("◎ Effects")]
    [Space(10f)]
    [SerializeField] GameObject _skillObject;
    [SerializeField] Sprite _iconImage;
    [SerializeField] string _animation;
    [SerializeField] AudioClip _sound;

    [Space(10f)]
    [Header("◎ General")]
    [SerializeField] int _value;
    [SerializeField] float _baseCooldown;
    [SerializeField] float _attackRange;

    [Header("◎ Projectile")]
    [SerializeField] GameObject _onCollisionObject;
    [SerializeField] float _speed;

    [Header("◎ AOE")]
    [SerializeField] float _bounds;

    [Header("◎ Buff")]
    [SerializeField] StatModifiers _statMod;

    

    #region Getters
    public string skillName { get => _skillName; }
    public SKILLTYPE skillType { get => _skillType; }
    public string description { get => _description; }

    public GameObject skillObject { get => _skillObject; }
    public Sprite iconImage { get => _iconImage; }
    public string animation { get => _animation; }
    public AudioClip sound { get => _sound; }

    public int value { get => _value; }
    public float baseCooldown { get => _baseCooldown; }
    public float attackRange { get => _attackRange; }
    public GameObject onCollisionObject { get => _onCollisionObject; }
    public float speed { get => _speed; }
    public float bounds { get => _bounds; }
    public StatModifiers statMod { get => _statMod; }

	#endregion

}
