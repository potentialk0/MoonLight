using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnCollisionObject : MonoBehaviour
{
    [SerializeField] float duration;

	private void Update()
	{
		Destroy(this.gameObject, duration);
	}
}
