using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenFrost : SkillObject
{
    Vector3 dir;

    // Start is called before the first frame update
    void Start()
    {
        //transform.localScale /= 2;
        transform.position = Player.player.transform.position - Player.player.transform.forward * 3 + Player.player.transform.up;
        transform.rotation = Player.player.transform.rotation;

        dir = Player.player.transform.forward;
        Player.ChangeState(STATE.ATTACK);
        Player.SetAnimation(skillData.animation);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += dir * skillData.speed * Time.deltaTime;
    }
}
