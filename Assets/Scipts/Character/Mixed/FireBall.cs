using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
{
    [SerializeField]
    private float ballSpeed;
    [SerializeField]
    private float lifeTime;
    private Rigidbody2D rb;

    [SerializeField]
    private int damage = 10;
    private Transform player;
    bool dir;

    // Start is called before the first frame update

    void Start()
    {
       
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.Find("Player").transform;

        Invoke("DestroyFireBall", lifeTime);
         dir = FireBallDirection();
    }

    // Update is called once per frame
    void Update()
    {
        FireBallMovement();
        //checkColision();
    }

    public void FireBallMovement() 
    {
            if(dir) 
            {
                rb.MovePosition(rb.position + Vector2.right * ballSpeed * Time.deltaTime);
            }
            else
            {
                rb.MovePosition(rb.position + Vector2.left * ballSpeed * Time.deltaTime);
            //rb.transform.position = new Vector2(ballSpeed * -1 * Time.deltaTime, rb.velocity.y);
            }
           
       
       
    }

    public bool FireBallDirection() 
    {
        if(player.localScale.x>=0) return true;
        return false;
    }

    //void checkColision() 
    //{
    //    RaycastHit2D ray = Physics2D.Raycast(rb.position, Vector2.left);

    //    Enemy enemy = ray.transform.GetComponent<Enemy>();
    //    if (enemy != null) 
    //    {
    //        Debug.Log("Hit");
    //        DestroyFireBall();
    //    }
    //}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Turtle enemy = collision.GetComponent<Turtle>();
        if (enemy != null) 
        {
            enemy.TakeDamage(damage);
        }
       
       
       
        DestroyFireBall();
    }

    void DestroyFireBall()
    {
        if (gameObject != null)
        Destroy(gameObject);
    }
}
