﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGameManager : MonoBehaviour
{
    public void StartGameScene()
    {
        SceneManager.LoadScene("StartMenuScene");
    }
}


