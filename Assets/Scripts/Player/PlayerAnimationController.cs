using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    Animator animator;
    string currAnimation;

    GameObject parent;
    Vector3 pos;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        currAnimation = "isIdle";

        parent = GameObject.Find("PlayerObject");
        pos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void LateUpdate()
    {
        transform.localEulerAngles = new Vector3(0, 0, 0);
        transform.localPosition = new Vector3(0, -0.5f, 0);
    }

    public void SetAnimation(string animation)
	{
        animator.SetBool(currAnimation, false);
        animator.SetBool(animation, true);
        currAnimation = animation;
	}
}
