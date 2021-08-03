using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolState : EnemyState
{
    public PatrolState(Enemy enemy, EnemyStateMashine enemyStateMashine) : base(enemy, enemyStateMashine) { }
    public override void Enter()
    {
        base.Enter();
        enemy.ChangeDir();
        


    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();

        enemy.Patrol();
        if (enemy.detectTarget())
        {
            enemyStateMashine.ChangeState(enemy.chaseState);
        }
    }

}
