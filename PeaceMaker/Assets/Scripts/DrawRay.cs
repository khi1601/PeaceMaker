using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawRay : MonoBehaviour
{

    private Rigidbody2D myRigid;
    public static GameObject scanObj; //싱글톤으로?
    /// <summary>
    ///플레이어가 바라보고 있는방향벡터인데
    ///플레이어움직임구현하고그스크립트에서가져와야함
    /// </summary>
    Vector3 dirVec; 


    private void Awake()
    {
        myRigid = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        DrawingRay();
    }

    void DrawingRay()
    {
        Debug.DrawRay(myRigid.position, dirVec, new Color(0, 1, 0));
        RaycastHit2D rayHit = Physics2D.Raycast(myRigid.position, dirVec, 0.7f, LayerMask.GetMask("Object")); //이미 플레이어는 collider 있음. 플레이어 제외 cast를 위해 레이어 나누어서 관리

        if (rayHit.collider != null)
        {
            scanObj = rayHit.collider.gameObject; //raycast된 오브젝트를 변수로 저장하여 활용
        }
        else
            scanObj = null;
    }
}
