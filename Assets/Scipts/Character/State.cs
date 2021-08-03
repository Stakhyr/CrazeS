

public abstract class State 
{
    protected Character character;
    protected StateMashine stateMashine;

    protected State(Character character, StateMashine stateMashine) 
    {
        this.character = character;
        this.stateMashine = stateMashine;
    }

    public virtual void Enter() 
    {

    }

    public virtual void HandleInput() 
    {

    }

    public virtual void LogicUpdate() 
    {

    }

    public virtual void PhysicsUpdate() 
    {
        character.MagicAmountRecovery();
    }

    public virtual void Exit() 
    {

    }

} 