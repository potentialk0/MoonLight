using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DamageManager : MonoBehaviour
{
    Camera mainCamera;
    float upSpeed;

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = GameObject.Find("Main Camera").GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

 //   Vector3 GetScreenPosition()
	//{
 //       Vector3 screenPos = mainCamera.WorldToScreenPoint(Input.mousePosition);
        
	//}
}
