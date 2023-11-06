using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBullet : MonoBehaviour
{
    [SerializeField]
    private float speed;
    [SerializeField]
    private float lifeTime = 1.2f;
    private float curTime;
    // Start is called before the first frame update
    void Start()
    {
        curTime = 0;
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
}
