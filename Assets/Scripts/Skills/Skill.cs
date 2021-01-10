using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public struct SkillData
{
    [Header("◎ General")]
    [SerializeField]
    public float value;
    [SerializeField]
    public float baseCooldown;
    [SerializeField]
    public float attackRange;

    [Header("◎ Projectile")]
    [SerializeField]
    public float speed;

    [Header("◎ AOE")]
    [SerializeField]
    public float bounds;
}

[CreateAssetMenu(menuName = "Scriptables/Skill")]
public class Skill : ScriptableObject
{
    [Header("◎ Description")]
    [Space(10f)]
    [SerializeField] string _skillName = "New Skill";
    [SerializeField] int _skillID = 0;
    [SerializeField]
    [TextArea(3, 10)] string _description;
    
    [Header("◎ Effects")]
    [Space(10f)]
    [SerializeField] GameObject _skillObject;
    [SerializeField] Sprite _iconImage;
    [SerializeField] AudioClip _sound;

    [Space(10f)]
    [SerializeField] SkillData _skillData;

    #region Getters
    public string skillName { get => _skillName; }// protected set => _skillName = value; }
    public int skillID { get => _skillID; }
    public string description { get => _description; }

    public GameObject skillObject { get => _skillObject; }
    public Sprite iconImage { get => _iconImage; }
    public AudioClip sound { get => _sound; }

    public SkillData skillData { get => _skillData; }

    #endregion

    //public abstract void Initialize();
    public void UseSkill()
	{
        GameObject obj = skillObject;
        obj.GetComponent<SkillObject>().skillData = this.skillData;
        Instantiate(obj);
	}
}
