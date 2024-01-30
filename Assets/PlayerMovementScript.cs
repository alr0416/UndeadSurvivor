using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class PlayerMovementScript : MonoBehaviour
{
    //public static string playernamestr;
    public TMP_Text playername;

    [SerializeField]
    public GameState gameState;

    [SerializeField]
    GameObject parent;

    [SerializeField]
    GameObject pitchfork;

    [SerializeField]
    GameObject gun;


    Rigidbody2D rb;

    float xDirection = 0.0f;
    float yDirection = 0.0f;

    const float speed = 5.0f;

    Animator animator;

    float limit = 1.0f;

    public GameObject currentWeapon;

    [SerializeField]
    private AudioSource deathEffect;

    [SerializeField]
    private AudioSource winEffect;

    [SerializeField]
    private AudioSource hitEffect;

    








    private enum AnimationState
    {
        Idle = 0,
        Running = 1
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {

        GameObject obj = collision.gameObject;




           
        if (obj.tag == "pitchfork")
        {

            if (currentWeapon != null)
            {
                
                Destroy(currentWeapon);
            }

            
                obj.transform.parent = this.transform;

                currentWeapon = obj;

                gameState.hasPitchfork = true;
                gameState.pitchforkDurability = 10;

                gameState.hasGun = false;
                gameState.gunDurability = 0;

            
           
        }

            

        if (obj.tag == "gun")
        {
            if (currentWeapon != null)
            {
                //currentWeapon.transform.parent = null;
                Destroy(currentWeapon);
            }


            obj.transform.parent = this.transform;

            currentWeapon = obj;

            gameState.hasPitchfork = false;
            gameState.pitchforkDurability = 0;

            gameState.hasGun = true;
            gameState.gunDurability = 10;


        }

        if (obj.tag == "zombie1")
        {

            if (gameState.hasPitchfork) {
                if (obj.GetComponent<ZombieLifeScript>().thisZombieDead == false)
                { //if pitchfork and alive
                    //gameState.pitchforkDurability--;
                }
                
            }
            else 
            {
                hitEffect.Play();
                gameState.totalLives--;
            }
            
            
            

        }

        if (obj.tag == "zombie2")
        {

            if (gameState.hasPitchfork) {
                if (obj.GetComponent<Zombie2LifeScript>().thisZombieDead == false)
                { //if pitchfork and alive
                    //gameState.pitchforkDurability--;
                }

            }
            else
            {
                hitEffect.Play();
                gameState.totalLives--;
            }




        }

        if (obj.tag == "health")
        {
            gameState.totalLives++;
            Destroy(obj);
        }

    }





   



    IEnumerator IAmFrozen()
    {
        yield return new WaitForSeconds(3.0f);




        gameState.isFrozen= false;
        
    }

   
       
        
            
        

     
       

    



    // Start is called before the first frame update
    void Start()
    {
        //playername.text = playernamestr;

        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        //zombie1Class = GetComponent<ZombieLifeScript>();



    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(gameState.pitchforkDurability + "  :  " + gameState.gunDurability);

        if (gameState.totalLives <= 0)
        {
            kill();
        }

        if (gameState.score >= 30)
        {
            win();
        }

        xDirection = Input.GetAxisRaw("Horizontal");
        yDirection = Input.GetAxisRaw("Vertical");

        if (gameState.isFrozen != true)
        {
            rb.velocity = new Vector2(xDirection * speed, yDirection * speed);
        }

        SetAnimationState();

        if (xDirection < 0)
        {
            transform.eulerAngles = new Vector2(0, 180);
        }
        else
        {
            transform.eulerAngles = new Vector2(0, 0);
        }

        if (gameState.isFrozen)
        {
            StartCoroutine(IAmFrozen());
        }


        if (gameState.hasPitchfork == true && gameState.pitchforkDurability <= 0)
        {

            //currentWeapon.transform.parent = null; //why is this not working
            Destroy(currentWeapon);
            currentWeapon = null;
            gameState.hasPitchfork = false;
            gameState.hasGun = false;
            gameState.gunDurability = 0;
            gameState.pitchforkDurability = 0;

        } ////////////////

        if (gameState.hasGun == true && gameState.gunDurability <= 0)
        {
            //currentWeapon.transform.parent = null; //why is this not working
            Destroy(currentWeapon);
            currentWeapon = null;
            gameState.hasPitchfork = false;
            gameState.hasGun = false;
            gameState.gunDurability = 0;
            gameState.pitchforkDurability = 0;

        } ////////////////




    }

    void SetAnimationState()
    {
        AnimationState state;

        if (xDirection != 0 || yDirection != 0)
        {
            state = AnimationState.Running;    
        }
        else
        {
            state = AnimationState.Idle;        
        }

        animator.SetInteger("playerState", (int)state);

    }

    void kill()
    {
        deathEffect.Play();
        //death function
        SceneManager.LoadSceneAsync(2);
    }

    void win()
    {
        winEffect.Play();
        //win function
        SceneManager.LoadSceneAsync(3);
    }
}
