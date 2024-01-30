using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class GameLogicScript : MonoBehaviour
{
    [SerializeField]
    public TextMeshProUGUI scoreText;



    [SerializeField]
    public GameState gameState;

    

    // Start is called before the first frame update
    void Start()
    {


        //INITIALIZE ALL STATS

        gameState.score = 0;
        gameState.totalLives = 3;

        gameState.hasPitchfork = false;
        gameState.hasGun = false;

        gameState.pitchforkDurability = 0;
        gameState.gunDurability = 0;








}

// Update is called once per frame
void Update()
    {





        
    }
}
