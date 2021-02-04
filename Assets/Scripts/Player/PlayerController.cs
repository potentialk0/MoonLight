using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using TMPro;
using System;

public enum STATE
{
    IDLE, MOVE, ATTACK, DEAD,
}

public class PlayerController : MonoBehaviour
{
    PlayerAnimation playerModel;
    STATE _previousState;
    public STATE previousState { get => _previousState; }
    STATE _currentState;
    public STATE currentState { get => _currentState; }

    NavMeshPath path;
    Vector3 destination;
    Vector3[] corners;
    Vector3 targetPos;
    int cornerNum = 1;
    bool isTargetInRange = false;

    public float arriveOffset = 0.2f;
    public float speed = 3f;
    public float rotSpeed = 10f;

    GameObject targetObject;
    public GameObject targetMark;

    TextMeshProUGUI text;

    [SerializeField]
    List<SkillShortcutSlot> skills = new List<SkillShortcutSlot>(5);
    Queue<SkillShortcutSlot> skillQueue = new Queue<SkillShortcutSlot>();

    float globalCooldown = 2.0f;
    bool isGlobalCooldown = false;

    void AutoSkill()
    {
        GlobalCoolDown();
        for(int i = 0; i < 5; i++)
        {
            if(skills[i] != null && isGlobalCooldown == false && skills[i].isCoolDown == false)
            {
                skills[i].UseSkill();
                isGlobalCooldown = true;
                return;
            }
        }
    }

    void GlobalCoolDown()
    {
        if (isGlobalCooldown == true)
        {
            globalCooldown -= Time.deltaTime;

            if (globalCooldown <= 0)
            {
                globalCooldown = 2;
                isGlobalCooldown = false;
            }
        }
    }

    private void Awake()
    {
        text = GameObject.Find("stateText").GetComponent<TextMeshProUGUI>();

        playerModel = GetComponentInChildren<PlayerAnimation>();
        _previousState = STATE.IDLE;
        _currentState = STATE.IDLE;
        path = new NavMeshPath();
    }

    // Update is called once per frame
    void Update()
    {
        transform.localEulerAngles = new Vector3(0, transform.localEulerAngles.y, 0);
        text.text = _currentState.ToString();

        if (targetObject != null)
            Debug.Log(targetObject.name);

        //targetObject = UI.GetEnemy();
        AutoSkill();
        OnClick();
        ProcessState();
    }

    void ProcessState()
    {
        SetTargetMark();
        switch (_currentState)
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
                DeadState();
                break;
        }
    }

    public void ChangeState(STATE s)
    {
        if (_currentState == s) return;

        _previousState = _currentState;
        _currentState = s;

        switch (_currentState)
        {
            case STATE.IDLE:
                playerModel.SetAnimation("isIdle");
                break;
            case STATE.MOVE:
                playerModel.SetAnimation("isRunning");
                break;
            case STATE.ATTACK:
                break;
            case STATE.DEAD:
                break;
        }
    }

    private void IdleState()
    {
        StayStill();
    }

    private void MoveState()
    {
        if (corners != null && corners.Length > 0)
        {
            targetPos = corners[cornerNum];
            LookAtTarget();
            if(isTargetInRange)
			{
                ChangeState(STATE.ATTACK);
			}
            if (HasArrivedTo(destination))
            {
                StayStill();
                ChangeState(STATE.IDLE);
                return;
            }
            else if (!HasArrivedTo(destination) && HasArrivedTo(corners[cornerNum]))
                cornerNum++;
            else if (!HasArrivedTo(destination))
                transform.position += (corners[cornerNum] - transform.position).normalized * Time.deltaTime * speed;
        }
    }

    private void AttackState()
    {
        //hasArrivedToDestination = true;
        if (playerModel.IsAnimName("fireProjectile") && playerModel.IsAnimEnd())// && !SkillManager.isAutoAttacking)
        {
            ChangeState(STATE.IDLE);
        }
    }

    private void DeadState()
    {
        throw new NotImplementedException();
    }

    void OnClick()
    {
        if (Input.GetMouseButtonDown(1))
        {
            if (UI.IsUIHit()) return;
            
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.tag == "Ground")
                {
                    SetPath(hit);
                }
                else if(hit.transform.tag == "Enemy")
				{
                    SetTargetObject(hit.transform.gameObject);
                    SetPath(hit);
				}
            }
        }
    }

    void SetPath(RaycastHit hit)
    {
        cornerNum = 0;
        destination = new Vector3(hit.point.x, transform.position.y, hit.point.z);
        if (NavMesh.CalculatePath(transform.position, destination, NavMesh.AllAreas, path))
        {
            corners = path.corners;
            ChangeState(STATE.MOVE);
            return;
        }
    }

    void SetTargetObject(GameObject target)
	{
        targetObject = target.transform.gameObject;
    }

    void SetTargetMark()
	{
        if(targetObject != null && targetObject.tag == "Enemy")
		{
            targetMark.SetActive(true);
            targetMark.transform.position = targetObject.transform.position;
		}
        else
		{
            targetMark.SetActive(false);
		}
	}

    void LookAtTarget()
    {
        Quaternion targetRot = Quaternion.LookRotation(targetPos - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRot, Time.deltaTime * rotSpeed);
    }

    public bool HasArrivedTo(Vector3 pos)
    {
        if (Vector2.Distance(new Vector2(transform.position.x, transform.position.z), new Vector2(pos.x, pos.z)) <= arriveOffset)
            return true;
        return false;
    }

    void StayStill()
    {
        cornerNum = 0;
        corners = null;
        transform.position = transform.position;
        transform.rotation = transform.rotation;
    }
}
