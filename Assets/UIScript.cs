using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.UI;


public class UIScript : MonoBehaviour
{
    public static string playernamestr;
    //public static string playernamestr;
    //public TMP_Text playername;

    [SerializeField]
    public TextMeshProUGUI livesText;

    [SerializeField]
    public TextMeshProUGUI scoreText;

    [SerializeField]
    public TextMeshProUGUI nameText;



    [SerializeField]
    public GameState gameState;



    // Start is called before the first frame update
    void Start()
    {
        //playername.text = playernamestr;
    }

    // Update is called once per frame
    void Update()
    {

        livesText.text = "Remaining Lives: " + gameState.totalLives.ToString();
        scoreText.text = "Score: " + gameState.score.ToString();
        nameText.text = "Farmer " + playernamestr;

       /* if (gameState.alive == false) { 
        
            gameOverText.text = "GAME OVER!";
            //need to pause game
        }
       */


    }
}
