using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MyBox;
public enum PlayerType
{
    Irus,
    Erica,
    Max
}
public abstract class Player : MonoBehaviour
{
    [SerializeField]
    protected PlayerType Type;
    [SerializeField]
    protected Image portrait;
    [SerializeField]
    protected float moveSpeed;
    [SerializeField]
    protected float jumpPower;
    [SerializeField]
    protected float testCognizeSideGround;
    [SerializeField]
    protected float testCognizeBottomGround;
    public bool isground;
    protected bool fixedJump;
    [AutoProperty]
    public Rigidbody2D rigid;
    [AutoProperty]
    public Animator ani;
    public LayerMask islayer;

    protected bool isAttack;
    // Start is called before the first frame update
    protected void Start()
    {
        isground = true;
        fixedJump = false;
        isAttack = false;
    }

    protected void Movement()
    {
        if (isAttack && !isground)
        {

        }
        else if (isAttack)
            return;
        
        Vector3 flipMove = Vector3.zero;
        if (Input.GetAxisRaw("Horizontal") < 0)
        {
            flipMove = Vector3.left;
            transform.localScale = new Vector3(-1, 1, 1);
            //ani.SetBool("isWalk", true);
        }
        else if (Input.GetAxisRaw("Horizontal") > 0)
        {
            flipMove = Vector3.right;
            transform.localScale = new Vector3(1, 1, 1);
           // ani.SetBool("isWalk", true);
        }
        else
        {
            flipMove = Vector3.zero;
            //ani.SetBool("isWalk", false);
        }
        transform.position += flipMove * moveSpeed * Time.deltaTime;

    }
    protected void Jump()
    {
        if ((isground || Physics2D.OverlapCircle(transform.position, testCognizeSideGround, islayer)) && Input.GetKeyDown(KeyCode.Space))
        {
            rigid.velocity = Vector2.up * jumpPower;
            //ani.SetBool("isJump", true);
            isground = false;
            //fixedJump = true;
        }
    }
    protected void GroundCheck()
    {
        //isground = Physics2D.OverlapCircle(transform.position, 0.59f, islayer);
        Vector3 rayPos = new Vector3(transform.position.x, transform.position.y - testCognizeBottomGround, transform.position.z);
        RaycastHit2D hit = Physics2D.Raycast(rayPos, new Vector3(0, -1, 0), 0.07f, LayerMask.GetMask("Ground"));

        if (hit.collider != null)
        {
            isground = true;
        }
        else
        {
            isground = false;
        }

        if (isground && rigid.velocity.y <= 0f)
        {
            rigid.velocity = new Vector3(rigid.velocity.x, 0, 0);
            //ani.SetBool("isJump", false);
        }
    }
}

