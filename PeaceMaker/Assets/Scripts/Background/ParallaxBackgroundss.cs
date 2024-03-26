using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxBackgroundss : MonoBehaviour
{
    private Material[] materials;
    private float[] layerMoveSpeed;

    [SerializeField]
    [Range(0.01f, 1.0f)]
    private float parallaxSpeed; //layerMoveSpeed�� ���ؼ� ����ϴ� ��潺ũ�� �̵��ӵ�

    private void Awake()
    {
        int backgroundCnt = transform.childCount;
        GameObject[] backgrounds = new GameObject[backgroundCnt];

        materials = new Material[backgroundCnt];
        layerMoveSpeed = new float[backgroundCnt];

        for (int i = 0; i < backgroundCnt; i++)
        {
            backgrounds[i] = transform.GetChild(i).gameObject;
            materials[i] = backgrounds[i].GetComponent<Renderer>().material;
        }

    }
}
