using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public void FixedUpdate()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameManagerScript.Instance.GameStartedFromMainMenu = true;
            SceneManager.LoadScene("MainScene");
        }
    }
}
