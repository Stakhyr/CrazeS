using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandingState : GroundedState
{
    private bool jump;
    private bool crouch;
    private bool slashingAtack;
    private bool fireMagicAtack;

    public StandingState(Character character, StateMashine stateMashine): base(character, stateMashine){}

    public override void Enter()
    {
        base.Enter();
        speed = character.movementSpeed;
        crouch = false;
        jump = false;
        slashingAtack = false;
        fireMagicAtack = false;


    }

    public override void HandleInput()
    {
        base.HandleInput();
        jump = Input.GetButtonDown("Jump");
        //crouch = Input.GetButtonDown("Crouch");
        slashingAtack = Input.GetButtonDown("Fire1");
        fireMagicAtack = Input.GetButtonDown("Fire2");
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if (crouch) 
        {
            //stateMashine.ChangeState(character.duking);
           
        } else if (jump /*&& character.Test()*/) 
        {
            stateMashine.ChangeState(character.jumping);
           
        }else if (slashingAtack) 
        {
            stateMashine.ChangeState(character.slashAtack);
        }else if (fireMagicAtack) 
        {
            stateMashine.ChangeState(character.magicAtack);
        }
    } 
}
