using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MonsterCtrl : MonoBehaviour
{
    public enum State
    {
        IDLE,
        TRACE
    }
    public State state = State.IDLE;
    public float traceDist = 5.0f;

    private Transform monsterTr;
    private Transform playerTr1;
    private Transform playerTr2;
    private Transform goToPos;
    private NavMeshAgent agent;
    private Animator anim;

    public int losePlayer = 0;

    void Start()
    {
        monsterTr = GetComponent<Transform>();
        anim = GetComponent<Animator>();
        playerTr1 = GameObject.FindWithTag("PLAYER1").GetComponent<Transform>();
        playerTr2 = GameObject.FindWithTag("PLAYER2").GetComponent<Transform>();
        agent = GetComponent<NavMeshAgent>();
        goToPos = monsterTr.transform;
        //StartCoroutine(CheckMonsterState());
        //StartCoroutine(MonsterAction());
    }

    void Update()
    {
        float distance1 = Vector3.Distance(playerTr1.position, monsterTr.position);
        float distance2 = Vector3.Distance(playerTr2.position, monsterTr.position);
        //Debug.Log("distance 1 : "+ distance1 +", distance 2: "+ distance2);

        if(distance1 <= traceDist || distance2 <= traceDist)
        {
            state = State.TRACE;
            agent.isStopped = false;
            anim.SetBool("isTrace", true);
            if(distance1 <= distance2)
                goToPos = playerTr1;
            else
                goToPos = playerTr2;
        }
        else
        {
            state = State.IDLE;
            agent.isStopped = true;
            anim.SetBool("isTrace", false);
        }

        agent.SetDestination(goToPos.position);
    }

    void OnCollisionEnter(Collision coll)
    {
        if(coll.collider.tag == "PLAYER1")
        {
            losePlayer = 1;
        }
        if(coll.collider.tag == "PLAYER2")
        {
            losePlayer = 2;
        }
    }
/*
    IEnumerator CheckMonsterState()
    {
        yield return new WaitForSeconds(0.3f);
        float distance1 = Vector3.Distance(playerTr1.position, monsterTr.position);
        float distance2 = Vector3.Distance(playerTr2.position, monsterTr.position);
        Debug.Log("distance 1 : "+ distance1 +", distance 2: "+ distance2);

        if(distance1 <= traceDist || distance2 <= traceDist)
        {
            state = State.TRACE;
            if(distance1 <= distance2)
                goToPos = playerTr1;
            else
                goToPos = playerTr2;
        }
        else
        {
            Debug.Log("bbb");
            state = State.IDLE;
        }
    }

    IEnumerator MonsterAction()
    {
        switch(state)
        {
            case State.IDLE:
                agent.isStopped = true;
                anim.SetBool("isTrace", false);
                break;
            case State.TRACE:
                agent.SetDestination(playerTr1.position);
                anim.SetBool("isTrace", true);
                agent.isStopped = false;
                break;
        }
        yield return new WaitForSeconds(0.3f);
    }
*/
}
