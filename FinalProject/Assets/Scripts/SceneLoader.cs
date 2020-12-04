using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{

    public void LoadGame_1()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void LoadGame_2()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 4);
    }

        public void LoadGame_3()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 7);
    }


    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit!");
    }
}
  