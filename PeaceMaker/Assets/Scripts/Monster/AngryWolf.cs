using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngryWolf : Monster
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public override void HandleHP()
    {
        
    }
    public override void StopVelocity()
    {
        rigi.velocity = Vector2.zero;
    }
    public override void ReturntoIdle()
    {
        //currentState = State.Idle;
    }
    void AW_AttackSound()
    {
        SoundBox.instance.PlaySFX("AW_Attack");
    }
    void AW_DieSound()
    {
        SoundBox.instance.PlaySFX("AW_Die");
    }
}
