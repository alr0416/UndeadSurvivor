using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieLifeScript : MonoBehaviour
{


    public SpriteRenderer spriteRenderer;
    public Sprite newSprite;

    [SerializeField]
    public GameState gameState;

    float distance;

    public GameObject thisZombie;

    [SerializeField]
    public GameObject player;

    public bool thisZombieDead = false;



  
    public float maxSpeed = 2.0f;
    private Vector2 movement;
    private float timeLeft;

    public Rigidbody2D rb;


    [SerializeField]
    private AudioSource meleeEffect;

    [SerializeField]
    private AudioSource rangedEffect;

    // myAnimation.gameObject.GetComponent<Animator>().enabled = false;
    






    private void OnCollisionEnter2D(Collision2D collision)
    {

        GameObject obj = collision.gameObject;

        if (collision.gameObject.tag == "Player" && gameState.hasPitchfork == true && thisZombieDead == false)
        {
            //kill zombie
            KillZombieByPitchfork();
            

            
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        thisZombie = gameObject;
        player = GameObject.FindWithTag("Player");

        rb = GetComponent<Rigidbody2D>();


    }

    // Update is called once per frame
    void Update()
    {

        


        if (gameState.hasGun)
        {
            distance = Vector3.Distance(player.transform.position, thisZombie.transform.position);

            if (distance < 5 && thisZombieDead == false) 
            {
                KillZombieByGun();
                gameObject.GetComponent<Animator>().enabled = false;

            }
        }

        if (thisZombieDead == true)
        {
            gameObject.GetComponent<Animator>().enabled = false;
        }



        timeLeft -= Time.deltaTime;
        if (timeLeft <= 0)
        {
            movement = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
            //timeLeft += accelerationTime;
        }



    }


    void FixedUpdate()
    {
        if (thisZombieDead == false)
        {
            rb.AddForce(movement * maxSpeed);
        }
        else
        {
            rb.velocity = Vector3.zero;

        }
    }



    void ChangeSprite()
    {
        spriteRenderer.sprite = newSprite;
    }

    void KillZombieByGun()
    {
        rangedEffect.Play();
        ChangeSprite();
        Destroy(gameObject, 5);
        gameState.score++;
        thisZombieDead = true;
        gameState.gunDurability--;
    }

    void KillZombieByPitchfork()
    {
        meleeEffect.Play();
        ChangeSprite();
        Destroy(gameObject, 5);
        gameState.score++;
        thisZombieDead = true;
        gameState.pitchforkDurability--;
    }


}
