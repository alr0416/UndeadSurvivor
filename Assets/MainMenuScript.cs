using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class MainMenuScript : MonoBehaviour
{
    
    public TMP_InputField playername;

    

    public void PlayGame()
    {
        SceneManager.LoadSceneAsync(1);
        UIScript.playernamestr = playername.text;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
    

}
