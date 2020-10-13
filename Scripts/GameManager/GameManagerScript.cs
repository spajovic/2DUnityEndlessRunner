using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
    public static GameManagerScript Instance
    {
        get;
        private set;
    }
    [HideInInspector]
    public int score,highscore,lives;
    [HideInInspector]
    public bool GameStartedFromMainMenu, gameRestarted;
    void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
