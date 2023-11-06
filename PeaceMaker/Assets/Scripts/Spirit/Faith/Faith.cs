using MyBox;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Faith : Spirit
{
    [SerializeField]
    private GameObject bullet;
    [SerializeField]
    private GameObject bulletPos;
    private Animator ani;
    public int bulletCount=6;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<Player>();
        ani=GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(ani.GetBool("isAttack")==false)
            Movement();
        if(Input.GetKeyDown(KeyCode.R))
        {
            Ability();
        }
    }
    public override void Ability()
    {
        ani.SetBool("isAttack", true);
    }
    public void FinishAttack()
    {
        ani.SetBool("isAttack", false);
    }
    public void Launch()
    {
        Vector3 backupPos = bulletPos.transform.position;
        float angle = 360 / bulletCount;
        Vector3 rotationAxis = Vector3.back;
        for (int i=0;i< bulletCount; i++)
        {
            Instantiate(bullet, bulletPos.transform.position, Quaternion.identity);
            //float x = bulletPos.transform.position.x * Mathf.Cos(angle) - bulletPos.transform.position.y * Mathf.Sin(angle);
            //float y = bulletPos.transform.position.x * Mathf.Sin(angle) + bulletPos.transform.position.y * Mathf.Cos(angle);
            bulletPos.transform.RotateAround(gameObject.transform.position, rotationAxis, angle);
        }
        bulletPos.transform.position = backupPos;
    }
}
