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
    void LaunchMissile()
    {
        //GameObject bulletobj = Instantiate(bullet, bulletPos.position, Quaternion.identity);
        if (transform.localScale.x == -1)
        {
            //bulletobj.GetComponent<PenguinMissile>().Direction = -1;
            //bullet.transform.eulerAngles = new Vector3(0, 180f, 0);
        }
        else
        {
            //bulletobj.GetComponent<PenguinMissile>().Direction = 1;
            //bullet.transform.eulerAngles = new Vector3(0, 0, 0);
        }
    }
    void PlayerWalk1Sound()
    {
        SoundBox.instance.PlaySFX("PlayerWalk1");
    }
    void PlayerWalk2Sound()
    {
        SoundBox.instance.PlaySFX("PlayerWalk2");
    }
    void PlayerShootSound()
    {
        SoundBox.instance.PlaySFX("Shoot");
    }
    public override void TakeDamage(float damage)
    {
        
    }
}

