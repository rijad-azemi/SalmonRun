using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuUI : MonoBehaviour {

    public void NewGame()
    {
        SceneManager.LoadScene("lvl", LoadSceneMode.Single);
    }
    
    public void Quit()
    {
        Application.Quit();
    }
}
