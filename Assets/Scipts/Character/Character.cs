using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Character : MonoBehaviour
{
    /// <summary>
    /// Main character controller
    /// </summary>
    /// 
    private BoxCollider2D boxCollider;
    #region Variables

    #region AnimatorParams
    private readonly int horizonalMoveParam = Animator.StringToHash("Speed");
    #endregion

    [SerializeField]
    GameObject dustCloud;
    [SerializeField]
    private int maxMagicAmount = 100;

    [SerializeField]
    internal int currentMagicAmount;
    //Health
    [SerializeField]
    internal int currentHealthAmount;

    [SerializeField]
    private int maxHealthAmount = 100;
    public MagicBar magicBar;

    public HealthBar healthBar;

    private Inventory inventory;


    [SerializeField]
    public Animator anim;

    [SerializeField]
    private LayerMask whatIsGround;

    [SerializeField]
    private Transform groundCheck;

    [SerializeField]
    private GameObject fireBall;

    [SerializeField]
    private Transform launchPoint;

    protected float Timer;


    private float timeBtwShots;
    [SerializeField]
    private float startTimeBtwShots;

    public bool isRight = true;

    public int DelayAmount = 1;
    [SerializeField]
    CoinPicker coinPicker;

    [SerializeField]
    ScoreCounter scoreCount;

    public UI_Inventory uI_Inventory;

    #endregion

    #region Properties
    public float GroundCollisionRadius = 0.2f;
    public float movementSpeed = 2f;
    public float movementSmoothing = 0.05f;
    public float JumpForce = 400f;
    private Vector3 velocity = Vector3.zero;
    #endregion

    public Rigidbody2D characterBody;

    protected StateMashine movementSM;
    public StandingState standing;
    public JumpingState jumping;
    public SlachAtackSate slashAtack;
    public MagicAtackState magicAtack;
    public SlidingState sliding;
    public GroundedState movingSt;

    private bool facingRight = true;




    void Awake()
    {
        inventory = new Inventory();
        ///uI_Inventory = GetComponent<UI_Inventory>();
        uI_Inventory.SetInventory(inventory);

        //Magic
        currentMagicAmount = maxMagicAmount;
        magicBar.SetMaxMagicAmount(maxMagicAmount);

        //Health
        currentHealthAmount = maxHealthAmount;
        healthBar.SetMaxHealth(maxMagicAmount);

        ScoreCounter scoreCount = new ScoreCounter();
        CoinPicker coinPicker = new CoinPicker();

        anim = GetComponent<Animator>();
        characterBody = GetComponent<Rigidbody2D>();
        movementSM = new StateMashine();
        standing = new StandingState(this, movementSM);
        jumping = new JumpingState(this, movementSM);
        slashAtack = new SlachAtackSate(this, movementSM);
        magicAtack = new MagicAtackState(this, movementSM);
        sliding = new SlidingState(this, movementSM);
        movingSt = new GroundedState(this, movementSM);

        boxCollider = GetComponent<BoxCollider2D>();

        movementSM.InitializeState(standing);

        ItemInWorld.SpawnIteamInWorld(new Vector3(50, 2, 0), new Item {itemType = Item.ItemType.HealthPotion,amount=2});
        ItemInWorld.SpawnIteamInWorld(new Vector3(53, 2, 0), new Item { itemType = Item.ItemType.ManaPotion, amount = 1 });
        ItemInWorld.SpawnIteamInWorld(new Vector3(55, 2, 0), new Item { itemType = Item.ItemType.PowerPotion, amount = 1 });


    }



    #region MovementBlock
    public void Move(float speed)
    {
        Vector3 targetVelocity = new Vector2(speed * 5f, characterBody.velocity.y);

        characterBody.velocity = Vector3.SmoothDamp(characterBody.velocity, targetVelocity, ref velocity, movementSmoothing);

        anim.SetFloat(horizonalMoveParam, Mathf.Abs(characterBody.velocity.x));
    }
    public void ResetMoveParams()
    {
        characterBody.velocity = Vector2.zero;
        anim.SetFloat(horizonalMoveParam, 0f);
    }
    #endregion

    #region AtackBlock
    public void PlayAtack()
    {
        anim.Play("PlayerSlashing");
    }
    #endregion

    #region JumpBlock
    public void ApplyImpulse(float imp)
    {
        anim.SetBool("isOnGround", false);
        characterBody.velocity = Vector2.up * JumpForce;
        
    }

    public void OnLand()
    {
        anim.SetBool("isOnGround", true);
    }
    public bool CheckGroundCollision()
    {
        return Physics2D.OverlapCircle(groundCheck.position, GroundCollisionRadius, whatIsGround);
    }
    #endregion

    public void DustEffect() 
    {
        Instantiate(dustCloud, transform.position, dustCloud.transform.rotation);
    }
    public void UseMagic() 
    {
        if (timeBtwShots <= 0) 
        {
            Instantiate(fireBall, launchPoint.position, launchPoint.rotation);
            timeBtwShots = startTimeBtwShots;
        }
        else 
        {
            timeBtwShots -= Time.deltaTime;
        }  
    }

    public void MagicAmountRecovery() 
    {
        if (currentMagicAmount <= 100) 
        {
            Timer += Time.deltaTime;

            if (Timer >= DelayAmount)
            {
                Timer = 0f;
                currentMagicAmount+=4;
                magicBar.SetMagicAmount(currentMagicAmount);
            }
        }
    } 

    
    public void MagicConsumption(int magicPerHit) 
    {
        currentMagicAmount -= magicPerHit;
        magicBar.SetMagicAmount(currentMagicAmount);
    }

    void fallingFromHeight() 
    {
        if (characterBody.position.y < -5f) 
        {
            int scoreAmount = scoreCount.scoreCounter;
            int coinsAmount = coinPicker.coinsCount;
            FindObjectOfType<GameManaging>().endGame(scoreAmount, coinsAmount);
        }
    }
    public void TriggerAnimation(int param)
    {
        anim.SetTrigger(param);
    }
    #region MonoBehavior Callbacks
    void Update()
    {
        movementSM.CurrentState.HandleInput();
        movementSM.CurrentState.LogicUpdate();
    }

    void FixedUpdate()
    {
        
        movementSM.CurrentState.PhysicsUpdate();
        fallingFromHeight();
    }
    #endregion


    public bool Test()
    {
        RaycastHit2D hit2D = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size,0f, Vector2.down,0.5f, whatIsGround);
        Debug.Log(hit2D.collider);
        return hit2D.collider != null;
    }

    public void TT(float horizontalInput) 
    {
        characterBody.velocity = new Vector2(100f * horizontalInput * Time.deltaTime, characterBody.velocity.y);
    }


    public void Fliping()
    {
        facingRight = !facingRight;
        Vector3 tmpScale = gameObject.transform.localScale;
        tmpScale.z *= -1;
        gameObject.transform.localScale = tmpScale;
        transform.Rotate(0f, 180f, 0f);
    }


    public void ApplyDamage(int damage)
    {
        currentHealthAmount -= damage;
        healthBar.SetHealthAmount(currentHealthAmount);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        ItemInWorld itemInWorld = collision.GetComponent<ItemInWorld>();

        if (itemInWorld != null)
        {
            inventory.AddItem(itemInWorld.GetItem());

            itemInWorld.DestroySelf();
        }
    }
}
