using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovementController : MonoBehaviour
{
    public enum STATE
	{
        ROAM, CHASE, ATTACK, DEAD, WAIT, GOBACK,
	}

    // 애니메이션을 위한 변수들
    Animator animator;
    STATE state;

    float walkSpeed = 2.0f;// 1.5f;
    float runSpeed = 3.0f; //2.0f;
    float rotSpeed = 1.0f;

    int isWalkingHash;
    int isRunningHash;
    int isWaitHash;
    int isHitHash;
    int isAttackingHash;
    int isDeadHash;

    // 플레이어를 인식하기 위한 변수들
    float sightRange = 5.0f;    // 몬스터의 시야 범위
    Transform player;           // 플레이어와의 거리 계산을 위한 transform
    bool isSighted = false;     // 몬스터가 플레이어를 인식했는지 판단하기 위한 bool
    bool isChasing = false;

    
    // 몬스터 roaming을 위한 변수들
    // startPos와 currPos사이 거리를 수시로 비교하여 roamRange 내에서만 로밍하도록
    // Transform의 경우 참조형 값이기 때문에 한 번만 받아와도 수시로 Update됨 ex) gameobject.trasform
    // position(Vector3)의 경우 따로 Update문에 코드를 작성하지 않는 이상 한 번만 받아오게 됨
    Vector3 startPos;               // 생성시 최초 위치(업데이트 되지 않으며, 로밍 범위의 기준이다)
    Vector3 currPos;                // update되는 현재 위치
    float roamRange = 8.0f;         // 로밍 범위
    float chaseRange = 12.0f;       // 플레이어를 따라가는 범위
    Vector3 nextRoamDestination;    // 다음 로밍 목적지
    float nextRoamDistMin = 3.0f;   // 다음 로밍 목적지가 현재 위치에서 일정 거리 이상 떨어지도록 하는 최소값
    bool hasArrived = true;         // 로밍 목적지에 도착했는지 판별
    float waitTime = 3.0f;          // 로밍 목적지에 머무르는 시간
    bool isWaitTimeSet = false;
    float waitTimer = 0.0f;       // 머무르는 시간을 구현하기 위한 deltatime의 누적값

    // 몬스터가 chase할 때 필요한 변수들
    float chaseDist = 1.8f;


    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponentInChildren<Animator>();
        startPos = this.transform.position;

        isWalkingHash   = Animator.StringToHash("isWalking");
        isRunningHash   = Animator.StringToHash("isRunning");
        isWaitHash      = Animator.StringToHash("isIdle");
        isHitHash       = Animator.StringToHash("isHit");
        isAttackingHash = Animator.StringToHash("isAttacking");
        isDeadHash      = Animator.StringToHash("isDead");

        player = GameObject.Find("PlayerObject").transform;
    }

    // Update is called once per frame
    void Update()
    {
        Test();
        StateProcess();
    }

    private void Test()
	{
        //currPos = this.transform.position;
        //Debug.DrawLine(startPos, (currPos - startPos).normalized * roamRange, Color.red);
	}

    private void StateProcess()
	{
        //Debug.Log(state);

        switch (state)
		{
            case STATE.ROAM:
                Roam();
                break;
            case STATE.CHASE:
                ChasePlayer();
                break;
            case STATE.ATTACK:
                AttackPlayer();
                break;
            case STATE.WAIT:
                Wait();
                break;
            case STATE.GOBACK:
                GoBack();
                break;
            case STATE.DEAD:
                Die();
                break;
        }
	}

    private void ChangeState(STATE s)
	{
        if (state == s) return;
        state = s;

        switch (state)
        {
            case STATE.ROAM:
                //animator.Play("Walk");
                animator.SetBool(isWalkingHash, true);
                break;
            case STATE.CHASE:
                //animator.Play("Run");
                animator.SetBool(isRunningHash, true);
                break;
            case STATE.ATTACK:
                //animator.Play("Attack");
                animator.SetBool(isAttackingHash, true);
                break;
            case STATE.WAIT:
                //animator.Play("Idle");
                animator.SetBool(isWaitHash, true);
                break;
            case STATE.GOBACK:
                break;
            case STATE.DEAD:
                break;
        }
    }

    private bool IsSighted()
    {
        if (player != null)
        // 시야각의 좌우 단위 벡터
        {
            Vector3 left = (-this.transform.right + this.transform.forward).normalized;
            Vector3 right = (this.transform.right + this.transform.forward).normalized;

            float distance = Vector3.Distance(this.transform.position, player.position);
            Vector3 toPlayer = (player.position - this.transform.position).normalized;

            if (distance < sightRange && Vector3.Dot(left, toPlayer) > 0 && Vector3.Dot(right, toPlayer) > 0)
            {
                isSighted = true;
                isChasing = true;
            }
            else
            {
                isSighted = false;
            }

            // 벡터 가시화(디버깅용)
            if (isChasing)
            {
                Debug.DrawLine(this.transform.position, this.transform.position + right * sightRange, Color.green);
                Debug.DrawLine(this.transform.position, this.transform.position + left * sightRange, Color.green);
                //Debug.DrawLine(this.transform.position, this.transform.position + toPlayer, Color.green);
                //Debug.Log("Player Sighted!");
            }
            else if(!isChasing)
            {
                Debug.DrawLine(this.transform.position, this.transform.position + right * sightRange, Color.red);
                Debug.DrawLine(this.transform.position, this.transform.position + left * sightRange, Color.red);
                //Debug.DrawLine(this.transform.position, this.transform.position + toPlayer, Color.red);
                //Debug.Log("Player Not Sighted...");
            }
        }
        else if(player == null)
        {
            Debug.LogWarning("Player is null!!");
        }
        return isSighted;
    }

    private void Roam()
	{
        if (IsSighted())
        {
            animator.SetBool(isWalkingHash, false);
            ChangeState(STATE.CHASE);
            return;
        }

        // 로밍 범위는 roamRange 이내
        currPos = this.transform.position;

        // 목적지에 도착했다면 새로운 목적지를 설정해야 함
        if (hasArrived)
        {
            // 최초 생성 위치를 기준으로 roamRange 이내의 거리인 무작위 좌표를 다음 목적지 좌표로 설정
            do
            {
                float ranX = Random.Range(startPos.x, startPos.x + Random.Range(-roamRange, roamRange));
                float ranZ = Random.Range(startPos.z, startPos.z + Random.Range(-roamRange, roamRange));

                nextRoamDestination = new Vector3(ranX, 0, ranZ);
            } while (Vector3.Distance(currPos, nextRoamDestination) < nextRoamDistMin);
            // 이때, 현재 도착점과 다음 목적지 사이의 거리가 일정 거리 이하이면 좌표 재설정

            // 새로운 목적지가 생겼으므로 hasArrived = false;
            hasArrived = false;

            // 일정 시간 IDLE 상태를 유지
            animator.SetBool(isWalkingHash, false);
            ChangeState(STATE.WAIT);
            return;

            // 이 때, hasArrived가 false이므로 다시 ROAM 상태가 되었을 때 이 if문이 아니라 아래의 else if문으로 들어오게 됨
        }
        else if(!hasArrived)
        {
            // IDLE 상태가 끝나고 다시 ROAM 상태가 되었을 때 목적지를 바라봄
            //this.transform.LookAt(nextRoamDestination);
            LookAtTarget(nextRoamDestination);
            // else if 문 아래의 코드로 목적지를 향해 이동하다가, 목적지와 일정 거리 이하가 되면(도착한 것을 구현) hasArrived = true;
            if (Vector3.Distance(currPos, nextRoamDestination) < 0.1f)
                hasArrived = true;
        }

        Vector3 moveVec = (nextRoamDestination - currPos).normalized;
        this.transform.position += moveVec * walkSpeed * Time.deltaTime;

        Debug.DrawLine(currPos, nextRoamDestination, Color.green);
    }

    private void ChasePlayer()
	{
        // ATTACK 상태로 바꾸기 위한 조건
        if (Vector3.Distance(currPos, player.position) < chaseDist)
        {
            animator.SetBool(isRunningHash, false);
            ChangeState(STATE.ATTACK);
            return;
        }

        float dist = Vector3.Distance(startPos, currPos);
        // 시작 지점과 현재 위치 사이의 거리가 chaseRange보다 멀어진다면 다시 로밍
        // 이 때, 자연스러움을 위해 IDLE 상태로 바꿔준다. IDLE 상태는 로밍 상태로 가는 코드 밖에 없기 때문.
        // 또한, 1초 정도 머무르도록 idleTime을 설정해준다
        // elapsedTime

        if (dist > chaseRange)
        {
            animator.SetBool(isRunningHash, false);
            waitTime = 1.0f;
            isWaitTimeSet = true;
            waitTimer = 0.0f;
            ChangeState(STATE.GOBACK);
            return;
        }

        // runSpeed로 플레이어를 향해 이동
        currPos = this.transform.position;
        Vector3 moveVec = (player.position - currPos).normalized;
        LookAtTarget(player.position);
        this.transform.position += moveVec * runSpeed * Time.deltaTime;
	}

    private void AttackPlayer()
	{
        // 공격 시작 시 자연스럽게 플레이어를 향하게 하는 건 코루틴으로 해보자. 현재는 Attack Animation Event에서 LookAtEvent 함수를 호출
        if (Vector3.Distance(currPos, player.position) >= chaseDist)
        {
            animator.SetBool(isAttackingHash, false);
			if (!animator.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
			{
				ChangeState(STATE.CHASE);
				return;
			}
		}
        //if (Vector3.Distance(currPos, player.position) < chaseDist)
		//{
        else
            animator.SetBool(isAttackingHash, true);
		//}
    }

    private void Wait()
    {
        if (IsSighted())
        {
            animator.SetBool(isWaitHash, false);
            ChangeState(STATE.CHASE);
            return;
        }

        waitTimer += Time.deltaTime;

        if(!isWaitTimeSet)
		{
            waitTime = Random.Range(2.0f, 3.5f);
            isWaitTimeSet = true;
		}

        if(waitTimer >= waitTime)
        {
            waitTimer = 0.0f;
            isWaitTimeSet = false;
            animator.SetBool(isWaitHash, false);
            ChangeState(STATE.ROAM);
            return;
        }
    }

    private void GoBack()
	{
        animator.SetBool(isWaitHash, true);
        if (jTimer.SetTimer(2.0f))
        {
            animator.SetBool(isWaitHash, false);
            animator.SetBool(isWalkingHash, true);
            LookAtTarget(startPos);
            currPos = this.transform.position;
            Vector3 moveVec = (startPos - currPos).normalized;
            this.transform.position += moveVec * walkSpeed * Time.deltaTime;
        }

        if (Vector3.Distance(currPos, startPos) < 0.1f)
		{
            jTimer.ResetTimer();
            ChangeState(STATE.ROAM);
            return;
		}
	}

    private void Die()
	{
        animator.SetBool(isDeadHash, true);
	}

    private void LookAtTarget(Vector3 target)
	{
        Vector3 targetDir = target - this.transform.position;
        targetDir.y = 0.0f;
        this.transform.rotation = Quaternion.RotateTowards(this.transform.rotation, Quaternion.LookRotation(targetDir), rotSpeed * Time.time);
	}

}
