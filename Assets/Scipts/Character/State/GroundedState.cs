using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundedState : State
{
    protected float speed;
    private bool facingRight = true;
    private bool sliding;

    private float horizontalInput;

    public GroundedState(Character character, StateMashine stateMashine): base(character, stateMashine)
    {

    }
    public override void Enter()
    {
        base.Enter();
        horizontalInput = 0.0f;
        sliding = false;
    }

    public override void Exit()
    {
        base.Exit();
        character.ResetMoveParams();
    }

    public override void HandleInput()
    {
        base.HandleInput();
        horizontalInput = Input.GetAxis("Horizontal");
        sliding = Input.GetButtonDown("Crouch");

    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if (sliding)
        {
            stateMashine.ChangeState(character.sliding);

        }
       
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
        character.Move(horizontalInput * speed);
        if(horizontalInput>0 && !facingRight) 
        {
            Flip();
        }
        else if (horizontalInput < 0 && facingRight)
        {
            // ... flip the player.
            Flip();
        }
    }

    private void Flip()
    {
        // Switch the way the player is labelled as facing.
        facingRight = !facingRight;

        // Multiply the player's x local scale by -1.
        //Vector3 theScale = character.transform.localScale;
        //theScale.x *= -1;
        //character.transform.localScale = theScale;



        character.transform.Rotate(0f, 180f, 0f);

    }

}
