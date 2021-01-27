using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SkillObject : MonoBehaviour
{
    public SkillData skillData;
	bool isChangeToP = false;
	protected Collider collider;
	protected float destroyTime = 0;

	private void Awake()
	{
		collider = GetComponent<Collider>();
	}

	private void OnTriggerEnter(Collider other)
	{
		if(other.tag == "Enemy")
		{
            if(other.GetComponent<StatContainer>() != null)
                other.GetComponent<StatContainer>().GetDamage(skillData.value);

            if(skillData.onCollisionObject != null)
			{
                GameObject obj = skillData.onCollisionObject;
                Instantiate(obj, collider.ClosestPoint(other.transform.position), Quaternion.identity);
			}

            Destroy(this.gameObject, destroyTime);
		}
	}
}
