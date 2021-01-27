using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jCameraController : MonoBehaviour
{
    GameObject player;
    Vector3 dir;
    public float distance;
    public Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        player      = GameObject.Find("PlayerObject");
        dir         = new Vector3(1f, 1f, -1f).normalized;
        distance    = 14f;
        offset      = new Vector3(0, 4f, 0);
    }

    // Update is called once per frame
    void Update()
    {
        LockPosition();
    }

    void LockPosition()
	{
        transform.position = player.transform.position + offset + dir * distance;
	}
}
