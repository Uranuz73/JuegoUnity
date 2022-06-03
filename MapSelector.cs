using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MapSelector : MonoBehaviour
{
    public Button[] But1;


    private void Start()
    {
        int levelReached = PlayerPrefs.GetInt("levelReached", 1);

        for (int i = 0; i < But1.Length; i++)
        {
            if (i + 1 > levelReached) {
                But1[i].interactable = false;
            }
        }
        
    }
    public void map1() 
    
    {
        SceneManager.LoadScene("ForestMap");


    }

    public void map2()
    {

        SceneManager.LoadScene(4);
    }

    public void map3()
    {
        SceneManager.LoadScene(5);

    }

    public void back()
    {
        SceneManager.LoadScene("Menu");

    }

    public void turrets()
    {
        SceneManager.LoadScene("Towers");


    }





}
