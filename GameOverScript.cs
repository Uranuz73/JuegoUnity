using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverScript : MonoBehaviour
{
    public Text RoundsText;


    private void OnEnable()
    {
        RoundsText.text = Stats.Rounds.ToString();
    }


    public void Retry() {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }


    public void Menu() {
        SceneManager.LoadScene("Menu");

    }



}
