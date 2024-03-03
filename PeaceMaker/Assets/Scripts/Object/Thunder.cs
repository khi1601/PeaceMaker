using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thunder : MonoBehaviour
{
    [SerializeField]
    private float lifeTime;
    [SerializeField]
    private float curTime;
    [SerializeField]
    private float moveSpeed;
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.down*moveSpeed*Time.deltaTime);
        curTime += Time.deltaTime;
        if(curTime>lifeTime)
            Destroy(gameObject);
    }
    public void ToIdle()
    {
        animator.Play("Thunder_Idle");
    }
    public void DestroyGameobj()
    {
        Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Monster"))
        {
            Debug.Log("몬스터 히트");
            animator.Play("Thunder_Disappear");
        }
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("플레이어 히트");
            animator.Play("Thunder_Disappear");
        }
    }
}
