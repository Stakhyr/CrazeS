using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtackState : EnemyState
{

    public AtackState(Enemy enemy, EnemyStateMashine enemyStateMashine):base(enemy, enemyStateMashine) 
    {

    }
    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if (!enemy.playerInRange())
        {
            enemy.atackPlayer(false);

            enemyStateMashine.ChangeState(enemy.chaseState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();

        Atack();
    }

    void Atack() 
    {
        //Debug.Log("Atack");
        enemy.atackPlayer(true);
    }
}
