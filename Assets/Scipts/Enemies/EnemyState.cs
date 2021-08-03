public abstract class EnemyState
{
    protected Enemy enemy;
    protected EnemyStateMashine enemyStateMashine;

    protected EnemyState(Enemy enemy, EnemyStateMashine enemyStateMashine)
    {
        this.enemy = enemy;
        this.enemyStateMashine = enemyStateMashine;
    }

    public virtual void Enter()
    {

    }

    public virtual void LogicUpdate()
    {

    }

    public virtual void PhysicsUpdate()
    {
       
    }

    public virtual void Exit()
    {

    }

}
