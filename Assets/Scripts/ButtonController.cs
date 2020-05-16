using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour
{
    public void StartNewGame()
    {
        SceneManager.LoadScene("SpaceGame");
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}
