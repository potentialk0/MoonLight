using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public enum STATE
{
    IDLE, MOVE, ATTACK, DEAD,
}

public class PlayerController : MonoBehaviour
{
    PlayerMovement playerMovement;
    GameObject playerModel;
    STATE state;

    // 클릭을 통한 움직임을 위한 변수들
    Camera cam;
    Rigidbody rigidbody;
    UI ui;

    Vector3 target;
    float arriveDist;
    Vector3 moveDir;
    float moveSpeed;
    float rotSpeed;

    bool isRunning = false;

    [SerializeField]
    Icon[] skills;
    TextMeshProUGUI text;

    [SerializeField]
    GameObject effect;

    // Start is called before the first frame update
    void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
        playerModel = GameObject.Find("PlayerModel");
        state = STATE.IDLE;

        playerModel.GetComponent<PlayerAnimation>().SetAnimation("isIdle");

        rigidbody = GetComponent<Rigidbody>();
        ui = GameObject.Find("Canvas").GetComponent<UI>();

        target = this.gameObject.transform.position;
        arriveDist = 0.1f;
        moveDir = Vector3.zero;
        moveSpeed = 5f;
        rotSpeed = 10f;

        text = GameObject.Find("stateText").GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        text.text = state.ToString();
    }

	private void LateUpdate()
	{
        ProcessState();

        gameObject.transform.localEulerAngles = new Vector3(0, transform.localEulerAngles.y, 0);
        playerModel.transform.localEulerAngles = new Vector3(0, 0, 0);
        playerModel.transform.localPosition = new Vector3(0, 0, 0);
    }

	private void FixedUpdate()
	{
		if (state != STATE.ATTACK && state != STATE.IDLE && state == STATE.MOVE)
		{
			Move();
		}
	}

	public void ChangeState(STATE s)
    {
        if (state == s) return;

        state = s;

        switch (state)
        {
            case STATE.IDLE:
                playerModel.GetComponent<PlayerAnimation>().SetAnimation("isIdle");
                break;
            case STATE.MOVE:
                playerModel.GetComponent<PlayerAnimation>().SetAnimation("isRunning");
                break;
            case STATE.ATTACK:
                playerModel.GetComponent<PlayerAnimation>().SetAnimation("isAttacking");
                break;
            case STATE.DEAD:
                break;
        }
    }

    public void ProcessState()
    {
        //Debug.Log("player state : " + state);
        switch (state)
        {
            case STATE.IDLE:
                IdleState();
                break;
            case STATE.MOVE:
                MoveState();
                break;
            case STATE.ATTACK:
                AttackState();
                break;
            case STATE.DEAD:
                break;
        }
    }

    void IdleState()
	{
        if(IsRunning())
		{
            ChangeState(STATE.MOVE);
            return;
		}

        SetDestination();
    }

    void MoveState()
	{
        if (!IsRunning())
		{
            ChangeState(STATE.IDLE);
            return;
		}

        SetDestination();
        LookAtTarget();
    }

    void AttackState()
	{
        target = transform.position;
        if (playerModel.GetComponent<PlayerAnimation>().IsAnimEnd())
        {
            ChangeState(STATE.IDLE);
            return;
        }
    }

    void DieState()
	{

	}

    public bool IsRunning()
    {
        return Vector3.Distance(rigidbody.position, target) > arriveDist;
    }

    public void Move()
    {
        rigidbody.MovePosition(rigidbody.position + moveDir * moveSpeed * Time.deltaTime);
    }

    public void SetDestination()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (ui.IsUIHit()) return;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            
            if (Physics.Raycast(ray, out hit))
            {
                Debug.Log(hit.transform.gameObject.ToString());
                if (hit.transform.tag == "Ground")
                {
                    target = hit.point + new Vector3(0, rigidbody.position.y - hit.point.y, 0);

                    if (target != null)
                        moveDir = (target - rigidbody.position).normalized;
                }
            }
        }
    }

    public void LookAtTarget()
    {
        Quaternion targetRot = Quaternion.LookRotation(target - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRot, Time.deltaTime * rotSpeed);
    }
}
