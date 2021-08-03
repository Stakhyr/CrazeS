using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseState : EnemyState
{
    public ChaseState(Enemy enemy, EnemyStateMashine enemyStateMashine) : base(enemy, enemyStateMashine) { }
    public override void Enter()
    {
        base.Enter();
        //enemy.rotateEnemy();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (enemy.playerInRange()) 
        {
            enemyStateMashine.ChangeState(enemy.atackState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
        

           
            if(enemy.CheckLeft()||enemy.CheckRight()) 
            {
                enemy.Flip();
                enemyStateMashine.ChangeState(enemy.patrolState);
            }

            else 
            {
            ///enemy.rotateEnemy();

            enemy.chaseTarget();
            }
            
        
        

    }
}
