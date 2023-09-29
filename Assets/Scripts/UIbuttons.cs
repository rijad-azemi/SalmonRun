using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIbuttons : MonoBehaviour {

   
    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
        Time.timeScale = 1;
    }

    public void Restart()
    {
        SceneManager.LoadScene("lvl", LoadSceneMode.Single);
        Time.timeScale = 1;
    }

}
