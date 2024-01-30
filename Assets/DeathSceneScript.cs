using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class DeathSceneScript : MonoBehaviour
{
    public void RestartGame()
    {
        SceneManager.LoadSceneAsync(1);
    }

    public void MainMenu()
    {
        SceneManager.LoadSceneAsync(0);
    }



            
}
