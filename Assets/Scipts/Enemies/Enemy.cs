using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    #region parameters
    [SerializeField] private int health = 100;
    [SerializeField] Transform player;
    [SerializeField] private float patrolSpeed = 0.1f;
    [SerializeField] private float chaseSpeed = 3;
    [SerializeField] private float stopTime = 3;
    [SerializeField] private GameObject rightEdge, leftEdge;

    public bool isFlipped = false;

    private Rigidbody2D mainBody;
    private Vector2 direction;
    private bool moveRight = true;
    private bool facingRight;
    private Animator enemyAnim;
    private BoxCollider2D box;
    #endregion

    #region StatesParameters
    EnemyStateMashine enemyStateMashine;
    public PatrolState patrolState;
    public ChaseState chaseState;
    public AtackState atackState;
    #endregion

    [SerializeField]
    public int enemyCurrentHealthAmount;

    [SerializeField]
    private int enemyMaxHealthAmount = 100;
    /// <summary>
    /// ///
    /// </summary>
    public EnemyHealthBar enemyHealthBar;

    void Start()
    {
        box = GetComponent<BoxCollider2D>();
        enemyAnim = GetComponent<Animator>();
        mainBody = GetComponent<Rigidbody2D>();

        enemyCurrentHealthAmount = enemyMaxHealthAmount;
        enemyHealthBar.SetMaxHealth(enemyMaxHealthAmount);

        enemyStateMashine = new EnemyStateMashine();
        patrolState = new PatrolState(this, enemyStateMashine);
        chaseState = new ChaseState(this, enemyStateMashine);
        atackState = new AtackState(this, enemyStateMashine);

        enemyStateMashine.InitializeState(patrolState);
    }

    private void Update()
    {
        enemyStateMashine.CurrentState.LogicUpdate();
    }

    void FixedUpdate()
    {
        enemyStateMashine.CurrentState.PhysicsUpdate();
    }

    public void Patrol()
    {
        if (moveRight)
        {
            moveEnemy(patrolSpeed);
            if (CheckRight())
            {
                moveRight = false;
                Flip();
            }
        }
        if (!moveRight)
        {
            moveEnemy(patrolSpeed * -1);
            if (CheckLeft())
            {
                Flip();
                moveRight = true;
            }
        }
    }

    public void moveEnemy(float Speed)
    {
        mainBody.transform.position = mainBody.position + new Vector2(Speed * Time.deltaTime, 0);
    }

    public void chaseTarget()
    {
        direction = new Vector2(player.position.x - transform.position.x, 0);
        direction.Normalize();

        mainBody.MovePosition((Vector2)transform.position + (direction * chaseSpeed));
        if (player.position.x > transform.position.x && facingRight) //if the target is to the right of enemy and the enemy is not facing right
            Flip();
        if (player.position.x < transform.position.x && !facingRight)
            Flip();

    }

    public void ChangeDir()
    {
        float distanceLeft = Vector2.Distance(transform.position, leftEdge.transform.position);
        float distanceRight = Vector2.Distance(transform.position, rightEdge.transform.position);

        if (distanceRight < 1f || distanceRight < 3f && moveRight) Flip();
        if (distanceLeft < 4f && !moveRight) Flip();

    }
    public void atackPlayer(bool Atack)
    {
        enemyAnim.SetBool("isAtacking", Atack);
    }


    public bool playerInRange()
    {
        if (Vector2.Distance(transform.position, player.position) < 2.2f)
        {
            return true;
        }
        return false;
    }
    public bool detectTarget()
    {
        float distance = Vector2.Distance(transform.position, GameObject.Find("Player").transform.position);
        if (player.position.x > leftEdge.transform.position.x && player.position.x < rightEdge.transform.position.x)
        {
            return true;
        }
        return false;
    }

    public bool CheckLeft()
    {
        float distanceLeft = Vector2.Distance(transform.position, leftEdge.transform.position);
        if (distanceLeft < 2f)
        {
            return true;
        }
        return false;
    }

    public bool CheckRight()
    {
        float distanceRight = Vector2.Distance(transform.position, rightEdge.transform.position);
        if (distanceRight < 2f)
        {
            return true;
        }
        return false;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Trigger");
            Vector2 ff = new Vector2(0, 10f * Time.deltaTime);
            other.gameObject.GetComponent<Rigidbody2D>().AddForce(transform.up * 5f, ForceMode2D.Impulse);
        }
    }

    public void LookAtPlayer()
    {
       

        if (transform.position.x > player.position.x && facingRight)
        {
            Flip();
        }
        else if (transform.position.x < player.position.x && !facingRight)
        {
            Flip();
        }
    }

    public void Flip()
    {
        //here your flip funktion, as example
        facingRight = !facingRight;
        Vector3 tmpScale = gameObject.transform.localScale;
        tmpScale.z *= -1;
        gameObject.transform.localScale = tmpScale;
        transform.Rotate(0f,180f , 0f);
    }

    //public void TakeDamage(int damage) 
    //{
    //    health -= damage;
    //    Debug.Log(health);
    //    if (health <= 0) 
    //    {
    //        Die();
    //    }
    //}

    public void Die()
    {
        if (enemyCurrentHealthAmount <= 0)
        {
            ItemInWorld.SpawnIteamInWorld(transform.position, new Item { itemType = Item.ItemType.HealthPotion, amount = 1 });

            Destroy(gameObject);
        }
    }



    public void ApplyDamageToEnemy(int damage)
    {
        enemyCurrentHealthAmount -= damage;
        enemyHealthBar.SetEnemyHealthAmount(enemyCurrentHealthAmount);
        if (enemyCurrentHealthAmount <= 0)
        {
            Destroy(gameObject);
        }
    }
}

