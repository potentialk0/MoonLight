using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackHole : SkillObject
{
    GameObject playerModel;

    // Start is called before the first frame update
    void Start()
    {
        playerModel = GameObject.Find("PlayerObject");
        transform.position = playerModel.transform.position + playerModel.transform.forward + playerModel.transform.up;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
