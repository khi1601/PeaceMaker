using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBullet : MonoBehaviour
{
    [SerializeField]
    private float speed;
    [SerializeField]
    private float lifeTime;
    [SerializeField]
    private float damage;
    private float curTime;
    public GameObject target;
    public float rotationSpeed = 30.0f;
    private Rigidbody2D rigid;
    // Start is called before the first frame update
    void Start()
    {
        curTime = 0;
        //target = GameObject.FindWithTag("Player");
        rigid = GetComponent<Rigidbody2D>();
        SoundBox.instance.PlaySFX("Faith_Missile");
    }

    // Update is called once per frame
    void Update()
    {
        curTime += Time.deltaTime;
        if (curTime > lifeTime)
        {
            Destroy(gameObject);
        }
        
    }
    private void FixedUpdate()
    {
        if (target == null)
            return;
        Vector2 dir = (Vector2)target.transform.position - rigid.position;
        dir.Normalize();
        float rotateAmount=Vector3.Cross(dir, transform.up).z;
        rigid.angularVelocity = -rotateAmount*rotationSpeed;
        rigid.velocity = transform.up * speed;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject==target)
        {
            Destroy(gameObject);
        }
    }
}
