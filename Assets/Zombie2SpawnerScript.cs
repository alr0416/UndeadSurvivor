using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class Zombie2SpawnerScript : MonoBehaviour
{




    //int currKnowledge = 0; // gameState.knowledgeScore;
    //public string displayCurrPoints = "Points: ";




    //
    [SerializeField]
    public GameObject zombie2Prefab;

    [SerializeField]
    public GameState gameState;

    float randomX;
    float randomY;

    System.Random random = new System.Random();



    IEnumerator SpawnUniformDistribution(float min, float max)
    {
        while (true)
        {




            //randomX = (float)(random.NextDouble() * (19 - (-19)) + (-19));
            randomX = UnityEngine.Random.Range(-30.0f, 20.0f);

            //randomY = (float)(random.NextDouble() * (17 - (10)) + (-10));
            randomY = UnityEngine.Random.Range(-10.0f, 25.0f);

            float waitTime = UnityEngine.Random.Range(min, max);

            yield return new WaitForSeconds(waitTime);
            Vector3 position = new Vector3(randomX, randomY, 0.0f);
            Instantiate(zombie2Prefab, position, Quaternion.identity);

        }

    }



    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnUniformDistribution(1.0f, 4.0f));
    }

    // Update is called once per frame
    void Update()
    {




    }
}
