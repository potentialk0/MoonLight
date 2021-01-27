using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationControllerModule : MonoBehaviour
{
    PlayerAnimationModule anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<PlayerAnimationModule>();
        anim.SetAnimation(0);
    }

    // Update is called once per frame
    void Update()
    {
        //if (moveNavMesh.HasArrivedToDestination()) anim.SetAnimation(0);
        //else anim.SetAnimation(1f);
    }
}
