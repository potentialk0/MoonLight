using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    Animator animator;
    string currAnimation;

	private void Awake()
	{
        animator = GetComponent<Animator>();
        currAnimation = "isIdle";
    }

	// Start is called before the first frame update
	void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetAnimation(string animation)
	{
        animator.SetBool(currAnimation, false);
        animator.SetBool(animation, true);
        currAnimation = animation;
	}

    public Animator GetAnimator()
	{
        return animator;
	}

    public bool IsAnimEnd()
    {
        return animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f;
    }
}
