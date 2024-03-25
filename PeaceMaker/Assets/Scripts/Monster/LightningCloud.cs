using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LightningCloud : Monster
{
    public State currentState = State.Idle;
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
    [SerializeField]
    private bool isFinish;

    public Transform SpawnThunderPos;
    public GameObject SpawnThunder;

    private int monsterLayer;
    [SerializeField]
    private List<GameObject> ableFollow=new List<GameObject>() { };
    [SerializeField]
    private Vector3 moveDir;
    // Start is called before the first frame update
    void Start()
    {
        base.Start();
        monsterLayer = LayerMask.NameToLayer("MonsterPass");
        CanAttack = true;
        sr = GetComponent<SpriteRenderer>();
        curHp = hp;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        RefreshAbleFollow();
        StartCoroutine(FSM());
    }
    IEnumerator FSM()
    {
        while (true)
        {
            yield return StartCoroutine(currentState.ToString());
        }
    }
    IEnumerator Idle()
    {
        yield return null;
        if(isFinish)
            currentState = State.Patrol;
    }
    IEnumerator Patrol()
    {

        transform.Translate(moveDir * moveSpeed * Time.deltaTime);
        //if (transform.position.x>player.position.x)
        //{
        //    transform.Translate(Vector3.right *-1.0f* moveSpeed * Time.deltaTime);
        //}
        //else
        //{
        //    transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
        //}
        yield return null;
    }
    IEnumerator Follow()
    {
        while (true)
        {
            yield return null;
            if (CanAttack&&followingMonster!=null)
            {
                currentState = State.Attack;              
                break;
            }
            else
            {
                if(followingMonster==null)
                {
                    currentState = State.Idle;
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
        if (followingMonster&&followingMonster.GetComponent<Monster>().stageBuff)
        {
            followingMonster = null;
            RefreshAbleFollow();
        }
        if (followingMonster==null&&isFinish==false)
        {
            RefreshAbleFollow();
        }
        //if (hit.collider != null && hit.collider.CompareTag("Monster")&& isFollow==false)
        //{
        //    StopCoroutine(FSM());
        //    currentState = State.Follow;
        //    StartCoroutine(FSM());
        //    followingMonster =hit.collider.gameObject;
        //    isFollow = true;
        //}
        if (Input.GetKeyDown(KeyCode.T))
        {
            StopAllCoroutines();
            PlayAnimation("LC_Die");
            SoundBox.instance.PlaySFX("LC_Die");
            GameManager.Instance.ReMapMonsters(gameObject);
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
        currentState = State.Follow;
        PlayAnimation("LC_Idle");
    }
    public void Destroy()
    {
        Destroy(gameObject);
    }
    private void RefreshAbleFollow()
    {
        ableFollow.Clear();
        List<GameObject> l = GameManager.Instance.GetCurMapMonsters();
        for(int i=0;i<l.Count;i++)
        {
            if (l[i].layer == monsterLayer&& l[i].GetComponent<Monster>().stageBuff == false)
            {
                ableFollow.Add(l[i]);
            }
        }
        
        int min = int.MaxValue;
        for(int i=0;i<ableFollow.Count;i++)
        {
            float dist = Vector2.Distance(gameObject.transform.position, ableFollow[i].transform.position);
            if((int)dist<=min&& ableFollow[i].GetComponent<Monster>().stageBuff==false)
            {
                followingMonster = ableFollow[i];
                currentState = State.Follow;
            }
        }
        if (followingMonster == null)
        {
            currentState = State.Patrol;
            if (transform.position.x > player.position.x)
            {
                moveDir = Vector3.right;

            }
            else
            {
                moveDir = Vector3.right * -1.0f;
            }
            isFinish = true;
            return;
        }
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
    public override void ActivateStageBuff()
    {
    }
    void LC_AttackSound()
    {
        SoundBox.instance.PlaySFX("LC_Attack");
    }
    void LC_DieSound()
    {
        SoundBox.instance.PlaySFX("LC_Die");
    }

    public override void TakeDamage(float damage)
    {
        throw new System.NotImplementedException();
    }
}
