using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Erica : Player
{
    [SerializeField]
    private Transform bulletPos;
    public GameObject bullet;
    new
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Jump();
        Movement();
        GroundCheck();
        Attack();
        Sit();
    }
    void Attack()
    {
        if (Input.GetKeyDown(KeyCode.D)&&!isAttack)
        {
            isAttack = true;
            UpAnim.SetBool("isAttack", true);
            DownAnim.SetBool("isAttack", true);
        }
    }
    void FinishAttack()
    {
        isAttack = false;
        UpAnim.SetBool("isAttack", false);
        DownAnim.SetBool("isAttack", true);
    }
   
    public override void TakeDamage(float damage)
    {
        if(!isDamaged)
        {
            isDamaged = true;


            //구현하기
            Invoke("isDamagedFalse", 0.7f);
        }
    }
}

