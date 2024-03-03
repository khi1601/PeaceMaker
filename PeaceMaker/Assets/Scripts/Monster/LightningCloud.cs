using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningCloud : Monster
{
    public State currentState = State.Patrol;
    // Start is called before the first frame update
    private Transform player;
    private SpriteRenderer sr;
    public bool CanAttack;
    public bool isAttack;
    Vector2 nowplayertrans;

    private RaycastHit2D hit;
    public float raycastDistance = 10f; 
    public LayerMask layerMask;
    public GameObject followingMonster;
    public bool isFollow;

    public Transform SpawnThunderPos;
    public GameObject SpawnThunder;
    // Start is called before the first frame update
    void Start()
    {
        base.Start();
        CanAttack = true;
        sr = GetComponent<SpriteRenderer>();
        curHp = hp;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        StartCoroutine(FSM());
    }
    IEnumerator FSM()
    {
        while (true)
        {
            yield return StartCoroutine(currentState.ToString());
        }
    }
    IEnumerator Patrol()
    {      
        
        if (transform.position.x>player.position.x)
        {
            transform.Translate(Vector3.right *-1.0f* moveSpeed * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
        }
        yield return null;
    }
    IEnumerator Follow()
    {
        while (true)
        {
            yield return null;
            if (CanAttack)
            {
                currentState = State.Attack;              
                break;
            }
            else
            {
                if(followingMonster==null)
                {
                    currentState = State.Patrol;
                    break;
                }
                transform.position = Vector2.MoveTowards(transform.position, new Vector2(followingMonster.transform.position.x, transform.position.y), moveSpeed * Time.deltaTime);
            }

            

        }
    }
    IEnumerator Attack()
    {
        yield return null;
        isAttack = true;
        PlayAnimation("LC_Charge");
        CanAttack = false;
        while (isAttack)
        {
            yield return new WaitForFixedUpdate();
        }
        currentState = State.Follow;
    }
    // Update is called once per frame
    void Update()
    {
        
        if(followingMonster==null)
        {
            if(currentState!= State.Patrol)
                currentState = State.Patrol;
            hit = Physics2D.Raycast(transform.position, Vector2.down, raycastDistance, layerMask);
            isFollow = false;
        }

        if (hit.collider != null && hit.collider.CompareTag("Monster")&& isFollow==false)
        {
            StopCoroutine(FSM());
            currentState = State.Follow;
            StartCoroutine(FSM());
            followingMonster =hit.collider.gameObject;
            isFollow = true;
        }
        if (Input.GetKeyDown(KeyCode.T))
        {
            StopCoroutine(FSM());
            PlayAnimation("LC_Die");
            SoundBox.instance.PlaySFX("LC_Die");
        }
    }
    public void CanAttackTrue()
    {
        CanAttack = true;
    }
    public void FinishAttack()
    {
        Instantiate(SpawnThunder, SpawnThunderPos.position, Quaternion.identity);
        SoundBox.instance.PlaySFX("LC_Attack");
        isAttack = false;
        Invoke("CanAttackTrue", 1.0f);
        currentState = State.Patrol;
        PlayAnimation("LC_Idle");
    }
    public void Destroy()
    {
        Destroy(gameObject);
    }
    public override void HandleHP()
    {

    }
    public override void StopVelocity()
    {
        rigi.velocity = Vector2.zero;
    }
    public override void ReturntoIdle()
    {
        //currentState = State.Idle;
    }
    void LC_AttackSound()
    {
        SoundBox.instance.PlaySFX("LC_Attack");
    }
    void LC_DieSound()
    {
        SoundBox.instance.PlaySFX("LC_Die");
    }
}
