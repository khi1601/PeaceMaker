using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngryWolf : Monster
{
    public State currentState = State.Idle;
    // Start is called before the first frame update
    private Transform player;
    private SpriteRenderer sr;
    public bool CanDash;
    public bool isAttack;
    Vector2 nowplayertrans;
    // Start is called before the first frame update
    void Start()
    {
        base.Start();
        CanDash = true;
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
    IEnumerator Idle()
    {
        yield return null;
        if (Vector2.Distance(transform.position, player.position) <= 30.0f)
            currentState = State.Follow;
    }
    IEnumerator Follow()
    {
        while (true)
        {
            yield return null;
            CheckDirection();
            if (CanDash&& Vector2.Distance(transform.position, player.position) < 15.0f)
            {
                currentState = State.Dash;
                break;
            }
            else
            {
                PlayAnimation("AW_Run");
                transform.position = Vector2.MoveTowards(transform.position, new Vector2(player.position.x,transform.position.y), moveSpeed * Time.deltaTime);
            }

            if (Vector2.Distance(transform.position, player.position) > 30.0f)
            {
                currentState = State.Idle;
                PlayAnimation("AW_Idle");
                break;
            }

        }
    }
    IEnumerator Dash()
    {
        yield return null;
        isAttack = true;
        PlayAnimation("AW_Attack");
        while (isAttack)
        {
            yield return new WaitForFixedUpdate();
        }
        CanDash = false;
        Invoke("CanDashTrue", 1.0f);
        currentState = State.Idle;
        PlayAnimation("AW_Idle");
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.U))
        {
            StopAllCoroutines();
            PlayAnimation("AW_Die");
        }

    }
    public void CanDashTrue()
    {
        CanDash = true;
    }
    public void CheckDirection()
    {
        Vector3 m_Scale = transform.localScale;
        if (transform.position.x < player.transform.position.x)
        {
            if (MonsterDirRight)
                return;
            FlipMonster();
        }
        else
        {
            if (!MonsterDirRight)
                return;
            FlipMonster();
        }
    }
    public void DashAtk()
    {
        if(MonsterDirRight)
            rigi.AddForce((Vector2.right) * 25.0f+Vector2.up*3.0f, ForceMode2D.Impulse);
        else
            rigi.AddForce((Vector2.right) * 25.0f*-1.0f+Vector2.up * 3.0f, ForceMode2D.Impulse);

    }
    public void FinishAttack()
    {
        isAttack=false;
        StopVelocity();
    }
    public void Destroy()
    {
        GameManager.Instance.ReMapMonsters(gameObject);

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
    public override void ActivateStageBuff()
    {
        stageBuff = true;
        moveSpeed *= 1.2f;
        curHp*=2.0f;
        Atk *= 2.0f;
    }
    void AW_AttackSound()
    {
        SoundBox.instance.PlaySFX("AW_Attack");
    }
    void AW_DieSound()
    {
        SoundBox.instance.PlaySFX("AW_Die");
    }
    public override void TakeDamage(float damage)
    {

    }
}
