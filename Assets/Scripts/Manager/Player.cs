using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private static Player instance;

    public static Player Instance
    {
        get
        {
            if (null == instance)
            {
                instance = new Player();
            }
            return instance;
        }
    }

    public static PlayerController player;
    public static PlayerAnimation playerAnimation;

	private void Awake()
	{
        player = GameObject.Find("PlayerObject").GetComponent<PlayerController>();
        playerAnimation = GameObject.Find("PlayerModel").GetComponent<PlayerAnimation>();
	}
	
    public static void ChangeState(STATE state)
	{
        player.ChangeState(state);
	}

    public static void SetAnimation(string animation)
	{
        playerAnimation.SetAnimation(animation);
	}
}
