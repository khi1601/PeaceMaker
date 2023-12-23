using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterAtk : MonoBehaviour
{
    public bool isOnce;
    public bool ElementalAttack;
    public float attackRate;
    private int ParentAtk;
    // Start is called before the first frame update
    void Start()
    {
        ParentAtk = (int)GetComponentInParent<Monster>().Atk;
    }

    // Update is called once per frame

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!isOnce)
            return;
        if (collision.gameObject.tag.Equals("PlayerTakeArea"))
        {          
            //collision.gameObject.GetComponentInParent<Player>().TakeDamage((int)(ParentAtk * attackRate));          
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        ///수정필요
        if (isOnce)
            return;
        if (collision.gameObject.tag.Equals("PlayerTakeArea"))
        {
            //collision.gameObject.GetComponentInParent<Player>().TakeDamage((int)(ParentAtk * attackRate));
        }

    }
}
