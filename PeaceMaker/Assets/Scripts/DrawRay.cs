using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawRay : MonoBehaviour
{

    private Rigidbody2D myRigid;
    public static GameObject scanObj; //�̱�������?
    /// <summary>
    ///�÷��̾ �ٶ󺸰� �ִ¹��⺤���ε�
    ///�÷��̾�����ӱ����ϰ�׽�ũ��Ʈ���������;���
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
        RaycastHit2D rayHit = Physics2D.Raycast(myRigid.position, dirVec, 0.7f, LayerMask.GetMask("Object")); //�̹� �÷��̾�� collider ����. �÷��̾� ���� cast�� ���� ���̾� ����� ����

        if (rayHit.collider != null)
        {
            scanObj = rayHit.collider.gameObject; //raycast�� ������Ʈ�� ������ �����Ͽ� Ȱ��
        }
        else
            scanObj = null;
    }
}
