using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToPosition : MonoBehaviour
{
    private Vector3 movePosition;
    IMoveVelocity moveVelocity;

    public void SetMovePosition(Vector3 movePosition)
	{
        this.movePosition = movePosition;
        moveVelocity = GetComponent<IMoveVelocity>();
	}

    // Update is called once per frame
    void Update()
    {
        Vector3 moveDir = (movePosition - transform.position).normalized;
        if (Vector3.Distance(movePosition, transform.position) < 0.5f) moveDir = Vector3.zero;
        moveVelocity.SetVelocity(moveDir);
    }
}
