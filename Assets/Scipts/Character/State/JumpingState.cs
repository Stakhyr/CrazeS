using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpingState : State
{
    private bool grounded;
    private readonly int jumpParam = Animator.StringToHash("Jump");
    //private int landParam = Animator.StringToHash("land");
    private float horizontalInput;

    private bool facingRight = true;


    public JumpingState(Character character, StateMashine stateMashine) : base(character, stateMashine) {}


    public override void Enter()
    {
        horizontalInput = 0.0f;
        base.Enter();
        grounded = false;
        Jump();
    }

    public override void HandleInput()
    {
        base.HandleInput();
        horizontalInput = Input.GetAxis("Horizontal");
    }
    public override void LogicUpdate()
    {
        base.LogicUpdate();

        

        if (character.Test())
        {
            character.OnLand();
            stateMashine.ChangeState(character.standing);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();



        //if (!character.Test() && horizontalInput > 0.1f || horizontalInput < 0.1f)
        if (horizontalInput > 0f)
        {
            
            character.characterBody.velocity += new Vector2(600f * Time.deltaTime, 0);
            //character.characterBody.velocity = new Vector2(Mathf.Clamp(character.characterBody.velocity.x, -40f, 40f), character.characterBody.velocity.y);
        }
        else if (horizontalInput < 0f) 
        {
           

            Debug.Log(horizontalInput + "VAL");
            character.characterBody.velocity += new Vector2(-600f * Time.deltaTime, 0);
        }
        //else 
        //{
        //    character.characterBody.velocity += new Vector2(0, 0);
        //}
       


    }

    private void Jump()
    {
        character.ApplyImpulse(character.JumpForce);
       
        character.TriggerAnimation(jumpParam);
    }

    
}
