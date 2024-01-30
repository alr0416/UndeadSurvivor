using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class ChestSpawnerScript : MonoBehaviour
{

    [SerializeField]
    public GameObject chestPrefab;

    [SerializeField]
    public GameState gameState;

    float randomX;
    float randomY;

    System.Random random = new System.Random();

    

    IEnumerator SpawnUniformDistribution(float min, float max)
    {
        while (true)
        {




            randomX = (float)(random.NextDouble() * (10 - (-10)) + (-10));
            randomY = (float)(random.NextDouble() * (5 - (-5)) + (-5));

            float waitTime = UnityEngine.Random.Range(min, max);

            yield return new WaitForSeconds(waitTime);
            Vector3 position = new Vector3(randomX, randomY, 0.0f);
            Instantiate(chestPrefab, position, Quaternion.identity);

        }

    }



    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnUniformDistribution(6.0f, 10.0f));
    }

    // Update is called once per frame
    void Update()
    {




    }
}
