using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MapSelector : MonoBehaviour
{

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
