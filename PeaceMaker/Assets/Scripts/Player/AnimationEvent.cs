using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationEvent : MonoBehaviour
{
    private Animator animator;
    private Player player;
    // Start is called before the first frame update
    void Start()
    {
        animator= GetComponent<Animator>();
        player=GetComponentInParent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void FinishAttack()
    {
        player.isAttack = false;
        animator.SetBool("isAttack", false);
    }
    void PlayerWalk1Sound()
    {
        SoundBox.instance.PlaySFX("PlayerWalk1");
    }
    void PlayerWalk2Sound()
    {
        SoundBox.instance.PlaySFX("PlayerWalk2");
    }
    void PlayerShootSound()
    {
        SoundBox.instance.PlaySFX("Shoot");
    }
}
