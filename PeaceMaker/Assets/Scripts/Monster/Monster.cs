using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using MyBox;
public enum M_Kind
{
    Normal,
    Boss,
    Max,
}


public enum State
{
    Idle,
    Follow,
    Patrol,
    Dash,
    Attack,

};
public abstract class Monster : MonoBehaviour
{
    protected float defaultmoveSpeed;
    [AutoProperty]
    public Rigidbody2D rigi;
    [AutoProperty]
    public Animator ani;
    public bool MonsterDirRight;
    // Start is called before the first frame update
    public float curHp;
    public float hp;
    [SerializeField]
    protected M_Kind monsterKind;
    public float Atk;
    protected float defaultAtk;
    [SerializeField]
    protected float Defense;
    [SerializeField]
    protected float moveSpeed;
    public bool stageBuff;

    public bool isKnockbacking;
    public bool invincible;

    protected WaitForSeconds wait1second;
    protected void Start()
    {
        defaultmoveSpeed = moveSpeed;
        defaultAtk = Atk;
        rigi = GetComponent<Rigidbody2D>();
        ani = GetComponent<Animator>();
        wait1second = new WaitForSeconds(1.0f);
    }

    // Update is called once per frame

    public abstract void HandleHP();
    public abstract void StopVelocity();
    public abstract void ActivateStageBuff();
    public abstract void TakeDamage(float damage);
    protected void FlipMonster()
    {
        MonsterDirRight = !MonsterDirRight;
        Vector3 m_Scale = transform.localScale;
        if (MonsterDirRight)
            m_Scale.x = -Mathf.Abs(m_Scale.x);
        else
            m_Scale.x = Mathf.Abs(m_Scale.x);
        transform.localScale = m_Scale;
    }
    public bool isPlayingAni(string name)
    {
        if (ani.GetCurrentAnimatorStateInfo(0).IsName(name))
            return true;
        return false;
    }
    public void PlayAnimation(string aniname)
    {
        if (!isPlayingAni(aniname))
        {
            ani.Play(aniname);
        }
    }
    public void AniSetTrigger(string name)
    {
        if (!isPlayingAni(name))
        {
            ani.SetTrigger(name);
        }
    }
   
    public void KnockBack(Vector2 pos, float power)
    {
        StopVelocity();
        StartCoroutine(KnockBacking(pos, power));
    }
    public abstract void ReturntoIdle();
    private IEnumerator KnockBacking(Vector2 pos, float power)
    {
        isKnockbacking = true;
       
         rigi.AddForce((pos.normalized) * power, ForceMode2D.Impulse);
         yield return null;
        
        isKnockbacking = false;
    }


}
