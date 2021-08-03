using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlidingState : State
{
   public SlidingState(Character character, StateMashine stateMashine) : base(character, stateMashine) { }
   private readonly int slidingParam = Animator.StringToHash("Sliding");
    private float horizontalInput;
    public override void Enter()
    {
        base.Enter();
        Sliding();


    }


    public override void HandleInput()
    {
        base.HandleInput();
        horizontalInput = Input.GetAxis("Horizontal");
        

    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        //if (horizontalInput>0)
        //{
        //    stateMashine.ChangeState(character.movingSt);

        //}
        //else 
        //{
        //    stateMashine.ChangeState(character.standing);

        //}
        stateMashine.ChangeState(character.standing);
    }

    private void Sliding()
    {

        character.TriggerAnimation(slidingParam);
    }
}
