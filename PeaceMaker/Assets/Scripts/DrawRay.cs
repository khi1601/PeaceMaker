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
        RaycastHit2D rayHit = Physics2D.Raycast(myRigid.position, player.flipMove, 0.7f, LayerMask.GetMask("Object")); //�̹� �÷��̾�� collider ����. �÷��̾� ���� cast�� ���� ���̾� ����� ����

        if (rayHit.collider != null)
        {
            scanObj = rayHit.collider.gameObject; //raycast�� ������Ʈ�� ������ �����Ͽ� Ȱ��
            TalkManager.Instance.Action(scanObj);
        }
        else
            scanObj = null;
    }
}
