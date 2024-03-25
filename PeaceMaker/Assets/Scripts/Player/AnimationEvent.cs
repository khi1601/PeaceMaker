using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationEvent : MonoBehaviour
{
    private Animator animator;
    private Player player;
    public GameObject bullet;
    public GameObject bulletEff;
    [SerializeField]
    private Transform bulletPos;
    // Start is called before the first frame update
    void Start()
    {
        animator= GetComponent<Animator>();
        player=GetComponentInParent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void FinishAttack()
    {
        player.isAttack = false;
        animator.SetBool("isAttack", false);
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
    void LaunchMissile()
    {
        GameObject bulletobj = Instantiate(bullet, bulletPos.position, Quaternion.identity);
        GameObject bulletEffobj = Instantiate(bulletEff, bulletPos.position, Quaternion.identity);
        if (player.transform.localScale.x == -1)
        {
            bulletobj.GetComponent<PBullet>().Direction = -1;
            bulletobj.transform.eulerAngles = new Vector3(0, 180f, 0);
            bulletEffobj.transform.eulerAngles = new Vector3(0, 180f, 0);
            bulletEffobj.transform.SetParent(bulletPos, false);
            bulletEffobj.transform.localPosition = new Vector3(0, 0, 0);
        }
        else
        {
            bulletobj.GetComponent<PBullet>().Direction = 1;
            bulletobj.transform.eulerAngles = new Vector3(0, 0, 0);
            bulletEffobj.transform.eulerAngles = new Vector3(0, 0, 0);
            bulletEffobj.transform.SetParent(bulletPos, false);
            bulletEffobj.transform.localPosition = new Vector3(0, 0, 0);
        }
    }
}
