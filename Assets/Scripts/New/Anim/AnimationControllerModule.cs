using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationControllerModule : MonoBehaviour
{
    PlayerAnimationModule anim;
    MoveToPositionNavMesh moveNavMesh;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<PlayerAnimationModule>();
        moveNavMesh = GetComponentInParent<MoveToPositionNavMesh>();
        anim.SetAnimation(0);
    }

    // Update is called once per frame
    void Update()
    {
        if (moveNavMesh.HasArrived()) anim.SetAnimation(0);
        else anim.SetAnimation(1f);
    }
}
