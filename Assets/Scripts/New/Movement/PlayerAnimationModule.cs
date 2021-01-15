using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationModule : MonoBehaviour
{
    Animator anim;

    // Start is called before the first frame update
    void Awake()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetAnimation(float animNumber)
	{
        anim.SetFloat("animNumber", animNumber);
	}
}
