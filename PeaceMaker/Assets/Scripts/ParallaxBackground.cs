using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxBackground : MonoBehaviour
{
    [SerializeField] [Range(-0.1f, 0.1f)]
    private float   moveSpeed = 0.1f;
    private Material material;

    private void Awake()
    {
        material = GetComponent<Renderer>().material;
    }
    private void Update()
    {
        material.SetTextureOffset("_MainTex", Vector2.right * moveSpeed * Time.time);
    }
}
