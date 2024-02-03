using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PGSample : MonoBehaviour
{
    [SerializeField]
    private Slider pgBar;

    [SerializeField]
    private float maxPG;
    [SerializeField]
    private float curPG;

    void Start()
    {
        pgBar.value = (float)curPG/(float)maxPG;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void handlePG()
    {

    }
}
