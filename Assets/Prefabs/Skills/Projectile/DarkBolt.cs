using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarkBolt : SkillObject
{
    GameObject playerModel;
    Vector3 dir;

	// Start is called before the first frame update
	void Start()
    {
        playerModel = GameObject.Find("PlayerObject");
        transform.position = playerModel.transform.position + playerModel.transform.forward + playerModel.transform.up;
        transform.rotation = playerModel.transform.rotation;

        dir = playerModel.transform.forward;
        //playerModel.GetComponent<PlayerController>().ChangeState(STATE.ATTACK);
        transform.localScale /= 2;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += dir * 10f * Time.deltaTime;
    }
}
