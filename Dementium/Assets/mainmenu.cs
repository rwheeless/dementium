﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainmenu : MonoBehaviour
{
    public void PlayGame()
    {
       SceneManager.LoadScene("Dementium"); 
    }

    public void QuitGame()
    {
        Debug.Log("Quit!");
        Application.Quit();    
    
    }
}
