using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawRay : MonoBehaviour
{

    private Rigidbody2D myRigid;
    public static GameObject scanObj;
    [SerializeField]
    private Player player;
   


    private void Start()
    {
        myRigid = GetComponent<Rigidbody2D>();

    }
    private void FixedUpdate()
    {
        DrawingRay();
    }

    void DrawingRay()
    {
        Debug.DrawRay(myRigid.position, player.flipMove*2.0f, new Color(0, 1, 0));
        RaycastHit2D rayHit = Physics2D.Raycast(myRigid.position, player.flipMove, 0.7f, LayerMask.GetMask("Object")); //이미 플레이어는 collider 있음. 플레이어 제외 cast를 위해 레이어 나누어서 관리

        if (rayHit.collider != null)
        {
            scanObj = rayHit.collider.gameObject; //raycast된 오브젝트를 변수로 저장하여 활용
            TalkManager.Instance.Action(scanObj);
        }
        else
            scanObj = null;
    }
}
