using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayScene (){

        SceneManager.LoadScene("MapSelector");


    }

    public void SettingsScene()
    {

        SceneManager.LoadScene("Settings");



    }

    public void Exit()
    {

        Application.Quit();



    }
}
