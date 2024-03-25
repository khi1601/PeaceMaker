using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PBullet : MonoBehaviour
{
    public float damage;
    [SerializeField]
    private float speed;
    [SerializeField]
    private float knockbackPower=6.0f;
    public int Direction;

    [SerializeField]
    private float lifetime;
    public GameObject bulletExplosion;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        lifetime += Time.deltaTime;
        if (lifetime > 5.0f)
            Destroy(gameObject);

        Vector2 movement = Vector2.right * speed * Time.deltaTime;
        transform.Translate(movement, Space.Self);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Monster"))
        {
            Vector2 vec2=new Vector2(Direction == 1 ?  1 : -1,0);
            
            collision.GetComponent<Monster>().TakeDamage(damage);
            collision.GetComponent<Monster>().KnockBack(vec2, knockbackPower);

            GameObject bulletobj = Instantiate(bulletExplosion, gameObject.transform.position, Quaternion.identity);
            if (Direction == -1)
            {
                bulletobj.transform.eulerAngles = new Vector3(0, 180f, 0);
            }
            else
            {
                bulletobj.transform.eulerAngles = new Vector3(0, 0, 0);
            }
            Destroy(gameObject);
        }
    }
}
