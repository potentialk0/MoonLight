using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveVelocityTransform : MonoBehaviour, IMoveVelocity
{
	[SerializeField] private float moveSpeed;

	private Vector3 velocityVector;
	// 애니메이터?

	private void Awake()
	{
		//getcomponent 애니메이터?
	}

	public void SetVelocity(Vector3 velocityVector)
	{
		this.velocityVector = velocityVector;
	}

	private void Update()
	{
		transform.position += velocityVector * moveSpeed * Time.deltaTime;
		//애니메이터? (velocityVector)
	}
}
