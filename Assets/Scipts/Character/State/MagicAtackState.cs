using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicAtackState : State
{
    
   
    private readonly int magicAtack = Animator.StringToHash("MagicAtack");
    private readonly int magicPerHit = 10;
    public MagicAtackState(Character character, StateMashine stateMashine) : base(character, stateMashine)
    {
       
    }
    public override void Enter()
    {
        base.Enter();
        MagicAtack();
       
    }

    public void MagicAtack()
    {
        character.TriggerAnimation(magicAtack);
        if(character.currentMagicAmount>= magicPerHit) 
        {
            character.UseMagic();
            character.MagicConsumption(magicPerHit);
        }
        
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        stateMashine.ChangeState(character.standing);
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
        


    }





    
}
