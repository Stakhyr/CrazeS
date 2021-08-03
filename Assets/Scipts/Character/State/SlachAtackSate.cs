using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlachAtackSate : State
{
    private readonly int slashAtack = Animator.StringToHash("SlashAtack");
    public SlachAtackSate(Character character, StateMashine stateMashine) : base(character, stateMashine) { }
    public override void Enter()
    {
        base.Enter();
        SlashAtack();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        stateMashine.ChangeState(character.standing);
    }



    private void SlashAtack()
    {
        
        character.TriggerAnimation(slashAtack);
    }
}
