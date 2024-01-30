using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class WinSceneScript : MonoBehaviour
{
    public void ReplayGame()
    {
        SceneManager.LoadSceneAsync(1);
    }

    public void MainMenu()
    {
        SceneManager.LoadSceneAsync(0);
    }




}
