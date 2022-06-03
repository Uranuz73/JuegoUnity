using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{


    public GameObject ui;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P)) {

            Toogle();

        }
    }



    public void Toogle() {

        ui.SetActive(!ui.activeSelf);


        if (ui.activeSelf) {
            Time.timeScale = 0f;
        }
        else{
            Time.timeScale = 1f;
        }



    }


    public void Retry() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
    }

    public void Exit() {
        SceneManager.LoadScene("Menu");
    }

}
