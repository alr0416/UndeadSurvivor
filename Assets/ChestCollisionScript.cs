using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestCollisionScript : MonoBehaviour
{

    public SpriteRenderer spriteRenderer;
    public Sprite newSprite;



    [SerializeField]
    GameObject pitchfork;

    [SerializeField]
    GameObject gun;

    //Random r = new Random();

    bool isOpened = false;




    void ChangeSprite()
    {
        spriteRenderer.sprite = newSprite;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        GameObject obj = collision.gameObject;

        if (collision.gameObject.tag == "Player" && isOpened == false)
        {
            isOpened= true;
            ChangeSprite();
            //Destroy(obj);



            int randomInt = Random.Range(1, 3);

            var position = obj.transform.position;
            position.x += 1;
            


            if (randomInt == 1)
            {
                Instantiate(gun, position, Quaternion.identity);
            }
            else
            {
                Instantiate(pitchfork, position, Quaternion.identity);
            }

        }
    }
}
