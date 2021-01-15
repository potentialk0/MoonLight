using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementMouse : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(1))
		{
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if(Physics.Raycast(ray, out hit))
			{
                if (hit.transform.tag == "Ground")
                {
                    Vector3 dest = new Vector3(hit.point.x, 0.5f, hit.point.z);
                    GetComponent<MoveToPosition>().SetMovePosition(dest);
                }
            }
		}
    }
}
