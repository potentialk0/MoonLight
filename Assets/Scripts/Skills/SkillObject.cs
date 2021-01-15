using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SkillObject : MonoBehaviour
{
    public Skill skill;

	private void OnTriggerEnter(Collider other)
	{
		if(other.tag == "Enemy")
		{
            if(other.GetComponent<StatContainer>() != null)
                other.GetComponent<StatContainer>().GetDamage(skill.value);

            if(skill.onCollisionObject != null)
			{
                GameObject obj = skill.onCollisionObject;
                Instantiate(obj, transform.position, Quaternion.identity);
			}

            Destroy(this.gameObject);
		}
	}
}
