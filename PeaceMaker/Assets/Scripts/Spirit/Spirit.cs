using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MyBox;
public enum Kind
{
    Faith,
    Lify,
    hopy,
    wili,
    MAX
}
public abstract class Spirit : MonoBehaviour
{
    [SerializeField]
    protected Kind Type;
    [SerializeField]
    protected Image portrait;
    [SerializeField]
    protected float moveSpeed;
    public GameObject followPos;
    public Player player;
    // Start is called before the first frame update
    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Movement()
    {
        transform.position = Vector3.Lerp(transform.position, followPos.transform.position, 0.005f);
        if (player.transform.localScale.x == -1)
        {
            transform.localScale = new Vector3(2, 2, 2);
            //ani.SetBool("isWalk", true);
        }
        else
        {
            transform.localScale = new Vector3(-2, 2, 2);
        }
    }
    public abstract void Ability();
}
