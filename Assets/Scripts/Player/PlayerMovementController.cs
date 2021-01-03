using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    // 클릭을 통한 움직임을 위한 변수들
    Camera cam;
    Rigidbody rigidbody;

    Vector3 target;
    Vector3 clickPoint;
    float arriveDist;
    Vector3 moveDir;
    float moveSpeed;


    // animation을 바꾸기 위한 변수들
    PlayerAnimationController animController;

    //public GameObject effect;

    // Start is called before the first frame update
    void Start()
    {
        cam = GameObject.Find("Main Camera").GetComponent<Camera>();
        rigidbody = GetComponent<Rigidbody>();

        target = this.gameObject.transform.position;
        clickPoint = this.gameObject.transform.position;
        arriveDist = 0.1f;
        moveDir = Vector3.zero;
        moveSpeed = 5f;

        animController = GameObject.Find("Player").GetComponent<PlayerAnimationController>();
    }

    // Update is called once per frame
    void Update()
    {
        SetDestination();
    }

    private void FixedUpdate()
    {
        if (Vector3.Distance(rigidbody.position, target) > arriveDist)
        {
            rigidbody.MovePosition(rigidbody.position + moveDir * moveSpeed * Time.fixedDeltaTime);
            animController.SetAnimation("isRunning");
        }
        else
            animController.SetAnimation("isIdle");
    }

    private void LateUpdate()
    {
        transform.localEulerAngles = new Vector3(0, transform.localEulerAngles.y, 0);
    }

    void SetDestination()
	{
        if(Input.GetMouseButtonDown(0))
		{
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if(Physics.Raycast(ray, out hit))
			{
                if(hit.transform.tag == "Ground")
				{
                    clickPoint = hit.point;
                    target = hit.point + new Vector3(0, rigidbody.position.y - hit.point.y, 0);

                    //GameObject obj = effect;
                    //Instantiate(obj, hit.point, Quaternion.identity);

                    moveDir = (target - rigidbody.position).normalized;
                    this.gameObject.transform.forward = moveDir;
                }
			}
		}
	}
}
