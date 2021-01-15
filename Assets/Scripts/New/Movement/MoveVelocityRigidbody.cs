using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveVelocityRigidbody : MonoBehaviour, IMoveVelocity
{
	[SerializeField] private float moveSpeed;

	private Vector3 velocityVector;
	private Rigidbody rigidbody3D;
	// 애니메이터?

	private void Awake()
	{
		rigidbody3D = GetComponent<Rigidbody>();
		//getcomponent 애니메이터?
	}

	public void SetVelocity(Vector3 velocityVector)
	{
		this.velocityVector = velocityVector;
	}

	private void FixedUpdate()
	{
		rigidbody3D.velocity = velocityVector * moveSpeed;
		//애니메이터? (velocityVector)
	}
}
